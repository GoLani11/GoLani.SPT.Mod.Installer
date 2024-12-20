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
        private const string MetadataUrl = "https://raw.githubusercontent.com/GoLani11/GoLani_ModPack/main/GoLani_ModPack/DownloadMetaData/DownloadMetaData.json";
        private List<MetadataMod> mods = new List<MetadataMod>(); // 메타데이터에서 로드된 모드 리스트
        private string installPath; // 설치 경로

        public InstallModPage()
        {
            InitializeComponent();
            this.Load += async (s, e) => await LoadMetadataAsync(); // 비동기적으로 메타데이터 로드
            LinkButtonsInitialize(); // 링크 버튼 초기화
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
                UpdateCheckBoxText(mod); // 각 모드에 대해 UpdateCheckBoxText 호출
            }
        }

        private void UpdateCheckBoxText(MetadataMod mod)
        {
            CheckBox targetCheckBox = null;

            switch (mod.Name)
            {
                case "SPT 타르코프 한글화 프로젝트":
                    SPTKRlink.Text += $"\n- {mod.Version}";
                    SPTKRlink.Tag = mod;
                    SPTKRBox.Tag = mod.Name;
                    targetCheckBox = SPTKRBox;
                    break;
                case "타르코프 로고 한글화":
                    LogoKRlink.Text += $" - {mod.Version}";
                    LogoKRlink.Tag = mod;
                    SPTLogoKRBox.Tag = mod.Name;
                    targetCheckBox = SPTLogoKRBox;
                    break;
                case "SPT 타르코프 아이템 텍스처 한글화 프로젝트 - 기본":
                    SPTTexDefaultBox.Text += $" - {mod.Version}";
                    SPTTexDefaultBox.Tag = mod;
                    targetCheckBox = SPTTexDefaultBox;
                    break;
                case "SPT 타르코프 아이템 텍스처 한글화 프로젝트 - 4096":
                    SPTTex4096Box.Text += $" - {mod.Version}";
                    SPTTex4096Box.Tag = mod;
                    targetCheckBox = SPTTex4096Box;
                    break;
                case "SAIN":
                    Sainlink.Text += $" - {mod.Version}";
                    Sainlink.Tag = mod;
                    SAINBox.Tag = mod.Name;
                    targetCheckBox = SAINBox;
                    break;
                case "Donut":
                    Donutlink.Text += $" - {mod.Version}";
                    Donutlink.Tag = mod;
                    DonutBox.Tag = mod.Name;
                    targetCheckBox = DonutBox;
                    break;
                case "Realism":
                    Realisemlink.Text += $" - {mod.Version}";
                    Realisemlink.Tag = mod;
                    RealismBox.Tag = mod.Name;
                    targetCheckBox = RealismBox;
                    break;
                case "Questing Bots":
                    Questinglink.Text += $" - {mod.Version}";
                    Questinglink.Tag = mod;
                    QuestingBotsBox.Tag = mod.Name;
                    targetCheckBox = QuestingBotsBox;
                    break;
                case "Dynamic Maps":
                    Maplink.Text += $" - {mod.Version}";
                    Maplink.Tag = mod;
                    MapsBox.Tag = mod.Name;
                    targetCheckBox = MapsBox;
                    break;
                case "Amands Graphics":
                    Graphicslink.Text += $" - {mod.Version}";
                    Graphicslink.Tag = mod;
                    GraphicsBox.Tag = mod.Name;
                    targetCheckBox = GraphicsBox;
                    break;
                case "Game Panel HUD":
                    Hudlink.Text += $" - {mod.Version}";
                    Hudlink.Tag = mod;
                    HudBox.Tag = mod.Name;
                    targetCheckBox = HudBox;
                    break;
                case "De-Clutterer":
                    Clutterlink.Text += $" - {mod.Version}";
                    Clutterlink.Tag = mod;
                    CluttererBox.Tag = mod.Name;
                    targetCheckBox = CluttererBox;
                    break;
                case "Boss Notifier":
                    Notifierlink.Text += $" - {mod.Version}";
                    Notifierlink.Tag = mod;
                    NotifierBox.Tag = mod.Name;
                    targetCheckBox = NotifierBox;
                    break;
                case "Fontaine's FOV Fix":
                    Fovlink.Text += $" - {mod.Version}";
                    Fovlink.Tag = mod;
                    FOVFixBox.Tag = mod.Name;
                    targetCheckBox = FOVFixBox;
                    break;
                case "Dad Gamer Mode":
                    DadGamerlink.Text += $" - {mod.Version}";
                    DadGamerlink.Tag = mod;
                    DadGamerBox.Tag = mod.Name;
                    targetCheckBox = DadGamerBox;
                    break;
                case "Personal Trainer":
                    Trainerlink.Text += $" - {mod.Version}";
                    Trainerlink.Tag = mod;
                    TrainerBox.Tag = mod.Name;
                    targetCheckBox = TrainerBox;
                    break;
                case "Grenade Indicator":
                    G_Indicatorlink.Text += $" - {mod.Version}";
                    G_Indicatorlink.Tag = mod;
                    GrenadeBox.Tag = mod.Name;
                    targetCheckBox = GrenadeBox;
                    break;
                case "SVM":
                    SVMlink.Text += $" - {mod.Version}";
                    SVMlink.Tag = mod;
                    SVMBox.Tag = mod.Name;
                    targetCheckBox = SVMBox;
                    break;
                case "UI Fixes":
                    UIlink.Text += $" - {mod.Version}";
                    UIlink.Tag = mod;
                    UIBox.Tag = mod.Name;
                    targetCheckBox = UIBox;
                    break;
                case "MOAR":
                    MOARlink.Text += $" - {mod.Version}";
                    MOARlink.Tag = mod;
                    MOARBox.Tag = mod.Name;
                    targetCheckBox = MOARBox;
                    break;
                case "Performance Improvements":
                    Performancelink.Text += $" - {mod.Version}";
                    Performancelink.Tag = mod;
                    PerformanceBox.Tag = mod.Name;
                    targetCheckBox = PerformanceBox;
                    break;
                case "Quest Tracker":
                    QuestTrackerlink.Text += $" - {mod.Version}";
                    QuestTrackerlink.Tag = mod;
                    QuestTrackerBox.Tag = mod.Name;
                    targetCheckBox = QuestTrackerBox;
                    break;
                case "Audio Accessibility Indicators":
                    A_Indicatorlink.Text += $" - {mod.Version}";
                    A_Indicatorlink.Tag = mod;
                    AudioBox.Tag = mod.Name;
                    targetCheckBox = AudioBox;
                    break;
                case "SamSWAT's Fire Support":
                    FireSupportlink.Text += $" - {mod.Version}";
                    FireSupportlink.Tag = mod;
                    FireSupportBox.Tag = mod.Name;
                    targetCheckBox = FireSupportBox;
                    break;
                case "Trader Modding and Improved Weapon Building":
                    WeaponBuildinglink.Text += $" - {mod.Version}";
                    WeaponBuildinglink.Tag = mod;
                    ModdingBox.Tag = mod.Name;
                    targetCheckBox = ModdingBox;
                    break;
                case "Borkel's Bloody Bullet Wounds + Particles + Splatters":
                    Bloodylink.Text += $" - {mod.Version}";
                    Bloodylink.Tag = mod;
                    BloodyBox.Tag = mod.Name;
                    targetCheckBox = BloodyBox;
                    break;
                case "SAIN - KR":
                    SainKRlink.Text += $" - {mod.Version}";
                    SainKRlink.Tag = mod;
                    SAINKRBox.Tag = mod.Name;
                    targetCheckBox = SAINKRBox;
                    break;
                case "Donut - KR":
                    DonutKRlink.Text += $" - {mod.Version}";
                    DonutKRlink.Tag = mod;
                    DonutKRBox.Tag = mod.Name;
                    targetCheckBox = DonutKRBox;
                    break;
                case "Realism - KR":
                    RealisemKRlink.Text += $" - {mod.Version}";
                    RealisemKRlink.Tag = mod;
                    RealismKRBox.Tag = mod.Name;
                    targetCheckBox = RealismKRBox;
                    break;
                case "Questing Bots - KR":
                    QuestingKRlink.Text += $" - {mod.Version}";
                    QuestingKRlink.Tag = mod;
                    QuestingBotsKRBox.Tag = mod.Name;
                    targetCheckBox = QuestingBotsKRBox;
                    break;
                case "Dynamic Maps - KR":
                    MapKRlink.Text += $" - {mod.Version}";
                    MapKRlink.Tag = mod;
                    MapsKRBox.Tag = mod.Name;
                    targetCheckBox = MapsKRBox;
                    break;
                case "Amands Graphics - KR":
                    GraphicsKRlink.Text += $" - {mod.Version}";
                    GraphicsKRlink.Tag = mod;
                    GraphicsKRBox.Tag = mod.Name;
                    targetCheckBox = GraphicsKRBox;
                    break;
                case "Game Panel HUD - KR":
                    HudKRlink.Text += $" - {mod.Version}";
                    HudKRlink.Tag = mod;
                    HudKRBox.Tag = mod.Name;
                    targetCheckBox = HudKRBox;
                    break;
                case "De-Clutterer - KR":
                    ClutterKRlink.Text += $" - {mod.Version}";
                    ClutterKRlink.Tag = mod;
                    CluttererKRBox.Tag = mod.Name;
                    targetCheckBox = CluttererKRBox;
                    break;
                case "Boss Notifier - KR":
                    NotifierKRlink.Text += $" - {mod.Version}";
                    NotifierKRlink.Tag = mod;
                    NotifierKRBox.Tag = mod.Name;
                    targetCheckBox = NotifierKRBox;
                    break;
                case "Fontaine's FOV Fix - KR":
                    FovKRlink.Text += $" - {mod.Version}";
                    FovKRlink.Tag = mod;
                    FOVFixKRBox.Tag = mod.Name;
                    targetCheckBox = FOVFixKRBox;
                    break;
                case "Dad Gamer Mode - KR":
                    DadGamerKRlink.Text += $" - {mod.Version}";
                    DadGamerKRlink.Tag = mod;
                    DadGamerKRBox.Tag = mod.Name;
                    targetCheckBox = DadGamerKRBox;
                    break;
                case "Personal Trainer - KR":
                    TrainerKRlink.Text += $" - {mod.Version}";
                    TrainerKRlink.Tag = mod;
                    TrainerKRBox.Tag = mod.Name;
                    targetCheckBox = TrainerKRBox;
                    break;
                case "Grenade Indicator - KR":
                    G_IndicatorKRlink.Text += $" - {mod.Version}";
                    G_IndicatorKRlink.Tag = mod;
                    GrenadeKRBox.Tag = mod.Name; // 수정: G_IndicatorKRBox 연결
                    targetCheckBox = GrenadeKRBox;
                    break;
                case "UI Fixes - KR":
                    UIKRlink.Text += $" - {mod.Version}";
                    UIKRlink.Tag = mod;
                    UIKRBox.Tag = mod.Name;
                    targetCheckBox = UIKRBox;
                    break;
                case "MOAR - KR":
                    MOARKRlink.Text += $" - {mod.Version}";
                    MOARKRlink.Tag = mod;
                    MOARKRBox.Tag = mod.Name;
                    targetCheckBox = MOARKRBox;
                    break;
                case "Performance Improvements - KR":
                    PerformanceKRlink.Text += $" - {mod.Version}";
                    PerformanceKRlink.Tag = mod;
                    PerformanceKRBox.Tag = mod.Name;
                    targetCheckBox = PerformanceKRBox;
                    break;
                case "Quest Tracker - KR":
                    QuestTrackerKRlink.Text += $" - {mod.Version}";
                    QuestTrackerKRlink.Tag = mod;
                    QuestTrackerKRBox.Tag = mod.Name;
                    targetCheckBox = QuestTrackerKRBox;
                    break;
                case "Audio Accessibility Indicators - KR":
                    A_IndicatorKRlink.Text += $" - {mod.Version}";
                    A_IndicatorKRlink.Tag = mod;
                    AudioKRBox.Tag = mod.Name;
                    targetCheckBox = AudioKRBox;
                    break;
                case "SamSWAT's Fire Support - KR":
                    FireSupportKRlink.Text += $" - {mod.Version}";
                    FireSupportKRlink.Tag = mod;
                    FireSupportKRBox.Tag = mod.Name;
                    targetCheckBox = FireSupportKRBox;
                    break;
                case "Trader Modding and Improved Weapon Building - KR":
                    WeaponBuildingKRlink.Text += $" - {mod.Version}";
                    WeaponBuildingKRlink.Tag = mod;
                    ModdingKRBox.Tag = mod.Name;
                    targetCheckBox = ModdingKRBox;
                    break;
                case "Borkel's Bloody Bullet Wounds + Particles + Splatters - KR":
                    BloodyKRlink.Text += $" - {mod.Version}";
                    BloodyKRlink.Tag = mod;
                    BloodyKRBox.Tag = mod.Name;
                    targetCheckBox = BloodyKRBox;
                    break;
            }
            string originalModName = mod.Name.Replace(" - KR", "");
            var originalMod = mods.FirstOrDefault(m => m.Name == originalModName);
            
            // 한글화 모드인 경우 원본 모드와 버전 비교
            if (mod.KrVersion)
            {
                if (originalMod != null && targetCheckBox != null && originalMod.Version != mod.Version)
                {
                    targetCheckBox.Enabled = false;
                    targetCheckBox.Text += " (버전 불일치)";
                }
            }
            // 원본 모드인 경우, 연결된 한글화 모드를 찾아서 처리
            else
            {
                string krModName = mod.Name + " - KR";
                var krMod = mods.FirstOrDefault(m => m.Name == krModName);
                CheckBox krCheckBox = null;

                // 해당하는 한글화 체크박스 찾기
                switch (krModName)
                {
                    case "SAIN - KR": krCheckBox = SAINKRBox; break;
                    case "Donut - KR": krCheckBox = DonutKRBox; break;
                    case "Realism - KR": krCheckBox = RealismKRBox; break;
                    case "Questing Bots - KR": krCheckBox = QuestingBotsKRBox; break;
                    case "Dynamic Maps - KR": krCheckBox = MapsKRBox; break;
                    case "Amands Graphics - KR": krCheckBox = GraphicsKRBox; break;
                    case "Game Panel HUD - KR": krCheckBox = HudKRBox; break;
                    case "De-Clutterer - KR": krCheckBox = CluttererKRBox; break;
                    case "Boss Notifier - KR": krCheckBox = NotifierKRBox; break;
                    case "Fontaine's FOV Fix - KR": krCheckBox = FOVFixKRBox; break;
                    case "Dad Gamer Mode - KR": krCheckBox = DadGamerKRBox; break;
                    case "Personal Trainer - KR": krCheckBox = TrainerKRBox; break;
                    case "Grenade Indicator - KR": krCheckBox = GrenadeKRBox; break;
                    case "UI Fixes - KR": krCheckBox = UIKRBox; break;
                    case "MOAR - KR": krCheckBox = MOARKRBox; break;
                    case "Performance Improvements - KR": krCheckBox = PerformanceKRBox; break;
                    case "Quest Tracker - KR": krCheckBox = QuestTrackerKRBox; break;
                    case "Audio Accessibility Indicators - KR": krCheckBox = AudioKRBox; break;
                    case "SamSWAT's Fire Support - KR": krCheckBox = FireSupportKRBox; break;
                    case "Trader Modding and Improved Weapon Building - KR": krCheckBox = ModdingKRBox; break;
                    case "Borkel's Bloody Bullet Wounds + Particles + Splatters - KR": krCheckBox = BloodyKRBox; break;
                }

                if (krMod != null && krCheckBox != null && originalMod.Version != krMod.Version)
                {
                    krCheckBox.Enabled = false;
                    krCheckBox.Text += " (버전 불일치)";
                }
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

            // 체크된 모드만 설치하도록 수정
            var checkedMods = GetCheckedMods();

            foreach (var mod in checkedMods)
            {
                try
                {
                    InstallLogBox.Text += $"{mod.Name} 다운로드 및 설치 중...\r\n";

                    // 파일 다운로드
                    string archivePath = Path.Combine(installPath, $"{mod.Name.Replace(" - KR", "")}.zip"); // 한글화 모드 이름에서 " - KR" 제거
                    await DownloadFileAsync(mod.DownloadUrls.First(), archivePath);

                    // 압축 해제
                    InstallLogBox.Text += $"{mod.Name} 압축 해제 중...\r\n";
                    using (var archive = ArchiveFactory.Open(archivePath))
                    {
                        foreach (var entry in archive.Entries.Where(e => !e.IsDirectory))
                        {
                            entry.WriteToDirectory(installPath, new ExtractionOptions()
                            {
                                ExtractFullPath = true,
                                Overwrite = true
                            });
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

        // 체크된 모드 목록을 가져오는 메서드 추가
        private List<MetadataMod> GetCheckedMods()
        {
            var checkedMods = new List<MetadataMod>();

            // 체크박스의 Tag 속성에 저장된 모드 이름을 기반으로 MetadataMod 객체를 찾음
            foreach (Control control in Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked && checkBox.Tag is string modName)
                {
                    var mod = mods.FirstOrDefault(m => m.Name == modName);
                    if (mod != null)
                    {
                        checkedMods.Add(mod);
                    }
                }
            }

            return checkedMods;
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

        // 링크 버튼 초기화
        private void LinkButtonsInitialize()
        {
            // SPT 한글화 관련 링크
            SPTKRlink.LinkClicked += (s, e) => OpenSourceLink("SPT 타르코프 한글화 프로젝트");
            LogoKRlink.LinkClicked += (s, e) => OpenSourceLink("타르코프 로고 한글화");
            TextureKRlink.LinkClicked += (s, e) => OpenSourceLink("SPT 타르코프 아이템 텍스처 한글화 프로젝트 - 기본");

            // 원본 모드 링크
            Sainlink.LinkClicked += (s, e) => OpenSourceLink("SAIN");
            Donutlink.LinkClicked += (s, e) => OpenSourceLink("Donut");
            Realisemlink.LinkClicked += (s, e) => OpenSourceLink("Realism");
            Questinglink.LinkClicked += (s, e) => OpenSourceLink("Questing Bots");
            Maplink.LinkClicked += (s, e) => OpenSourceLink("Dynamic Maps");
            Graphicslink.LinkClicked += (s, e) => OpenSourceLink("Amands Graphics");
            Hudlink.LinkClicked += (s, e) => OpenSourceLink("Game Panel HUD");
            Clutterlink.LinkClicked += (s, e) => OpenSourceLink("De-Clutterer");
            Notifierlink.LinkClicked += (s, e) => OpenSourceLink("Boss Notifier");
            Fovlink.LinkClicked += (s, e) => OpenSourceLink("Fontaine's FOV Fix");
            DadGamerlink.LinkClicked += (s, e) => OpenSourceLink("Dad Gamer Mode");
            SVMlink.LinkClicked += (s, e) => OpenSourceLink("SVM");
            UIlink.LinkClicked += (s, e) => OpenSourceLink("UI Fixes");
            MOARlink.LinkClicked += (s, e) => OpenSourceLink("MOAR");
            Performancelink.LinkClicked += (s, e) => OpenSourceLink("Performance Improvements");
            QuestTrackerlink.LinkClicked += (s, e) => OpenSourceLink("Quest Tracker");
            A_Indicatorlink.LinkClicked += (s, e) => OpenSourceLink("Audio Accessibility Indicators");
            FireSupportlink.LinkClicked += (s, e) => OpenSourceLink("SamSWAT's Fire Support");
            Trainerlink.LinkClicked += (s, e) => OpenSourceLink("Trader Modding and Improved Weapon Building");
            Bloodylink.LinkClicked += (s, e) => OpenSourceLink("Borkel's Bloody Bullet Wounds + Particles + Splatters");

            // 한글화 모드 링크
            SainKRlink.LinkClicked += (s, e) => OpenSourceLink("SAIN - KR");
            DonutKRlink.LinkClicked += (s, e) => OpenSourceLink("Donut - KR");
            RealisemKRlink.LinkClicked += (s, e) => OpenSourceLink("Realism - KR");
            QuestingKRlink.LinkClicked += (s, e) => OpenSourceLink("Questing Bots - KR");
            MapKRlink.LinkClicked += (s, e) => OpenSourceLink("Dynamic Maps - KR");
            GraphicsKRlink.LinkClicked += (s, e) => OpenSourceLink("Amands Graphics - KR");
            HudKRlink.LinkClicked += (s, e) => OpenSourceLink("Game Panel HUD - KR");
            ClutterKRlink.LinkClicked += (s, e) => OpenSourceLink("De-Clutterer - KR");
            NotifierKRlink.LinkClicked += (s, e) => OpenSourceLink("Boss Notifier - KR");
            FovKRlink.LinkClicked += (s, e) => OpenSourceLink("Fontaine's FOV Fix - KR");
            DadGamerKRlink.LinkClicked += (s, e) => OpenSourceLink("Dad Gamer Mode - KR");
            UIKRlink.LinkClicked += (s, e) => OpenSourceLink("UI Fixes - KR");
            MOARKRlink.LinkClicked += (s, e) => OpenSourceLink("MOAR - KR");
            PerformanceKRlink.LinkClicked += (s, e) => OpenSourceLink("Performance Improvements - KR");
            QuestTrackerKRlink.LinkClicked += (s, e) => OpenSourceLink("Quest Tracker - KR");
            A_IndicatorKRlink.LinkClicked += (s, e) => OpenSourceLink("Audio Accessibility Indicators - KR");
            FireSupportKRlink.LinkClicked += (s, e) => OpenSourceLink("SamSWAT's Fire Support - KR");
            TrainerKRlink.LinkClicked += (s, e) => OpenSourceLink("Trader Modding and Improved Weapon Building - KR");
            BloodyKRlink.LinkClicked += (s, e) => OpenSourceLink("Borkel's Bloody Bullet Wounds + Particles + Splatters - KR");
            //ViscreralKRlink.LinkClicked += (s, e) => OpenSourceLink("Visceral Dismemberment - KR"); // 해당 모드 이름 메타데이터와 불일치
            //Contentlink.LinkClicked += (s, e) => OpenSourceLink("Item Context Menu - KR"); // 해당 모드 이름 메타데이터와 불일치

        }

        private void SPTTexKRBox_CheckedChanged(object sender, EventArgs e)
        {
            SPTTexDefaultBox.Enabled = SPTTexKRBox.Checked;
            SPTTex4096Box.Enabled = SPTTexKRBox.Checked;
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
        public string SPTVersion { get; set; }
        public string SPTDefaultVersion { get; set; }
        public List<string> DownloadUrls { get; set; }
        public bool KrVersion { get; set; }
        public string SourceUrl { get; set; }
    }
}