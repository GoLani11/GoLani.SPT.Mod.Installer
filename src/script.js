document.addEventListener('DOMContentLoaded', () => {
    // 푸터 프로그램 버전 및 SPT 버전 업데이트
    function updateFooterVersions(programVersion, sptVersion) {
        document.getElementById('program-version').textContent = `프로그램 버전: ${programVersion}`;
        document.getElementById('spt-version').textContent = `SPT 게임 버전: ${sptVersion}`;
    }

    // config 파일 로드 및 내용 설정 함수
    function loadContentFromFiles() {
        const metaFilePath = '../config/DownloadMetaData.json';
        const hangeulLogPath = '../config/KR-Update-Log.txt';
        const patcherNoticePath = '../config/Notice.txt';

        fetch(metaFilePath)
            .then(response => response.json())
            .then(metaData => {
                updateFooterVersions(metaData.programVersion, metaData.SPTDefaultVersion);
                document.getElementById('hangeul-log-date').textContent = `(${metaData.home_page_notices.hangeul_log_date})`;
                document.getElementById('patcher-notice-date').textContent = `(${metaData.home_page_notices.patcher_notice_date})`;
                // copyright 섹션 내용 직접 설정 (파일 로드 대신)
                setCopyrightSection();
            })
            .catch(error => console.error('Error loading meta data:', error));

        loadTextContent(hangeulLogPath, 'hangeul-log-list');
        loadTextContent(patcherNoticePath, 'patcher-notice-list');
    }

    function loadTextContent(filePath, listId) {
        fetch(filePath)
            .then(response => response.text())
            .then(text => {
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
            })
            .catch(error => console.error('Error loading content file:', error));
    }

    // 저작권 정보 섹션 내용 설정 함수
    function setCopyrightSection() {
        const copyrightSection = document.getElementById('copyright-section');
        const copyrightList = document.getElementById('copyright-list');
        copyrightList.innerHTML = ''; // ul 비우기

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
        copyrightList.insertAdjacentHTML('beforeend', copyrightContent); // ul 내부에 HTML 삽입
        copyrightSection.querySelector('.update-date').remove(); // 업데이트 날짜 span 제거
        // copyrightSection.querySelector('.toggle-btn').remove(); // 더보기 버튼 제거 (내용 펼침/숨김 불필요) <- 제거
    }


    loadContentFromFiles();

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
    });
});