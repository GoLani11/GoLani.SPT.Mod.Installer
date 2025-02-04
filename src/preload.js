const path = require('path');
const { BrowserWindow } = require('electron');

function createWindow() {
    const win = new BrowserWindow({
        width: 1200,
        height: 800,
        webPreferences: {
            preload: path.join(__dirname, 'preload.js'), // __dirname이 src 폴더 내라면
            nodeIntegration: true,
            contextIsolation: false
        }
    });
    win.loadFile(path.join(__dirname, '..', 'html', 'index.html')); // html 폴더 경로 수정
    win.webContents.openDevTools();
}