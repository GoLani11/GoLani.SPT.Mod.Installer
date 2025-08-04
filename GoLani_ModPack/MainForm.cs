using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using SharpCompress.Archives;
using SharpCompress.Common;
using GoLani_ModPack.Pages;
using static GoLani_ModPack.MainForm;

namespace GoLani_ModPack
{
    public partial class MainForm : Form
    {
        private UserControl[] pages;

        private const string GitHubExeUrl = "https://github.com/GoLani11/GoLani_ModPack/releases/latest/download/GoLani_ModPack.7z";
        private const string GitHubLatestApiUrl = "https://api.github.com/repos/GoLani11/GoLani_ModPack/releases/latest";
        private const string LocalExePath = "GoLaniModPack.exe"; // 로컬 exe 파일 경로
        private const string MetadataUrl = "https://raw.githubusercontent.com/GoLani11/GoLani_ModPack/main/GoLani_ModPack/DownloadMetaData/DownloadMetaData.json"; // 메타데이터 URL

        public MainForm()
        {
            InitializeComponent();

            pages = new UserControl[] { new HomePage(), new ModInfomationPage(), new InstallModPage(), new DeleteModPage(), };
        }

        public class Metadata
        {
            [JsonProperty("SPTDefaultVersion")] // JSON 속성 이름과 매핑
            public string SPTDefaultVersion { get; set; }
        }

        private async void StartLoadForm(object sender, EventArgs e)
        {
            // 현재 모드팩 버전 출력
            string localVersion = GetLocalProjectVersion();
            VersionLabel.Text = $"현재 패치기 버전: {localVersion}";

            // 현재 SPT 버전 출력
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(MetadataUrl);
                    Metadata metadata = JsonConvert.DeserializeObject<Metadata>(json);
                    SPTVersionlabel.Text = $"현재 SPT 버전: {metadata?.SPTDefaultVersion}";
                }
            }
            catch (HttpRequestException ex)
            {
                SPTVersionlabel.Text = $"SPT 버전 정보 로드 실패: 네트워크 오류 - {ex.Message}";
            }
            catch (JsonException ex)
            {
                SPTVersionlabel.Text = $"SPT 버전 정보 로드 실패: JSON 파싱 오류 - {ex.Message}";
            }
            catch (Exception ex)
            {
                SPTVersionlabel.Text = $"SPT 버전 정보 로드 실패: 알 수 없는 오류 - {ex.Message}";
            }

