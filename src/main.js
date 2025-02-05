// main.js (수정된 전체 코드)
const { app, BrowserWindow, ipcMain, dialog } = require('electron');
const path = require('path');
const fs = require('fs'); // fs 모듈 추가

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

    app.on('activate', function () {
        if (BrowserWindow.getAllWindows().length === 0) createWindow();
    });
});

app.on('window-all-closed', function () {
    if (process.platform !== 'darwin') app.quit();
});