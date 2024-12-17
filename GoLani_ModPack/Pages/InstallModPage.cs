using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using SharpCompress.Archives;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace GoLani_ModPack.Pages
{
    public partial class InstallModPage : UserControl
    {
        private const string MetadataUrl = "https://raw.githubusercontent.com/YourRepo/YourProject/main/meta.json";
        private List<MetadataMod> mods = new List<MetadataMod>(); // 메타데이터에서 로드된 모드 리스트
        private string installPath; // 설치 경로

        public InstallModPage()
        {
            InitializeComponent();
            this.Load += async (s, e) => await LoadMetadataAsync(); // 비동기적으로 메타데이터 로드
        }

        private async Task LoadMetadataAsync()
        {
            try
            {
                using HttpClient client = new HttpClient();
                string jsonContent = await client.GetStringAsync(MetadataUrl);

                // JSON 데이터를 Metadata 객체로 파싱
                Metadata metadata = JsonConvert.DeserializeObject<Metadata>(jsonContent);
                mods = metadata.Mods;

                // UI 업데이트
                UpdateUIWithMods(mods);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"메타데이터 로드 실패: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUIWithMods(List<MetadataMod> mods)
        {
            foreach (var mod in mods)
            {
                Console.WriteLine($"모드: {mod.Name}, 버전: {mod.Version}, 출처: {mod.SourceUrl}");
                // UI 연동 로직 추가 (예: 체크박스 활성화 및 초기화)
            }
        }

        private async void InstallBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(installPath))
            {
                MessageBox.Show("설치 경로를 먼저 선택해주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InstallBtn.Enabled = false;
            InstallLogBox.Text = "설치를 시작합니다...\r\n";

            foreach (var mod in mods.Where(m => m.KrVersion))
            {
                try
                {
                    InstallLogBox.Text += $"{mod.Name} 다운로드 및 설치 중...\r\n";

                    // 파일 다운로드
                    string archivePath = Path.Combine(installPath, $"{mod.Name}.zip");
                    await DownloadFileAsync(mod.DownloadUrls.First(), archivePath);

                    // 압축 해제
                    InstallLogBox.Text += $"{mod.Name} 압축 해제 중...\r\n";
                    using (var archive = ArchiveFactory.Open(archivePath))
                    {
                        foreach (var entry in archive.Entries.Where(e => !e.IsDirectory))
                        {
                            entry.WriteToDirectory(installPath, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                        }
                    }

                    File.Delete(archivePath); // 압축 파일 삭제
                    InstallLogBox.Text += $"{mod.Name} 설치 완료.\r\n";
                }
                catch (Exception ex)
                {
                    InstallLogBox.Text += $"{mod.Name} 설치 실패: {ex.Message}\r\n";
                }
            }

            InstallLogBox.Text += "모든 설치가 완료되었습니다.\r\n";
            MessageBox.Show("모드 설치가 완료되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

            InstallBtn.Enabled = true;
        }

        private async Task DownloadFileAsync(string url, string destinationPath)
        {
            using HttpClient client = new HttpClient();
            byte[] fileBytes = await client.GetByteArrayAsync(url);
            await File.WriteAllBytesAsync(destinationPath, fileBytes);
        }

        private void OpenSourceLink(string modName)
        {
            var mod = mods.FirstOrDefault(m => m.Name == modName);
            if (mod != null && !string.IsNullOrEmpty(mod.SourceUrl))
            {
                Process.Start(new ProcessStartInfo(mod.SourceUrl) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("출처 링크를 찾을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 경로 선택 버튼 클릭 이벤트
        private void LinkBtn_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                installPath = dialog.FileName;
                LinkBox.Text = $"SPT 모드 설치 경로: {installPath}";
            }
        }
    }

    // 메타데이터 클래스 정의
    public class Metadata
    {
        public List<MetadataMod> Mods { get; set; }
    }

    public class MetadataMod
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public List<string> DownloadUrls { get; set; }
        public bool KrVersion { get; set; }
        public string SourceUrl { get; set; }
    }
}
