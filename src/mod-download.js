// mod-download.js (수정된 전체 코드 - 라이트 모드 테마 전환 기능 추가)
const { ipcRenderer } = require('electron');
const fs = require('fs');
const path = require('path');
const https = require('https');
const http = require('http');
const { spawn } = require('child_process');
const AdmZip = require('adm-zip');
const sevenZipPath = require('7zip-bin').path7za;

document.addEventListener("DOMContentLoaded", () => {
    let autoSelectEnabled = true;
    const autoToggle = document.getElementById("auto-select-toggle");
    autoToggle.addEventListener("change", () => {
        autoSelectEnabled = autoToggle.checked;
    });

    let isFallbackActive = false; // Fallback 모드 활성 여부 추적 (mod-download.js에도 추가)
    let currentTheme = localStorage.getItem('theme') || 'dark'; // 초기 테마 설정 (localStorage에서 로드, 없으면 'dark' 기본)

    // 초기 테마 적용 및 아이콘 설정
    setTheme(currentTheme);
    updateSettingsIcon(currentTheme);

    // GitHub DownloadMetaData.json URL
    const githubMetaUrl = 'https://raw.githubusercontent.com/GoLani11/GoLani.SPT.Mod.Installer/main/config/DownloadMetaData.json';

    // 알림 배너 메시지 표시 함수 (mod-download.js) - 기존 알림 배너 용도
    function showNotificationBannerMessage(message, type = 'default') { // type 인자 추가 (default, fallback)
        const banner = document.querySelector('.notification-banner');
        const bannerSpan = document.querySelector('.notification-banner span');
        bannerSpan.textContent = message;
        banner.style.display = 'flex';

        banner.classList.remove('fallback-mode', 'success-mode'); // 모든 스타일 클래스 제거
        if (type === 'fallback') {
            banner.classList.add('fallback-mode'); // Fallback 스타일 적용
        }

        // 기존 닫기 버튼은 그대로 유지하거나 필요에 따라 별도 처리
    }

    // 새로고침 상태 메시지 표시 함수 (mod-download.js)
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

        setTimeout(() => {
            banner.style.display = 'none';
            banner.classList.remove('fallback-mode', 'success-mode');
        }, 3000);
    }


    // 메타데이터 로드 함수 (GitHub에서 다운로드)
    function loadMetaData() {
        isFallbackActive = false; // 리로드 시 Fallback 모드 초기화
        updateNotificationBanner(); // 배너 텍스트 업데이트 (초기화)
        showRefreshStatusMessage('새로고침 중...', null); // "새로고침 중..." 메시지 표시

        fetch(githubMetaUrl)
            .then(response => response.json())
            .then(metaData => {
                isFallbackActive = false;
                updateNotificationBanner(); // 배너 텍스트 업데이트 (GitHub 로드 성공)
                document.getElementById("spt-version").textContent = "SPT 게임 버전: " + metaData.SPTDefaultVersion;
                // 프로그램 버전은 main.js에서 ipc 통신으로 받아서 업데이트
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
                    checkbox.setAttribute("data-download", mod.downloadUrls.join(','));
                    checkbox.setAttribute("data-source", mod.sourceUrl);
                    if (mod.filename) {
                        checkbox.setAttribute("data-filename", mod.filename);
                    }
                    const label = document.createElement("label");
                    label.htmlFor = checkbox.id;
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
                showRefreshStatusMessage('새로고침 완료', true); // "새로고침 완료" 메시지 표시 (성공)
            })
            .catch(error => {
                isFallbackActive = true; // Fallback 모드 활성화
                updateNotificationBanner(); // 배너 텍스트 업데이트 (Fallback 모드)
                console.error("GitHub 메타데이터 로드 실패, 로컬 파일 사용:", error);
                ipcRenderer.invoke('show-notification', '서버와 연결이 되지 않아 프로그램에 저장된 설정을 가져옵니다.\n인터넷 연결을 확인해주세요.'); // 알림 표시
                // GitHub 로드 실패 시, 로컬 파일 로드 (기존 방식 유지)
                loadMetaDataLocal();
                showRefreshStatusMessage('새로고침 실패 (GitHub)', false); // "새로고침 실패 (GitHub)" 메시지 표시 (GitHub 실패)
            });
    }

    // 알림 배너 텍스트 업데이트 함수 (mod-download.js 용)
    function updateNotificationBanner() {
        const banner = document.querySelector('.notification-banner span');
        if (isFallbackActive) {
            banner.textContent = 'GitHub 설정 로드 실패. 로컬 설정 사용 중 (인터넷 연결 확인 요망).';
            showNotificationBannerMessage('GitHub 설정 로드 실패. 로컬 설정 사용 중 (인터넷 연결 확인 요망)', 'fallback'); // Fallback 모드 알림 배너 메시지 표시 (기존 함수 재활용)
            document.querySelector('.notification-banner').classList.add('fallback-mode'); // Fallback 모드 스타일 클래스 추가 (CSS 스타일 적용을 위해 유지)
            document.querySelector('.notification-banner').classList.remove('success-mode'); // success-mode 클래스 제거
        } else {
            banner.textContent = '모드 다운로드 페이지입니다.'; // 모드 다운로드 페이지 기본 배너 텍스트
            showNotificationBannerMessage('경로 지정 시 SPT 게임 폴더에 경로를 지정해주세요.'); // 기본 배너 메시지 표시 (기존 함수 재활용)
            document.querySelector('.notification-banner').classList.remove('fallback-mode', 'success-mode'); // Fallback, Success 모드 스타일 클래스 제거
        }
        banner.style.display = 'flex'; // 알림 배너 보이도록 설정 (updateNotificationBanner에서도 보이게 해야 초기 로딩 시 배너가 나타남)
    }


    // 로컬 JSON 메타데이터 로드 (GitHub 로드 실패 시 Fallback)
    function loadMetaDataLocal() {
        const metaFilePath = path.join(__dirname, '..', 'config', 'DownloadMetaData.json');
        fs.readFile(metaFilePath, 'utf8', (err, data) => {
            if (err) {
                console.error("로컬 메타데이터 로드 실패:", err);
                showRefreshStatusMessage('새로고침 실패 (로컬 설정)', false); // "새로고침 실패 (로컬 설정)" 메시지 표시 (로컬 파일 로드 실패)
                return;
            }
            try {
                const metaData = JSON.parse(data);
                document.getElementById("spt-version").textContent = "SPT 게임 버전: " + metaData.SPTDefaultVersion;
                // 프로그램 버전은 main.js에서 ipc 통신으로 받아서 업데이트
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
                    checkbox.setAttribute("data-download", mod.downloadUrls.join(','));
                    checkbox.setAttribute("data-source", mod.sourceUrl);
                    if (mod.filename) {
                        checkbox.setAttribute("data-filename", mod.filename);
                    }
                    const label = document.createElement("label");
                    label.htmlFor = checkbox.id;
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
                showRefreshStatusMessage('새로고침 완료 (로컬 설정)', true); // "새로고침 완료 (로컬 설정)" 메시지 표시 (로컬 파일 로드 성공)
            } catch (e) {
                console.error("로컬 메타데이터 파싱 오류:", e);
                showRefreshStatusMessage('새로고침 실패 (로컬 설정 파싱)', false); // "새로고침 실패 (로컬 설정 파싱)" 메시지 표시 (로컬 JSON 파싱 오류)
            }
        });
    }

    loadMetaData(); // 프로그램 시작 시 GitHub에서 메타데이터 로드 시도

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

        // 체크된 모드들의 충돌 검사
        const checkedMods = [];
        const categories = ['korean', 'original', 'translation'];
        categories.forEach(cat => {
            document.querySelectorAll(`#${cat}Grid .mode-item input[type="checkbox"]`)
                .forEach(checkbox => {
                    if (checkbox.checked && !checkbox.disabled) {
                        const modName = checkbox.getAttribute('data-name');
                        checkedMods.push(modName);
                    }
                });
        });

        // 충돌하는 모드 쌍 검사
        let conflictFound = false;
        checkedMods.forEach((mod1, index) => {
            for (let i = index + 1; i < checkedMods.length; i++) {
                const mod2 = checkedMods[i];
                // CompareModName 비교
                const compareResult = checkModConflict(mod1, mod2);
                if (compareResult) {
                    showNotificationModal(`'${mod1}'와(과) '${mod2}'는 함께 설치할 수 없습니다.`);
                    conflictFound = true;
                    return;
                }
            }
        });

        if (conflictFound) {
            return;
        }

        // 기존 다운로드 로직
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

    // CompareModName을 확인하는 함수 추가
    function checkModConflict(mod1Name, mod2Name) {
        // DownloadMetaData.json에서 모드 정보 찾기
        const findModInfo = (modName) => {
            return metaData.mods.find(mod => mod.name === modName);
        };

        const mod1Info = findModInfo(mod1Name);
        const mod2Info = findModInfo(mod2Name);

        if (!mod1Info || !mod2Info) return false;

        // CompareModName이 서로의 이름과 일치하는지 확인
        if (mod1Info.CompareModName === mod2Name || mod2Info.CompareModName === mod1Name) {
            return true;
        }

        return false;
    }

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
            let fileNames = []; // 다운로드할 파일 이름 배열
            const isTranslationMod = (modElement.closest('#translationGrid') !== null);
            const modName = modElement.querySelector('.mod-text').textContent.split(' ')[0]; // 모드 이름 추출
            const chosenPath = chosenPathSpan.textContent;
            const extractPath = (modName === "SVM") ? path.join(chosenPath, 'user', 'mods') : chosenPath;
            if (modName === "SVM" && !fs.existsSync(extractPath)) {
                fs.mkdirSync(extractPath, { recursive: true });
            }
            const statusIcon = modElement.querySelector('.mod-status i');
            statusIcon.textContent = 'hourglass_empty'; // 초기 상태: 대기

            // URL에서 파일명 추출 함수 (Content-Disposition 처리 포함) - 기존 함수 재사용
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

            // 파일명 추출 및 파일 다운로드 시도 (urlList 순회)
            function attemptDownloads(urlIndex) {
                if (urlIndex >= urlList.length) {
                    if (fileNames.length === 0) {
                        statusIcon.textContent = 'error'; // 모든 URL 실패
                        reject(new Error('모든 다운로드 URL 실패'));
                    } else {
                        // 모든 URL 시도 완료, 파일 다운로드 성공 (압축 해제 및 정리)
                        decompressAndClean(fileNames, extractPath, statusIcon, resolve, reject);
                    }
                    return;
                }

                let currentUrl = urlList[urlIndex].trim();
                let fileName = '';

                // 파일명 추출 로직 (기존 로직 재사용)
                try {
                    if (!fileName) {
                        let testUrl = currentUrl.trim();
                        if (testUrl.includes("drive.google.com")) {
                            const urlObj = new URL(testUrl);
                            fileName = urlObj.searchParams.get('id') || 'download';
                        } else {
                            fileName = decodeURIComponent(testUrl.split('/').pop());
                        }
                    }
                } catch (e) {
                    console.error("파일명 추출 실패:", e);
                    fileName = "download_" + urlIndex; // fallback 파일명
                }

                if (isTranslationMod && !fileName.toLowerCase().endsWith('.zip')) {
                    fileName = fileName.replace(/\.[^/.]+$/, '') + '.zip';
                }

                const filePath = path.join(chosenPath, fileName);
                const file = fs.createWriteStream(filePath);
                const finalUrl = currentUrl.includes("drive.google.com") ? convertGoogleDriveUrl(currentUrl) : currentUrl;


                downloadRequest(finalUrl, file, (response, err) => { // response 추가
                    if (err) {
                        try { fs.unlinkSync(filePath); } catch (e) { }
                        console.log(`URL ${currentUrl} 다운로드 실패, 다음 URL 시도`);
                        attemptDownloads(urlIndex + 1); // 다음 URL 시도
                    } else {
                        // Content-Disposition 처리 (파일명 추출 및 변경) - 기존 로직 재사용
                        const contentDispositionFilename = getFilenameFromContentDisposition(response.headers);
                        const finalFileName = contentDispositionFilename || fileName;
                        const finalFilePath = path.join(chosenPath, finalFileName);

                        if (contentDispositionFilename) {
                            fs.rename(filePath, finalFilePath, (renameErr) => {
                                if (renameErr) {
                                    console.error("파일명 변경 실패:", renameErr);
                                    fileNames.push(filePath); // 기존 파일 경로 추가 (파일명 변경 실패 시)
                                } else {
                                    fileNames.push(finalFilePath); // 변경된 파일 경로 추가
                                }
                                attemptDownloads(urlIndex + 1); // 다음 URL 시도 (성공/실패 관계없이)
                            });
                        } else {
                            fileNames.push(filePath); // 기존 파일 경로 추가
                            attemptDownloads(urlIndex + 1); // 다음 URL 시도 (성공/실패 관계없이)
                        }
                    }
                });
            }


            // 압축 해제 및 파일 정리 함수 (수정됨: 파일 경로 배열 처리, 삭제 시점 조정)
            function decompressAndClean(filePaths, extractPath, statusIcon, resolve, reject) {
                if (filePaths.length === 0) {
                    statusIcon.textContent = 'error';
                    reject(new Error('다운로드된 파일 없음'));
                    return;
                }

                let zipFilePaths = [];
                let sevenZipFilePaths = [];
                let nonArchiveFilePaths = [];

                // 파일 경로들을 압축 형식에 따라 분류
                filePaths.forEach(filePath => {
                    if (filePath.toLowerCase().endsWith('.zip')) {
                        zipFilePaths.push(filePath);
                    } else if (filePath.toLowerCase().endsWith('.7z')) {
                        sevenZipFilePaths.push(filePath);
                    } else {
                        nonArchiveFilePaths.push(filePath); // 압축 파일이 아닌 경우
                    }
                });

                let archiveFilePaths = [...zipFilePaths, ...sevenZipFilePaths]; // 압축 파일 경로 목록

                if (zipFilePaths.length > 0) {
                    try {
                        Promise.all(zipFilePaths.map(filePath => { // 모든 zip 파일 압축 해제 Promise.all 사용
                            return new Promise((res, rej) => {
                                const zip = new AdmZip(filePath);
                                zip.extractAllTo(extractPath, true);
                                res(); // 압축 해제 성공 resolve
                            });
                        })).then(() => {
                            // 모든 zip 파일 압축 해제 성공 후, 7z 압축 해제 처리
                            if (sevenZipFilePaths.length > 0) {
                                decompress7zAndClean(sevenZipFilePaths, extractPath, archiveFilePaths, nonArchiveFilePaths, statusIcon, resolve, reject); // 7z 압축 해제 함수 호출
                            } else {
                                // zip 파일만 있고, 7z 파일 없으면, 최종 정리 및 resolve
                                finalizeCleanUp(archiveFilePaths, nonArchiveFilePaths, statusIcon, resolve);
                            }
                        }).catch(err => {
                            statusIcon.textContent = 'error';
                            reject(err);
                        });
                    } catch (err) {
                        statusIcon.textContent = 'error';
                        reject(err);
                    }
                } else if (sevenZipFilePaths.length > 0) {
                    // zip 파일 없으면, 7z 압축 해제 처리
                    decompress7zAndClean(sevenZipFilePaths, extractPath, archiveFilePaths, nonArchiveFilePaths, statusIcon, resolve, reject);
                } else {
                    // 압축 파일 없는 경우, 바로 최종 정리 및 resolve
                    finalizeCleanUp(archiveFilePaths, nonArchiveFilePaths, statusIcon, resolve);
                }
            }


            // 7z 압축 해제 및 정리 함수 (별도 함수로 분리)
            function decompress7zAndClean(sevenZipFilePaths, extractPath, archiveFilePaths, nonArchiveFilePaths, statusIcon, resolve, reject) {
                // 7z 압축 해제 (첫 번째 7z 파일만 압축 해제 -> 모든 7z 파일 순차 압축 해제로 변경)
                Promise.all(sevenZipFilePaths.map(filePath => {
                    return new Promise((res, rej) => {
                        const sevenZip = spawn(sevenZipPath, ['x', filePath, `-o${extractPath}`, '-y']);
                        sevenZip.stdout.on('data', (data) => { console.log(data.toString()); });
                        sevenZip.stderr.on('data', (data) => { console.error(data.toString()); });
                        sevenZip.on('close', (code) => {
                            if (code === 0) {
                                res(); // 7z 압축 해제 성공 resolve
                            } else {
                                rej(new Error('7z 압축 해제 실패'));
                            }
                        });
                    });
                })).then(() => {
                    // 모든 7z 파일 압축 해제 성공 후, 최종 정리 및 resolve
                    finalizeCleanUp(archiveFilePaths, nonArchiveFilePaths, statusIcon, resolve);
                }).catch(err => {
                    statusIcon.textContent = 'error';
                    reject(err);
                });
            }


            // 최종 파일 정리 및 resolve 함수 (모든 압축 해제 완료 후 호출)
            function finalizeCleanUp(archiveFilePaths, nonArchiveFilePaths, statusIcon, resolve) {
                // 압축 해제된 압축 파일 삭제 (zip, 7z)
                archiveFilePaths.forEach(filePath => {
                    try { fs.unlinkSync(filePath); } catch (e) { console.error("압축 파일 삭제 실패:", filePath, e); }
                });
                statusIcon.textContent = 'check_circle';
                resolve(); // 최종 resolve 호출
            }


            // downloadRequest 함수 (기존 코드 재사용)
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

            attemptDownloads(0); // 첫 번째 URL부터 다운로드 시도 시작

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


    // 알림 모달 (기존과 동일)
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

    // 테마 설정 함수 (다크/라이트 모드 전환) - script.js 와 동일
    function setTheme(themeName) {
        const body = document.body;
        if (themeName === 'light') {
            body.classList.add('light-mode');
            body.classList.remove('dark-mode');
        } else {
            body.classList.remove('light-mode');
            body.classList.add('dark-mode');
        }
        localStorage.setItem('theme', themeName); // localStorage에 테마 설정 저장
        currentTheme = themeName; // 현재 테마 업데이트
    }

    // 설정 아이콘 업데이트 함수
    function updateSettingsIcon(themeName) {
        const settingsIcon = document.querySelector('#settings-btn .material-icons');
        if (themeName === 'light') {
            settingsIcon.textContent = 'light_mode'; // Light Mode 아이콘
        } else {
            settingsIcon.textContent = 'dark_mode'; // Dark Mode 아이콘 (동일 아이콘 유지 or 다르게 변경)
        }
    }

    // 설정 버튼 클릭 이벤트 리스너 (테마 전환) - script.js 와 동일
    const settingsBtn = document.getElementById('settings-btn');
    settingsBtn.addEventListener('click', () => {
        const newTheme = currentTheme === 'dark' ? 'light' : 'dark';
        setTheme(newTheme); // 테마 변경 함수 호출
        updateSettingsIcon(newTheme); // 아이콘 업데이트
    });


    // 새로고침 버튼 클릭 이벤트 리스너 (mod-download.js 용)
    const refreshBtn = document.getElementById('refresh-btn');
    refreshBtn.addEventListener('click', () => {
        showRefreshStatusMessage('새로고침 중...', null); // "새로고침 중..." 메시지 표시
        loadMetaData(); // 새로고침 시 파일 다시 로드
    });

    // ipcRenderer를 통해 main process로부터 programVersion 받기 (mod-download.js에도 추가)
    ipcRenderer.on('program-version', (event, version) => {
        document.getElementById('program-version').textContent = `프로그램 버전: ${version}`; // 푸터에 프로그램 버전 업데이트
    });

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
});