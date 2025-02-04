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
        private const string LocalExePath = "GoLaniModPack.exe"; // ���� exe ���� ���
        private const string MetadataUrl = "https://raw.githubusercontent.com/GoLani11/GoLani_ModPack/main/GoLani_ModPack/DownloadMetaData/DownloadMetaData.json"; // ��Ÿ������ URL

        public MainForm()
        {
            InitializeComponent();

            pages = new UserControl[] { new HomePage(), new ModInfomationPage(), new InstallModPage(), new DeleteModPage(), };
        }

        public class Metadata
        {
            [JsonProperty("SPTDefaultVersion")] // JSON �Ӽ� �̸��� ����
            public string SPTDefaultVersion { get; set; }
        }

        private async void StartLoadForm(object sender, EventArgs e)
        {
            // ���� ����� ���� ���
            string localVersion = GetLocalProjectVersion();
            VersionLabel.Text = $"���� ��ġ�� ����: {localVersion}";

            // ���� SPT ���� ���
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(MetadataUrl);
                    Metadata metadata = JsonConvert.DeserializeObject<Metadata>(json);
                    SPTVersionlabel.Text = $"���� SPT ����: {metadata?.SPTDefaultVersion}";
                }
            }
            catch (HttpRequestException ex)
            {
                SPTVersionlabel.Text = $"SPT ���� ���� �ε� ����: ��Ʈ��ũ ���� - {ex.Message}";
            }
            catch (JsonException ex)
            {
                SPTVersionlabel.Text = $"SPT ���� ���� �ε� ����: JSON �Ľ� ���� - {ex.Message}";
            }
            catch (Exception ex)
            {
                SPTVersionlabel.Text = $"SPT ���� ���� �ε� ����: �� �� ���� ���� - {ex.Message}";
            }

            // �ֽ� ���� Ȯ�� �� ������Ʈ �޽���
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
                        Text = "�ֽ� �������� ������Ʈ�Ǿ����ϴ�.\n\n �ֽ� �������� �ٿ�ε带 �������ּ���.",
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("���� ���", 30),
                        ForeColor = Color.Red
                    };
                    MainPanel.Controls.Add(updateLabel);

                    var result = MessageBox.Show(
                        $"���ο� ����({latestVersion})�� �ֽ��ϴ�. �ٿ�ε��Ͻðڽ��ϱ�?",
                        "������Ʈ Ȯ��",
                        MessageBoxButtons.YesNo
                    );

                    if (result == DialogResult.Yes)
                    {
                        string destinationFolder = GetDownloadFolder();
                        if (string.IsNullOrEmpty(destinationFolder))
                        {
                            MessageBox.Show("��ΰ� ���õ��� �ʾҽ��ϴ�. �ٿ�ε带 ����մϴ�.", "���");
                            return;
                        }

                        // ���� ���� ��� ����
                        string archivePath = Path.Combine(destinationFolder, $"GoLaniModPack_{latestVersion}.7z");

                        // �ֽ� ���� �ٿ�ε�
                        await DownloadFileAsync(GitHubExeUrl, archivePath);

                        // ���� ���� �� ����
                        await ExtractAndDeleteArchiveAsync(archivePath, destinationFolder);
                    }
                }
                else
                {
                    MessageBox.Show("���� �ѱ�ȭ �����ġ�⿡ ���� ���� ȯ���մϴ�.\n���� �ֽ� ������ ��� �� �Դϴ�.", "");
                    MainPanel.Controls.Clear();
                    MainPanel.Controls.Add(pages[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"���� �߻�: {ex.Message}", "����");
            }
        }

        private string GetDownloadFolder()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "�ٿ�ε� ��θ� �����ϼ���.";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    return folderDialog.SelectedPath;
                }
            }

            return null; // ����ڰ� ����� ���
        }

        // ���� ���� ����
        private async Task ExtractAndDeleteArchiveAsync(string archivePath, string destinationFolder)
        {
            try
            {
                // ���� ���� ����
                using (var archive = ArchiveFactory.Open(archivePath))
                {
                    // ���� ������ ��� �׸��� ������ ������ ����
                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                        {
                            await Task.Run(() =>
                            {
                                entry.WriteToDirectory(destinationFolder, new ExtractionOptions
                                {
                                    ExtractFullPath = true,
                                    Overwrite = true // �̹� ������ ���� ��� �����
                                });
                            });
                        }
                    }
                }

                // ���� ���� ����
                if (File.Exists(archivePath))
                {
                    File.Delete(archivePath);
                    MessageBox.Show("�ֽ� �������� �����Ͻ� ��ο� �ٿ�ε� �Ǿ����ϴ�.\n�ֽ� ������ ������ּ���.", "�Ϸ�");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"���� ���� �� ���� �߻�: {ex.Message}", "����");
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
            // ����� ���� ��������
            Version version = typeof(MainForm).Assembly.GetName().Version ?? new Version(0, 0, 0, 0);

            // ������ ���ڰ� 0�� ��� ����
            if (version.Revision == 0)
            {
                if (version.Build == 0)
                {
                    // Build�� Revision�� ��� 0�̸� Major.Minor�� ��ȯ
                    return $"{version.Major}.{version.Minor}";
                }
                else
                {
                    // Revision�� 0�̸� Major.Minor.Build�� ��ȯ
                    return $"{version.Major}.{version.Minor}.{version.Build}";
                }
            }

            // ��� �� ����
            return version.ToString();
        }

        private async Task<string> GetLatestVersionFromGitHubAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("request");

                // GitHub API�� JSON ���� �ޱ�
                string json = await client.GetStringAsync(GitHubLatestApiUrl);

                // JSON���� "tag_name" ����
                dynamic release = JsonConvert.DeserializeObject(json);
                string latestVersion = release.tag_name;

                if (string.IsNullOrEmpty(latestVersion))
                {
                    throw new Exception("�ֽ� ������ ������ �� �����ϴ�.\n ���ͳ� ������ Ȯ�����ּ���.");
                }

                return latestVersion.TrimStart('v'); // 'v1.0.0' ���¿��� 'v' ����
            }
        }

        private bool IsNewerVersion(string latestVersion, string localVersion)
        {
            // ���� ���ڿ��� �� (v1.2.3 ����)
            Version latest = new Version(latestVersion);
            Version local = new Version(localVersion);
            return latest.CompareTo(local) > 0;
        }

        private async Task DownloadFileAsync(string url, string destinationPath)
        {
            using (HttpClient client = new HttpClient())
            {
                // HTTP ��û �� ��Ʈ�� ó��
                using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();

                    var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                    var canReportProgress = totalBytes != -1;

                    // ProgressBar �ʱ�ȭ
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
                            // ������ ����
                            await fileStream.WriteAsync(buffer, 0, read);
                            totalRead += read;

                            // ProgressBar ������Ʈ
                            if (canReportProgress)
                            {
                                int progress = (int)((totalRead * 100) / totalBytes);
                                downloadProgressBar.Value = progress;
                            }
                        }
                    }

                    downloadProgressBar.Visible = false; // �ٿ�ε� �Ϸ� �� ����
                }
            }
        }
    }
}