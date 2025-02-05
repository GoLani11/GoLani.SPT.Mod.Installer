// script.js (수정된 전체 코드)
const { ipcRenderer } = require('electron'); // ipcRenderer 추가

document.addEventListener('DOMContentLoaded', () => {
    let isFallbackActive = false; // Fallback 모드 활성 여부 추적

    // 푸터 프로그램 버전 및 SPT 버전 업데이트
    function updateFooterVersions(programVersion, sptVersion) {
        document.getElementById('program-version').textContent = `프로그램 버전: ${programVersion}`;
        document.getElementById('spt-version').textContent = `SPT 게임 버전: ${sptVersion}`;
    }

    // config 파일 로드 및 내용 설정 함수
    function loadContentFromFiles() {
        isFallbackActive = false; // 리로드 시 Fallback 모드 초기화
        updateNotificationBanner(); // 배너 텍스트 업데이트 (초기화)

        const metaFilePath = '../config/DownloadMetaData.json'; // 기존 파일 경로 유지 (fallback)
        const hangeulLogPath = '../config/KR-Update-Log.txt'; // 기존 파일 경로 유지 (fallback)
        const patcherNoticePath = '../config/Notice.txt'; // 기존 파일 경로 유지 (fallback)

        // GitHub config 파일 경로 (동적 로딩)
        const githubMetaUrl = 'https://raw.githubusercontent.com/GoLani11/GoLani.SPT.Mod.Installer/main/config/DownloadMetaData.json';
        const githubLogUrl = 'https://raw.githubusercontent.com/GoLani11/GoLani.SPT.Mod.Installer/main/config/KR-Update-Log.txt';
        const githubNoticeUrl = 'https://raw.githubusercontent.com/GoLani11/GoLani.SPT.Mod.Installer/main/config/Notice.txt';

        let githubLoadSuccess = true; // GitHub 로딩 성공 여부 추적

        // GitHub에서 DownloadMetaData.json 로드 시도
        fetch(githubMetaUrl)
            .then(response => response.json())
            .then(metaData => {
                githubLoadSuccess = true;
                // GitHub 로딩 성공 시, 메타데이터 및 날짜 정보 업데이트
                updateFooterVersions(document.getElementById('program-version').textContent.split(': ')[1], metaData.SPTDefaultVersion);
                document.getElementById('hangeul-log-date').textContent = `(${metaData.home_page_notices.hangeul_log_date})`;
                document.getElementById('patcher-notice-date').textContent = `(${metaData.home_page_notices.patcher_notice_date})`;
                setCopyrightSection();
            })
            .catch(error => {
                githubLoadSuccess = false;
                isFallbackActive = true; // Fallback 모드 활성화
                updateNotificationBanner(); // 배너 텍스트 업데이트
                console.error('GitHub 메타데이터 로드 실패, 로컬 파일 사용:', error);
                ipcRenderer.invoke('show-notification', '서버와 연결이 되지 않아 프로그램에 저장된 설정을 가져옵니다. 인터넷 연결을 확인해주세요.'); // 알림 창 표시 (추가)
                // GitHub 로딩 실패 시, 로컬 파일 로드 (기존 방식 유지)
                fetch(metaFilePath)
                    .then(response => response.json())
                    .then(metaData => {
                        updateFooterVersions(document.getElementById('program-version').textContent.split(': ')[1], metaData.SPTDefaultVersion);
                        document.getElementById('hangeul-log-date').textContent = `(${metaData.home_page_notices.hangeul_log_date})`;
                        document.getElementById('patcher-notice-date').textContent = `(${metaData.home_page_notices.patcher_notice_date})`;
                        setCopyrightSection();
                    })
                    .catch(localError => console.error('로컬 메타데이터 로드 실패:', localError));
            });

        // GitHub에서 KR-Update-Log.txt 로드 시도
        fetch(githubLogUrl)
            .then(response => response.text())
            .then(text => loadTextContentFromText(text, 'hangeul-log-list'))
            .catch(error => {
                githubLoadSuccess = false;
                isFallbackActive = true; // Fallback 모드 활성화
                updateNotificationBanner(); // 배너 텍스트 업데이트
                console.error('GitHub 업데이트 로그 로드 실패, 로컬 파일 사용:', error);
                ipcRenderer.invoke('show-notification', '서버와 연결이 되지 않아 프로그램에 저장된 설정을 가져옵니다. 인터넷 연결을 확인해주세요.'); // 알림 창 표시 (추가)
                // GitHub 로딩 실패 시, 로컬 파일 로드 (기존 방식 유지)
                loadTextContent(hangeulLogPath, 'hangeul-log-list');
            });

        // GitHub에서 Notice.txt 로드 시도
        fetch(githubNoticeUrl)
            .then(response => response.text())
            .then(text => loadTextContentFromText(text, 'patcher-notice-list'))
            .catch(error => {
                githubLoadSuccess = false;
                isFallbackActive = true; // Fallback 모드 활성화
                updateNotificationBanner(); // 배너 텍스트 업데이트
                console.error('GitHub 공지사항 로드 실패, 로컬 파일 사용:', error);
                ipcRenderer.invoke('show-notification', '서버와 연결이 되지 않아 프로그램에 저장된 설정을 가져옵니다. 인터넷 연결을 확인해주세요.'); // 알림 창 표시 (추가)
                // GitHub 로딩 실패 시, 로컬 파일 로드 (기존 방식 유지)
                loadTextContent(patcherNoticePath, 'patcher-notice-list');
            });

        // 모든 GitHub 파일 로딩 시도 후 알림 표시 (최초 로딩 시에만)
        if (!isFallbackActive) { // Fallback 모드가 활성화되지 않았을 때만 (최초 로딩 성공 시에만)
            Promise.all([
                fetch(githubMetaUrl).catch(() => null), // Promise.reject를 null로 처리
                fetch(githubLogUrl).catch(() => null),
                fetch(githubNoticeUrl).catch(() => null)
            ]).finally(() => {
                if (!githubLoadSuccess && !isFallbackActive) { // Double check and prevent showing error if fallback already active
                    ipcRenderer.invoke('show-notification', '서버와 연결이 되지 않아 프로그램에 저장된 설정을 가져옵니다. 인터넷 연결을 확인해주세요.');
                }
            });
        } else {
            updateNotificationBanner(); // Fallback 활성화 시 배너 업데이트 (초기 로딩 실패 시)
        }
    }

    // 알림 배너 텍스트 업데이트 함수
    function updateNotificationBanner() {
        const banner = document.querySelector('.notification-banner span');
        if (isFallbackActive) {
            banner.textContent = 'GitHub 설정 로드 실패. 로컬 설정 사용 중 (인터넷 연결 확인 요망).';
            document.querySelector('.notification-banner').classList.add('fallback-mode'); // Fallback 모드 스타일 클래스 추가
        } else {
            banner.textContent = '홈 페이지입니다.'; // 기본 배너 텍스트
            document.querySelector('.notification-banner').classList.remove('fallback-mode'); // Fallback 모드 스타일 클래스 제거
        }
    }


    // 텍스트 내용을 직접 사용하여 content list 업데이트 (GitHub에서 로드)
    function loadTextContentFromText(text, listId) {
        const list = document.getElementById(listId);
        list.innerHTML = '';
        let moreContent = document.createElement('div');
        moreContent.className = 'more-content hidden';
        let isMoreContent = false;

        text.split('\n').forEach(line => {
            const trimmedLine = line.trim();
            if (trimmedLine === '----more----') {
                isMoreContent = true;
                return;
            }
            let listItem = document.createElement('li');
            listItem.textContent = trimmedLine;
            if (isMoreContent) {
                moreContent.appendChild(listItem);
            } else {
                list.appendChild(listItem);
            }
        });
        list.parentElement.appendChild(moreContent);
    }


    // 텍스트 파일 로드 및 내용 설정 함수 (기존 로컬 파일 로드 방식 유지)
    function loadTextContent(filePath, listId) {
        fetch(filePath)
            .then(response => response.text())
            .then(text => loadTextContentFromText(text, listId)) // 텍스트 로딩 후 loadTextContentFromText 함수 재사용
            .catch(error => console.error('Error loading content file:', error));
    }

    // 저작권 정보 섹션 내용 설정 함수 (수정됨: null 체크 추가)
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

        const updateDateElement = copyrightSection.querySelector('.update-date'); // updateDateElement 변수에 할당
        if (updateDateElement) { // null check 추가
            updateDateElement.remove();
        }
    }

    loadContentFromFiles(); // 최초 실행 시 파일 로드

    const toggleBtns = document.querySelectorAll('.toggle-btn');
    toggleBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            const section = btn.parentElement;
            const list = section.querySelector('.content-list');
            const moreContent = section.querySelector('.more-content');
            const expanded = list.getAttribute('data-expanded') === 'true';
            if (!expanded) {
                moreContent.classList.remove('hidden');
                btn.textContent = '접기';
                list.setAttribute('data-expanded', 'true');
            } else {
                moreContent.classList.add('hidden');
                btn.textContent = '더보기';
                list.setAttribute('data-expanded', 'false');
            }
        });
    });

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

    const settingsBtn = document.getElementById('settings-btn');
    settingsBtn.addEventListener('click', () => {
        console.log('설정 버튼 클릭됨');
        // 설정 메뉴 열기 또는 설정 페이지로 이동 (추후 구현)
    });

    // 새로고침 버튼 클릭 이벤트 리스너
    const refreshBtn = document.getElementById('refresh-btn');
    refreshBtn.addEventListener('click', () => {
        loadContentFromFiles(); // 새로고침 시 파일 다시 로드
    });


    // ipcRenderer를 통해 main process로부터 programVersion 받기
    ipcRenderer.on('program-version', (event, version) => {
        updateFooterVersions(version, document.getElementById('spt-version').textContent.split(': ')[1]); // SPT 버전은 기존 방식 유지
        document.getElementById('program-version').textContent = `프로그램 버전: ${version}`; // 푸터에 프로그램 버전 업데이트
    });
});