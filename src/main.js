// main.js (수정된 전체 코드)
const { app, BrowserWindow, ipcMain, dialog } = require('electron');
const path = require('path');
const fs = require('fs'); // fs 모듈 추가
const https = require('https');
const semver = require('semver'); // semver 라이브러리 추가

async function checkForUpdates() {
    const currentVersion = app.getVersion(); // package.json 버전 사용
    const repoOwner = 'GoLani11';
    const repoName = 'GoLani.SPT.Mod.Installer';

    try {
        const apiUrl = `https://api.github.com/repos/${repoOwner}/${repoName}/releases/latest`;
        const response = await fetch(apiUrl);
        if (!response.ok) {
            console.error(`GitHub API error: ${response.status} ${response.statusText}`);
            return; // API 요청 실패 시 종료 (알림은 선택 사항)
        }
        const releaseInfo = await response.json();
        const latestVersionTag = releaseInfo.tag_name;
        // 버전 태그가 'v1.0.1' 형식일 경우 semver.clean 필요 (v 제거)
        const latestVersion = semver.clean(latestVersionTag);

        if (latestVersion && semver.gt(latestVersion, currentVersion)) {
            const updateCheckResult = await dialog.showMessageBox({
                type: 'info',
                title: '업데이트 확인',
                message: `최신 버전 ${latestVersion}이 있습니다. 다운로드 하시겠습니까? (현재 버전: ${currentVersion})`,
                buttons: ['예', '아니오']
            });

            if (updateCheckResult.response === 0) { // "예" 버튼 클릭
                // assets 배열이 비어있거나, 첫 번째 asset에 browser_download_url이 없는 경우에 대한 안전 장치 추가
                if (releaseInfo.assets && releaseInfo.assets.length > 0 && releaseInfo.assets[0].browser_download_url) {
                    const downloadUrl = releaseInfo.assets[0].browser_download_url; // 첫 번째 asset 다운로드 URL (확장자 및 파일명 확인 필요)
                    const saveResult = await dialog.showSaveDialog({
                        defaultPath: path.join(app.getPath('downloads'), `GoLani_ModPack_v${latestVersion}.7z`), // 기본 파일명 및 경로 제안
                        filters: [{ name: '7z 압축 파일', extensions: ['7z'] }]
                    });

                    if (!saveResult.canceled && saveResult.filePath) {
                        const downloadPath = saveResult.filePath;
                        await downloadFile(downloadUrl, downloadPath, latestVersion); // 다운로드 함수 호출
                    }
                } else {
                    dialog.showMessageBox({
                        type: 'warning',
                        title: '다운로드 URL 오류',
                        message: '최신 버전의 다운로드 URL을 찾을 수 없습니다. GitHub Releases 페이지를 확인해주세요.'
                    });
                }
            }
        } /*else {
            dialog.showMessageBox({
                type: 'info',
                title: '최신 버전',
                message: '현재 최신 버전을 사용 중입니다.'
            });
        }*/

    } catch (error) {
        console.error('자동 업데이트 확인 실패:', error);
        dialog.showMessageBox({
            type: 'error',
            title: '업데이트 확인 실패',
            message: '업데이트 확인 중 오류가 발생했습니다. 인터넷 연결을 확인하거나 나중에 다시 시도해주세요.'
        });
    }
}

async function downloadFile(downloadUrl, downloadPath, latestVersion) {
    try {
        const file = fs.createWriteStream(downloadPath);
        const response = await fetch(downloadUrl);

        if (!response.ok) {
            throw new Error(`Failed to download file: ${response.status} ${response.statusText}`);
        }

        // response.body가 null이 아닌지 확인
        if (response.body) {
            await pipeline(response.body, file); // 파이프라인 사용
        } else {
            throw new Error('Response body is null');
        }


        dialog.showMessageBox({
            type: 'info',
            title: '다운로드 완료',
            message: `최신 버전 ${latestVersion} 다운로드 완료: ${downloadPath}\n\n프로그램을 종료하고, 다운로드 받은 파일로 수동으로 업데이트를 진행해주세요.`
        });

    } catch (error) {
        console.error('파일 다운로드 실패:', error);
        dialog.showMessageBox({
            type: 'error',
            title: '다운로드 실패',
            message: `최신 버전 다운로드에 실패했습니다: ${error.message}`
        });
    }
}

// Node.js 16 이하 버전 호환을 위한 pipeline (최신 버전에서는 내장 pipeline 사용 가능)
const { promisify } = require('util');
const pipeline = promisify(require('stream').pipeline);


function createWindow() {
    const win = new BrowserWindow({
        width: 1200,
        height: 800,
        webPreferences: {
            preload: path.join(__dirname, 'preload.js'),
            nodeIntegration: true,
            contextIsolation: false
        }
    });

    win.loadFile(path.join(__dirname, '..', 'html', 'index.html'));
    win.webContents.openDevTools();

    // package.json 파일 읽기
    fs.readFile(path.join(__dirname, '..', 'package.json'), 'utf8', (err, data) => {
        if (err) {
            console.error("package.json 파일 로드 실패:", err);
            return;
        }
        try {
            const packageData = JSON.parse(data);
            const programVersion = packageData.version;

            // 렌더러 프로세스에 프로그램 버전 정보 전달 (webContents.on('did-finish-load') 사용)
            win.webContents.on('did-finish-load', () => {
                win.webContents.send('program-version', programVersion);
            });

        } catch (e) {
            console.error("package.json 파싱 오류:", e);
        }
    });

    // 앱 시작 시 자동 업데이트 체크 (선택 사항: 사용자 경험 고려)
    checkForUpdates(); // 프로그램 시작 시 업데이트 확인
}

app.whenReady().then(() => {
    createWindow();

    ipcMain.handle('select-directory', async () => {
        const result = await dialog.showOpenDialog({
            properties: ['openDirectory']
        });
        return result;
    });

    // 알림 메시지 표시 핸들러 추가
    ipcMain.handle('show-notification', async (event, message) => {
        await dialog.showMessageBox({
            type: 'warning', // 경고 아이콘 표시
            title: '네트워크 연결 오류',
            message: message,
            buttons: ['확인']
        });
    });

    ipcMain.handle('check-for-update', async () => { // 렌더러 프로세스에서 업데이트 확인 요청을 처리하기 위한 ipcMain 핸들러 (선택 사항)
        checkForUpdates();
    });

    app.on('activate', function () {
        if (BrowserWindow.getAllWindows().length === 0) createWindow();
    });
});

app.on('window-all-closed', function () {
    if (process.platform !== 'darwin') app.quit();
});