            // 최신 버전 확인 및 업데이트 메시지
            await CheckAndPromptForUpdateAsync();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(pages[0]);
        }

        private void ModInfoBtn_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(pages[1]);
        }

        private void InstallBtn_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(pages[2]);
        }

        private void DeleteModBtn_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(pages[3]);
        }

        private async Task CheckAndPromptForUpdateAsync()
        {
            try
            {
                string localVersion = GetLocalProjectVersion();
                string latestVersion = await GetLatestVersionFromGitHubAsync();

                if (IsNewerVersion(latestVersion, localVersion))
                {
                    DisableButtons();
                    MainPanel.Controls.Clear();
                    Label updateLabel = new Label
                    {
                        Text = "최신 버전으로 업데이트되었습니다.\n\n 최신 버전으로 다운로드를 진행해주세요.",
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("맑은 고딕", 30),
                        ForeColor = Color.Red
                    };
                    MainPanel.Controls.Add(updateLabel);

                    var result = MessageBox.Show(
                        $"새로운 버전({latestVersion})이 있습니다. 다운로드하시겠습니까?",
                        "업데이트 확인",
                        MessageBoxButtons.YesNo
                    );

                    if (result == DialogResult.Yes)
                    {
                        string destinationFolder = GetDownloadFolder();
                        if (string.IsNullOrEmpty(destinationFolder))
                        {
                            MessageBox.Show("경로가 선택되지 않았습니다. 다운로드를 취소합니다.", "취소");
                            return;
                        }

                        // 압축 파일 경로 설정
                        string archivePath = Path.Combine(destinationFolder, $"GoLaniModPack_{latestVersion}.7z");

                        // 최신 파일 다운로드
                        await DownloadFileAsync(GitHubExeUrl, archivePath);

                        // 압축 해제 및 삭제
                        await ExtractAndDeleteArchiveAsync(archivePath, destinationFolder);
                    }
                }
                else
                {
                    MessageBox.Show("고라니 한글화 모드패치기에 오신 것을 환영합니다.\n현재 최신 버전을 사용 중 입니다.", "");
                    MainPanel.Controls.Clear();
                    MainPanel.Controls.Add(pages[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}", "오류");
            }
        }

        private string GetDownloadFolder()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "다운로드 경로를 선택하세요.";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    return folderDialog.SelectedPath;
                }
            }

            return null; // 사용자가 취소한 경우
        }

        // 압축 파일 해제
        private async Task ExtractAndDeleteArchiveAsync(string archivePath, string destinationFolder)
        {
            try
            {
                // 압축 파일 열기
                using (var archive = ArchiveFactory.Open(archivePath))
                {
                    // 압축 파일의 모든 항목을 지정된 폴더에 해제
                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                        {
                            await Task.Run(() =>
                            {
                                entry.WriteToDirectory(destinationFolder, new ExtractionOptions
                                {
                                    ExtractFullPath = true,
                                    Overwrite = true // 이미 파일이 있을 경우 덮어쓰기
                                });
                            });
                        }
                    }
                }

                // 압축 파일 삭제
                if (File.Exists(archivePath))
                {
                    File.Delete(archivePath);
                    MessageBox.Show("최신 버전으로 지정하신 경로에 다운로드 되었습니다.\n최신 버전을 사용해주세요.", "완료");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"압축 해제 중 오류 발생: {ex.Message}", "오류");
            }
        }

        private void DisableButtons()
        {
            HomeBtn.Enabled = false;
            ModInfoBtn.Enabled = false;
            InstallBtn.Enabled = false;
            DeleteModBtn.Enabled = false;
        }

        private string GetLocalProjectVersion()
        {
            // 어셈블리 버전 가져오기
            Version version = typeof(MainForm).Assembly.GetName().Version ?? new Version(0, 0, 0, 0);

            // 마지막 숫자가 0인 경우 제외
            if (version.Revision == 0)
            {
                if (version.Build == 0)
                {
                    // Build와 Revision이 모두 0이면 Major.Minor만 반환
                    return $"{version.Major}.{version.Minor}";
                }
                else
                {
                    // Revision만 0이면 Major.Minor.Build만 반환
                    return $"{version.Major}.{version.Minor}.{version.Build}";
                }
            }

            // 모든 값 포함
            return version.ToString();
        }

        private async Task<string> GetLatestVersionFromGitHubAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("request");

                // GitHub API로 JSON 응답 받기
                string json = await client.GetStringAsync(GitHubLatestApiUrl);

                // JSON에서 "tag_name" 추출
                dynamic release = JsonConvert.DeserializeObject(json);
                string latestVersion = release.tag_name;

                if (string.IsNullOrEmpty(latestVersion))
                {
                    throw new Exception("최신 버전을 가져올 수 없습니다.\n 인터넷 연결을 확인해주세요.");
                }

                return latestVersion.TrimStart('v'); // 'v1.0.0' 형태에서 'v' 제거
            }
        }

        private bool IsNewerVersion(string latestVersion, string localVersion)
        {
            // 버전 문자열을 비교 (v1.2.3 형식)
            Version latest = new Version(latestVersion);
            Version local = new Version(localVersion);
            return latest.CompareTo(local) > 0;
        }

        private async Task DownloadFileAsync(string url, string destinationPath)
        {
            using (HttpClient client = new HttpClient())
            {
                // HTTP 요청 및 스트림 처리
                using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();

                    var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                    var canReportProgress = totalBytes != -1;

                    // ProgressBar 초기화
                    downloadProgressBar.Visible = true;
                    downloadProgressBar.Value = 0;

                    using (var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    using (var httpStream = await response.Content.ReadAsStreamAsync())
                    {
                        var buffer = new byte[8192];
                        long totalRead = 0;
                        int read;

                        while ((read = await httpStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            // 데이터 쓰기
                            await fileStream.WriteAsync(buffer, 0, read);
                            totalRead += read;

                            // ProgressBar 업데이트
                            if (canReportProgress)
                            {
                                int progress = (int)((totalRead * 100) / totalBytes);
                                downloadProgressBar.Value = progress;
                            }
                        }
                    }

                    downloadProgressBar.Visible = false; // 다운로드 완료 후 숨김
                }
            }
        }
    }
}