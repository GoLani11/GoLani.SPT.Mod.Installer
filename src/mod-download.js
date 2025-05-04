const { ipcRenderer, shell } = require('electron');
const fs = require('fs');
const path = require('path');
const https = require('https');
const http = require('http');
const { spawn } = require('child_process');
const AdmZip = require('adm-zip');
const sevenZipPath = require('7zip-bin').path7za;

document.addEventListener("DOMContentLoaded", () => {
    // 상태 변수 초기화
    let autoSelectEnabled = true;
    let isFallbackActive = false;
    let initializeModsEnabled = false;
    let translatorEnabled = true;

    // DOM 요소 참조
    const autoToggle = document.getElementById("auto-select-toggle");
    const translatorToggle = document.getElementById("translator-toggle");
    const refreshBtn = document.getElementById('refresh-btn');
    const closeBanner = document.getElementById('close-banner');
    const selectPathBtn = document.getElementById("select-path-btn");
    const downloadBtn = document.getElementById("download-btn");
    const modalCloseBtn = document.getElementById("modal-close-btn");
    const downloadModalCloseBtn = document.getElementById("download-modal-close-btn");
    const chosenPathSpan = document.getElementById("chosen-path");
    const initializeModsToggle = document.getElementById("initialize-mods-toggle");

    // GitHub 메타데이터 URL
    const githubMetaUrl = 'https://raw.githubusercontent.com/GoLani11/GoLani.SPT.Mod.Installer/main/config/DownloadMetaData.json';

    // UI 이벤트 리스너 설정
    autoToggle.addEventListener("change", () => {
        autoSelectEnabled = autoToggle.checked;
    });

    translatorToggle.addEventListener("change", () => {
        translatorEnabled = translatorToggle.checked;
    });

    initializeModsToggle.addEventListener("change", () => {
        initializeModsEnabled = initializeModsToggle.checked;
    });

    refreshBtn.addEventListener('click', () => {
        loadMetaData();
    });

    closeBanner.addEventListener('click', () => {
        document.querySelector('.notification-banner').style.display = 'none';
    });

    selectPathBtn.addEventListener("click", async () => {
        const result = await ipcRenderer.invoke('select-directory');
        if (!result.canceled && result.filePaths && result.filePaths[0]) {
            chosenPathSpan.textContent = result.filePaths[0];
        }
    });

    downloadBtn.addEventListener("click", () => {
        handleDownloadButtonClick();
    });

    modalCloseBtn.addEventListener("click", () => {
        document.getElementById("notification-modal").classList.add("hidden");
    });

    downloadModalCloseBtn.addEventListener("click", () => {
        document.getElementById("download-modal").classList.add("hidden");
    });

    // 탭 전환 이벤트 설정
    setupTabSwitching();

    // 메뉴 버튼 이벤트 설정
    setupMenuButtons();

    // ipcRenderer 이벤트 수신 리스너
    ipcRenderer.on('program-version', (event, version) => {
        document.getElementById('program-version').textContent = `프로그램 버전: ${version}`;
    });

    // 초기 메타데이터 로드
    loadMetaData();

    /**
     * 알림 배너 메시지 표시
     * @param {string} message - 표시할 메시지
     * @param {string} type - 메시지 유형 ('default', 'fallback')
     */
    function showNotificationBannerMessage(message, type = 'default') {
        const banner = document.querySelector('.notification-banner');
        const bannerSpan = document.querySelector('.notification-banner span');

        bannerSpan.textContent = message;
        banner.style.display = 'flex';

        banner.classList.remove('fallback-mode', 'success-mode');
        if (type === 'fallback') {
            banner.classList.add('fallback-mode');
        }
    }

    /**
     * 새로고침 상태 메시지 표시
     * @param {string} message - 표시할 메시지
     * @param {boolean|null} isSuccess - 성공 여부 (true: 성공, false: 실패, null: 진행 중)
     */
    function showRefreshStatusMessage(message, isSuccess) {
        const banner = document.querySelector('.refresh-status-banner');
        const bannerSpan = banner.querySelector('span');

        bannerSpan.textContent = message;
        banner.style.display = 'flex';

        banner.classList.remove('fallback-mode', 'success-mode');
        if (isSuccess === true) {
            banner.classList.add('success-mode');
        } else if (isSuccess === false) {
            banner.classList.add('fallback-mode');
        }

        // 3초 후 상태 메시지 숨기기 (진행 중일 때는 제외)
        if (isSuccess !== null) {
            setTimeout(() => {
                banner.style.display = 'none';
                banner.classList.remove('fallback-mode', 'success-mode');
            }, 3000);
        }
    }

    /**
     * 알림 배너 텍스트 업데이트
     */
    function updateNotificationBanner() {
        if (isFallbackActive) {
            showNotificationBannerMessage("GitHub 메타데이터 로드 실패. 로컬 메타데이터를 사용합니다. 인터넷 연결을 확인하세요.", "fallback");
        } else {
            showNotificationBannerMessage("모드 다운로드 페이지에 오신 것을 환영합니다. 원하는 모드를 선택하세요.");
        }
    }

    /**
     * 메타데이터 로드 (GitHub에서 다운로드 시도, 실패 시 로컬 파일 사용)
     */
    function loadMetaData() {
        isFallbackActive = false;
        updateNotificationBanner();
        showRefreshStatusMessage('새로고침 중...', null);

        fetch(githubMetaUrl)
            .then(response => response.json())
            .then(metaData => {
                isFallbackActive = false;
                updateNotificationBanner();
                processMetaData(metaData);
                showRefreshStatusMessage('새로고침 완료', true);
            })
            .catch(error => {
                isFallbackActive = true;
                updateNotificationBanner();
                console.error("GitHub 메타데이터 로드 실패, 로컬 파일 사용:", error);
                ipcRenderer.invoke('show-notification', '서버와 연결이 되지 않아 프로그램에 저장된 설정을 가져옵니다.\n인터넷 연결을 확인해주세요.');
                loadMetaDataLocal();
                showRefreshStatusMessage('새로고침 실패 (GitHub)', false);
            });
    }

    /**
     * 로컬 파일에서 메타데이터 로드
     */
    function loadMetaDataLocal() {
        const metaFilePath = path.join(__dirname, '..', 'config', 'DownloadMetaData.json');
        fs.readFile(metaFilePath, 'utf8', (err, data) => {
            if (err) {
                console.error("로컬 메타데이터 로드 실패:", err);
                showRefreshStatusMessage('새로고침 실패 (로컬 설정)', false);
                return;
            }
            try {
                const metaData = JSON.parse(data);
                processMetaData(metaData);
                showRefreshStatusMessage('새로고침 완료 (로컬 설정)', true);
            } catch (e) {
                console.error("로컬 메타데이터 파싱 오류:", e);
                showRefreshStatusMessage('새로고침 실패 (로컬 설정 파싱)', false);
            }
        });
    }

    /**
     * 메타데이터 처리 및 UI 업데이트
     * @param {Object} metaData - 메타데이터 객체
     */
    function processMetaData(metaData) {
        document.getElementById("spt-version").textContent = "SPT 게임 버전: " + metaData.SPTDefaultVersion;

        const mods = metaData.mods;
        let originalMods = {};
        mods.forEach(mod => {
            if (mod.Category === "원본 모드") {
                originalMods[mod.name] = mod.version;
            }
        });

        // 그리드 초기화
        const koreanGrid = document.getElementById("koreanGrid");
        const originalGrid = document.getElementById("originalGrid");
        const translationGrid = document.getElementById("translationGrid");
        koreanGrid.innerHTML = "";
        originalGrid.innerHTML = "";
        translationGrid.innerHTML = "";

        // 모드 항목 생성
        mods.forEach(mod => {
            // "필수 모드" 카테고리는 UI에 표시하지 않음
            if (mod.Category === "필수 모드") {
                return;
            }
            
            const modElement = createModElement(mod, originalMods, metaData.SPTDefaultVersion);

            if (mod.Category === "한글 모드") {
                koreanGrid.appendChild(modElement);
            } else if (mod.Category === "원본 모드") {
                originalGrid.appendChild(modElement);
            } else if (mod.Category === "한글화 모드") {
                translationGrid.appendChild(modElement);
            }
        });

        // 의존성 및 자동 선택 이벤트 리스너 설정
        bindDependencyListeners();
        bindOriginalToTranslationAutoSelect();
    }

    /**
     * 모드 항목 요소 생성
     * @param {Object} mod - 모드 정보 객체
     * @param {Object} originalMods - 원본 모드 맵
     * @param {string} sptDefaultVersion - SPT 기본 버전
     * @returns {HTMLDivElement} 모드 아이템 요소
     */
    function createModElement(mod, originalMods, sptDefaultVersion) {
        const div = document.createElement("div");
        div.className = "mode-item";

        const checkbox = document.createElement("input");
        checkbox.type = "checkbox";
        checkbox.id = mod.name + "-" + mod.version;

        // SPT 버전 호환성 확인
        const sptMatch = (mod.SPTversion === sptDefaultVersion);
        checkbox.disabled = !sptMatch;

        // 한글화 모드 의존성 처리
        if (mod.Category === "한글화 모드") {
            if (!originalMods[mod["Parent mod name"]] || originalMods[mod["Parent mod name"]] !== mod.version) {
                checkbox.disabled = true;
            }
            checkbox.setAttribute("data-parent", mod["Parent mod name"]);
        }

        // 필수 모드 의존성 처리
        if (mod.RequiredModName) {
            checkbox.disabled = true;
            checkbox.setAttribute("data-required", mod.RequiredModName);
        }

        // 데이터 속성 설정
        checkbox.setAttribute("data-name", mod.name);
        checkbox.setAttribute("data-version", mod.version);
        checkbox.setAttribute("data-download", mod.downloadUrls.join(','));
        checkbox.setAttribute("data-source", mod.sourceUrl);

        if (mod.filename) {
            checkbox.setAttribute("data-filename", mod.filename);
        }

        // 라벨 생성 - 기본 브라우저에서 링크 열기 수정
        const label = document.createElement("label");
        label.htmlFor = checkbox.id;

        // a 태그 생성 및 스타일 적용 (인라인 스타일 제거)
        const a = document.createElement("a");
        a.href = "#"; // 내부 이동 방지
        a.textContent = mod.name;
        a.innerHTML = `${mod.name} <small>(v${mod.version})</small>`;

        // 클릭 이벤트에서 shell.openExternal 사용하여 기본 브라우저에서 열기
        a.addEventListener("click", (event) => {
            event.preventDefault();
            shell.openExternal(mod.sourceUrl);
        });

        a.style.cursor = "pointer"; // 커서 스타일만 유지

        label.appendChild(a);
        div.appendChild(checkbox);
        div.appendChild(label);

        return div;
    }

    /**
     * 탭 전환 설정
     */
    function setupTabSwitching() {
        const tabButtons = document.querySelectorAll(".tab-btn");
        const tabContents = document.querySelectorAll(".tab-content");

        tabButtons.forEach(btn => {
            btn.addEventListener("click", () => {
                const target = btn.getAttribute("data-tab");
                tabButtons.forEach(b => b.classList.remove("active"));
                tabContents.forEach(content => content.classList.remove("active"));
                btn.classList.add("active");
                document.getElementById(target).classList.add("active");
            });
        });
    }

    /**
     * 메뉴 버튼 설정
     */
    function setupMenuButtons() {
        const menuButtons = document.querySelectorAll('.menu-btn');
        menuButtons.forEach(btn => {
            btn.addEventListener('click', () => {
                menuButtons.forEach(b => b.classList.remove('active'));
                btn.classList.add('active');
                const page = btn.getAttribute('data-page');
                if (page === 'home') {
                    window.location.href = '../html/index.html';
                }
            });
        });
    }

    /**
     * 종속성 리스너 설정
     */
    function bindDependencyListeners() {
        const childCheckboxes = document.querySelectorAll("input[data-required]");
        childCheckboxes.forEach(childBox => {
            const requiredModName = childBox.getAttribute("data-required");
            const parentBox = document.querySelector(`input[data-name="${requiredModName}"]`);
            if (parentBox) {
                parentBox.addEventListener("change", () => {
                    childBox.disabled = !parentBox.checked;
                    if (!parentBox.checked) {
                        childBox.checked = false;
                    }
                });
            }
        });
    }

    /**
     * 원본 모드와 한글화 모드 자동 선택 연동
     */
    function bindOriginalToTranslationAutoSelect() {
        const originalCheckboxes = document.querySelectorAll("#originalGrid .mode-item input[type='checkbox']");
        originalCheckboxes.forEach(origBox => {
            origBox.addEventListener("change", () => {
                if (!autoSelectEnabled) return;

                const origName = origBox.getAttribute("data-name");
                const translationBoxes = document.querySelectorAll(`#translationGrid .mode-item input[type='checkbox']`);

                translationBoxes.forEach(transBox => {
                    const parentMod = transBox.getAttribute("data-parent");
                    if (parentMod === origName) {
                        if (origBox.checked && !transBox.disabled) {
                            transBox.checked = true;
                        } else {
                            transBox.checked = false;
                        }
                    }
                });
            });
        });
    }

    /**
     * 다운로드 버튼 클릭 처리
     */
    function handleDownloadButtonClick() {
        if (chosenPathSpan.textContent === "설정되지 않음") {
            showNotificationModal("다운로드 경로가 선택되지 않았습니다. 경로를 선택해주세요.");
            return;
        }

        const chosenPath = chosenPathSpan.textContent;

        // 경로 유효성 검증 - SPT 게임 폴더인지 확인
        if (!isValidSPTPath(chosenPath)) {
            showNotificationModal("올바른 SPT 게임 폴더가 아닙니다. 'BepInEx'와 'user' 폴더를 포함하는 SPT 게임 폴더를 선택해주세요.");
            return;
        }

        // 모드 초기화 옵션이 켜져있을 경우
        if (initializeModsEnabled) {
            try {
                // 사용자에게 모드 초기화 작업 확인 요청
                showConfirmModal("모드 초기화", "모드를 초기화하시겠습니까? 기존에 설치된 모드와 모드 설정, 로그들이 모두 삭제됩니다.",
                    () => {
                        try {
                            initializeMods(chosenPath);
                            showNotificationModal("모드가 성공적으로 초기화되었습니다.");
                            // 다운로드 프로세스 계속 진행
                            continueWithDownload();
                        } catch (error) {
                            console.error("모드 초기화 중 오류 발생:", error);
                            showNotificationModal(`모드 초기화 중 오류가 발생했습니다: ${error.message}`);
                        }
                    },
                    () => {
                        // 초기화 없이 다운로드만 진행
                        continueWithDownload();
                    }
                );
                return;
            } catch (error) {
                console.error("모드 초기화 중 오류 발생:", error);
                showNotificationModal(`모드 초기화 중 오류가 발생했습니다: ${error.message}`);
                return;
            }
        }

        // 초기화 없이 다운로드 계속 진행
        continueWithDownload();
    }

    /**
     * 확인 모달 표시
     * @param {string} title - 모달 제목
     * @param {string} message - 표시할 메시지
     * @param {Function} onConfirm - 확인 시 실행할 콜백 함수
     * @param {Function} onCancel - 취소 시 실행할 콜백 함수
     */
    function showConfirmModal(title, message, onConfirm, onCancel) {
        // 기존 모달이 있으면 재사용, 없으면 새로 생성
        let confirmModal = document.getElementById('confirm-modal');

        if (!confirmModal) {
            confirmModal = document.createElement('div');
            confirmModal.id = 'confirm-modal';
            confirmModal.className = 'modal';

            const modalContent = document.createElement('div');
            modalContent.className = 'modal-content';

            const modalTitle = document.createElement('h3');
            modalTitle.id = 'confirm-modal-title';

            const modalMessage = document.createElement('p');
            modalMessage.id = 'confirm-modal-message';

            const buttonContainer = document.createElement('div');
            buttonContainer.className = 'modal-buttons';

            const confirmBtn = document.createElement('button');
            confirmBtn.id = 'confirm-yes-btn';
            confirmBtn.className = 'modal-btn';
            confirmBtn.textContent = '확인';

            const cancelBtn = document.createElement('button');
            cancelBtn.id = 'confirm-no-btn';
            cancelBtn.className = 'modal-btn secondary-btn';
            cancelBtn.textContent = '취소';

            buttonContainer.appendChild(confirmBtn);
            buttonContainer.appendChild(cancelBtn);

            modalContent.appendChild(modalTitle);
            modalContent.appendChild(modalMessage);
            modalContent.appendChild(buttonContainer);
            confirmModal.appendChild(modalContent);

            document.body.appendChild(confirmModal);
        }

        // 모달 내용 설정
        document.getElementById('confirm-modal-title').textContent = title;
        document.getElementById('confirm-modal-message').textContent = message;

        // 이벤트 리스너 설정 (기존 리스너 제거 후 새로 설정)
        const confirmBtn = document.getElementById('confirm-yes-btn');
        const cancelBtn = document.getElementById('confirm-no-btn');

        const newConfirmBtn = confirmBtn.cloneNode(true);
        const newCancelBtn = cancelBtn.cloneNode(true);

        confirmBtn.parentNode.replaceChild(newConfirmBtn, confirmBtn);
        cancelBtn.parentNode.replaceChild(newCancelBtn, cancelBtn);

        newConfirmBtn.addEventListener('click', () => {
            confirmModal.classList.add('hidden');
            if (onConfirm) onConfirm();
        });

        newCancelBtn.addEventListener('click', () => {
            confirmModal.classList.add('hidden');
            if (onCancel) onCancel();
        });

        // 모달 표시
        confirmModal.classList.remove('hidden');
    }

    /**
     * 다운로드 계속 진행 (모드 초기화 이후 또는 초기화 없이)
     */
    function continueWithDownload() {
        // 선택된 모드들의 호환성 체크
        const incompatibleMods = checkModCompatibility();
        if (incompatibleMods.length > 0) {
            showNotificationModal(`다음 모드들은 함께 설치할 수 없습니다. 한 가지 버전만 선택해주세요.\n\n${incompatibleMods.join('\n')}`, true);
            return;
        }

        // 선택된 모드 수집
        let selectedMods = collectSelectedMods();

        // 번역기 체크박스만 체크된 경우도 허용
        if (selectedMods.length === 0 && !translatorEnabled) {
            showNotificationModal("다운로드할 모드를 선택해주세요.");
            return;
        }

        // 고라니 번역기가 체크되어 있으면 추가
        if (translatorEnabled) {
            try {
                const metaData = JSON.parse(fs.readFileSync(path.join(__dirname, '..', 'config', 'DownloadMetaData.json'), 'utf8'));
                const translatorMod = metaData.mods.find(m => m.name === "고라니 SPT 한글화 번역기");
                if (translatorMod) {
                    const alreadySelected = selectedMods.some(m => m.name === "고라니 SPT 한글화 번역기");
                    if (!alreadySelected) {
                        console.log("번역기 다운로드 추가: ", translatorMod.name, translatorMod.version);
                        console.log("다운로드 URL: ", translatorMod.downloadUrls);
                        
                        selectedMods.push({
                            name: translatorMod.name,
                            version: translatorMod.version,
                            downloadUrl: translatorMod.downloadUrls.join(','),
                            sourceUrl: translatorMod.sourceUrl
                        });
                    }
                } else {
                    console.error("고라니 번역기 정보를 찾을 수 없습니다.");
                }
            } catch (error) {
                console.error("고라니 번역기 정보 로드 실패:", error);
            }
        }

        if (selectedMods.length === 0) {
            showNotificationModal("다운로드할 모드가 없습니다. 모드를 선택하거나 번역기 설치 옵션을 체크해주세요.");
            return;
        }
        
        console.log("다운로드할 모드 목록:", selectedMods);
        populateDownloadModal(selectedMods);
        showDownloadModal();
        startSequentialDownload();
    }

    /**
     * SPT 게임 폴더 유효성 검사
     * @param {string} folderPath - 검사할 폴더 경로
     * @returns {boolean} 유효한 SPT 게임 폴더인지 여부
     */
    function isValidSPTPath(folderPath) {
        try {
            return (
                fs.existsSync(path.join(folderPath, 'BepInEx')) &&
                fs.existsSync(path.join(folderPath, 'user'))
            );
        } catch (error) {
            console.error("경로 검증 중 오류 발생:", error);
            return false;
        }
    }

    /**
     * 모드 초기화 함수 - 지정된 폴더의 모드 파일을 정리
     * @param {string} sptPath - SPT 게임 폴더 경로
     */
    function initializeMods(sptPath) {
        try {
            // 1. BepInEx/plugins 내 파일 정리 (spt 폴더는 제외)
            const pluginsPath = path.join(sptPath, 'BepInEx', 'plugins');
            if (fs.existsSync(pluginsPath)) {
                const pluginsFiles = fs.readdirSync(pluginsPath);
                pluginsFiles.forEach(file => {
                    const filePath = path.join(pluginsPath, file);
                    // SPT 폴더 제외
                    if (file !== 'spt' && file !== 'spt.dll') {
                        if (fs.lstatSync(filePath).isDirectory()) {
                            // 디렉토리인 경우 재귀적으로 삭제
                            fs.rmdirSync(filePath, { recursive: true });
                        } else {
                            // 파일인 경우 삭제
                            fs.unlinkSync(filePath);
                        }
                    }
                });
            }

            // 2. user/mods 내 파일 정리
            const modsPath = path.join(sptPath, 'user', 'mods');
            if (fs.existsSync(modsPath)) {
                clearDirectory(modsPath);
            }

            // 3. user/cache 내 파일 정리
            const userCachePath = path.join(sptPath, 'user', 'cache');
            if (fs.existsSync(userCachePath)) {
                clearDirectory(userCachePath);
            }

            // 4. BepInEx/cache 내 파일 정리
            const bepinexCachePath = path.join(sptPath, 'BepInEx', 'cache');
            if (fs.existsSync(bepinexCachePath)) {
                clearDirectory(bepinexCachePath);
            }

            // 5. BepInEx/config 내 파일 정리 (특정 파일 제외)
            const bepinexConfigPath = path.join(sptPath, 'BepInEx', 'config');
            if (fs.existsSync(bepinexConfigPath)) {
                // 삭제하지 않을 중요 파일 목록
                const preserveFiles = ['BepInEx.cfg', 'com.bepis.bepinex.configurationmanager.cfg'];
                clearDirectory(bepinexConfigPath, preserveFiles);
            }

            console.log("모드 초기화가 완료되었습니다.");
            return true;
        } catch (error) {
            console.error("모드 초기화 중 오류 발생:", error);
            throw error;
        }
    }

    /**
     * 디렉토리 내 모든 파일 및 폴더 삭제 (제외 목록 지원)
     * @param {string} dirPath - 삭제할 디렉토리 경로
     * @param {string[]} excludeFiles - 삭제에서 제외할 파일 목록
     */
    function clearDirectory(dirPath, excludeFiles = []) {
        if (!fs.existsSync(dirPath)) {
            return;
        }

        const files = fs.readdirSync(dirPath);
        files.forEach(file => {
            // 제외 목록에 있는 파일은 건너뛰기
            if (excludeFiles.includes(file)) {
                console.log(`보존된 파일: ${file}`);
                return;
            }

            const filePath = path.join(dirPath, file);
            if (fs.lstatSync(filePath).isDirectory()) {
                // 디렉토리인 경우 재귀적으로 삭제
                fs.rmdirSync(filePath, { recursive: true });
            } else {
                // 파일인 경우 삭제
                fs.unlinkSync(filePath);
            }
        });
    }

    /**
     * 모드 호환성 체크
     * @returns {string[]} 호환되지 않는 모드 쌍 목록
     */
    function checkModCompatibility() {
        const incompatiblePairs = [];
        const selectedMods = document.querySelectorAll('input[type="checkbox"]:checked');
        const selectedModsArray = Array.from(selectedMods);

        for (let i = 0; i < selectedModsArray.length; i++) {
            const mod1 = selectedModsArray[i];
            const mod1Name = mod1.getAttribute('data-name');

            for (let j = i + 1; j < selectedModsArray.length; j++) {
                const mod2 = selectedModsArray[j];
                const mod2Name = mod2.getAttribute('data-name');

                // 호환성 체크
                try {
                    const mods = JSON.parse(fs.readFileSync(path.join(__dirname, '..', 'config', 'DownloadMetaData.json'), 'utf8')).mods;
                    const mod1Data = mods.find(m => m.name === mod1Name);
                    const mod2Data = mods.find(m => m.name === mod2Name);

                    if (mod1Data && mod2Data &&
                        ((mod1Data.CompareModName === mod2Name) ||
                            (mod2Data.CompareModName === mod1Name))) {
                        incompatiblePairs.push(`${mod1Name}\n${mod2Name}`);
                    }
                } catch (e) {
                    console.error("호환성 체크 중 오류 발생:", e);
                }
            }
        }

        return incompatiblePairs;
    }

    /**
     * 선택된 모드 수집
     * @returns {Object[]} 선택된 모드 정보 배열
     */
    function collectSelectedMods() {
        const categories = ['koreanGrid', 'originalGrid', 'translationGrid'];
        let selectedMods = [];

        categories.forEach(gridId => {
            document.querySelectorAll(`#${gridId} input[type="checkbox"]`)
                .forEach(checkbox => {
                    if (checkbox.checked && !checkbox.disabled) {
                        selectedMods.push({
                            name: checkbox.getAttribute('data-name'),
                            version: checkbox.getAttribute('data-version'),
                            downloadUrl: checkbox.getAttribute('data-download'),
                            sourceUrl: checkbox.getAttribute('data-source'),
                            fileName: checkbox.getAttribute('data-filename') || ""
                        });
                    }
                });
        });

        return selectedMods;
    }

    /**
     * 다운로드 모달에 선택된 모드 표시
     * @param {Object[]} mods - 선택된 모드 배열
     */
    function populateDownloadModal(mods) {
        const grid = document.getElementById("selected-mod-grid");
        grid.innerHTML = "";

        mods.forEach(mod => {
            const div = document.createElement("div");
            div.className = "mod-item";

            const spanText = document.createElement("span");
            spanText.className = "mod-text";
            spanText.innerHTML = `${mod.name} <small>(v${mod.version})</small>`;

            const spanStatus = document.createElement("span");
            spanStatus.className = "mod-status";
            spanStatus.innerHTML = '<i class="material-icons">hourglass_empty</i>';

            div.dataset.downloadurl = mod.downloadUrl;
            if (mod.fileName) {
                div.dataset.filename = mod.fileName;
            }

            div.appendChild(spanText);
            div.appendChild(spanStatus);
            grid.appendChild(div);
        });
    }

    /**
     * 다운로드 모달 표시
     */
    function showDownloadModal() {
        const downloadModal = document.getElementById("download-modal");
        const progressBar = document.getElementById("progress-bar");
        const progressPercent = document.getElementById("progress-percent");

        downloadModal.classList.remove("hidden");
        progressBar.style.width = "0%";
        progressPercent.textContent = "0%";
        document.getElementById("download-modal-close-btn").classList.add("hidden");
    }

    /**
     * 알림 모달 표시
     * @param {string} message - 표시할 메시지
     * @param {boolean} preserveLineBreaks - 줄바꿈 유지 여부
     */
    function showNotificationModal(message, preserveLineBreaks = false) {
        const modalMessage = document.getElementById("modal-message");
        const notificationModal = document.getElementById("notification-modal");

        modalMessage.style.whiteSpace = preserveLineBreaks ? 'pre-line' : 'normal';
        modalMessage.textContent = message;
        notificationModal.classList.remove("hidden");
    }

    /**
     * 순차적 다운로드 시작
     */
    async function startSequentialDownload() {
        const modItems = document.querySelectorAll("#selected-mod-grid .mod-item");
        const totalMods = modItems.length;
        const progressBar = document.getElementById("progress-bar");
        const progressPercent = document.getElementById("progress-percent");

        for (let i = 0; i < totalMods; i++) {
            try {
                await downloadAndExtractMod(modItems[i]);
            } catch (err) {
                console.error("모드 다운로드 오류:", err);
            }

            let overallProgress = Math.round(((i + 1) / totalMods) * 100);
            progressBar.style.width = overallProgress + "%";
            progressPercent.textContent = overallProgress + "%";
        }

        showNotificationModal("모드 다운로드가 모두 완료되었습니다.");
        document.getElementById("download-modal-close-btn").classList.remove("hidden");
    }

    /**
     * 모드 다운로드 및 압축 해제
     * @param {HTMLElement} modElement - 모드 요소
     * @returns {Promise} 다운로드 및 추출 완료 Promise
     */
    function downloadAndExtractMod(modElement) {
        return new Promise((resolve, reject) => {
            const urlList = modElement.dataset.downloadurl.split(',');
            let fileNames = [];
            const isTranslationMod = modElement.closest('#translationGrid') !== null;
            const modName = modElement.querySelector('.mod-text').textContent.split(' ')[0];
            const chosenPath = chosenPathSpan.textContent;
            const extractPath = (modName === "SVM") ? path.join(chosenPath, 'user', 'mods') : chosenPath;

            if (modName === "SVM" && !fs.existsSync(extractPath)) {
                fs.mkdirSync(extractPath, { recursive: true });
            }

            const statusIcon = modElement.querySelector('.mod-status i');
            statusIcon.textContent = 'hourglass_empty';

            // 파일 다운로드 시도
            attemptDownloads(0);

            /**
             * Content-Disposition 헤더에서 파일명 추출
             * @param {Object} headers - HTTP 응답 헤더
             * @returns {string|null} 파일명 또는 null
             */
            function getFilenameFromContentDisposition(headers) {
                const disposition = headers['content-disposition'];
                if (disposition && disposition.includes('filename=')) {
                    const filenameMatch = disposition.match(/filename\*?=['"]?(?:UTF-8''?)?([^;"']+)['"]?;?/i);
                    if (filenameMatch && filenameMatch[1]) {
                        return decodeURIComponent(filenameMatch[1].replace(/['"]/g, ''));
                    }
                }
                return null;
            }

            /**
             * URL 목록에서 순차적으로 다운로드 시도
             * @param {number} urlIndex - 현재 시도할 URL 인덱스
             */
            function attemptDownloads(urlIndex) {
                if (urlIndex >= urlList.length) {
                    if (fileNames.length === 0) {
                        statusIcon.textContent = 'error';
                        console.error("모든 다운로드 URL 실패, 대상 모드:", modName);
                        reject(new Error('모든 다운로드 URL 실패'));
                    } else {
                        decompressAndClean(fileNames, extractPath, statusIcon, resolve, reject);
                    }
                    return;
                }

                let currentUrl = urlList[urlIndex].trim();
                console.log(`[${modName}] 다운로드 시도 URL (${urlIndex+1}/${urlList.length}):`, currentUrl);
                
                let fileName = '';

                // URL에서 파일명 추출
                try {
                    let testUrl = currentUrl.trim();
                    if (testUrl.includes("drive.google.com")) {
                        const urlObj = new URL(testUrl);
                        fileName = urlObj.searchParams.get('id') || 'download';
                        console.log("Google Drive 파일 ID:", fileName);
                    } else {
                        fileName = decodeURIComponent(testUrl.split('/').pop());
                        console.log("추출된 파일명:", fileName);
                    }
                } catch (e) {
                    console.error("파일명 추출 실패:", e);
                    fileName = "download_" + urlIndex;
                    console.log("기본 파일명 사용:", fileName);
                }

                // 한글화 모드면서 zip 확장자가 아닌 경우 zip으로 변경
                if (isTranslationMod && !fileName.toLowerCase().endsWith('.zip')) {
                    fileName = fileName.replace(/\.[^/.]+$/, '') + '.zip';
                    console.log("확장자 변경된 파일명:", fileName);
                }

                const filePath = path.join(chosenPath, fileName);
                console.log("저장 경로:", filePath);
                
                const file = fs.createWriteStream(filePath);
                const finalUrl = currentUrl.includes("drive.google.com")
                    ? convertGoogleDriveUrl(currentUrl)
                    : currentUrl;
                
                console.log("최종 다운로드 URL:", finalUrl);

                downloadRequest(finalUrl, filePath, file, (response, err) => {
                    if (err) {
                        try { 
                            fs.unlinkSync(filePath); 
                            console.error(`URL ${currentUrl} 다운로드 실패:`, err);
                        } catch (e) { 
                            console.error("파일 삭제 실패:", e);
                        }
                        console.log(`URL ${currentUrl} 다운로드 실패, 다음 URL 시도`);
                        attemptDownloads(urlIndex + 1); // 다음 URL 시도
                    } else {
                        console.log(`URL ${currentUrl} 다운로드 성공`);
                        // Content-Disposition 헤더에서 파일명 확인
                        const contentDispositionFilename = getFilenameFromContentDisposition(response.headers);
                        if (contentDispositionFilename) {
                            const finalFilePath = path.join(chosenPath, contentDispositionFilename);
                            console.log("Content-Disposition 파일명:", contentDispositionFilename);
                            fs.rename(filePath, finalFilePath, (renameErr) => {
                                if (renameErr) {
                                    console.error("파일명 변경 실패:", renameErr);
                                    fileNames.push(filePath);
                                } else {
                                    console.log("파일명 변경 성공:", finalFilePath);
                                    fileNames.push(finalFilePath);
                                }
                                attemptDownloads(urlIndex + 1);
                            });
                        } else {
                            console.log("Content-Disposition 파일명 없음, 원본 파일명 사용");
                            fileNames.push(filePath);
                            attemptDownloads(urlIndex + 1);
                        }
                    }
                });
            }

            /**
             * HTTP/HTTPS 다운로드 요청 처리
             * @param {string} url - 다운로드 URL
             * @param {string} filePath - 저장할 파일 경로
             * @param {fs.WriteStream} fileStream - 파일 쓰기 스트림
             * @param {Function} callback - 콜백 함수
             */
            function downloadRequest(url, filePath, fileStream, callback) {
                const protocol = url.startsWith("https") ? https : http;
                protocol.get(url, (response) => {
                    // 리디렉션 처리
                    if (response.statusCode >= 300 && response.statusCode < 400 && response.headers.location) {
                        return downloadRequest(response.headers.location, filePath, fileStream, callback);
                    }

                    // 오류 응답 처리
                    if (response.statusCode !== 200) {
                        statusIcon.textContent = 'error';
                        if (response.statusCode === 404) {
                            console.error("응답 코드 404 - 파일 미존재:", url);
                            return callback(response, new Error("404"));
                        }
                        return callback(response, new Error("응답 코드 " + response.statusCode));
                    }

                    // 정상 다운로드 처리
                    response.pipe(fileStream);
                    fileStream.on('finish', () => {
                        fileStream.close(() => callback(response, null));
                    });
                }).on('error', (err) => {
                    try { fs.unlinkSync(filePath); } catch (e) { }
                    statusIcon.textContent = 'error';
                    callback(null, err);
                });
            }
        });
    }

    /**
     * 압축 파일 해제 및 정리
     * @param {string[]} filePaths - 다운로드된 파일 경로 배열
     * @param {string} extractPath - 압축 해제 경로
     * @param {Element} statusIcon - 상태 아이콘 요소
     * @param {Function} resolve - Promise resolve 함수
     * @param {Function} reject - Promise reject 함수
     */
    function decompressAndClean(filePaths, extractPath, statusIcon, resolve, reject) {
        if (filePaths.length === 0) {
            statusIcon.textContent = 'error';
            reject(new Error('다운로드된 파일 없음'));
            return;
        }

        // 파일 유형별 분류
        const zipFiles = filePaths.filter(path => path.toLowerCase().endsWith('.zip'));
        const sevenZipFiles = filePaths.filter(path => path.toLowerCase().endsWith('.7z'));
        const otherFiles = filePaths.filter(path =>
            !path.toLowerCase().endsWith('.zip') && !path.toLowerCase().endsWith('.7z'));

        const archiveFiles = [...zipFiles, ...sevenZipFiles];

        // ZIP 파일 압축 해제
        if (zipFiles.length > 0) {
            Promise.all(zipFiles.map(filePath => {
                return new Promise((res, rej) => {
                    try {
                        const zip = new AdmZip(filePath);
                        zip.extractAllTo(extractPath, true);
                        res();
                    } catch (err) {
                        rej(err);
                    }
                });
            }))
                .then(() => {
                    // ZIP 해제 후 7z 파일 처리
                    if (sevenZipFiles.length > 0) {
                        processSevenZipFiles(sevenZipFiles, extractPath, archiveFiles, otherFiles, statusIcon, resolve, reject);
                    } else {
                        cleanupFiles(archiveFiles, otherFiles, statusIcon, resolve);
                    }
                })
                .catch(err => {
                    statusIcon.textContent = 'error';
                    reject(err);
                });
        } else if (sevenZipFiles.length > 0) {
            // ZIP 파일 없는 경우 7z 파일만 처리
            processSevenZipFiles(sevenZipFiles, extractPath, archiveFiles, otherFiles, statusIcon, resolve, reject);
        } else {
            // 압축 파일 없는 경우
            cleanupFiles(archiveFiles, otherFiles, statusIcon, resolve);
        }
    }

    /**
     * 7z 파일 처리
     * @param {string[]} sevenZipFiles - 7z 파일 경로 배열
     * @param {string} extractPath - 압축 해제 경로
     * @param {string[]} archiveFiles - 모든 압축 파일 경로 배열
     * @param {string[]} otherFiles - 비압축 파일 경로 배열
     * @param {Element} statusIcon - 상태 아이콘 요소
     * @param {Function} resolve - Promise resolve 함수
     * @param {Function} reject - Promise reject 함수
     */
    function processSevenZipFiles(sevenZipFiles, extractPath, archiveFiles, otherFiles, statusIcon, resolve, reject) {
        Promise.all(sevenZipFiles.map(filePath => {
            return new Promise((res, rej) => {
                const sevenZip = spawn(sevenZipPath, ['x', filePath, `-o${extractPath}`, '-y']);

                sevenZip.on('close', (code) => {
                    if (code === 0) {
                        res();
                    } else {
                        rej(new Error(`7z 압축 해제 실패 (코드: ${code})`));
                    }
                });

                sevenZip.on('error', (err) => {
                    rej(err);
                });
            });
        }))
            .then(() => {
                cleanupFiles(archiveFiles, otherFiles, statusIcon, resolve);
            })
            .catch(err => {
                statusIcon.textContent = 'error';
                reject(err);
            });
    }

    /**
     * 임시 파일 정리 및 완료 처리
     * @param {string[]} archiveFiles - 압축 파일 경로 배열
     * @param {string[]} otherFiles - 비압축 파일 경로 배열
     * @param {Element} statusIcon - 상태 아이콘 요소
     * @param {Function} resolve - Promise resolve 함수
     */
    function cleanupFiles(archiveFiles, otherFiles, statusIcon, resolve) {
        // 압축 파일 삭제
        archiveFiles.forEach(filePath => {
            try {
                fs.unlinkSync(filePath);
            } catch (e) {
                console.error("압축 파일 삭제 실패:", filePath, e);
            }
        });

        // 상태 아이콘 업데이트 및 완료 처리
        statusIcon.textContent = 'check_circle';
        resolve();
    }

    /**
     * Google Drive URL을 직접 다운로드 가능한 URL로 변환
     * @param {string} url - Google Drive URL
     * @returns {string} 변환된 다운로드 URL
     */
    function convertGoogleDriveUrl(url) {
        try {
            console.log("Google Drive URL 변환 시도:", url);
            let fileId = null;
            const urlObj = new URL(url);

            // URL 파라미터에서 id 추출 시도
            fileId = urlObj.searchParams.get('id');
            if (fileId) {
                console.log("URL 파라미터에서 fileId 추출 성공:", fileId);
            }

            // URL 경로에서 id 추출 시도 (/d/[FILE_ID] 패턴)
            if (!fileId) {
                const match = url.match(/\/d\/([a-zA-Z0-9_-]+)/);
                if (match && match[1]) {
                    fileId = match[1];
                    console.log("URL 경로에서 fileId 추출 성공:", fileId);
                }
            }

            if (fileId) {
                const convertedUrl = `https://drive.google.com/uc?export=download&id=${fileId}`;
                console.log("변환된 Google Drive URL:", convertedUrl);
                return convertedUrl;
            } else {
                console.warn("Google Drive fileId 추출 실패, 원본 URL 반환");
            }
        } catch (e) {
            console.error("Google Drive URL 변환 실패:", e);
        }

        // 변환 실패 시 원본 URL 반환
        return url;
    }
});