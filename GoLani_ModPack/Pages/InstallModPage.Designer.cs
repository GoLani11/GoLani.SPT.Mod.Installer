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
            label23 = new Label();
            UIlink = new LinkLabel();
            UIBox = new CheckBox();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            SVMlink = new LinkLabel();
            SVMBox = new CheckBox();
            A_Indicatorlink = new LinkLabel();
            AudioBox = new CheckBox();
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
            label11 = new Label();
            Contentlink = new LinkLabel();
            ContextMenuBox = new CheckBox();
            label22 = new Label();
            label21 = new Label();
            label20 = new Label();
            Bloodylink = new LinkLabel();
            BloodyBox = new CheckBox();
            WeaponBuildinglink = new LinkLabel();
            ModdingBox = new CheckBox();
            ViscreralKRlink = new LinkLabel();
            VisceralBox = new CheckBox();
            FireSupportlink = new LinkLabel();
            FireSupportBox = new CheckBox();
            panel4 = new Panel();
            SPTTexDefaultBox = new CheckBox();
            SPTTex4096Box = new CheckBox();
            TextureKRlink = new LinkLabel();
            SPTTexKRBox = new CheckBox();
            LogoKRlink = new LinkLabel();
            SPTLogoKRBox = new CheckBox();
            SPTKRlink = new LinkLabel();
            SPTKRBox = new CheckBox();
            panel3 = new Panel();
            KRtabControl = new TabControl();
            KRtabPage1 = new TabPage();
            UIKRlink = new LinkLabel();
            UIKRBox = new CheckBox();
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
            LinkBtn.Location = new Point(69, 6);
            LinkBtn.Name = "LinkBtn";
            LinkBtn.Size = new Size(88, 51);
            LinkBtn.TabIndex = 2;
            LinkBtn.Text = "경로";
            LinkBtn.UseVisualStyleBackColor = true;
            LinkBtn.Click += LinkBtn_Click;
            // 
            // LinkBox
            // 
            LinkBox.Location = new Point(163, 6);
            LinkBox.Name = "LinkBox";
            LinkBox.ReadOnly = true;
            LinkBox.Size = new Size(631, 23);
            LinkBox.TabIndex = 3;
            LinkBox.Text = "SPT 폴더를 지정해주세요. ex) C:\\SPT\r\n";
            // 
            // InstallBtn
            // 
            InstallBtn.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            InstallBtn.Location = new Point(803, 6);
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
            InstallLogBox.Location = new Point(163, 35);
            InstallLogBox.Multiline = true;
            InstallLogBox.Name = "InstallLogBox";
            InstallLogBox.ReadOnly = true;
            InstallLogBox.ScrollBars = ScrollBars.Vertical;
            InstallLogBox.Size = new Size(631, 73);
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
            ModtabPage1.Controls.Add(label23);
            ModtabPage1.Controls.Add(UIlink);
            ModtabPage1.Controls.Add(UIBox);
            ModtabPage1.Controls.Add(label19);
            ModtabPage1.Controls.Add(label18);
            ModtabPage1.Controls.Add(label17);
            ModtabPage1.Controls.Add(label16);
            ModtabPage1.Controls.Add(label15);
            ModtabPage1.Controls.Add(label14);
            ModtabPage1.Controls.Add(label13);
            ModtabPage1.Controls.Add(label12);
            ModtabPage1.Controls.Add(label10);
            ModtabPage1.Controls.Add(label9);
            ModtabPage1.Controls.Add(label8);
            ModtabPage1.Controls.Add(label7);
            ModtabPage1.Controls.Add(label6);
            ModtabPage1.Controls.Add(label5);
            ModtabPage1.Controls.Add(label4);
            ModtabPage1.Controls.Add(SVMlink);
            ModtabPage1.Controls.Add(SVMBox);
            ModtabPage1.Controls.Add(A_Indicatorlink);
            ModtabPage1.Controls.Add(AudioBox);
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
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(99, 72);
            label23.Name = "label23";
            label23.Size = new Size(34, 15);
            label23.TabIndex = 112;
            label23.Text = "2.5.3";
            // 
            // UIlink
            // 
            UIlink.AutoSize = true;
            UIlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            UIlink.LinkColor = Color.Black;
            UIlink.Location = new Point(27, 67);
            UIlink.Name = "UIlink";
            UIlink.Size = new Size(66, 21);
            UIlink.TabIndex = 111;
            UIlink.TabStop = true;
            UIlink.Text = "UI Fixes";
            UIlink.LinkClicked += UIlink_LinkClicked;
            // 
            // UIBox
            // 
            UIBox.AutoSize = true;
            UIBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            UIBox.Location = new Point(6, 73);
            UIBox.Name = "UIBox";
            UIBox.Size = new Size(15, 14);
            UIBox.TabIndex = 110;
            UIBox.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(345, 252);
            label19.Name = "label19";
            label19.Size = new Size(34, 15);
            label19.TabIndex = 109;
            label19.Text = "1.2.0";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(385, 199);
            label18.Name = "label18";
            label18.Size = new Size(34, 15);
            label18.TabIndex = 108;
            label18.Text = "1.1.1";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(395, 167);
            label17.Name = "label17";
            label17.Size = new Size(34, 15);
            label17.TabIndex = 107;
            label17.Text = "2.1.8";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(358, 137);
            label16.Name = "label16";
            label16.Size = new Size(34, 15);
            label16.TabIndex = 106;
            label16.Text = "1.2.4";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(395, 104);
            label15.Name = "label15";
            label15.Size = new Size(34, 15);
            label15.TabIndex = 105;
            label15.Text = "1.6.3";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(370, 72);
            label14.Name = "label14";
            label14.Size = new Size(34, 15);
            label14.TabIndex = 104;
            label14.Text = "0.8.1";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(395, 41);
            label13.Name = "label13";
            label13.Size = new Size(34, 15);
            label13.TabIndex = 103;
            label13.Text = "1.9.1";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(311, 11);
            label12.Name = "label12";
            label12.Size = new Size(34, 15);
            label12.TabIndex = 102;
            label12.Text = "3.5.1";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(172, 231);
            label10.Name = "label10";
            label10.Size = new Size(34, 15);
            label10.TabIndex = 100;
            label10.Text = "1.0.0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(172, 199);
            label9.Name = "label9";
            label9.Size = new Size(34, 15);
            label9.TabIndex = 99;
            label9.Text = "1.9.3";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(132, 167);
            label8.Name = "label8";
            label8.Size = new Size(34, 15);
            label8.TabIndex = 98;
            label8.Text = "1.5.1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(172, 137);
            label7.Name = "label7";
            label7.Size = new Size(34, 15);
            label7.TabIndex = 97;
            label7.Text = "3.1.1";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(149, 104);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 96;
            label6.Text = "0.5.0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(172, 42);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 95;
            label5.Text = "1.4.8";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(79, 13);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 94;
            label4.Text = "3.1.0";
            // 
            // SVMlink
            // 
            SVMlink.AutoSize = true;
            SVMlink.Font = new Font("맑은 고딕", 12F);
            SVMlink.LinkColor = Color.Black;
            SVMlink.Location = new Point(250, 36);
            SVMlink.Name = "SVMlink";
            SVMlink.Size = new Size(146, 21);
            SVMlink.TabIndex = 93;
            SVMlink.TabStop = true;
            SVMlink.Text = "SVM (공식 한글화)";
            SVMlink.LinkClicked += SVM_LinkClicked;
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
            A_Indicatorlink.LinkClicked += A_Indicatorlink_LinkClicked;
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
            // G_Indicatorlink
            // 
            G_Indicatorlink.AutoSize = true;
            G_Indicatorlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            G_Indicatorlink.LinkColor = Color.Black;
            G_Indicatorlink.Location = new Point(27, 226);
            G_Indicatorlink.Name = "G_Indicatorlink";
            G_Indicatorlink.Size = new Size(143, 21);
            G_Indicatorlink.TabIndex = 87;
            G_Indicatorlink.TabStop = true;
            G_Indicatorlink.Text = "Grenade Indicator";
            G_Indicatorlink.LinkClicked += G_Indicatorlink_LinkClicked;
            // 
            // GrenadeBox
            // 
            GrenadeBox.AutoSize = true;
            GrenadeBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            GrenadeBox.Location = new Point(6, 232);
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
            Trainerlink.LinkClicked += Trainerlink_LinkClicked;
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
            DadGamerlink.Location = new Point(27, 194);
            DadGamerlink.Name = "DadGamerlink";
            DadGamerlink.Size = new Size(143, 21);
            DadGamerlink.TabIndex = 83;
            DadGamerlink.TabStop = true;
            DadGamerlink.Text = "Dad Gamer Mode";
            DadGamerlink.LinkClicked += DadGamerlink_LinkClicked;
            // 
            // DadGamerBox
            // 
            DadGamerBox.AutoSize = true;
            DadGamerBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            DadGamerBox.Location = new Point(6, 200);
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
            Fovlink.LinkClicked += Fovlink_LinkClicked;
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
            Notifierlink.Location = new Point(27, 162);
            Notifierlink.Name = "Notifierlink";
            Notifierlink.Size = new Size(105, 21);
            Notifierlink.TabIndex = 79;
            Notifierlink.TabStop = true;
            Notifierlink.Text = "Boss Notifier";
            Notifierlink.LinkClicked += Notifierlink_LinkClicked;
            // 
            // NotifierBox
            // 
            NotifierBox.AutoSize = true;
            NotifierBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            NotifierBox.Location = new Point(6, 168);
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
            Clutterlink.LinkClicked += Clutterlink_LinkClicked;
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
            Hudlink.Location = new Point(27, 132);
            Hudlink.Name = "Hudlink";
            Hudlink.Size = new Size(143, 21);
            Hudlink.TabIndex = 75;
            Hudlink.TabStop = true;
            Hudlink.Text = "Game Pannel Hud";
            Hudlink.LinkClicked += Hudlink_LinkClicked;
            // 
            // HudBox
            // 
            HudBox.AutoSize = true;
            HudBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            HudBox.Location = new Point(6, 138);
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
            Graphicslink.LinkClicked += Graphicslink_LinkClicked;
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
            Maplink.Location = new Point(27, 99);
            Maplink.Name = "Maplink";
            Maplink.Size = new Size(118, 21);
            Maplink.TabIndex = 71;
            Maplink.TabStop = true;
            Maplink.Text = "Dynamic Maps";
            Maplink.LinkClicked += Maplink_LinkClicked;
            // 
            // MapsBox
            // 
            MapsBox.AutoSize = true;
            MapsBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            MapsBox.Location = new Point(6, 105);
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
            Questinglink.LinkClicked += Questinglink_LinkClicked;
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
            Donutlink.LinkClicked += Donutlink_LinkClicked;
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
            ModtabPage2.Controls.Add(label11);
            ModtabPage2.Controls.Add(Contentlink);
            ModtabPage2.Controls.Add(ContextMenuBox);
            ModtabPage2.Controls.Add(label22);
            ModtabPage2.Controls.Add(label21);
            ModtabPage2.Controls.Add(label20);
            ModtabPage2.Controls.Add(Bloodylink);
            ModtabPage2.Controls.Add(BloodyBox);
            ModtabPage2.Controls.Add(WeaponBuildinglink);
            ModtabPage2.Controls.Add(ModdingBox);
            ModtabPage2.Controls.Add(ViscreralKRlink);
            ModtabPage2.Controls.Add(VisceralBox);
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
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(201, 234);
            label11.Name = "label11";
            label11.Size = new Size(34, 15);
            label11.TabIndex = 102;
            label11.Text = "1.1.0";
            // 
            // Contentlink
            // 
            Contentlink.AutoSize = true;
            Contentlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Contentlink.LinkColor = Color.Black;
            Contentlink.Location = new Point(40, 219);
            Contentlink.Name = "Contentlink";
            Contentlink.Size = new Size(157, 42);
            Contentlink.TabIndex = 92;
            Contentlink.TabStop = true;
            Contentlink.Text = "Item Context Menu\r\n(포팅 - 한글화 포함)";
            Contentlink.LinkClicked += Contentlink_LinkClicked_1;
            // 
            // ContextMenuBox
            // 
            ContextMenuBox.AutoSize = true;
            ContextMenuBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            ContextMenuBox.Location = new Point(19, 225);
            ContextMenuBox.Name = "ContextMenuBox";
            ContextMenuBox.Size = new Size(15, 14);
            ContextMenuBox.TabIndex = 91;
            ContextMenuBox.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(300, 129);
            label22.Name = "label22";
            label22.Size = new Size(34, 15);
            label22.TabIndex = 90;
            label22.Text = "1.2.3";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(259, 71);
            label21.Name = "label21";
            label21.Size = new Size(34, 15);
            label21.TabIndex = 89;
            label21.Text = "1.8.0";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(241, 26);
            label20.Name = "label20";
            label20.Size = new Size(34, 15);
            label20.TabIndex = 88;
            label20.Text = "2.2.4";
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
            Bloodylink.LinkClicked += Bloodylink_LinkClicked;
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
            WeaponBuildinglink.LinkClicked += WeaponBuildinglink_LinkClicked;
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
            // ViscreralKRlink
            // 
            ViscreralKRlink.AutoSize = true;
            ViscreralKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            ViscreralKRlink.LinkColor = Color.Black;
            ViscreralKRlink.Location = new Point(40, 167);
            ViscreralKRlink.Name = "ViscreralKRlink";
            ViscreralKRlink.Size = new Size(194, 42);
            ViscreralKRlink.TabIndex = 87;
            ViscreralKRlink.TabStop = true;
            ViscreralKRlink.Text = "Visceral Dismemberment\r\n(포팅 - 한글화 포함)";
            ViscreralKRlink.LinkClicked += ViscreralKRlink_LinkClicked;
            // 
            // VisceralBox
            // 
            VisceralBox.AutoSize = true;
            VisceralBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            VisceralBox.Location = new Point(19, 173);
            VisceralBox.Name = "VisceralBox";
            VisceralBox.Size = new Size(15, 14);
            VisceralBox.TabIndex = 86;
            VisceralBox.UseVisualStyleBackColor = true;
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
            FireSupportlink.LinkClicked += FireSupportlink_LinkClicked;
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
            panel4.Controls.Add(SPTTexDefaultBox);
            panel4.Controls.Add(SPTTex4096Box);
            panel4.Controls.Add(TextureKRlink);
            panel4.Controls.Add(SPTTexKRBox);
            panel4.Controls.Add(LogoKRlink);
            panel4.Controls.Add(SPTLogoKRBox);
            panel4.Controls.Add(SPTKRlink);
            panel4.Controls.Add(SPTKRBox);
            panel4.Location = new Point(156, 55);
            panel4.Name = "panel4";
            panel4.Size = new Size(638, 110);
            panel4.TabIndex = 8;
            // 
            // SPTTexDefaultBox
            // 
            SPTTexDefaultBox.AutoSize = true;
            SPTTexDefaultBox.Enabled = false;
            SPTTexDefaultBox.Font = new Font("맑은 고딕", 12F);
            SPTTexDefaultBox.Location = new Point(482, 19);
            SPTTexDefaultBox.Name = "SPTTexDefaultBox";
            SPTTexDefaultBox.Size = new Size(99, 25);
            SPTTexDefaultBox.TabIndex = 95;
            SPTTexDefaultBox.Text = "기본 버전";
            SPTTexDefaultBox.UseVisualStyleBackColor = true;
            SPTTexDefaultBox.CheckedChanged += SPTTexDefaultBox_CheckedChanged;
            // 
            // SPTTex4096Box
            // 
            SPTTex4096Box.AutoSize = true;
            SPTTex4096Box.Enabled = false;
            SPTTex4096Box.Font = new Font("맑은 고딕", 9F);
            SPTTex4096Box.Location = new Point(482, 50);
            SPTTex4096Box.Name = "SPTTex4096Box";
            SPTTex4096Box.Size = new Size(126, 49);
            SPTTex4096Box.TabIndex = 94;
            SPTTex4096Box.Text = "4K 버전\r\n(기본 버전 체크 후\r\n받아주세요.)";
            SPTTex4096Box.UseVisualStyleBackColor = true;
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
            TextureKRlink.LinkClicked += TextureKRlink_LinkClicked;
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
            LogoKRlink.LinkClicked += LogoKRlink_LinkClicked;
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
            SPTKRlink.LinkClicked += SPTKRlink_LinkClicked;
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
            KRtabPage1.Controls.Add(UIKRlink);
            KRtabPage1.Controls.Add(UIKRBox);
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
            // UIKRlink
            // 
            UIKRlink.AutoSize = true;
            UIKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            UIKRlink.LinkColor = Color.Black;
            UIKRlink.Location = new Point(30, 66);
            UIKRlink.Name = "UIKRlink";
            UIKRlink.Size = new Size(104, 21);
            UIKRlink.TabIndex = 95;
            UIKRlink.TabStop = true;
            UIKRlink.Text = "UI Fixes - KR";
            UIKRlink.LinkClicked += UIKRlink_LinkClicked;
            // 
            // UIKRBox
            // 
            UIKRBox.AutoSize = true;
            UIKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            UIKRBox.Location = new Point(9, 72);
            UIKRBox.Name = "UIKRBox";
            UIKRBox.Size = new Size(15, 14);
            UIKRBox.TabIndex = 94;
            UIKRBox.UseVisualStyleBackColor = true;
            // 
            // A_IndicatorKRlink
            // 
            A_IndicatorKRlink.AutoSize = true;
            A_IndicatorKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            A_IndicatorKRlink.LinkColor = Color.Black;
            A_IndicatorKRlink.Location = new Point(247, 221);
            A_IndicatorKRlink.Name = "A_IndicatorKRlink";
            A_IndicatorKRlink.Size = new Size(150, 42);
            A_IndicatorKRlink.TabIndex = 93;
            A_IndicatorKRlink.TabStop = true;
            A_IndicatorKRlink.Text = "Audio Accessibility\r\nIndicators - KR";
            A_IndicatorKRlink.LinkClicked += A_IndicatorKRlink_LinkClicked;
            // 
            // AudioKRBox
            // 
            AudioKRBox.AutoSize = true;
            AudioKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            AudioKRBox.Location = new Point(226, 227);
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
            G_IndicatorKRlink.Location = new Point(30, 222);
            G_IndicatorKRlink.Name = "G_IndicatorKRlink";
            G_IndicatorKRlink.Size = new Size(181, 21);
            G_IndicatorKRlink.TabIndex = 63;
            G_IndicatorKRlink.TabStop = true;
            G_IndicatorKRlink.Text = "Grenade Indicator - KR";
            G_IndicatorKRlink.LinkClicked += G_IndicatorKRlink_LinkClicked;
            // 
            // GrenadeKRBox
            // 
            GrenadeKRBox.AutoSize = true;
            GrenadeKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            GrenadeKRBox.Location = new Point(9, 228);
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
            TrainerKRlink.Location = new Point(247, 190);
            TrainerKRlink.Name = "TrainerKRlink";
            TrainerKRlink.Size = new Size(167, 21);
            TrainerKRlink.TabIndex = 61;
            TrainerKRlink.TabStop = true;
            TrainerKRlink.Text = "Personal Trainer - KR";
            TrainerKRlink.LinkClicked += TrainerKRlink_LinkClicked;
            // 
            // TrainerKRBox
            // 
            TrainerKRBox.AutoSize = true;
            TrainerKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            TrainerKRBox.Location = new Point(226, 196);
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
            DadGamerKRlink.Location = new Point(30, 192);
            DadGamerKRlink.Name = "DadGamerKRlink";
            DadGamerKRlink.Size = new Size(181, 21);
            DadGamerKRlink.TabIndex = 59;
            DadGamerKRlink.TabStop = true;
            DadGamerKRlink.Text = "Dad Gamer Mode - KR";
            DadGamerKRlink.LinkClicked += DadGamerKRlink_LinkClicked;
            // 
            // DadGamerKRBox
            // 
            DadGamerKRBox.AutoSize = true;
            DadGamerKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            DadGamerKRBox.Location = new Point(9, 198);
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
            FovKRlink.Location = new Point(247, 158);
            FovKRlink.Name = "FovKRlink";
            FovKRlink.Size = new Size(183, 21);
            FovKRlink.TabIndex = 57;
            FovKRlink.TabStop = true;
            FovKRlink.Text = "Fontaine's FOV Fix - KR";
            FovKRlink.LinkClicked += FovKRlink_LinkClicked;
            // 
            // FOVFixKRBox
            // 
            FOVFixKRBox.AutoSize = true;
            FOVFixKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            FOVFixKRBox.Location = new Point(226, 164);
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
            NotifierKRlink.Location = new Point(30, 160);
            NotifierKRlink.Name = "NotifierKRlink";
            NotifierKRlink.Size = new Size(143, 21);
            NotifierKRlink.TabIndex = 55;
            NotifierKRlink.TabStop = true;
            NotifierKRlink.Text = "Boss Notifier - KR";
            NotifierKRlink.LinkClicked += NotifierKRlink_LinkClicked;
            // 
            // NotifierKRBox
            // 
            NotifierKRBox.AutoSize = true;
            NotifierKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            NotifierKRBox.Location = new Point(9, 166);
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
            ClutterKRlink.Location = new Point(247, 128);
            ClutterKRlink.Name = "ClutterKRlink";
            ClutterKRlink.Size = new Size(140, 21);
            ClutterKRlink.TabIndex = 53;
            ClutterKRlink.TabStop = true;
            ClutterKRlink.Text = "De-Clutterer - KR";
            ClutterKRlink.LinkClicked += ClutterKRlink_LinkClicked;
            // 
            // CluttererKRBox
            // 
            CluttererKRBox.AutoSize = true;
            CluttererKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            CluttererKRBox.Location = new Point(226, 134);
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
            HudKRlink.Location = new Point(30, 130);
            HudKRlink.Name = "HudKRlink";
            HudKRlink.Size = new Size(181, 21);
            HudKRlink.TabIndex = 51;
            HudKRlink.TabStop = true;
            HudKRlink.Text = "Game Pannel Hud - KR";
            HudKRlink.LinkClicked += HudKRlink_LinkClicked;
            // 
            // HudKRBox
            // 
            HudKRBox.AutoSize = true;
            HudKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            HudKRBox.Location = new Point(9, 136);
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
            GraphicsKRlink.Location = new Point(247, 95);
            GraphicsKRlink.Name = "GraphicsKRlink";
            GraphicsKRlink.Size = new Size(177, 21);
            GraphicsKRlink.TabIndex = 49;
            GraphicsKRlink.TabStop = true;
            GraphicsKRlink.Text = "Amanda Graphics - KR";
            GraphicsKRlink.LinkClicked += GraphicsKRlink_LinkClicked;
            // 
            // GraphicsKRBox
            // 
            GraphicsKRBox.AutoSize = true;
            GraphicsKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            GraphicsKRBox.Location = new Point(226, 101);
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
            MapKRlink.Location = new Point(30, 97);
            MapKRlink.Name = "MapKRlink";
            MapKRlink.Size = new Size(156, 21);
            MapKRlink.TabIndex = 47;
            MapKRlink.TabStop = true;
            MapKRlink.Text = "Dynamic Maps - KR";
            MapKRlink.LinkClicked += MapKRlink_LinkClicked;
            // 
            // MapsKRBox
            // 
            MapsKRBox.AutoSize = true;
            MapsKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            MapsKRBox.Location = new Point(9, 103);
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
            QuestingKRlink.Location = new Point(247, 63);
            QuestingKRlink.Name = "QuestingKRlink";
            QuestingKRlink.Size = new Size(152, 21);
            QuestingKRlink.TabIndex = 45;
            QuestingKRlink.TabStop = true;
            QuestingKRlink.Text = "Questing Bots - KR";
            QuestingKRlink.LinkClicked += QuestingKRlink_LinkClicked;
            // 
            // QuestingBotsKRBox
            // 
            QuestingBotsKRBox.AutoSize = true;
            QuestingBotsKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            QuestingBotsKRBox.Location = new Point(226, 69);
            QuestingBotsKRBox.Name = "QuestingBotsKRBox";
            QuestingBotsKRBox.Size = new Size(15, 14);
            QuestingBotsKRBox.TabIndex = 44;
            QuestingBotsKRBox.UseVisualStyleBackColor = true;
            // 
            // RealisemKRlink
            // 
            RealisemKRlink.AutoSize = true;
            RealisemKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            RealisemKRlink.LinkColor = Color.Black;
            RealisemKRlink.Location = new Point(30, 36);
            RealisemKRlink.Name = "RealisemKRlink";
            RealisemKRlink.Size = new Size(178, 21);
            RealisemKRlink.TabIndex = 43;
            RealisemKRlink.TabStop = true;
            RealisemKRlink.Text = "SPT Realism Mod - KR";
            RealisemKRlink.LinkClicked += RealisemKRlink_LinkClicked;
            // 
            // RealismKRBox
            // 
            RealismKRBox.AutoSize = true;
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
            DonutKRlink.Location = new Point(247, 4);
            DonutKRlink.Name = "DonutKRlink";
            DonutKRlink.Size = new Size(93, 21);
            DonutKRlink.TabIndex = 41;
            DonutKRlink.TabStop = true;
            DonutKRlink.Text = "Donut - KR";
            DonutKRlink.LinkClicked += DonutKRlink_LinkClicked;
            // 
            // DonutKRBox
            // 
            DonutKRBox.AutoSize = true;
            DonutKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            DonutKRBox.Location = new Point(226, 10);
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
            SainKRlink.LinkClicked += SainKRlink_LinkClicked;
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
            BloodyKRlink.Location = new Point(28, 110);
            BloodyKRlink.Name = "BloodyKRlink";
            BloodyKRlink.Size = new Size(254, 42);
            BloodyKRlink.TabIndex = 87;
            BloodyKRlink.TabStop = true;
            BloodyKRlink.Text = "Borkel's Bloody Bullet Wounds +\r\nParticles + Splatters - KR";
            BloodyKRlink.LinkClicked += BloodyKRlink_LinkClicked;
            // 
            // BloodyKRBox
            // 
            BloodyKRBox.AutoSize = true;
            BloodyKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BloodyKRBox.Location = new Point(7, 116);
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
            WeaponBuildingKRlink.Location = new Point(28, 55);
            WeaponBuildingKRlink.Name = "WeaponBuildingKRlink";
            WeaponBuildingKRlink.Size = new Size(251, 42);
            WeaponBuildingKRlink.TabIndex = 89;
            WeaponBuildingKRlink.TabStop = true;
            WeaponBuildingKRlink.Text = "Trader Modding and \r\nImproved Weapon Building - KR\r\n";
            WeaponBuildingKRlink.LinkClicked += WeaponBuildingKRlink_LinkClicked;
            // 
            // ModdingKRBox
            // 
            ModdingKRBox.AutoSize = true;
            ModdingKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            ModdingKRBox.Location = new Point(7, 61);
            ModdingKRBox.Name = "ModdingKRBox";
            ModdingKRBox.Size = new Size(15, 14);
            ModdingKRBox.TabIndex = 88;
            ModdingKRBox.UseVisualStyleBackColor = true;
            // 
            // FireSupportKRlink
            // 
            FireSupportKRlink.AutoSize = true;
            FireSupportKRlink.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            FireSupportKRlink.LinkColor = Color.Black;
            FireSupportKRlink.Location = new Point(30, 19);
            FireSupportKRlink.Name = "FireSupportKRlink";
            FireSupportKRlink.Size = new Size(233, 21);
            FireSupportKRlink.TabIndex = 85;
            FireSupportKRlink.TabStop = true;
            FireSupportKRlink.Text = "SamSWAT's Fire Support - KR";
            FireSupportKRlink.LinkClicked += FireSupportKRlink_LinkClicked;
            // 
            // FireSupportKRBox
            // 
            FireSupportKRBox.AutoSize = true;
            FireSupportKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            FireSupportKRBox.Location = new Point(9, 26);
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
            label3.Location = new Point(158, 27);
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
        private LinkLabel SVMlink;
        private CheckBox SVMBox;
        private Label label4;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label20;
        private Label label22;
        private Label label21;
        private LinkLabel Contentlink;
        private CheckBox ContextMenuBox;
        private Label label11;
        private Label label23;
        private LinkLabel UIlink;
        private CheckBox UIBox;
        private LinkLabel UIKRlink;
        private CheckBox UIKRBox;
        private CheckBox SPTTex4096Box;
        private CheckBox SPTTexDefaultBox;
    }
}
