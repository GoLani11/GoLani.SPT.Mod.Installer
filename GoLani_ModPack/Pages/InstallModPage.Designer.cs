namespace GoLani_ModPack.Pages
{
    partial class InstallModPage
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            LinkBtn = new Button();
            LinkBox = new TextBox();
            InstallBtn = new Button();
            panel1 = new Panel();
            InstallLogBox = new TextBox();
            panel2 = new Panel();
            ModtabControl = new TabControl();
            ModtabPage1 = new TabPage();
            linkLabel1 = new LinkLabel();
            SVMBox = new CheckBox();
            A_Indicatorlink = new LinkLabel();
            AudioBox = new CheckBox();
            Contentlink = new LinkLabel();
            ContextMenuBox = new CheckBox();
            G_Indicatorlink = new LinkLabel();
            GrenadeBox = new CheckBox();
            Trainerlink = new LinkLabel();
            TrainerBox = new CheckBox();
            DadGamerlink = new LinkLabel();
            DadGamerBox = new CheckBox();
            Fovlink = new LinkLabel();
            FOVFixBox = new CheckBox();
            Notifierlink = new LinkLabel();
            NotifierBox = new CheckBox();
            Clutterlink = new LinkLabel();
            CluttererBox = new CheckBox();
            Hudlink = new LinkLabel();
            HudBox = new CheckBox();
            Graphicslink = new LinkLabel();
            GraphicsBox = new CheckBox();
            Maplink = new LinkLabel();
            MapsBox = new CheckBox();
            Questinglink = new LinkLabel();
            QuestingBotsBox = new CheckBox();
            Realisemlink = new LinkLabel();
            RealismBox = new CheckBox();
            Donutlink = new LinkLabel();
            DonutBox = new CheckBox();
            Sainlink = new LinkLabel();
            SAINBox = new CheckBox();
            ModtabPage2 = new TabPage();
            Bloodylink = new LinkLabel();
            BloodyBox = new CheckBox();
            WeaponBuildinglink = new LinkLabel();
            ModdingBox = new CheckBox();
            FireSupportlink = new LinkLabel();
            FireSupportBox = new CheckBox();
            panel4 = new Panel();
            Texture4Klink = new LinkLabel();
            SPTTexDefaultBtn = new RadioButton();
            SPTTex4096Btn = new RadioButton();
            TextureKRlink = new LinkLabel();
            SPTTexKRBox = new CheckBox();
            LogoKRlink = new LinkLabel();
            SPTLogoKRBox = new CheckBox();
            SPTKRlink = new LinkLabel();
            SPTKRBox = new CheckBox();
            panel3 = new Panel();
            KRtabControl = new TabControl();
            KRtabPage1 = new TabPage();
            A_IndicatorKRlink = new LinkLabel();
            AudioKRBox = new CheckBox();
            G_IndicatorKRlink = new LinkLabel();
            GrenadeKRBox = new CheckBox();
            TrainerKRlink = new LinkLabel();
            TrainerKRBox = new CheckBox();
            DadGamerKRlink = new LinkLabel();
            DadGamerKRBox = new CheckBox();
            FovKRlink = new LinkLabel();
            FOVFixKRBox = new CheckBox();
            NotifierKRlink = new LinkLabel();
            NotifierKRBox = new CheckBox();
            ClutterKRlink = new LinkLabel();
            CluttererKRBox = new CheckBox();
            HudKRlink = new LinkLabel();
            HudKRBox = new CheckBox();
            GraphicsKRlink = new LinkLabel();
            GraphicsKRBox = new CheckBox();
            MapKRlink = new LinkLabel();
            MapsKRBox = new CheckBox();
            QuestingKRlink = new LinkLabel();
            QuestingBotsKRBox = new CheckBox();
            RealisemKRlink = new LinkLabel();
            RealismKRBox = new CheckBox();
            DonutKRlink = new LinkLabel();
            DonutKRBox = new CheckBox();
            SainKRlink = new LinkLabel();
            SAINKRBox = new CheckBox();
            KRtabPage2 = new TabPage();
            BloodyKRlink = new LinkLabel();
            BloodyKRBox = new CheckBox();
            WeaponBuildingKRlink = new LinkLabel();
            ModdingKRBox = new CheckBox();
            ViscreralKRlink = new LinkLabel();
            VisceralBox = new CheckBox();
            FireSupportKRlink = new LinkLabel();
            FireSupportKRBox = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ModtabControl.SuspendLayout();
            ModtabPage1.SuspendLayout();
            ModtabPage2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            KRtabControl.SuspendLayout();
            KRtabPage1.SuspendLayout();
            KRtabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // LinkBtn
            // 
            LinkBtn.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            LinkBtn.Location = new Point(119, 6);
            LinkBtn.Name = "LinkBtn";
            LinkBtn.Size = new Size(88, 51);
            LinkBtn.TabIndex = 2;
            LinkBtn.Text = "경로";
            LinkBtn.UseVisualStyleBackColor = true;
            LinkBtn.Click += LinkBtn_Click;
            // 
            // LinkBox
            // 
            LinkBox.Location = new Point(213, 6);
            LinkBox.Name = "LinkBox";
            LinkBox.ReadOnly = true;
            LinkBox.Size = new Size(483, 23);
            LinkBox.TabIndex = 3;
            LinkBox.Text = "SPT 폴더를 지정해주세요. ex) C:\\SPT\r\n";
            // 
            // InstallBtn
            // 
            InstallBtn.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            InstallBtn.Location = new Point(702, 6);
            InstallBtn.Name = "InstallBtn";
            InstallBtn.Size = new Size(92, 102);
            InstallBtn.TabIndex = 4;
            InstallBtn.Text = "모드\r\n설치";
            InstallBtn.UseVisualStyleBackColor = true;
            InstallBtn.Click += InstallBtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(InstallLogBox);
            panel1.Controls.Add(InstallBtn);
            panel1.Controls.Add(LinkBtn);
            panel1.Controls.Add(LinkBox);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 550);
            panel1.Name = "panel1";
            panel1.Size = new Size(934, 111);
            panel1.TabIndex = 5;
            // 
            // InstallLogBox
            // 
            InstallLogBox.Location = new Point(213, 35);
            InstallLogBox.Multiline = true;
            InstallLogBox.Name = "InstallLogBox";
            InstallLogBox.ReadOnly = true;
            InstallLogBox.ScrollBars = ScrollBars.Vertical;
            InstallLogBox.Size = new Size(483, 73);
            InstallLogBox.TabIndex = 5;
            InstallLogBox.TabStop = false;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(ModtabControl);
            panel2.Location = new Point(19, 223);
            panel2.Name = "panel2";
            panel2.Size = new Size(445, 320);
            panel2.TabIndex = 6;
            // 
            // ModtabControl
            // 
            ModtabControl.Controls.Add(ModtabPage1);
            ModtabControl.Controls.Add(ModtabPage2);
            ModtabControl.Dock = DockStyle.Fill;
            ModtabControl.ItemSize = new Size(55, 40);
            ModtabControl.Location = new Point(0, 0);
            ModtabControl.Name = "ModtabControl";
            ModtabControl.SelectedIndex = 0;
            ModtabControl.Size = new Size(443, 318);
            ModtabControl.TabIndex = 0;
            // 
            // ModtabPage1
            // 
            ModtabPage1.Controls.Add(linkLabel1);
            ModtabPage1.Controls.Add(SVMBox);
            ModtabPage1.Controls.Add(A_Indicatorlink);
            ModtabPage1.Controls.Add(AudioBox);
            ModtabPage1.Controls.Add(Contentlink);
            ModtabPage1.Controls.Add(ContextMenuBox);
            ModtabPage1.Controls.Add(G_Indicatorlink);
            ModtabPage1.Controls.Add(GrenadeBox);
            ModtabPage1.Controls.Add(Trainerlink);
            ModtabPage1.Controls.Add(TrainerBox);
            ModtabPage1.Controls.Add(DadGamerlink);
            ModtabPage1.Controls.Add(DadGamerBox);
            ModtabPage1.Controls.Add(Fovlink);
            ModtabPage1.Controls.Add(FOVFixBox);
            ModtabPage1.Controls.Add(Notifierlink);
            ModtabPage1.Controls.Add(NotifierBox);
            ModtabPage1.Controls.Add(Clutterlink);
            ModtabPage1.Controls.Add(CluttererBox);
            ModtabPage1.Controls.Add(Hudlink);
            ModtabPage1.Controls.Add(HudBox);
            ModtabPage1.Controls.Add(Graphicslink);
            ModtabPage1.Controls.Add(GraphicsBox);
            ModtabPage1.Controls.Add(Maplink);
            ModtabPage1.Controls.Add(MapsBox);
            ModtabPage1.Controls.Add(Questinglink);
            ModtabPage1.Controls.Add(QuestingBotsBox);
            ModtabPage1.Controls.Add(Realisemlink);
            ModtabPage1.Controls.Add(RealismBox);
            ModtabPage1.Controls.Add(Donutlink);
            ModtabPage1.Controls.Add(DonutBox);
            ModtabPage1.Controls.Add(Sainlink);
            ModtabPage1.Controls.Add(SAINBox);
            ModtabPage1.Location = new Point(4, 44);
            ModtabPage1.Name = "ModtabPage1";
            ModtabPage1.Padding = new Padding(3);
            ModtabPage1.Size = new Size(435, 270);
            ModtabPage1.TabIndex = 0;
            ModtabPage1.Text = "1페이지";
            ModtabPage1.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(250, 36);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(146, 21);
            linkLabel1.TabIndex = 93;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "SVM (공식 한글화)";
            // 
            // SVMBox
            // 
            SVMBox.AutoSize = true;
            SVMBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            SVMBox.Location = new Point(229, 42);
            SVMBox.Name = "SVMBox";
            SVMBox.Size = new Size(15, 14);
            SVMBox.TabIndex = 92;
            SVMBox.UseVisualStyleBackColor = true;
            // 
            // A_Indicatorlink
            // 
            A_Indicatorlink.AutoSize = true;
            A_Indicatorlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            A_Indicatorlink.LinkColor = Color.Black;
            A_Indicatorlink.Location = new Point(250, 226);
            A_Indicatorlink.Name = "A_Indicatorlink";
            A_Indicatorlink.Size = new Size(150, 42);
            A_Indicatorlink.TabIndex = 91;
            A_Indicatorlink.TabStop = true;
            A_Indicatorlink.Text = "Audio Accessibility\r\nIndicators";
            // 
            // AudioBox
            // 
            AudioBox.AutoSize = true;
            AudioBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            AudioBox.Location = new Point(229, 232);
            AudioBox.Name = "AudioBox";
            AudioBox.Size = new Size(15, 14);
            AudioBox.TabIndex = 90;
            AudioBox.UseVisualStyleBackColor = true;
            // 
            // Contentlink
            // 
            Contentlink.AutoSize = true;
            Contentlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Contentlink.LinkColor = Color.Black;
            Contentlink.Location = new Point(26, 221);
            Contentlink.Name = "Contentlink";
            Contentlink.Size = new Size(157, 42);
            Contentlink.TabIndex = 89;
            Contentlink.TabStop = true;
            Contentlink.Text = "Item Context Menu\r\n(포팅 - 한글화 포함)";
            // 
            // ContextMenuBox
            // 
            ContextMenuBox.AutoSize = true;
            ContextMenuBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            ContextMenuBox.Location = new Point(5, 227);
            ContextMenuBox.Name = "ContextMenuBox";
            ContextMenuBox.Size = new Size(15, 14);
            ContextMenuBox.TabIndex = 88;
            ContextMenuBox.UseVisualStyleBackColor = true;
            // 
            // G_Indicatorlink
            // 
            G_Indicatorlink.AutoSize = true;
            G_Indicatorlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            G_Indicatorlink.LinkColor = Color.Black;
            G_Indicatorlink.Location = new Point(27, 195);
            G_Indicatorlink.Name = "G_Indicatorlink";
            G_Indicatorlink.Size = new Size(143, 21);
            G_Indicatorlink.TabIndex = 87;
            G_Indicatorlink.TabStop = true;
            G_Indicatorlink.Text = "Grenade Indicator";
            // 
            // GrenadeBox
            // 
            GrenadeBox.AutoSize = true;
            GrenadeBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            GrenadeBox.Location = new Point(6, 201);
            GrenadeBox.Name = "GrenadeBox";
            GrenadeBox.Size = new Size(15, 14);
            GrenadeBox.TabIndex = 86;
            GrenadeBox.UseVisualStyleBackColor = true;
            // 
            // Trainerlink
            // 
            Trainerlink.AutoSize = true;
            Trainerlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Trainerlink.LinkColor = Color.Black;
            Trainerlink.Location = new Point(250, 194);
            Trainerlink.Name = "Trainerlink";
            Trainerlink.Size = new Size(129, 21);
            Trainerlink.TabIndex = 85;
            Trainerlink.TabStop = true;
            Trainerlink.Text = "Personal Trainer";
            // 
            // TrainerBox
            // 
            TrainerBox.AutoSize = true;
            TrainerBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            TrainerBox.Location = new Point(229, 200);
            TrainerBox.Name = "TrainerBox";
            TrainerBox.Size = new Size(15, 14);
            TrainerBox.TabIndex = 84;
            TrainerBox.UseVisualStyleBackColor = true;
            // 
            // DadGamerlink
            // 
            DadGamerlink.AutoSize = true;
            DadGamerlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            DadGamerlink.LinkColor = Color.Black;
            DadGamerlink.Location = new Point(27, 163);
            DadGamerlink.Name = "DadGamerlink";
            DadGamerlink.Size = new Size(143, 21);
            DadGamerlink.TabIndex = 83;
            DadGamerlink.TabStop = true;
            DadGamerlink.Text = "Dad Gamer Mode";
            // 
            // DadGamerBox
            // 
            DadGamerBox.AutoSize = true;
            DadGamerBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            DadGamerBox.Location = new Point(6, 169);
            DadGamerBox.Name = "DadGamerBox";
            DadGamerBox.Size = new Size(15, 14);
            DadGamerBox.TabIndex = 82;
            DadGamerBox.UseVisualStyleBackColor = true;
            // 
            // Fovlink
            // 
            Fovlink.AutoSize = true;
            Fovlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Fovlink.LinkColor = Color.Black;
            Fovlink.Location = new Point(250, 162);
            Fovlink.Name = "Fovlink";
            Fovlink.Size = new Size(145, 21);
            Fovlink.TabIndex = 81;
            Fovlink.TabStop = true;
            Fovlink.Text = "Fontaine's FOV Fix";
            // 
            // FOVFixBox
            // 
            FOVFixBox.AutoSize = true;
            FOVFixBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            FOVFixBox.Location = new Point(229, 168);
            FOVFixBox.Name = "FOVFixBox";
            FOVFixBox.Size = new Size(15, 14);
            FOVFixBox.TabIndex = 80;
            FOVFixBox.UseVisualStyleBackColor = true;
            // 
            // Notifierlink
            // 
            Notifierlink.AutoSize = true;
            Notifierlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Notifierlink.LinkColor = Color.Black;
            Notifierlink.Location = new Point(27, 131);
            Notifierlink.Name = "Notifierlink";
            Notifierlink.Size = new Size(105, 21);
            Notifierlink.TabIndex = 79;
            Notifierlink.TabStop = true;
            Notifierlink.Text = "Boss Notifier";
            // 
            // NotifierBox
            // 
            NotifierBox.AutoSize = true;
            NotifierBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            NotifierBox.Location = new Point(6, 137);
            NotifierBox.Name = "NotifierBox";
            NotifierBox.Size = new Size(15, 14);
            NotifierBox.TabIndex = 78;
            NotifierBox.UseVisualStyleBackColor = true;
            // 
            // Clutterlink
            // 
            Clutterlink.AutoSize = true;
            Clutterlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Clutterlink.LinkColor = Color.Black;
            Clutterlink.Location = new Point(250, 132);
            Clutterlink.Name = "Clutterlink";
            Clutterlink.Size = new Size(102, 21);
            Clutterlink.TabIndex = 77;
            Clutterlink.TabStop = true;
            Clutterlink.Text = "De-Clutterer";
            // 
            // CluttererBox
            // 
            CluttererBox.AutoSize = true;
            CluttererBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            CluttererBox.Location = new Point(229, 138);
            CluttererBox.Name = "CluttererBox";
            CluttererBox.Size = new Size(15, 14);
            CluttererBox.TabIndex = 76;
            CluttererBox.UseVisualStyleBackColor = true;
            // 
            // Hudlink
            // 
            Hudlink.AutoSize = true;
            Hudlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Hudlink.LinkColor = Color.Black;
            Hudlink.Location = new Point(27, 101);
            Hudlink.Name = "Hudlink";
            Hudlink.Size = new Size(143, 21);
            Hudlink.TabIndex = 75;
            Hudlink.TabStop = true;
            Hudlink.Text = "Game Pannel Hud";
            // 
            // HudBox
            // 
            HudBox.AutoSize = true;
            HudBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            HudBox.Location = new Point(6, 107);
            HudBox.Name = "HudBox";
            HudBox.Size = new Size(15, 14);
            HudBox.TabIndex = 74;
            HudBox.UseVisualStyleBackColor = true;
            // 
            // Graphicslink
            // 
            Graphicslink.AutoSize = true;
            Graphicslink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Graphicslink.LinkColor = Color.Black;
            Graphicslink.Location = new Point(250, 99);
            Graphicslink.Name = "Graphicslink";
            Graphicslink.Size = new Size(139, 21);
            Graphicslink.TabIndex = 73;
            Graphicslink.TabStop = true;
            Graphicslink.Text = "Amanda Graphics";
            // 
            // GraphicsBox
            // 
            GraphicsBox.AutoSize = true;
            GraphicsBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            GraphicsBox.Location = new Point(229, 105);
            GraphicsBox.Name = "GraphicsBox";
            GraphicsBox.Size = new Size(15, 14);
            GraphicsBox.TabIndex = 72;
            GraphicsBox.UseVisualStyleBackColor = true;
            // 
            // Maplink
            // 
            Maplink.AutoSize = true;
            Maplink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Maplink.LinkColor = Color.Black;
            Maplink.Location = new Point(27, 68);
            Maplink.Name = "Maplink";
            Maplink.Size = new Size(118, 21);
            Maplink.TabIndex = 71;
            Maplink.TabStop = true;
            Maplink.Text = "Dynamic Maps";
            // 
            // MapsBox
            // 
            MapsBox.AutoSize = true;
            MapsBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            MapsBox.Location = new Point(6, 74);
            MapsBox.Name = "MapsBox";
            MapsBox.Size = new Size(15, 14);
            MapsBox.TabIndex = 70;
            MapsBox.UseVisualStyleBackColor = true;
            // 
            // Questinglink
            // 
            Questinglink.AutoSize = true;
            Questinglink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Questinglink.LinkColor = Color.Black;
            Questinglink.Location = new Point(250, 67);
            Questinglink.Name = "Questinglink";
            Questinglink.Size = new Size(114, 21);
            Questinglink.TabIndex = 69;
            Questinglink.TabStop = true;
            Questinglink.Text = "Questing Bots";
            // 
            // QuestingBotsBox
            // 
            QuestingBotsBox.AutoSize = true;
            QuestingBotsBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            QuestingBotsBox.Location = new Point(229, 73);
            QuestingBotsBox.Name = "QuestingBotsBox";
            QuestingBotsBox.Size = new Size(15, 14);
            QuestingBotsBox.TabIndex = 68;
            QuestingBotsBox.UseVisualStyleBackColor = true;
            // 
            // Realisemlink
            // 
            Realisemlink.AutoSize = true;
            Realisemlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Realisemlink.LinkColor = Color.Black;
            Realisemlink.Location = new Point(27, 36);
            Realisemlink.Name = "Realisemlink";
            Realisemlink.Size = new Size(140, 21);
            Realisemlink.TabIndex = 67;
            Realisemlink.TabStop = true;
            Realisemlink.Text = "SPT Realism Mod";
            Realisemlink.LinkClicked += Realisemlink_LinkClicked;
            // 
            // RealismBox
            // 
            RealismBox.AutoSize = true;
            RealismBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            RealismBox.Location = new Point(6, 42);
            RealismBox.Name = "RealismBox";
            RealismBox.Size = new Size(15, 14);
            RealismBox.TabIndex = 66;
            RealismBox.UseVisualStyleBackColor = true;
            // 
            // Donutlink
            // 
            Donutlink.AutoSize = true;
            Donutlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Donutlink.LinkColor = Color.Black;
            Donutlink.Location = new Point(250, 6);
            Donutlink.Name = "Donutlink";
            Donutlink.Size = new Size(55, 21);
            Donutlink.TabIndex = 65;
            Donutlink.TabStop = true;
            Donutlink.Text = "Donut";
            // 
            // DonutBox
            // 
            DonutBox.AutoSize = true;
            DonutBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            DonutBox.Location = new Point(229, 12);
            DonutBox.Name = "DonutBox";
            DonutBox.Size = new Size(15, 14);
            DonutBox.TabIndex = 64;
            DonutBox.UseVisualStyleBackColor = true;
            // 
            // Sainlink
            // 
            Sainlink.AutoSize = true;
            Sainlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Sainlink.LinkColor = Color.Black;
            Sainlink.Location = new Point(27, 6);
            Sainlink.Name = "Sainlink";
            Sainlink.Size = new Size(46, 21);
            Sainlink.TabIndex = 63;
            Sainlink.TabStop = true;
            Sainlink.Text = "SAIN";
            Sainlink.LinkClicked += Sainlink_LinkClicked;
            // 
            // SAINBox
            // 
            SAINBox.AutoSize = true;
            SAINBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            SAINBox.Location = new Point(6, 12);
            SAINBox.Name = "SAINBox";
            SAINBox.Size = new Size(15, 14);
            SAINBox.TabIndex = 62;
            SAINBox.UseVisualStyleBackColor = true;
            // 
            // ModtabPage2
            // 
            ModtabPage2.Controls.Add(Bloodylink);
            ModtabPage2.Controls.Add(BloodyBox);
            ModtabPage2.Controls.Add(WeaponBuildinglink);
            ModtabPage2.Controls.Add(ModdingBox);
            ModtabPage2.Controls.Add(FireSupportlink);
            ModtabPage2.Controls.Add(FireSupportBox);
            ModtabPage2.Location = new Point(4, 44);
            ModtabPage2.Name = "ModtabPage2";
            ModtabPage2.Padding = new Padding(3);
            ModtabPage2.Size = new Size(435, 270);
            ModtabPage2.TabIndex = 1;
            ModtabPage2.Text = "2페이지";
            ModtabPage2.UseVisualStyleBackColor = true;
            // 
            // Bloodylink
            // 
            Bloodylink.AutoSize = true;
            Bloodylink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Bloodylink.LinkColor = Color.Black;
            Bloodylink.Location = new Point(40, 111);
            Bloodylink.Name = "Bloodylink";
            Bloodylink.Size = new Size(254, 42);
            Bloodylink.TabIndex = 85;
            Bloodylink.TabStop = true;
            Bloodylink.Text = "Borkel's Bloody Bullet Wounds +\r\nParticles + Splatters";
            // 
            // BloodyBox
            // 
            BloodyBox.AutoSize = true;
            BloodyBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BloodyBox.Location = new Point(19, 117);
            BloodyBox.Name = "BloodyBox";
            BloodyBox.Size = new Size(15, 14);
            BloodyBox.TabIndex = 84;
            BloodyBox.UseVisualStyleBackColor = true;
            // 
            // WeaponBuildinglink
            // 
            WeaponBuildinglink.AutoSize = true;
            WeaponBuildinglink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            WeaponBuildinglink.LinkColor = Color.Black;
            WeaponBuildinglink.Location = new Point(40, 56);
            WeaponBuildinglink.Name = "WeaponBuildinglink";
            WeaponBuildinglink.Size = new Size(213, 42);
            WeaponBuildinglink.TabIndex = 83;
            WeaponBuildinglink.TabStop = true;
            WeaponBuildinglink.Text = "Trader Modding and \r\nImproved Weapon Building";
            // 
            // ModdingBox
            // 
            ModdingBox.AutoSize = true;
            ModdingBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            ModdingBox.Location = new Point(19, 62);
            ModdingBox.Name = "ModdingBox";
            ModdingBox.Size = new Size(15, 14);
            ModdingBox.TabIndex = 82;
            ModdingBox.UseVisualStyleBackColor = true;
            // 
            // FireSupportlink
            // 
            FireSupportlink.AutoSize = true;
            FireSupportlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            FireSupportlink.LinkColor = Color.Black;
            FireSupportlink.Location = new Point(40, 21);
            FireSupportlink.Name = "FireSupportlink";
            FireSupportlink.Size = new Size(195, 21);
            FireSupportlink.TabIndex = 75;
            FireSupportlink.TabStop = true;
            FireSupportlink.Text = "SamSWAT's Fire Support";
            // 
            // FireSupportBox
            // 
            FireSupportBox.AutoSize = true;
            FireSupportBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            FireSupportBox.Location = new Point(19, 27);
            FireSupportBox.Name = "FireSupportBox";
            FireSupportBox.Size = new Size(15, 14);
            FireSupportBox.TabIndex = 74;
            FireSupportBox.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ButtonHighlight;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(Texture4Klink);
            panel4.Controls.Add(SPTTexDefaultBtn);
            panel4.Controls.Add(SPTTex4096Btn);
            panel4.Controls.Add(TextureKRlink);
            panel4.Controls.Add(SPTTexKRBox);
            panel4.Controls.Add(LogoKRlink);
            panel4.Controls.Add(SPTLogoKRBox);
            panel4.Controls.Add(SPTKRlink);
            panel4.Controls.Add(SPTKRBox);
            panel4.Location = new Point(156, 64);
            panel4.Name = "panel4";
            panel4.Size = new Size(638, 110);
            panel4.TabIndex = 8;
            // 
            // Texture4Klink
            // 
            Texture4Klink.AutoSize = true;
            Texture4Klink.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Texture4Klink.LinkColor = Color.Black;
            Texture4Klink.Location = new Point(513, 48);
            Texture4Klink.Name = "Texture4Klink";
            Texture4Klink.Size = new Size(84, 40);
            Texture4Klink.TabIndex = 94;
            Texture4Klink.TabStop = true;
            Texture4Klink.Text = "4K 버전\r\n(수동 설치)";
            // 
            // SPTTexDefaultBtn
            // 
            SPTTexDefaultBtn.AutoSize = true;
            SPTTexDefaultBtn.Enabled = false;
            SPTTexDefaultBtn.Font = new Font("맑은 고딕", 11.25F);
            SPTTexDefaultBtn.Location = new Point(493, 21);
            SPTTexDefaultBtn.Name = "SPTTexDefaultBtn";
            SPTTexDefaultBtn.Size = new Size(92, 24);
            SPTTexDefaultBtn.TabIndex = 93;
            SPTTexDefaultBtn.TabStop = true;
            SPTTexDefaultBtn.Text = "기본 버전";
            SPTTexDefaultBtn.UseVisualStyleBackColor = true;
            // 
            // SPTTex4096Btn
            // 
            SPTTex4096Btn.AutoSize = true;
            SPTTex4096Btn.Enabled = false;
            SPTTex4096Btn.Font = new Font("맑은 고딕", 11.25F);
            SPTTex4096Btn.Location = new Point(493, 62);
            SPTTex4096Btn.Name = "SPTTex4096Btn";
            SPTTex4096Btn.Size = new Size(14, 13);
            SPTTex4096Btn.TabIndex = 92;
            SPTTex4096Btn.TabStop = true;
            SPTTex4096Btn.UseVisualStyleBackColor = true;
            // 
            // TextureKRlink
            // 
            TextureKRlink.AutoSize = true;
            TextureKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            TextureKRlink.LinkColor = Color.Black;
            TextureKRlink.Location = new Point(348, 21);
            TextureKRlink.Name = "TextureKRlink";
            TextureKRlink.Size = new Size(128, 63);
            TextureKRlink.TabIndex = 91;
            TextureKRlink.TabStop = true;
            TextureKRlink.Text = "SPT 타르코프 \r\n아이템 텍스처 \r\n한글화 프로젝트";
            // 
            // SPTTexKRBox
            // 
            SPTTexKRBox.AutoSize = true;
            SPTTexKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            SPTTexKRBox.Location = new Point(327, 27);
            SPTTexKRBox.Name = "SPTTexKRBox";
            SPTTexKRBox.Size = new Size(15, 14);
            SPTTexKRBox.TabIndex = 90;
            SPTTexKRBox.UseVisualStyleBackColor = true;
            SPTTexKRBox.CheckedChanged += SPTTexKRBox_CheckedChanged;
            // 
            // LogoKRlink
            // 
            LogoKRlink.AutoSize = true;
            LogoKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            LogoKRlink.LinkColor = Color.Black;
            LogoKRlink.Location = new Point(206, 33);
            LogoKRlink.Name = "LogoKRlink";
            LogoKRlink.Size = new Size(96, 42);
            LogoKRlink.TabIndex = 89;
            LogoKRlink.TabStop = true;
            LogoKRlink.Text = "타르코프 \r\n로고 한글화";
            // 
            // SPTLogoKRBox
            // 
            SPTLogoKRBox.AutoSize = true;
            SPTLogoKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            SPTLogoKRBox.Location = new Point(185, 39);
            SPTLogoKRBox.Name = "SPTLogoKRBox";
            SPTLogoKRBox.Size = new Size(15, 14);
            SPTLogoKRBox.TabIndex = 88;
            SPTLogoKRBox.UseVisualStyleBackColor = true;
            // 
            // SPTKRlink
            // 
            SPTKRlink.AutoSize = true;
            SPTKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            SPTKRlink.LinkColor = Color.Black;
            SPTKRlink.Location = new Point(39, 33);
            SPTKRlink.Name = "SPTKRlink";
            SPTKRlink.Size = new Size(128, 42);
            SPTKRlink.TabIndex = 87;
            SPTKRlink.TabStop = true;
            SPTKRlink.Text = "SPT 타르코프 \r\n한글화 프로젝트";
            // 
            // SPTKRBox
            // 
            SPTKRBox.AutoSize = true;
            SPTKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            SPTKRBox.Location = new Point(18, 39);
            SPTKRBox.Name = "SPTKRBox";
            SPTKRBox.Size = new Size(15, 14);
            SPTKRBox.TabIndex = 86;
            SPTKRBox.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(KRtabControl);
            panel3.Location = new Point(470, 224);
            panel3.Name = "panel3";
            panel3.Size = new Size(445, 320);
            panel3.TabIndex = 7;
            // 
            // KRtabControl
            // 
            KRtabControl.Controls.Add(KRtabPage1);
            KRtabControl.Controls.Add(KRtabPage2);
            KRtabControl.Dock = DockStyle.Fill;
            KRtabControl.ItemSize = new Size(55, 40);
            KRtabControl.Location = new Point(0, 0);
            KRtabControl.Name = "KRtabControl";
            KRtabControl.SelectedIndex = 0;
            KRtabControl.Size = new Size(443, 318);
            KRtabControl.TabIndex = 0;
            // 
            // KRtabPage1
            // 
            KRtabPage1.Controls.Add(A_IndicatorKRlink);
            KRtabPage1.Controls.Add(AudioKRBox);
            KRtabPage1.Controls.Add(G_IndicatorKRlink);
            KRtabPage1.Controls.Add(GrenadeKRBox);
            KRtabPage1.Controls.Add(TrainerKRlink);
            KRtabPage1.Controls.Add(TrainerKRBox);
            KRtabPage1.Controls.Add(DadGamerKRlink);
            KRtabPage1.Controls.Add(DadGamerKRBox);
            KRtabPage1.Controls.Add(FovKRlink);
            KRtabPage1.Controls.Add(FOVFixKRBox);
            KRtabPage1.Controls.Add(NotifierKRlink);
            KRtabPage1.Controls.Add(NotifierKRBox);
            KRtabPage1.Controls.Add(ClutterKRlink);
            KRtabPage1.Controls.Add(CluttererKRBox);
            KRtabPage1.Controls.Add(HudKRlink);
            KRtabPage1.Controls.Add(HudKRBox);
            KRtabPage1.Controls.Add(GraphicsKRlink);
            KRtabPage1.Controls.Add(GraphicsKRBox);
            KRtabPage1.Controls.Add(MapKRlink);
            KRtabPage1.Controls.Add(MapsKRBox);
            KRtabPage1.Controls.Add(QuestingKRlink);
            KRtabPage1.Controls.Add(QuestingBotsKRBox);
            KRtabPage1.Controls.Add(RealisemKRlink);
            KRtabPage1.Controls.Add(RealismKRBox);
            KRtabPage1.Controls.Add(DonutKRlink);
            KRtabPage1.Controls.Add(DonutKRBox);
            KRtabPage1.Controls.Add(SainKRlink);
            KRtabPage1.Controls.Add(SAINKRBox);
            KRtabPage1.Location = new Point(4, 44);
            KRtabPage1.Name = "KRtabPage1";
            KRtabPage1.Padding = new Padding(3);
            KRtabPage1.Size = new Size(435, 270);
            KRtabPage1.TabIndex = 0;
            KRtabPage1.Text = "1페이지";
            KRtabPage1.UseVisualStyleBackColor = true;
            // 
            // A_IndicatorKRlink
            // 
            A_IndicatorKRlink.AutoSize = true;
            A_IndicatorKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            A_IndicatorKRlink.LinkColor = Color.Black;
            A_IndicatorKRlink.Location = new Point(253, 223);
            A_IndicatorKRlink.Name = "A_IndicatorKRlink";
            A_IndicatorKRlink.Size = new Size(150, 42);
            A_IndicatorKRlink.TabIndex = 93;
            A_IndicatorKRlink.TabStop = true;
            A_IndicatorKRlink.Text = "Audio Accessibility\r\nIndicators - KR";
            // 
            // AudioKRBox
            // 
            AudioKRBox.AutoSize = true;
            AudioKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            AudioKRBox.Location = new Point(232, 229);
            AudioKRBox.Name = "AudioKRBox";
            AudioKRBox.Size = new Size(15, 14);
            AudioKRBox.TabIndex = 92;
            AudioKRBox.UseVisualStyleBackColor = true;
            // 
            // G_IndicatorKRlink
            // 
            G_IndicatorKRlink.AutoSize = true;
            G_IndicatorKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            G_IndicatorKRlink.LinkColor = Color.Black;
            G_IndicatorKRlink.Location = new Point(30, 193);
            G_IndicatorKRlink.Name = "G_IndicatorKRlink";
            G_IndicatorKRlink.Size = new Size(181, 21);
            G_IndicatorKRlink.TabIndex = 63;
            G_IndicatorKRlink.TabStop = true;
            G_IndicatorKRlink.Text = "Grenade Indicator - KR";
            // 
            // GrenadeKRBox
            // 
            GrenadeKRBox.AutoSize = true;
            GrenadeKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            GrenadeKRBox.Location = new Point(9, 199);
            GrenadeKRBox.Name = "GrenadeKRBox";
            GrenadeKRBox.Size = new Size(15, 14);
            GrenadeKRBox.TabIndex = 62;
            GrenadeKRBox.UseVisualStyleBackColor = true;
            // 
            // TrainerKRlink
            // 
            TrainerKRlink.AutoSize = true;
            TrainerKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            TrainerKRlink.LinkColor = Color.Black;
            TrainerKRlink.Location = new Point(253, 192);
            TrainerKRlink.Name = "TrainerKRlink";
            TrainerKRlink.Size = new Size(167, 21);
            TrainerKRlink.TabIndex = 61;
            TrainerKRlink.TabStop = true;
            TrainerKRlink.Text = "Personal Trainer - KR";
            // 
            // TrainerKRBox
            // 
            TrainerKRBox.AutoSize = true;
            TrainerKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            TrainerKRBox.Location = new Point(232, 198);
            TrainerKRBox.Name = "TrainerKRBox";
            TrainerKRBox.Size = new Size(15, 14);
            TrainerKRBox.TabIndex = 60;
            TrainerKRBox.UseVisualStyleBackColor = true;
            // 
            // DadGamerKRlink
            // 
            DadGamerKRlink.AutoSize = true;
            DadGamerKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            DadGamerKRlink.LinkColor = Color.Black;
            DadGamerKRlink.Location = new Point(30, 163);
            DadGamerKRlink.Name = "DadGamerKRlink";
            DadGamerKRlink.Size = new Size(181, 21);
            DadGamerKRlink.TabIndex = 59;
            DadGamerKRlink.TabStop = true;
            DadGamerKRlink.Text = "Dad Gamer Mode - KR";
            // 
            // DadGamerKRBox
            // 
            DadGamerKRBox.AutoSize = true;
            DadGamerKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            DadGamerKRBox.Location = new Point(9, 169);
            DadGamerKRBox.Name = "DadGamerKRBox";
            DadGamerKRBox.Size = new Size(15, 14);
            DadGamerKRBox.TabIndex = 58;
            DadGamerKRBox.UseVisualStyleBackColor = true;
            // 
            // FovKRlink
            // 
            FovKRlink.AutoSize = true;
            FovKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            FovKRlink.LinkColor = Color.Black;
            FovKRlink.Location = new Point(253, 160);
            FovKRlink.Name = "FovKRlink";
            FovKRlink.Size = new Size(183, 21);
            FovKRlink.TabIndex = 57;
            FovKRlink.TabStop = true;
            FovKRlink.Text = "Fontaine's FOV Fix - KR";
            // 
            // FOVFixKRBox
            // 
            FOVFixKRBox.AutoSize = true;
            FOVFixKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            FOVFixKRBox.Location = new Point(232, 166);
            FOVFixKRBox.Name = "FOVFixKRBox";
            FOVFixKRBox.Size = new Size(15, 14);
            FOVFixKRBox.TabIndex = 56;
            FOVFixKRBox.UseVisualStyleBackColor = true;
            // 
            // NotifierKRlink
            // 
            NotifierKRlink.AutoSize = true;
            NotifierKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            NotifierKRlink.LinkColor = Color.Black;
            NotifierKRlink.Location = new Point(30, 131);
            NotifierKRlink.Name = "NotifierKRlink";
            NotifierKRlink.Size = new Size(143, 21);
            NotifierKRlink.TabIndex = 55;
            NotifierKRlink.TabStop = true;
            NotifierKRlink.Text = "Boss Notifier - KR";
            // 
            // NotifierKRBox
            // 
            NotifierKRBox.AutoSize = true;
            NotifierKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            NotifierKRBox.Location = new Point(9, 137);
            NotifierKRBox.Name = "NotifierKRBox";
            NotifierKRBox.Size = new Size(15, 14);
            NotifierKRBox.TabIndex = 54;
            NotifierKRBox.UseVisualStyleBackColor = true;
            // 
            // ClutterKRlink
            // 
            ClutterKRlink.AutoSize = true;
            ClutterKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            ClutterKRlink.LinkColor = Color.Black;
            ClutterKRlink.Location = new Point(253, 130);
            ClutterKRlink.Name = "ClutterKRlink";
            ClutterKRlink.Size = new Size(140, 21);
            ClutterKRlink.TabIndex = 53;
            ClutterKRlink.TabStop = true;
            ClutterKRlink.Text = "De-Clutterer - KR";
            // 
            // CluttererKRBox
            // 
            CluttererKRBox.AutoSize = true;
            CluttererKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            CluttererKRBox.Location = new Point(232, 136);
            CluttererKRBox.Name = "CluttererKRBox";
            CluttererKRBox.Size = new Size(15, 14);
            CluttererKRBox.TabIndex = 52;
            CluttererKRBox.UseVisualStyleBackColor = true;
            // 
            // HudKRlink
            // 
            HudKRlink.AutoSize = true;
            HudKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            HudKRlink.LinkColor = Color.Black;
            HudKRlink.Location = new Point(30, 101);
            HudKRlink.Name = "HudKRlink";
            HudKRlink.Size = new Size(181, 21);
            HudKRlink.TabIndex = 51;
            HudKRlink.TabStop = true;
            HudKRlink.Text = "Game Pannel Hud - KR";
            // 
            // HudKRBox
            // 
            HudKRBox.AutoSize = true;
            HudKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            HudKRBox.Location = new Point(9, 107);
            HudKRBox.Name = "HudKRBox";
            HudKRBox.Size = new Size(15, 14);
            HudKRBox.TabIndex = 50;
            HudKRBox.UseVisualStyleBackColor = true;
            // 
            // GraphicsKRlink
            // 
            GraphicsKRlink.AutoSize = true;
            GraphicsKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            GraphicsKRlink.LinkColor = Color.Black;
            GraphicsKRlink.Location = new Point(253, 97);
            GraphicsKRlink.Name = "GraphicsKRlink";
            GraphicsKRlink.Size = new Size(177, 21);
            GraphicsKRlink.TabIndex = 49;
            GraphicsKRlink.TabStop = true;
            GraphicsKRlink.Text = "Amanda Graphics - KR";
            // 
            // GraphicsKRBox
            // 
            GraphicsKRBox.AutoSize = true;
            GraphicsKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            GraphicsKRBox.Location = new Point(232, 103);
            GraphicsKRBox.Name = "GraphicsKRBox";
            GraphicsKRBox.Size = new Size(15, 14);
            GraphicsKRBox.TabIndex = 48;
            GraphicsKRBox.UseVisualStyleBackColor = true;
            // 
            // MapKRlink
            // 
            MapKRlink.AutoSize = true;
            MapKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            MapKRlink.LinkColor = Color.Black;
            MapKRlink.Location = new Point(30, 68);
            MapKRlink.Name = "MapKRlink";
            MapKRlink.Size = new Size(156, 21);
            MapKRlink.TabIndex = 47;
            MapKRlink.TabStop = true;
            MapKRlink.Text = "Dynamic Maps - KR";
            // 
            // MapsKRBox
            // 
            MapsKRBox.AutoSize = true;
            MapsKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            MapsKRBox.Location = new Point(9, 74);
            MapsKRBox.Name = "MapsKRBox";
            MapsKRBox.Size = new Size(15, 14);
            MapsKRBox.TabIndex = 46;
            MapsKRBox.UseVisualStyleBackColor = true;
            // 
            // QuestingKRlink
            // 
            QuestingKRlink.AutoSize = true;
            QuestingKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            QuestingKRlink.LinkColor = Color.Black;
            QuestingKRlink.Location = new Point(253, 65);
            QuestingKRlink.Name = "QuestingKRlink";
            QuestingKRlink.Size = new Size(152, 21);
            QuestingKRlink.TabIndex = 45;
            QuestingKRlink.TabStop = true;
            QuestingKRlink.Text = "Questing Bots - KR";
            // 
            // QuestingBotsKRBox
            // 
            QuestingBotsKRBox.AutoSize = true;
            QuestingBotsKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            QuestingBotsKRBox.Location = new Point(232, 71);
            QuestingBotsKRBox.Name = "QuestingBotsKRBox";
            QuestingBotsKRBox.Size = new Size(15, 14);
            QuestingBotsKRBox.TabIndex = 44;
            QuestingBotsKRBox.UseVisualStyleBackColor = true;
            // 
            // RealisemKRlink
            // 
            RealisemKRlink.AutoSize = true;
            RealisemKRlink.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            RealisemKRlink.LinkColor = Color.Black;
            RealisemKRlink.Location = new Point(30, 36);
            RealisemKRlink.Name = "RealisemKRlink";
            RealisemKRlink.Size = new Size(143, 34);
            RealisemKRlink.TabIndex = 43;
            RealisemKRlink.TabStop = true;
            RealisemKRlink.Text = "SPT Realism Mod - KR\r\n(수동 설치)";
            // 
            // RealismKRBox
            // 
            RealismKRBox.AutoSize = true;
            RealismKRBox.Enabled = false;
            RealismKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            RealismKRBox.Location = new Point(9, 42);
            RealismKRBox.Name = "RealismKRBox";
            RealismKRBox.Size = new Size(15, 14);
            RealismKRBox.TabIndex = 42;
            RealismKRBox.UseVisualStyleBackColor = true;
            // 
            // DonutKRlink
            // 
            DonutKRlink.AutoSize = true;
            DonutKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            DonutKRlink.LinkColor = Color.Black;
            DonutKRlink.Location = new Point(253, 6);
            DonutKRlink.Name = "DonutKRlink";
            DonutKRlink.Size = new Size(93, 21);
            DonutKRlink.TabIndex = 41;
            DonutKRlink.TabStop = true;
            DonutKRlink.Text = "Donut - KR";
            // 
            // DonutKRBox
            // 
            DonutKRBox.AutoSize = true;
            DonutKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            DonutKRBox.Location = new Point(232, 12);
            DonutKRBox.Name = "DonutKRBox";
            DonutKRBox.Size = new Size(15, 14);
            DonutKRBox.TabIndex = 40;
            DonutKRBox.UseVisualStyleBackColor = true;
            // 
            // SainKRlink
            // 
            SainKRlink.AutoSize = true;
            SainKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            SainKRlink.LinkColor = Color.Black;
            SainKRlink.Location = new Point(30, 6);
            SainKRlink.Name = "SainKRlink";
            SainKRlink.Size = new Size(84, 21);
            SainKRlink.TabIndex = 39;
            SainKRlink.TabStop = true;
            SainKRlink.Text = "SAIN - KR";
            // 
            // SAINKRBox
            // 
            SAINKRBox.AutoSize = true;
            SAINKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            SAINKRBox.Location = new Point(9, 12);
            SAINKRBox.Name = "SAINKRBox";
            SAINKRBox.Size = new Size(15, 14);
            SAINKRBox.TabIndex = 38;
            SAINKRBox.UseVisualStyleBackColor = true;
            // 
            // KRtabPage2
            // 
            KRtabPage2.Controls.Add(BloodyKRlink);
            KRtabPage2.Controls.Add(BloodyKRBox);
            KRtabPage2.Controls.Add(WeaponBuildingKRlink);
            KRtabPage2.Controls.Add(ModdingKRBox);
            KRtabPage2.Controls.Add(ViscreralKRlink);
            KRtabPage2.Controls.Add(VisceralBox);
            KRtabPage2.Controls.Add(FireSupportKRlink);
            KRtabPage2.Controls.Add(FireSupportKRBox);
            KRtabPage2.Location = new Point(4, 44);
            KRtabPage2.Name = "KRtabPage2";
            KRtabPage2.Padding = new Padding(3);
            KRtabPage2.Size = new Size(435, 270);
            KRtabPage2.TabIndex = 1;
            KRtabPage2.Text = "2페이지";
            KRtabPage2.UseVisualStyleBackColor = true;
            // 
            // BloodyKRlink
            // 
            BloodyKRlink.AutoSize = true;
            BloodyKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BloodyKRlink.LinkColor = Color.Black;
            BloodyKRlink.Location = new Point(31, 95);
            BloodyKRlink.Name = "BloodyKRlink";
            BloodyKRlink.Size = new Size(254, 42);
            BloodyKRlink.TabIndex = 87;
            BloodyKRlink.TabStop = true;
            BloodyKRlink.Text = "Borkel's Bloody Bullet Wounds +\r\nParticles + Splatters - KR";
            // 
            // BloodyKRBox
            // 
            BloodyKRBox.AutoSize = true;
            BloodyKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BloodyKRBox.Location = new Point(10, 101);
            BloodyKRBox.Name = "BloodyKRBox";
            BloodyKRBox.Size = new Size(15, 14);
            BloodyKRBox.TabIndex = 86;
            BloodyKRBox.UseVisualStyleBackColor = true;
            // 
            // WeaponBuildingKRlink
            // 
            WeaponBuildingKRlink.AutoSize = true;
            WeaponBuildingKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            WeaponBuildingKRlink.LinkColor = Color.Black;
            WeaponBuildingKRlink.Location = new Point(34, 46);
            WeaponBuildingKRlink.Name = "WeaponBuildingKRlink";
            WeaponBuildingKRlink.Size = new Size(251, 42);
            WeaponBuildingKRlink.TabIndex = 89;
            WeaponBuildingKRlink.TabStop = true;
            WeaponBuildingKRlink.Text = "Trader Modding and \r\nImproved Weapon Building - KR\r\n";
            // 
            // ModdingKRBox
            // 
            ModdingKRBox.AutoSize = true;
            ModdingKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            ModdingKRBox.Location = new Point(13, 52);
            ModdingKRBox.Name = "ModdingKRBox";
            ModdingKRBox.Size = new Size(15, 14);
            ModdingKRBox.TabIndex = 88;
            ModdingKRBox.UseVisualStyleBackColor = true;
            // 
            // ViscreralKRlink
            // 
            ViscreralKRlink.AutoSize = true;
            ViscreralKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            ViscreralKRlink.LinkColor = Color.Black;
            ViscreralKRlink.Location = new Point(31, 146);
            ViscreralKRlink.Name = "ViscreralKRlink";
            ViscreralKRlink.Size = new Size(237, 42);
            ViscreralKRlink.TabIndex = 87;
            ViscreralKRlink.TabStop = true;
            ViscreralKRlink.Text = "Visceral Dismemberment\r\n(포팅 - 한글화 포함, 수동 설치)";
            // 
            // VisceralBox
            // 
            VisceralBox.AutoSize = true;
            VisceralBox.Enabled = false;
            VisceralBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            VisceralBox.Location = new Point(10, 152);
            VisceralBox.Name = "VisceralBox";
            VisceralBox.Size = new Size(15, 14);
            VisceralBox.TabIndex = 86;
            VisceralBox.UseVisualStyleBackColor = true;
            // 
            // FireSupportKRlink
            // 
            FireSupportKRlink.AutoSize = true;
            FireSupportKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            FireSupportKRlink.LinkColor = Color.Black;
            FireSupportKRlink.Location = new Point(34, 4);
            FireSupportKRlink.Name = "FireSupportKRlink";
            FireSupportKRlink.Size = new Size(233, 21);
            FireSupportKRlink.TabIndex = 85;
            FireSupportKRlink.TabStop = true;
            FireSupportKRlink.Text = "SamSWAT's Fire Support - KR";
            // 
            // FireSupportKRBox
            // 
            FireSupportKRBox.AutoSize = true;
            FireSupportKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            FireSupportKRBox.Location = new Point(13, 10);
            FireSupportKRBox.Name = "FireSupportKRBox";
            FireSupportKRBox.Size = new Size(15, 14);
            FireSupportKRBox.TabIndex = 84;
            FireSupportKRBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.Location = new Point(21, 190);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 9;
            label1.Text = "원본 모드";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label2.Location = new Point(475, 190);
            label2.Name = "label2";
            label2.Size = new Size(114, 25);
            label2.TabIndex = 10;
            label2.Text = "한글화 모드";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label3.Location = new Point(158, 36);
            label3.Name = "label3";
            label3.Size = new Size(110, 25);
            label3.TabIndex = 11;
            label3.Text = "SPT 한글화";
            // 
            // InstallModPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Control;
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(0);
            Name = "InstallModPage";
            Size = new Size(934, 661);
            Load += InstallModPage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ModtabControl.ResumeLayout(false);
            ModtabPage1.ResumeLayout(false);
            ModtabPage1.PerformLayout();
            ModtabPage2.ResumeLayout(false);
            ModtabPage2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            KRtabControl.ResumeLayout(false);
            KRtabPage1.ResumeLayout(false);
            KRtabPage1.PerformLayout();
            KRtabPage2.ResumeLayout(false);
            KRtabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button LinkBtn;
        private TextBox LinkBox;
        private Button InstallBtn;
        private Panel panel1;
        private TextBox InstallLogBox;
        private Panel panel2;
        private Panel panel4;
        private TabControl ModtabControl;
        private TabPage ModtabPage1;
        private LinkLabel Trainerlink;
        private CheckBox TrainerBox;
        private LinkLabel DadGamerlink;
        private CheckBox DadGamerBox;
        private LinkLabel Fovlink;
        private CheckBox FOVFixBox;
        private LinkLabel Notifierlink;
        private CheckBox NotifierBox;
        private LinkLabel Clutterlink;
        private CheckBox CluttererBox;
        private LinkLabel Hudlink;
        private CheckBox HudBox;
        private LinkLabel Graphicslink;
        private CheckBox GraphicsBox;
        private LinkLabel Maplink;
        private CheckBox MapsBox;
        private LinkLabel Questinglink;
        private CheckBox QuestingBotsBox;
        private LinkLabel Realisemlink;
        private CheckBox RealismBox;
        private LinkLabel Donutlink;
        private CheckBox DonutBox;
        private LinkLabel Sainlink;
        private CheckBox SAINBox;
        private TabPage ModtabPage2;
        private CheckBox checkBox26;
        private LinkLabel G_Indicatorlink;
        private CheckBox GrenadeBox;
        private CheckBox checkBox30;
        private LinkLabel A_Indicatorlink;
        private CheckBox AudioBox;
        private Panel panel3;
        private TabControl KRtabControl;
        private TabPage KRtabPage1;
        private TabPage KRtabPage2;
        private LinkLabel A_IndicatorKRlink;
        private CheckBox AudioKRBox;
        private LinkLabel G_IndicatorKRlink;
        private CheckBox GrenadeKRBox;
        private LinkLabel TrainerKRlink;
        private CheckBox TrainerKRBox;
        private LinkLabel DadGamerKRlink;
        private CheckBox DadGamerKRBox;
        private LinkLabel FovKRlink;
        private CheckBox FOVFixKRBox;
        private LinkLabel NotifierKRlink;
        private CheckBox NotifierKRBox;
        private LinkLabel ClutterKRlink;
        private CheckBox CluttererKRBox;
        private LinkLabel HudKRlink;
        private CheckBox HudKRBox;
        private LinkLabel GraphicsKRlink;
        private CheckBox GraphicsKRBox;
        private LinkLabel MapKRlink;
        private CheckBox MapsKRBox;
        private LinkLabel QuestingKRlink;
        private CheckBox QuestingBotsKRBox;
        private LinkLabel RealisemKRlink;
        private CheckBox RealismKRBox;
        private LinkLabel DonutKRlink;
        private CheckBox DonutKRBox;
        private LinkLabel SainKRlink;
        private CheckBox SAINKRBox;
        private LinkLabel Contentlink;
        private CheckBox ContextMenuBox;
        private LinkLabel WeaponBuildinglink;
        private CheckBox ModdingBox;
        private LinkLabel FireSupportlink;
        private CheckBox FireSupportBox;
        private LinkLabel WeaponBuildingKRlink;
        private CheckBox ModdingKRBox;
        private LinkLabel ViscreralKRlink;
        private CheckBox VisceralBox;
        private LinkLabel FireSupportKRlink;
        private CheckBox FireSupportKRBox;
        private LinkLabel Bloodylink;
        private CheckBox BloodyBox;
        private LinkLabel BloodyKRlink;
        private CheckBox BloodyKRBox;
        private Label label1;
        private Label label2;
        private LinkLabel TextureKRlink;
        private CheckBox SPTTexKRBox;
        private LinkLabel LogoKRlink;
        private CheckBox SPTLogoKRBox;
        private LinkLabel SPTKRlink;
        private CheckBox SPTKRBox;
        private Label label3;
        private RadioButton SPTTexDefaultBtn;
        private RadioButton SPTTex4096Btn;
        private LinkLabel Texture4Klink;
        private LinkLabel linkLabel1;
        private CheckBox SVMBox;
    }
}
