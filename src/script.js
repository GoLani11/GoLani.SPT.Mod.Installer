// script.js (최적화 및 아이콘 수정 완료 - 전체 코드)
const { ipcRenderer } = require('electron');

document.addEventListener('DOMContentLoaded', () => {
    let isFallbackActive = false;
    let currentTheme = localStorage.getItem('theme') || 'dark';
    let homeBannerMessage = '모드 간편 설치기가 새롭게 업데이트 되었습니다. 업데이트 내용은 아래에서 확인하세요. SPT 3.11 버전만 지원합니다.'; // 기본 메시지

    setTheme(currentTheme);
    updateSettingsIcon(currentTheme);

    function updateFooterVersions(programVersion, sptVersion) {
        document.getElementById('program-version').textContent = `프로그램 버전: ${programVersion}`;
        document.getElementById('spt-version').textContent = `SPT 게임 버전: ${sptVersion}`;
    }

    function showNotificationBannerMessage(message, type = 'default') {
        const banner = document.querySelector('.notification-banner');
        const bannerSpan = document.querySelector('.notification-banner span');
        bannerSpan.textContent = message;
        banner.style.display = 'flex';
        banner.classList.remove('fallback-mode', 'success-mode');
        if (type === 'fallback') banner.classList.add('fallback-mode');
    }

    function showRefreshStatusMessage(message, isSuccess) {
        const banner = document.querySelector('.refresh-status-banner');
        const bannerSpan = banner.querySelector('span');
        bannerSpan.textContent = message;
        banner.style.display = 'flex';
        banner.classList.remove('fallback-mode', 'success-mode');
        if (isSuccess === true) banner.classList.add('success-mode');
        else if (isSuccess === false) banner.classList.add('fallback-mode');
        setTimeout(() => {
            banner.style.display = 'none';
            banner.classList.remove('fallback-mode', 'success-mode');
        }, 3000);
    }

    function loadContentFromFiles() {
        isFallbackActive = false;
        updateNotificationBanner();
        showRefreshStatusMessage('새로고침 중...', null);

        const metaFilePath = '../config/DownloadMetaData.json';
        const hangeulLogPath = '../config/KR-Update-Log.txt';
        const patcherNoticePath = '../config/Notice.txt';
        const homeBannerPath = '../config/HomeBanner.txt'; // 새로운 배너 메시지 파일 경로

        const githubMetaUrl = 'https://raw.githubusercontent.com/GoLani11/GoLani.SPT.Mod.Installer/main/config/DownloadMetaData.json';
        const githubLogUrl = 'https://raw.githubusercontent.com/GoLani11/GoLani.SPT.Mod.Installer/main/config/KR-Update-Log.txt';
        const githubNoticeUrl = 'https://raw.githubusercontent.com/GoLani11/GoLani.SPT.Mod.Installer/main/config/Notice.txt';
        const githubBannerUrl = 'https://raw.githubusercontent.com/GoLani11/GoLani.SPT.Mod.Installer/main/config/HomeBanner.txt'; // 깃허브 배너 메시지 URL

        let githubLoadSuccess = true;

        // 배너 메시지 로드
        fetch(githubBannerUrl)
            .then(response => response.text())
            .then(text => {
                homeBannerMessage = text.trim();
                updateNotificationBanner();
            })
            .catch(error => {
                console.error('GitHub 배너 메시지 로드 실패, 로컬 파일 사용:', error);
                fetch(homeBannerPath)
                    .then(response => response.text())
                    .then(text => {
                        homeBannerMessage = text.trim();
                        updateNotificationBanner();
                    })
                    .catch(localError => {
                        console.error('로컬 배너 메시지 로드 실패, 기본 메시지 사용:', localError);
                        // 기본 메시지는 이미 설정되어 있음
                    });
            });

        fetch(githubMetaUrl)
            .then(response => response.json())
            .then(metaData => {
                githubLoadSuccess = true;
                updateFooterVersions(document.getElementById('program-version').textContent.split(': ')[1], metaData.SPTDefaultVersion);
                document.getElementById('hangeul-log-date').textContent = `(${metaData.home_page_notices.hangeul_log_date})`;
                document.getElementById('patcher-notice-date').textContent = `(${metaData.home_page_notices.patcher_notice_date})`;
                setCopyrightSection();
                showRefreshStatusMessage('새로고침 완료', true);
            })
            .catch(error => {
                githubLoadSuccess = false;
                isFallbackActive = true;
                updateNotificationBanner();
                console.error('GitHub 메타데이터 로드 실패, 로컬 파일 사용:', error);
                ipcRenderer.invoke('show-notification', '서버와 연결이 되지 않아 프로그램에 저장된 설정을 가져옵니다. 인터넷 연결을 확인해주세요.');
                fetch(metaFilePath)
                    .then(response => response.json())
                    .then(metaData => {
                        updateFooterVersions(document.getElementById('program-version').textContent.split(': ')[1], metaData.SPTDefaultVersion);
                        document.getElementById('hangeul-log-date').textContent = `(${metaData.home_page_notices.hangeul_log_date})`;
                        document.getElementById('patcher-notice-date').textContent = `(${metaData.home_page_notices.patcher_notice_date})`;
                        setCopyrightSection();
                        showRefreshStatusMessage('새로고침 완료 (로컬 설정 사용)', true);
                    })
                    .catch(localError => {
                        console.error('로컬 메타데이터 로드 실패:', localError);
                        showRefreshStatusMessage('새로고침 실패 (로컬 설정 로드 실패)', false);
                    });
            });

        fetch(githubLogUrl)
            .then(response => response.text())
            .then(text => loadTextContentFromText(text, 'hangeul-log-list'))
            .catch(error => {
                githubLoadSuccess = false;
                isFallbackActive = true;
                updateNotificationBanner();
                console.error('GitHub 업데이트 로그 로드 실패, 로컬 파일 사용:', error);
                ipcRenderer.invoke('show-notification', '서버와 연결이 되지 않아 프로그램에 저장된 설정을 가져옵니다. 인터넷 연결을 확인해주세요.');
                loadTextContent(hangeulLogPath, 'hangeul-log-list');
                showRefreshStatusMessage('새로고침 실패 (업데이트 로그)', false);
            });

        fetch(githubNoticeUrl)
            .then(response => response.text())
            .then(text => loadTextContentFromText(text, 'patcher-notice-list'))
            .catch(error => {
                githubLoadSuccess = false;
                isFallbackActive = true;
                updateNotificationBanner();
                console.error('GitHub 공지사항 로드 실패, 로컬 파일 사용:', error);
                ipcRenderer.invoke('show-notification', '서버와 연결이 되지 않아 프로그램에 저장된 설정을 가져옵니다. 인터넷 연결을 확인해주세요.');
                loadTextContent(patcherNoticePath, 'patcher-notice-list');
                showRefreshStatusMessage('새로고침 실패 (공지사항)', false);
            });

        if (!isFallbackActive) {
            Promise.all([
                fetch(githubMetaUrl).catch(() => null),
                fetch(githubLogUrl).catch(() => null),
                fetch(githubNoticeUrl).catch(() => null)
            ]).finally(() => {
                if (!githubLoadSuccess && !isFallbackActive) {
                    ipcRenderer.invoke('show-notification', '서버와 연결이 되지 않아 프로그램에 저장된 설정을 가져옵니다. 인터넷 연결을 확인해주세요.');
                    showRefreshStatusMessage('새로고침 실패 (전체 설정)', false);
                }
            });
        } else {
            updateNotificationBanner();
            showRefreshStatusMessage('새로고침 실패 (Fallback 모드)', false);
        }
    }

    function updateNotificationBanner() {
        const banner = document.querySelector('.notification-banner span');
        if (isFallbackActive) {
            banner.textContent = 'GitHub 설정 로드 실패. 로컬 설정 사용 중 (인터넷 연결 확인 요망).';
            showNotificationBannerMessage('GitHub 설정 로드 실패. 로컬 설정 사용 중 (인터넷 연결 확인 요망)', 'fallback');
            document.querySelector('.notification-banner').classList.add('fallback-mode');
            document.querySelector('.notification-banner').classList.remove('success-mode');
        } else {
            banner.textContent = '홈 페이지입니다.';
            showNotificationBannerMessage(homeBannerMessage); // 파일에서 로드한 메시지 사용
            document.querySelector('.notification-banner').classList.remove('fallback-mode', 'success-mode');
        }
        banner.style.display = 'flex';
    }

    function loadTextContentFromText(text, listId) {
        const list = document.getElementById(listId);
        list.innerHTML = '';
        text.split('\n').forEach(line => {
            const trimmedLine = line.trim();
            let listItem = document.createElement('li');
            listItem.textContent = trimmedLine;
            list.appendChild(listItem);
        });
    }

    function loadTextContent(filePath, listId) {
        fetch(filePath)
            .then(response => response.text())
            .then(text => loadTextContentFromText(text, listId))
            .catch(error => console.error('Error loading content file:', error));
    }

    function setCopyrightSection() {
        const copyrightSection = document.getElementById('copyright-section');
        const copyrightList = document.getElementById('copyright-list');
        copyrightList.innerHTML = '';

        const copyrightContent = `
            <p><strong>1. 원본 모드 출처:</strong></p>
            <p>본 모드 간편 설치기에 포함된 원본 모드들은 SPT 허브 및 기타 관련 사이트에서 제작 및 배포되었음을 명시합니다.
            각 모드의 구체적인 출처와 라이선스는 해당 모드의 문서를 참조하시기 바랍니다.</p>

            <p><strong>2. 한글화 저작권:</strong></p>
            <p>모든 한글화 작업은 '_고라니_(GoLani11)'에 의해 제작 및 수정되었습니다.</p>

            <p>본 모드 간편 설치기의 모드는 원본 제작자들의 지적 재산권을 존중합니다. 무단 복제, 배포, 수정은 엄격히 금지됩니다.</p>

            <div class="license-info">
                <p><strong>MIT License</strong></p>
                <p>Copyright (c) 2025 Golani11, _고라니_</p>
                <p>Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:</p>
                <p>The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.</p>
                <p>THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
                SOFTWARE.</p>
            </div>

            <p><strong>추가 제한 사항:</strong></p>
            <ul>
                <li>이 모드 간편 설치기의 무단 수정 및 재배포를 금지합니다.</li>
                <li>저작권자 이외에 상업적 목적으로 이 모드 간편 설치기의 사용을 금합니다.</li>
                <li>이 모드 간편 설치기의 소스코드를 수정 및 배포 시에는 원 저작자에게 사전 허락 후 사용하고, 수정하여 배포 시에는 배포 사이트 링크를 추가로 제공하고 원 저작자의 이름을 명시해야 합니다.</li>
            </ul>
        `;
        copyrightList.insertAdjacentHTML('beforeend', copyrightContent);

        const updateDateElement = copyrightSection.querySelector('.update-date');
        if (updateDateElement) updateDateElement.remove();
    }

    function setTheme(themeName) {
        const body = document.body;
        if (themeName === 'light') {
            body.classList.add('light-mode');
            body.classList.remove('dark-mode');
        } else {
            body.classList.remove('light-mode');
            body.classList.add('dark-mode');
        }
        localStorage.setItem('theme', themeName);
        currentTheme = themeName;
    }

    function updateSettingsIcon(themeName) {
        const settingsIcon = document.querySelector('#settings-btn .material-icons');
        if (themeName === 'light') {
            settingsIcon.textContent = 'light_mode';
        } else {
            settingsIcon.textContent = 'dark_mode';
        }
    }

    const settingsBtn = document.getElementById('settings-btn');
    settingsBtn.addEventListener('click', () => {
        const newTheme = currentTheme === 'dark' ? 'light' : 'dark';
        setTheme(newTheme);
        updateSettingsIcon(newTheme);
    });

    const refreshBtn = document.getElementById('refresh-btn');
    refreshBtn.addEventListener('click', () => {
        showRefreshStatusMessage('새로고침 중...', null);
        loadContentFromFiles();
    });

    loadContentFromFiles();

    const menuButtons = document.querySelectorAll('.menu-btn');
    menuButtons.forEach(btn => {
        btn.addEventListener('click', () => {
            menuButtons.forEach(b => b.classList.remove('active'));
            btn.classList.add('active');
            const page = btn.getAttribute('data-page');
            if (page === 'mod-download') {
                window.location.href = '../html/mod-download.html';
            } else {
                console.log(`페이지 전환: ${page}`);
            }
        });
    });

    const closeBanner = document.getElementById('close-banner');
    closeBanner.addEventListener('click', () => {
        document.querySelector('.notification-banner').style.display = 'none';
    });

    ipcRenderer.on('program-version', (event, version) => {
        updateFooterVersions(version, document.getElementById('spt-version').textContent.split(': ')[1]);
        document.getElementById('program-version').textContent = `프로그램 버전: ${version}`;
    });
});