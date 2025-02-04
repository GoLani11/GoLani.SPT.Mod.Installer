const { ipcRenderer } = require('electron');
const fs = require('fs');
const path = require('path');
const https = require('https');
const http = require('http');
const { spawn } = require('child_process');
const AdmZip = require('adm-zip');
// 7zip-bin를 이용하여 7za 실행 파일의 전체 경로를 가져옴
const sevenZipPath = require('7zip-bin').path7za;

document.addEventListener("DOMContentLoaded", () => {

    let autoSelectEnabled = true;
    // 자동 선택 토글 (기본 활성)
    const autoToggle = document.getElementById("auto-select-toggle");
    autoToggle.addEventListener("change", () => {
        autoSelectEnabled = autoToggle.checked;
    });

    // DownloadMetaData.json을 로드하여 모드 목록을 동적으로 생성
    loadMetaData();

    // 탭 전환 처리
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

    // 경로 선택 버튼 (Electron dialog API 연동)
    const selectPathBtn = document.getElementById("select-path-btn");
    const chosenPathSpan = document.getElementById("chosen-path");
    selectPathBtn.addEventListener("click", async () => {
        const result = await ipcRenderer.invoke('select-directory');
        if (!result.canceled && result.filePaths && result.filePaths[0]) {
            chosenPathSpan.textContent = result.filePaths[0];
        }
    });

    // 다운로드 버튼 처리
    const downloadBtn = document.getElementById("download-btn");
    downloadBtn.addEventListener("click", () => {
        if (chosenPathSpan.textContent === "설정되지 않음") {
            showNotificationModal("다운로드 경로가 선택되지 않았습니다. 경로를 선택해주세요.");
            return;
        }
        // 각 카테고리(한글, 원본, 한글화)에서 체크된 모드를 순서대로 배열
        const categories = ['korean', 'original', 'translation'];
        let selectedMods = [];
        categories.forEach(cat => {
            document.querySelectorAll(`#${cat} .mode-item input[type="checkbox"]`)
                .forEach(checkbox => {
                    if (checkbox.checked && !checkbox.disabled) {
                        const modName = checkbox.getAttribute('data-name');
                        const modVersion = checkbox.getAttribute('data-version');
                        const downloadUrl = checkbox.getAttribute('data-download');
                        const sourceUrl = checkbox.getAttribute('data-source');
                        // 만약 data-filename 속성이 있다면 원본 파일명을 그대로 사용
                        const fileName = checkbox.getAttribute('data-filename') || "";
                        selectedMods.push({ name: modName, version: modVersion, downloadUrl, sourceUrl, fileName });
                    }
                });
        });
        if (selectedMods.length === 0) {
            showNotificationModal("다운로드할 모드를 선택해주세요.");
            return;
        }
        populateDownloadModal(selectedMods);
        showDownloadModal();
        startSequentialDownload();
    });

    // 다운로드 진행 모달 관련 DOM 요소
    const downloadModal = document.getElementById("download-modal");
    const downloadModalCloseBtn = document.getElementById("download-modal-close-btn");
    const progressBar = document.getElementById("progress-bar");
    const progressPercent = document.getElementById("progress-percent");

    // 선택된 모드들을 모달 그리드에 추가 (모드 이름 옆에 버전 정보 포함)
    function populateDownloadModal(mods) {
        const grid = document.getElementById("selected-mod-grid");
        grid.innerHTML = "";
        mods.forEach(mod => {
            const div = document.createElement("div");
            div.className = "mod-item";
            const spanText = document.createElement("span");
            spanText.className = "mod-text";
            // 모드 이름과 버전 정보를 작은 글씨로 표시
            spanText.innerHTML = `${mod.name} <small>(v${mod.version})</small>`;
            const spanStatus = document.createElement("span");
            spanStatus.className = "mod-status";
            spanStatus.innerHTML = '<i class="material-icons">hourglass_empty</i>';
            // downloadUrl는 쉼표로 구분된 문자열; data-filename에 원본 파일명이 저장되어 있다면 그대로 사용
            div.dataset.downloadurl = mod.downloadUrl;
            if (mod.fileName) {
                div.dataset.filename = mod.fileName;
            }
            div.appendChild(spanText);
            div.appendChild(spanStatus);
            grid.appendChild(div);
        });
    }

    // 모달 표시 함수
    function showDownloadModal() {
        downloadModal.classList.remove("hidden");
        progressBar.style.width = "0%";
        progressPercent.textContent = "0%";
        downloadModalCloseBtn.classList.add("hidden");
    }

    // 순차적 다운로드 진행 함수
    async function startSequentialDownload() {
        const modItems = document.querySelectorAll("#selected-mod-grid .mod-item");
        const totalMods = modItems.length;
        for (let i = 0; i < totalMods; i++) {
            try {
                await simulateSingleDownload(modItems[i]);
            } catch (err) {
                console.error("모드 다운로드 오류:", err);
            }
            let overallProgress = Math.round(((i + 1) / totalMods) * 100);
            progressBar.style.width = overallProgress + "%";
            progressPercent.textContent = overallProgress + "%";
        }
        showNotificationModal("모드 다운로드가 모두 완료되었습니다.");
        downloadModalCloseBtn.classList.remove("hidden");
    }

    // 단일 모드 다운로드 및 압축 해제 함수
    function simulateSingleDownload(modElement) {
        return new Promise((resolve, reject) => {
            // downloadUrls가 쉼표로 구분된 문자열 => 배열로 변환
            let urlList = modElement.dataset.downloadurl.split(',');
            // 우선 data-filename 속성에 지정된 값(원본 파일명)이 있으면 사용, 없으면 URL에서 추출
            let fileName = modElement.dataset.filename;
            const isTranslationMod = (modElement.closest('#translationGrid') !== null);
            const modName = modElement.querySelector('.mod-text').textContent.split(' ')[0]; // 모드 이름 추출

            // URL에서 파일명 추출 (Content-Disposition 처리 추가)
            const getFilenameFromContentDisposition = (headers) => {
                const disposition = headers['content-disposition'];
                if (disposition && disposition.includes('filename=')) {
                    const filenameMatch = disposition.match(/filename\*?=['"]?(?:UTF-8''?)?([^;"']+)['"]?;?/i);
                    if (filenameMatch && filenameMatch[1]) {
                        return decodeURIComponent(filenameMatch[1].replace(/['"]/g, ''));
                    }
                }
                return null;
            };

            if (!fileName) {
                try {
                    let testUrl = urlList[0].trim();
                    if (testUrl.includes("drive.google.com")) {
                        // 구글 드라이브 링크인 경우, 파일명을 직접 추출하기 어려우므로 파일 ID 사용 (추후 Content-Disposition으로 개선)
                        const urlObj = new URL(testUrl);
                        fileName = urlObj.searchParams.get('id') || 'download';
                    } else {
                        fileName = decodeURIComponent(testUrl.split('/').pop());
                    }
                } catch (e) {
                    console.error("파일명 추출 실패:", e);
                    fileName = "download";
                }
            }

            // 한글화 모드인 경우 강제로 .zip 확장자 적용
            if (isTranslationMod && !fileName.toLowerCase().endsWith('.zip')) {
                fileName = fileName.replace(/\.[^/.]+$/, '') + '.zip';
            }

            const chosenPath = chosenPathSpan.textContent;
            // SVM 모드인 경우 user/mods 폴더에 압축 해제
            const extractPath = (modName === "SVM") ? path.join(chosenPath, 'user', 'mods') : chosenPath;
            // user/mods 폴더가 없다면 생성 (SVM 모드일 때만)
            if (modName === "SVM" && !fs.existsSync(extractPath)) {
                fs.mkdirSync(extractPath, { recursive: true });
            }

            const filePath = path.join(chosenPath, fileName); // 다운로드 경로는 chosenPath 유지
            const statusIcon = modElement.querySelector('.mod-status i');
            statusIcon.textContent = 'cloud_download';

            // 내부 재귀 함수: urlList를 순차적으로 시도
            function attemptDownload(index) {
                if (index >= urlList.length) {
                    statusIcon.textContent = 'error';
                    return resolve(); // 모든 URL 시도 후 실패하면 건너뛰기
                }
                const currentUrl = urlList[index].trim();
                // 구글 드라이브 링크인 경우, 변환 함수로 변경
                const finalUrl = currentUrl.includes("drive.google.com") ? convertGoogleDriveUrl(currentUrl) : currentUrl;
                const file = fs.createWriteStream(filePath);
                downloadRequest(finalUrl, file, (response, err) => { // response 추가
                    if (err) {
                        try { fs.unlinkSync(filePath); } catch (e) { }
                        return attemptDownload(index + 1);
                    } else {
                        // Content-Disposition 헤더에서 파일명 추출 시도 (Google Drive 대응)
                        const contentDispositionFilename = getFilenameFromContentDisposition(response.headers);
                        const finalFileName = contentDispositionFilename || fileName; // 우선 Content-Disposition 파일명 사용, 없으면 기존 파일명
                        const finalFilePath = path.join(chosenPath, finalFileName);

                        // 파일 이름 변경 (기존 파일 삭제 후 새 이름으로 변경) - Content-Disposition 파일명이 있을 때만 변경
                        if (contentDispositionFilename) {
                            fs.rename(filePath, finalFilePath, (renameErr) => {
                                if (renameErr) {
                                    console.error("파일명 변경 실패:", renameErr);
                                    // 파일명 변경 실패 시, 기존 파일명으로 진행
                                    decompressAndClean(filePath, extractPath, fileName, statusIcon, resolve, reject);
                                } else {
                                    decompressAndClean(finalFilePath, extractPath, contentDispositionFilename, statusIcon, resolve, reject);
                                }
                            });
                        } else {
                            decompressAndClean(filePath, extractPath, fileName, statusIcon, resolve, reject);
                        }
                    }
                });
            }

            // 압축 해제 및 파일 정리 함수
            function decompressAndClean(filePath, extractPath, finalFileName, statusIcon, resolve, reject) {
                if (finalFileName.toLowerCase().endsWith('.zip')) {
                    try {
                        const zip = new AdmZip(filePath);
                        zip.extractAllTo(extractPath, true);
                        fs.unlinkSync(filePath);
                        statusIcon.textContent = 'check_circle';
                        resolve();
                    } catch (err) {
                        statusIcon.textContent = 'error';
                        reject(err);
                    }
                } else if (finalFileName.toLowerCase().endsWith('.7z')) {
                    const sevenZip = spawn(sevenZipPath, ['x', filePath, `-o${extractPath}`, '-y']);
                    sevenZip.stdout.on('data', (data) => { console.log(data.toString()); });
                    sevenZip.stderr.on('data', (data) => { console.error(data.toString()); });
                    sevenZip.on('close', (code) => {
                        if (code === 0) {
                            fs.unlinkSync(filePath);
                            statusIcon.textContent = 'check_circle';
                            resolve();
                        } else {
                            statusIcon.textContent = 'error';
                            reject(new Error('7z 압축 해제 실패'));
                        }
                    });
                } else {
                    statusIcon.textContent = 'check_circle';
                    resolve();
                }
            }


            // downloadRequest: URL, 파일 스트림, callback (response 추가)
            function downloadRequest(url, fileStream, callback) {
                const protocol = url.startsWith("https") ? https : http;
                protocol.get(url, (response) => {
                    // 리디렉션 처리: 300 ≤ statusCode < 400
                    if (response.statusCode >= 300 && response.statusCode < 400 && response.headers.location) {
                        return downloadRequest(response.headers.location, fileStream, callback);
                    }
                    if (response.statusCode !== 200) {
                        statusIcon.textContent = 'error';
                        if (response.statusCode === 404) {
                            console.error("응답 코드 404 - 파일 미존재:", url);
                            return callback(response, new Error("404")); // response 전달
                        }
                        return callback(response, new Error("응답 코드 " + response.statusCode)); // response 전달
                    }
                    const totalBytes = parseInt(response.headers['content-length'], 10);
                    let receivedBytes = 0;
                    response.pipe(fileStream);
                    response.on('data', (chunk) => {
                        receivedBytes += chunk.length;
                    });
                    fileStream.on('finish', () => {
                        fileStream.close(() => {
                            callback(response, null); // response 와 null(error 없음) 전달
                        });
                    });
                }).on('error', (err) => {
                    fs.unlink(filePath, () => { });
                    statusIcon.textContent = 'error';
                    callback(null, err); // response 자리에 null, err 전달
                });
            }

            attemptDownload(0);
        });
    }

    // google drive 링크를 직접 다운로드 가능한 URL로 변환 (API 사용 없이)
    function convertGoogleDriveUrl(url) {
        try {
            let urlObj = new URL(url);
            let fileId = urlObj.searchParams.get('id');
            if (!fileId) {
                const match = url.match(/\/d\/([a-zA-Z0-9_-]+)/);
                if (match) {
                    fileId = match[1];
                }
            }
            if (fileId) {
                return "https://drive.google.com/uc?export=download&id=" + fileId;
            }
        } catch (e) {
            console.error("convertGoogleDriveUrl 오류:", e);
        }
        return url;
    }

    // JSON 메타데이터 로드 및 UI 업데이트
    loadMetaData();

    function loadMetaData() {
        const metaFilePath = path.join(__dirname, '..', 'config', 'DownloadMetaData.json');
        fs.readFile(metaFilePath, 'utf8', (err, data) => {
            if (err) {
                console.error("메타데이터 로드 실패:", err);
                return;
            }
            try {
                const metaData = JSON.parse(data);
                document.getElementById("spt-version").textContent = "SPT 게임 버전: " + metaData.SPTDefaultVersion;
                document.getElementById("program-version").textContent = "프로그램 버전: " + metaData.programVersion; // 프로그램 버전 푸터 업데이트
                const mods = metaData.mods;
                let originalMods = {};
                mods.forEach(mod => {
                    if (mod.Category === "원본 모드") {
                        originalMods[mod.name] = mod.version;
                    }
                });
                const koreanGrid = document.getElementById("koreanGrid");
                const originalGrid = document.getElementById("originalGrid");
                const translationGrid = document.getElementById("translationGrid");
                koreanGrid.innerHTML = "";
                originalGrid.innerHTML = "";
                translationGrid.innerHTML = "";
                mods.forEach(mod => {
                    const div = document.createElement("div");
                    div.className = "mode-item";
                    const checkbox = document.createElement("input");
                    checkbox.type = "checkbox";
                    checkbox.id = mod.name + "-" + mod.version;
                    const sptMatch = (mod.SPTversion === metaData.SPTDefaultVersion);
                    checkbox.disabled = !sptMatch;
                    if (mod.Category === "한글화 모드") {
                        if (!originalMods[mod["Parent mod name"]] || originalMods[mod["Parent mod name"]] !== mod.version) {
                            checkbox.disabled = true;
                        }
                        checkbox.setAttribute("data-parent", mod["Parent mod name"]);
                    }
                    if (mod.RequiredModName) {
                        checkbox.disabled = true;
                        checkbox.setAttribute("data-required", mod.RequiredModName);
                    }
                    checkbox.setAttribute("data-name", mod.name);
                    checkbox.setAttribute("data-version", mod.version);
                    // downloadUrls는 배열이므로 join하여 쉼표로 구분
                    checkbox.setAttribute("data-download", mod.downloadUrls.join(','));
                    checkbox.setAttribute("data-source", mod.sourceUrl);
                    // data-source 속성 추가
                    checkbox.setAttribute("data-source", mod.sourceUrl);
                    // 원본 파일명 유지(옵션): JSON에 filename이 있다면 data-filename에 저장
                    if (mod.filename) {
                        checkbox.setAttribute("data-filename", mod.filename);
                    }
                    const label = document.createElement("label");
                    label.htmlFor = checkbox.id;
                    // label에 링크 추가
                    label.innerHTML = `<a href="${mod.sourceUrl}" target="_blank">${mod.name} <small>(v${mod.version})</small></a>`;
                    div.appendChild(checkbox);
                    div.appendChild(label);
                    if (mod.Category === "한글 모드") {
                        koreanGrid.appendChild(div);
                    } else if (mod.Category === "원본 모드") {
                        originalGrid.appendChild(div);
                    } else if (mod.Category === "한글화 모드") {
                        translationGrid.appendChild(div);
                    }
                });
                bindDependencyListeners();
                bindOriginalToTranslationAutoSelect();
            } catch (e) {
                console.error("메타데이터 파싱 오류:", e);
            }
        });
    }


    // 부모 모드(RequiredModName) 의존 처리 (기존과 동일)
    function bindDependencyListeners() {
        const childCheckboxes = document.querySelectorAll("input[data-required]");
        childCheckboxes.forEach(childBox => {
            const requiredModName = childBox.getAttribute("data-required");
            const parentBox = document.querySelector(`input[data-name="${requiredModName}"]`);
            if (parentBox) {
                parentBox.addEventListener("change", () => {
                    if (parentBox.checked) {
                        childBox.disabled = false;
                    } else {
                        childBox.checked = false;
                        childBox.disabled = true;
                    }
                });
            }
        });
    }

    // 원본 모드 선택 시, 한글화 모드 자동 선택 처리 (토글 활성화된 경우) (기존과 동일)
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


    // 기본 알림 모달 (기존과 동일)
    const notificationModal = document.getElementById("notification-modal");
    const modalMessage = document.getElementById("modal-message");
    const modalCloseBtn = document.getElementById("modal-close-btn");
    function showNotificationModal(message) {
        modalMessage.textContent = message;
        notificationModal.classList.remove("hidden");
    }
    modalCloseBtn.addEventListener("click", () => {
        notificationModal.classList.add("hidden");
    });
    downloadModalCloseBtn.addEventListener("click", () => {
        downloadModal.classList.add("hidden");
    });
    const menuButtons = document.querySelectorAll('.menu-btn');
    menuButtons.forEach(btn => {
        btn.addEventListener('click', () => {
            menuButtons.forEach(b => b.classList.remove('active'));
            btn.classList.add('active');
            const page = btn.getAttribute('data-page');
            if (page === 'home') {
                window.location.href = '../html/index.html';
            } else if (page === 'mod-download') {
                console.log('모드 다운로드 페이지');
            }
        });
    });
    const closeBanner = document.getElementById('close-banner');
    closeBanner.addEventListener('click', () => {
        document.querySelector('.notification-banner').style.display = 'none';
    });
    const settingsBtn = document.getElementById('settings-btn');
    settingsBtn.addEventListener('click', () => {
        console.log('설정 버튼 클릭됨');
    });
});