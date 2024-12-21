using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using SharpCompress.Archives;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoLani_ModPack.Pages
{
    public partial class InstallModPage : UserControl
    {
        private const string MetadataUrl = "https://raw.githubusercontent.com/GoLani11/GoLani_ModPack/main/GoLani_ModPack/DownloadMetaData/DownloadMetaData.json";
        private List<MetadataMod> mods = new List<MetadataMod>();
        private string installPath;
        private const string KrSuffix = " - KR";
        private const string VersionSeparator = " - ";

        public InstallModPage()
        {
            InitializeComponent();
            this.Load += async (s, e) => await LoadMetadataAsync();
            LinkButtonsInitialize();
        }

        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                foreach (var child in GetAllControls(c))
                    yield return child;
                yield return c;
            }
        }

        private async Task LoadMetadataAsync()
        {
            using HttpClient client = new HttpClient();
            string jsonContent = await client.GetStringAsync(MetadataUrl);

            Metadata metadata = JsonConvert.DeserializeObject<Metadata>(jsonContent);
            if (metadata?.Mods != null)
            {
                foreach (var mod in metadata.Mods)
                {
                    mod.SPTDefaultVersion = metadata.SPTDefaultVersion;
                }

                mods = metadata.Mods;

                foreach (var mod in mods)
                {
                    UpdateLinkTextWithVersion(mod);
                }

                foreach (var mod in mods)
                {
                    UpdateCheckBoxState(mod);
                }
            }
            else
            {
                MessageBox.Show("메타데이터 구조가 올바르지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCheckBoxState(MetadataMod mod)
        {
            bool enabled = true;
            string disableReason = "";

            if (!string.IsNullOrEmpty(mod.SPTVersion) &&
                !string.IsNullOrEmpty(mod.SPTDefaultVersion) &&
                mod.SPTVersion != mod.SPTDefaultVersion)
            {
                enabled = false;
            }
            else
            {
                if (mod.KrVersion)
                {
                    var originalMod = mods.FirstOrDefault(m => m.Name == mod.Name.Replace(KrSuffix, ""));
                    if (originalMod == null)
                    {
                        enabled = false;
                    }
                    else if (Version.TryParse(originalMod.Version, out Version originalVersion) &&
                             Version.TryParse(mod.Version, out Version krVersion) &&
                             originalVersion > krVersion)
                    {
                        enabled = false;
                    }
                }
                else
                {
                    var krMod = mods.FirstOrDefault(m => m.Name == mod.Name + KrSuffix);
                    if (krMod != null &&
                        Version.TryParse(mod.Version, out Version originalVersion) &&
                        Version.TryParse(krMod.Version, out Version krVersion) &&
                        krVersion > originalVersion)
                    {
                        enabled = false;
                    }
                }
            }

            var allCheckBoxes = GetAllControls(this).OfType<CheckBox>();
            CheckBox targetCheckBox = allCheckBoxes.FirstOrDefault(cb => cb.Tag as string == mod.Name);
            if (targetCheckBox != null)
            {
                targetCheckBox.Enabled = enabled;
                UpdateCheckBoxText(targetCheckBox, GetBaseTextFromCheckBox(targetCheckBox), disableReason);
            }
        }

        private string GetBaseTextFromCheckBox(CheckBox checkBox)
        {
            int startIndex = checkBox.Text.IndexOf(" (");
            return startIndex > 0 ? checkBox.Text.Substring(0, startIndex) : checkBox.Text;
        }

        private void UpdateCheckBoxText(CheckBox checkBox, string baseText, string suffix)
        {
            checkBox.Text = string.IsNullOrEmpty(suffix) ? baseText : $"{baseText} ({suffix})";
        }

        private void UpdateLinkTextWithVersion(MetadataMod mod)
        {
            string versionText = VersionSeparator + mod.Version;
            Action<LinkLabel, CheckBox> updateControl = (link, box) =>
            {
                link.Text += versionText;
                link.Tag = mod.Name;
                box.Tag = mod.Name;
            };

            switch (mod.Name)
            {
                case "SPT 타르코프 한글화 프로젝트": updateControl(SPTKRlink, SPTKRBox); break;
                case "타르코프 로고 한글화": updateControl(LogoKRlink, SPTLogoKRBox); break;
                case "SPT 타르코프 아이템 텍스처 한글화 프로젝트 - 기본":
                    TextureKRlink.Text += "\n"+versionText;
                    SPTTexDefaultBox.Tag = mod.Name;
                    break;
                case "SPT 타르코프 아이템 텍스처 한글화 프로젝트 - 4096":
                    SPTTex4096Box.Tag = mod.Name;
                    break;
                case "SAIN": updateControl(Sainlink, SAINBox); break;
                case "Donut": updateControl(Donutlink, DonutBox); break;
                case "Realism": updateControl(Realisemlink, RealismBox); break;
                case "Questing Bots": updateControl(Questinglink, QuestingBotsBox); break;
                case "Dynamic Maps": updateControl(Maplink, MapsBox); break;
                case "Amands Graphics": updateControl(Graphicslink, GraphicsBox); break;
                case "Game Panel HUD": updateControl(Hudlink, HudBox); break;
                case "De-Clutterer": updateControl(Clutterlink, CluttererBox); break;
                case "Boss Notifier": updateControl(Notifierlink, NotifierBox); break;
                case "Fontaine's FOV Fix": updateControl(Fovlink, FOVFixBox); break;
                case "Dad Gamer Mode": updateControl(DadGamerlink, DadGamerBox); break;
                case "Personal Trainer": updateControl(Trainerlink, TrainerBox); break;
                case "Grenade Indicator": updateControl(G_Indicatorlink, GrenadeBox); break;
                case "SVM": updateControl(SVMlink, SVMBox); break;
                case "UI Fixes": updateControl(UIlink, UIBox); break;
                case "MOAR": updateControl(MOARlink, MOARBox); break;
                case "Performance Improvements": updateControl(Performancelink, PerformanceBox); break;
                case "Quest Tracker": updateControl(QuestTrackerlink, QuestTrackerBox); break;
                case "Audio Accessibility Indicators": updateControl(A_Indicatorlink, AudioBox); break;
                case "SamSWAT's Fire Support": updateControl(FireSupportlink, FireSupportBox); break;
                case "Trader Modding and Improved Weapon Building": updateControl(WeaponBuildinglink, ModdingBox); break;
                case "Borkel's Bloody Bullet Wounds + Particles + Splatters": updateControl(Bloodylink, BloodyBox); break;
                case "SAIN - KR": updateControl(SainKRlink, SAINKRBox); break;
                case "Donut - KR": updateControl(DonutKRlink, DonutKRBox); break;
                case "Realism - KR": updateControl(RealisemKRlink, RealismKRBox); break;
                case "Questing Bots - KR": updateControl(QuestingKRlink, QuestingBotsKRBox); break;
                case "Dynamic Maps - KR": updateControl(MapKRlink, MapsKRBox); break;
                case "Amands Graphics - KR": updateControl(GraphicsKRlink, GraphicsKRBox); break;
                case "Game Panel HUD - KR": updateControl(HudKRlink, HudKRBox); break;
                case "De-Clutterer - KR": updateControl(ClutterKRlink, CluttererKRBox); break;
                case "Boss Notifier - KR": updateControl(NotifierKRlink, NotifierKRBox); break;
                case "Fontaine's FOV Fix - KR": updateControl(FovKRlink, FOVFixKRBox); break;
                case "Dad Gamer Mode - KR": updateControl(DadGamerKRlink, DadGamerKRBox); break;
                case "Personal Trainer - KR": updateControl(TrainerKRlink, TrainerKRBox); break;
                case "Grenade Indicator - KR": updateControl(G_IndicatorKRlink, GrenadeKRBox); break;
                case "UI Fixes - KR": updateControl(UIKRlink, UIKRBox); break;
                case "MOAR - KR": updateControl(MOARKRlink, MOARKRBox); break;
                case "Performance Improvements - KR": updateControl(PerformanceKRlink, PerformanceKRBox); break;
                case "Quest Tracker - KR": updateControl(QuestTrackerKRlink, QuestTrackerKRBox); break;
                case "Audio Accessibility Indicators - KR": updateControl(A_IndicatorKRlink, AudioKRBox); break;
                case "SamSWAT's Fire Support - KR": updateControl(FireSupportKRlink, FireSupportKRBox); break;
                case "Trader Modding and Improved Weapon Building - KR": updateControl(WeaponBuildingKRlink, ModdingKRBox); break;
                case "Borkel's Bloody Bullet Wounds + Particles + Splatters - KR": updateControl(BloodyKRlink, BloodyKRBox); break;
                case "Visceral Dismemberment - KR": updateControl(ViscreralKRlink, VisceralBox); break;
                case "Item Context Menu - KR": updateControl(Contentlink, ContextMenuBox); break;
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

            var allCheckBoxes = GetAllControls(this).OfType<CheckBox>();
            var checkedMods = mods.Where(mod =>
                allCheckBoxes.Any(cb => cb.Checked && (cb.Tag as string) == mod.Name)).ToList();

            foreach (var mod in checkedMods)
            {
                try
                {
                    InstallLogBox.Text += $"{mod.Name} 다운로드 및 설치 중...\r\n";

                    string targetInstallPath = installPath;

                    //SVM 모드만 별도 경로 지정
                    if (mod.Name.Equals("SVM", StringComparison.OrdinalIgnoreCase))
                    {
                        targetInstallPath = Path.Combine(installPath, "user", "mods");
                        if (!Directory.Exists(targetInstallPath))
                            Directory.CreateDirectory(targetInstallPath);
                    }

                    foreach (var url in mod.DownloadUrls)
                    {
                        string fileName = Path.GetFileName(new Uri(url).AbsolutePath);
                        string archivePath = Path.Combine(installPath, fileName);

                        InstallLogBox.Text += $"{mod.Name} URL 다운로드 중: {url}\r\n";
                        await DownloadFileAsync(url, archivePath);

                        InstallLogBox.Text += $"{mod.Name} 압축 해제 중: {fileName}\r\n";
                        using (var archive = ArchiveFactory.Open(archivePath))
                        {
                            foreach (var entry in archive.Entries.Where(e => !e.IsDirectory))
                            {
                                entry.WriteToDirectory(targetInstallPath, new ExtractionOptions { ExtractFullPath = true, Overwrite = true });
                            }
                        }

                        File.Delete(archivePath);
                    }

                    InstallLogBox.Text += $"{mod.Name} 설치 완료.\r\n";
                }
                catch (Exception ex)
                {
                    InstallLogBox.Text += $"{mod.Name} 설치 실패: {ex.Message}\r\n";
                    Debug.WriteLine($"{mod.Name} 설치 실패: {ex}");
                }
            }

            InstallLogBox.Text += "모든 설치가 완료되었습니다.\r\n";
            MessageBox.Show("모드 설치가 완료되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InstallBtn.Enabled = true;

            // 모든 설치 완료 후 ProgressBar 초기화
            ModProgressBar.Value = 0;
            ModProgressBar.Style = ProgressBarStyle.Continuous;
        }

        private async Task DownloadFileAsync(string url, string destinationPath)
        {
            try
            {
                using HttpClient client = new HttpClient();
                var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                using (var streamToReadFrom = await response.Content.ReadAsStreamAsync())
                using (var streamToWriteTo = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    byte[] buffer = new byte[81920];
                    long totalRead = 0;
                    int read;

                    // 진행률 표시 설정
                    if (totalBytes > 0)
                    {
                        // 총 크기를 알 수 있으면 진행률 계산 가능
                        ModProgressBar.Invoke((Action)(() => {
                            ModProgressBar.Style = ProgressBarStyle.Continuous;
                            ModProgressBar.Maximum = 100;
                            ModProgressBar.Value = 0;
                        }));
                    }
                    else
                    {
                        // 총 크기를 모르면 막대가 움직이는 애니메이션 스타일
                        ModProgressBar.Invoke((Action)(() => {
                            ModProgressBar.Style = ProgressBarStyle.Marquee;
                        }));
                    }

                    while ((read = await streamToReadFrom.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        await streamToWriteTo.WriteAsync(buffer, 0, read);
                        totalRead += read;

                        if (totalBytes > 0)
                        {
                            int progress = (int)((double)totalRead / totalBytes * 100);
                            ModProgressBar.Invoke((Action)(() => {
                                ModProgressBar.Value = progress;
                            }));
                        }
                    }

                    // 다운로드 완료 후 100%로 설정
                    if (totalBytes > 0)
                    {
                        ModProgressBar.Invoke((Action)(() => {
                            ModProgressBar.Value = 100;
                        }));
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"다운로드 실패: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"파일 저장 실패: {ex.Message}", ex);
            }
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

        private void LinkBtn_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog { IsFolderPicker = true };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                installPath = dialog.FileName;
                LinkBox.Text = $"SPT 모드 설치 경로: {installPath}";
            }
        }

        private void LinkButtonsInitialize()
        {
            void AttachLinkClick(LinkLabel linkLabel, string modName)
            {
                linkLabel.LinkClicked += (s, e) => OpenSourceLink(modName);
            }

            AttachLinkClick(SPTKRlink, "SPT 타르코프 한글화 프로젝트");
            AttachLinkClick(LogoKRlink, "타르코프 로고 한글화");
            AttachLinkClick(TextureKRlink, "SPT 타르코프 아이템 텍스처 한글화 프로젝트 - 기본");
            AttachLinkClick(Sainlink, "SAIN");
            AttachLinkClick(Donutlink, "Donut");
            AttachLinkClick(Realisemlink, "Realism");
            AttachLinkClick(Questinglink, "Questing Bots");
            AttachLinkClick(Maplink, "Dynamic Maps");
            AttachLinkClick(Graphicslink, "Amands Graphics");
            AttachLinkClick(Hudlink, "Game Panel HUD");
            AttachLinkClick(Clutterlink, "De-Clutterer");
            AttachLinkClick(Notifierlink, "Boss Notifier");
            AttachLinkClick(Fovlink, "Fontaine's FOV Fix");
            AttachLinkClick(DadGamerlink, "Dad Gamer Mode");
            AttachLinkClick(SVMlink, "SVM");
            AttachLinkClick(UIlink, "UI Fixes");
            AttachLinkClick(MOARlink, "MOAR");
            AttachLinkClick(Performancelink, "Performance Improvements");
            AttachLinkClick(QuestTrackerlink, "Quest Tracker");
            AttachLinkClick(A_Indicatorlink, "Audio Accessibility Indicators");
            AttachLinkClick(FireSupportlink, "SamSWAT's Fire Support");
            AttachLinkClick(WeaponBuildinglink, "Trader Modding and Improved Weapon Building");
            AttachLinkClick(Bloodylink, "Borkel's Bloody Bullet Wounds + Particles + Splatters");

            AttachLinkClick(SainKRlink, "SAIN - KR");
            AttachLinkClick(DonutKRlink, "Donut - KR");
            AttachLinkClick(RealisemKRlink, "Realism - KR");
            AttachLinkClick(QuestingKRlink, "Questing Bots - KR");
            AttachLinkClick(MapKRlink, "Dynamic Maps - KR");
            AttachLinkClick(GraphicsKRlink, "Amands Graphics - KR");
            AttachLinkClick(HudKRlink, "Game Panel HUD - KR");
            AttachLinkClick(ClutterKRlink, "De-Clutterer - KR");
            AttachLinkClick(NotifierKRlink, "Boss Notifier - KR");
            AttachLinkClick(FovKRlink, "Fontaine's FOV Fix - KR");
            AttachLinkClick(DadGamerKRlink, "Dad Gamer Mode - KR");
            AttachLinkClick(UIKRlink, "UI Fixes - KR");
            AttachLinkClick(MOARKRlink, "MOAR - KR");
            AttachLinkClick(PerformanceKRlink, "Performance Improvements - KR");
            AttachLinkClick(QuestTrackerKRlink, "Quest Tracker - KR");
            AttachLinkClick(A_IndicatorKRlink, "Audio Accessibility Indicators - KR");
            AttachLinkClick(FireSupportKRlink, "SamSWAT's Fire Support - KR");
            AttachLinkClick(WeaponBuildingKRlink, "Trader Modding and Improved Weapon Building - KR");
            AttachLinkClick(BloodyKRlink, "Borkel's Bloody Bullet Wounds + Particles + Splatters - KR");
            AttachLinkClick(ViscreralKRlink, "Visceral Dismemberment - KR");
            AttachLinkClick(Contentlink, "Item Context Menu - KR");
        }
    }

    public class Metadata
    {
        public string SPTDefaultVersion { get; set; }
        public List<MetadataMod> Mods { get; set; }
    }

    public class MetadataMod
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string SPTVersion { get; set; }
        public string SPTDefaultVersion { get; set; }
        public List<string> DownloadUrls { get; set; }
        public bool KrVersion { get; set; }
        public string SourceUrl { get; set; }
    }
}
