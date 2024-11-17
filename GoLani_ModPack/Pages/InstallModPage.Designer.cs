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
            linkLabel25 = new LinkLabel();
            AudioBox = new CheckBox();
            linkLabel27 = new LinkLabel();
            ContextMenuBox = new CheckBox();
            linkLabel28 = new LinkLabel();
            GrenadeBox = new CheckBox();
            linkLabel1 = new LinkLabel();
            TrainerBox = new CheckBox();
            linkLabel2 = new LinkLabel();
            DadGamerBox = new CheckBox();
            linkLabel3 = new LinkLabel();
            FOVFixBox = new CheckBox();
            linkLabel4 = new LinkLabel();
            NotifierBox = new CheckBox();
            linkLabel5 = new LinkLabel();
            CluttererBox = new CheckBox();
            linkLabel6 = new LinkLabel();
            HudBox = new CheckBox();
            linkLabel7 = new LinkLabel();
            GraphicsBox = new CheckBox();
            linkLabel8 = new LinkLabel();
            MapsBox = new CheckBox();
            linkLabel9 = new LinkLabel();
            QuestingBotsBox = new CheckBox();
            linkLabel10 = new LinkLabel();
            RealismBox = new CheckBox();
            linkLabel11 = new LinkLabel();
            DonutBox = new CheckBox();
            linkLabel16 = new LinkLabel();
            SAINBox = new CheckBox();
            ModtabPage2 = new TabPage();
            linkLabel33 = new LinkLabel();
            BloodyBox = new CheckBox();
            linkLabel30 = new LinkLabel();
            ModdingBox = new CheckBox();
            linkLabel35 = new LinkLabel();
            FireSupportBox = new CheckBox();
            panel4 = new Panel();
            linkLabel40 = new LinkLabel();
            SPTTexDefaultBtn = new RadioButton();
            SPTTex4096Btn = new RadioButton();
            linkLabel37 = new LinkLabel();
            SPTTexKRBox = new CheckBox();
            linkLabel38 = new LinkLabel();
            SPTLogoKRBox = new CheckBox();
            linkLabel39 = new LinkLabel();
            SPTKRBox = new CheckBox();
            panel3 = new Panel();
            KRtabControl = new TabControl();
            KRtabPage1 = new TabPage();
            linkLabel26 = new LinkLabel();
            AudioKRBox = new CheckBox();
            linkLabel32 = new LinkLabel();
            GrenadeKRBox = new CheckBox();
            linkLabel12 = new LinkLabel();
            TrainerKRBox = new CheckBox();
            linkLabel13 = new LinkLabel();
            DadGamerKRBox = new CheckBox();
            linkLabel14 = new LinkLabel();
            FOVFixKRBox = new CheckBox();
            linkLabel15 = new LinkLabel();
            NotifierKRBox = new CheckBox();
            linkLabel17 = new LinkLabel();
            CluttererKRBox = new CheckBox();
            linkLabel18 = new LinkLabel();
            HudKRBox = new CheckBox();
            linkLabel19 = new LinkLabel();
            GraphicsKRBox = new CheckBox();
            linkLabel20 = new LinkLabel();
            MapsKRBox = new CheckBox();
            linkLabel21 = new LinkLabel();
            QuestingBotsKRBox = new CheckBox();
            linkLabel22 = new LinkLabel();
            RealismKRBox = new CheckBox();
            linkLabel23 = new LinkLabel();
            DonutKRBox = new CheckBox();
            linkLabel24 = new LinkLabel();
            SAINKRBox = new CheckBox();
            KRtabPage2 = new TabPage();
            linkLabel36 = new LinkLabel();
            BloodyKRBox = new CheckBox();
            linkLabel29 = new LinkLabel();
            ModdingKRBox = new CheckBox();
            linkLabel31 = new LinkLabel();
            VisceralBox = new CheckBox();
            linkLabel34 = new LinkLabel();
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
            ModtabPage1.Controls.Add(linkLabel25);
            ModtabPage1.Controls.Add(AudioBox);
            ModtabPage1.Controls.Add(linkLabel27);
            ModtabPage1.Controls.Add(ContextMenuBox);
            ModtabPage1.Controls.Add(linkLabel28);
            ModtabPage1.Controls.Add(GrenadeBox);
            ModtabPage1.Controls.Add(linkLabel1);
            ModtabPage1.Controls.Add(TrainerBox);
            ModtabPage1.Controls.Add(linkLabel2);
            ModtabPage1.Controls.Add(DadGamerBox);
            ModtabPage1.Controls.Add(linkLabel3);
            ModtabPage1.Controls.Add(FOVFixBox);
            ModtabPage1.Controls.Add(linkLabel4);
            ModtabPage1.Controls.Add(NotifierBox);
            ModtabPage1.Controls.Add(linkLabel5);
            ModtabPage1.Controls.Add(CluttererBox);
            ModtabPage1.Controls.Add(linkLabel6);
            ModtabPage1.Controls.Add(HudBox);
            ModtabPage1.Controls.Add(linkLabel7);
            ModtabPage1.Controls.Add(GraphicsBox);
            ModtabPage1.Controls.Add(linkLabel8);
            ModtabPage1.Controls.Add(MapsBox);
            ModtabPage1.Controls.Add(linkLabel9);
            ModtabPage1.Controls.Add(QuestingBotsBox);
            ModtabPage1.Controls.Add(linkLabel10);
            ModtabPage1.Controls.Add(RealismBox);
            ModtabPage1.Controls.Add(linkLabel11);
            ModtabPage1.Controls.Add(DonutBox);
            ModtabPage1.Controls.Add(linkLabel16);
            ModtabPage1.Controls.Add(SAINBox);
            ModtabPage1.Location = new Point(4, 44);
            ModtabPage1.Name = "ModtabPage1";
            ModtabPage1.Padding = new Padding(3);
            ModtabPage1.Size = new Size(435, 270);
            ModtabPage1.TabIndex = 0;
            ModtabPage1.Text = "1페이지";
            ModtabPage1.UseVisualStyleBackColor = true;
            // 
            // linkLabel25
            // 
            linkLabel25.AutoSize = true;
            linkLabel25.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel25.LinkColor = Color.Black;
            linkLabel25.Location = new Point(250, 195);
            linkLabel25.Name = "linkLabel25";
            linkLabel25.Size = new Size(150, 42);
            linkLabel25.TabIndex = 91;
            linkLabel25.TabStop = true;
            linkLabel25.Text = "Audio Accessibility\r\nIndicators";
            // 
            // AudioBox
            // 
            AudioBox.AutoSize = true;
            AudioBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            AudioBox.Location = new Point(229, 201);
            AudioBox.Name = "AudioBox";
            AudioBox.Size = new Size(15, 14);
            AudioBox.TabIndex = 90;
            AudioBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel27
            // 
            linkLabel27.AutoSize = true;
            linkLabel27.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel27.LinkColor = Color.Black;
            linkLabel27.Location = new Point(26, 221);
            linkLabel27.Name = "linkLabel27";
            linkLabel27.Size = new Size(157, 42);
            linkLabel27.TabIndex = 89;
            linkLabel27.TabStop = true;
            linkLabel27.Text = "Item Context Menu\r\n(포팅 - 한글화 포함)";
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
            // linkLabel28
            // 
            linkLabel28.AutoSize = true;
            linkLabel28.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel28.LinkColor = Color.Black;
            linkLabel28.Location = new Point(27, 195);
            linkLabel28.Name = "linkLabel28";
            linkLabel28.Size = new Size(143, 21);
            linkLabel28.TabIndex = 87;
            linkLabel28.TabStop = true;
            linkLabel28.Text = "Grenade Indicator";
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
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(250, 163);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(129, 21);
            linkLabel1.TabIndex = 85;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Personal Trainer";
            // 
            // TrainerBox
            // 
            TrainerBox.AutoSize = true;
            TrainerBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            TrainerBox.Location = new Point(229, 169);
            TrainerBox.Name = "TrainerBox";
            TrainerBox.Size = new Size(15, 14);
            TrainerBox.TabIndex = 84;
            TrainerBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel2.LinkColor = Color.Black;
            linkLabel2.Location = new Point(27, 163);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(143, 21);
            linkLabel2.TabIndex = 83;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Dad Gamer Mode";
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
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel3.LinkColor = Color.Black;
            linkLabel3.Location = new Point(250, 131);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(145, 21);
            linkLabel3.TabIndex = 81;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Fontaine's FOV Fix";
            // 
            // FOVFixBox
            // 
            FOVFixBox.AutoSize = true;
            FOVFixBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            FOVFixBox.Location = new Point(229, 137);
            FOVFixBox.Name = "FOVFixBox";
            FOVFixBox.Size = new Size(15, 14);
            FOVFixBox.TabIndex = 80;
            FOVFixBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel4.LinkColor = Color.Black;
            linkLabel4.Location = new Point(27, 131);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(105, 21);
            linkLabel4.TabIndex = 79;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "Boss Notifier";
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
            // linkLabel5
            // 
            linkLabel5.AutoSize = true;
            linkLabel5.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel5.LinkColor = Color.Black;
            linkLabel5.Location = new Point(250, 101);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(102, 21);
            linkLabel5.TabIndex = 77;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "De-Clutterer";
            // 
            // CluttererBox
            // 
            CluttererBox.AutoSize = true;
            CluttererBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            CluttererBox.Location = new Point(229, 107);
            CluttererBox.Name = "CluttererBox";
            CluttererBox.Size = new Size(15, 14);
            CluttererBox.TabIndex = 76;
            CluttererBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel6
            // 
            linkLabel6.AutoSize = true;
            linkLabel6.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel6.LinkColor = Color.Black;
            linkLabel6.Location = new Point(27, 101);
            linkLabel6.Name = "linkLabel6";
            linkLabel6.Size = new Size(143, 21);
            linkLabel6.TabIndex = 75;
            linkLabel6.TabStop = true;
            linkLabel6.Text = "Game Pannel Hud";
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
            // linkLabel7
            // 
            linkLabel7.AutoSize = true;
            linkLabel7.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel7.LinkColor = Color.Black;
            linkLabel7.Location = new Point(250, 68);
            linkLabel7.Name = "linkLabel7";
            linkLabel7.Size = new Size(139, 21);
            linkLabel7.TabIndex = 73;
            linkLabel7.TabStop = true;
            linkLabel7.Text = "Amanda Graphics";
            // 
            // GraphicsBox
            // 
            GraphicsBox.AutoSize = true;
            GraphicsBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            GraphicsBox.Location = new Point(229, 74);
            GraphicsBox.Name = "GraphicsBox";
            GraphicsBox.Size = new Size(15, 14);
            GraphicsBox.TabIndex = 72;
            GraphicsBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel8
            // 
            linkLabel8.AutoSize = true;
            linkLabel8.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel8.LinkColor = Color.Black;
            linkLabel8.Location = new Point(27, 68);
            linkLabel8.Name = "linkLabel8";
            linkLabel8.Size = new Size(118, 21);
            linkLabel8.TabIndex = 71;
            linkLabel8.TabStop = true;
            linkLabel8.Text = "Dynamic Maps";
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
            // linkLabel9
            // 
            linkLabel9.AutoSize = true;
            linkLabel9.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel9.LinkColor = Color.Black;
            linkLabel9.Location = new Point(250, 36);
            linkLabel9.Name = "linkLabel9";
            linkLabel9.Size = new Size(114, 21);
            linkLabel9.TabIndex = 69;
            linkLabel9.TabStop = true;
            linkLabel9.Text = "Questing Bots";
            // 
            // QuestingBotsBox
            // 
            QuestingBotsBox.AutoSize = true;
            QuestingBotsBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            QuestingBotsBox.Location = new Point(229, 42);
            QuestingBotsBox.Name = "QuestingBotsBox";
            QuestingBotsBox.Size = new Size(15, 14);
            QuestingBotsBox.TabIndex = 68;
            QuestingBotsBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel10
            // 
            linkLabel10.AutoSize = true;
            linkLabel10.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel10.LinkColor = Color.Black;
            linkLabel10.Location = new Point(27, 36);
            linkLabel10.Name = "linkLabel10";
            linkLabel10.Size = new Size(140, 21);
            linkLabel10.TabIndex = 67;
            linkLabel10.TabStop = true;
            linkLabel10.Text = "SPT Realism Mod";
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
            // linkLabel11
            // 
            linkLabel11.AutoSize = true;
            linkLabel11.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel11.LinkColor = Color.Black;
            linkLabel11.Location = new Point(250, 6);
            linkLabel11.Name = "linkLabel11";
            linkLabel11.Size = new Size(55, 21);
            linkLabel11.TabIndex = 65;
            linkLabel11.TabStop = true;
            linkLabel11.Text = "Donut";
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
            // linkLabel16
            // 
            linkLabel16.AutoSize = true;
            linkLabel16.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel16.LinkColor = Color.Black;
            linkLabel16.Location = new Point(27, 6);
            linkLabel16.Name = "linkLabel16";
            linkLabel16.Size = new Size(46, 21);
            linkLabel16.TabIndex = 63;
            linkLabel16.TabStop = true;
            linkLabel16.Text = "SAIN";
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
            ModtabPage2.Controls.Add(linkLabel33);
            ModtabPage2.Controls.Add(BloodyBox);
            ModtabPage2.Controls.Add(linkLabel30);
            ModtabPage2.Controls.Add(ModdingBox);
            ModtabPage2.Controls.Add(linkLabel35);
            ModtabPage2.Controls.Add(FireSupportBox);
            ModtabPage2.Location = new Point(4, 44);
            ModtabPage2.Name = "ModtabPage2";
            ModtabPage2.Padding = new Padding(3);
            ModtabPage2.Size = new Size(435, 270);
            ModtabPage2.TabIndex = 1;
            ModtabPage2.Text = "2페이지";
            ModtabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabel33
            // 
            linkLabel33.AutoSize = true;
            linkLabel33.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel33.LinkColor = Color.Black;
            linkLabel33.Location = new Point(40, 111);
            linkLabel33.Name = "linkLabel33";
            linkLabel33.Size = new Size(254, 42);
            linkLabel33.TabIndex = 85;
            linkLabel33.TabStop = true;
            linkLabel33.Text = "Borkel's Bloody Bullet Wounds +\r\nParticles + Splatters";
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
            // linkLabel30
            // 
            linkLabel30.AutoSize = true;
            linkLabel30.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel30.LinkColor = Color.Black;
            linkLabel30.Location = new Point(40, 56);
            linkLabel30.Name = "linkLabel30";
            linkLabel30.Size = new Size(213, 42);
            linkLabel30.TabIndex = 83;
            linkLabel30.TabStop = true;
            linkLabel30.Text = "Trader Modding and \r\nImproved Weapon Building";
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
            // linkLabel35
            // 
            linkLabel35.AutoSize = true;
            linkLabel35.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel35.LinkColor = Color.Black;
            linkLabel35.Location = new Point(40, 21);
            linkLabel35.Name = "linkLabel35";
            linkLabel35.Size = new Size(195, 21);
            linkLabel35.TabIndex = 75;
            linkLabel35.TabStop = true;
            linkLabel35.Text = "SamSWAT's Fire Support";
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
            panel4.Controls.Add(linkLabel40);
            panel4.Controls.Add(SPTTexDefaultBtn);
            panel4.Controls.Add(SPTTex4096Btn);
            panel4.Controls.Add(linkLabel37);
            panel4.Controls.Add(SPTTexKRBox);
            panel4.Controls.Add(linkLabel38);
            panel4.Controls.Add(SPTLogoKRBox);
            panel4.Controls.Add(linkLabel39);
            panel4.Controls.Add(SPTKRBox);
            panel4.Location = new Point(156, 64);
            panel4.Name = "panel4";
            panel4.Size = new Size(638, 110);
            panel4.TabIndex = 8;
            // 
            // linkLabel40
            // 
            linkLabel40.AutoSize = true;
            linkLabel40.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel40.LinkColor = Color.Black;
            linkLabel40.Location = new Point(513, 56);
            linkLabel40.Name = "linkLabel40";
            linkLabel40.Size = new Size(84, 40);
            linkLabel40.TabIndex = 94;
            linkLabel40.TabStop = true;
            linkLabel40.Text = "4K 버전\r\n(수동 설치)";
            // 
            // SPTTexDefaultBtn
            // 
            SPTTexDefaultBtn.AutoSize = true;
            SPTTexDefaultBtn.Enabled = false;
            SPTTexDefaultBtn.Font = new Font("맑은 고딕", 11.25F);
            SPTTexDefaultBtn.Location = new Point(493, 29);
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
            SPTTex4096Btn.Location = new Point(493, 70);
            SPTTex4096Btn.Name = "SPTTex4096Btn";
            SPTTex4096Btn.Size = new Size(14, 13);
            SPTTex4096Btn.TabIndex = 92;
            SPTTex4096Btn.TabStop = true;
            SPTTex4096Btn.UseVisualStyleBackColor = true;
            // 
            // linkLabel37
            // 
            linkLabel37.AutoSize = true;
            linkLabel37.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel37.LinkColor = Color.Black;
            linkLabel37.Location = new Point(348, 26);
            linkLabel37.Name = "linkLabel37";
            linkLabel37.Size = new Size(128, 63);
            linkLabel37.TabIndex = 91;
            linkLabel37.TabStop = true;
            linkLabel37.Text = "SPT 타르코프 \r\n아이템 텍스처 \r\n한글화 프로젝트";
            // 
            // SPTTexKRBox
            // 
            SPTTexKRBox.AutoSize = true;
            SPTTexKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            SPTTexKRBox.Location = new Point(327, 32);
            SPTTexKRBox.Name = "SPTTexKRBox";
            SPTTexKRBox.Size = new Size(15, 14);
            SPTTexKRBox.TabIndex = 90;
            SPTTexKRBox.UseVisualStyleBackColor = true;
            SPTTexKRBox.CheckedChanged += SPTTexKRBox_CheckedChanged;
            // 
            // linkLabel38
            // 
            linkLabel38.AutoSize = true;
            linkLabel38.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel38.LinkColor = Color.Black;
            linkLabel38.Location = new Point(206, 33);
            linkLabel38.Name = "linkLabel38";
            linkLabel38.Size = new Size(96, 42);
            linkLabel38.TabIndex = 89;
            linkLabel38.TabStop = true;
            linkLabel38.Text = "타르코프 \r\n로고 한글화";
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
            // linkLabel39
            // 
            linkLabel39.AutoSize = true;
            linkLabel39.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel39.LinkColor = Color.Black;
            linkLabel39.Location = new Point(39, 33);
            linkLabel39.Name = "linkLabel39";
            linkLabel39.Size = new Size(128, 42);
            linkLabel39.TabIndex = 87;
            linkLabel39.TabStop = true;
            linkLabel39.Text = "SPT 타르코프 \r\n한글화 프로젝트";
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
            KRtabPage1.Controls.Add(linkLabel26);
            KRtabPage1.Controls.Add(AudioKRBox);
            KRtabPage1.Controls.Add(linkLabel32);
            KRtabPage1.Controls.Add(GrenadeKRBox);
            KRtabPage1.Controls.Add(linkLabel12);
            KRtabPage1.Controls.Add(TrainerKRBox);
            KRtabPage1.Controls.Add(linkLabel13);
            KRtabPage1.Controls.Add(DadGamerKRBox);
            KRtabPage1.Controls.Add(linkLabel14);
            KRtabPage1.Controls.Add(FOVFixKRBox);
            KRtabPage1.Controls.Add(linkLabel15);
            KRtabPage1.Controls.Add(NotifierKRBox);
            KRtabPage1.Controls.Add(linkLabel17);
            KRtabPage1.Controls.Add(CluttererKRBox);
            KRtabPage1.Controls.Add(linkLabel18);
            KRtabPage1.Controls.Add(HudKRBox);
            KRtabPage1.Controls.Add(linkLabel19);
            KRtabPage1.Controls.Add(GraphicsKRBox);
            KRtabPage1.Controls.Add(linkLabel20);
            KRtabPage1.Controls.Add(MapsKRBox);
            KRtabPage1.Controls.Add(linkLabel21);
            KRtabPage1.Controls.Add(QuestingBotsKRBox);
            KRtabPage1.Controls.Add(linkLabel22);
            KRtabPage1.Controls.Add(RealismKRBox);
            KRtabPage1.Controls.Add(linkLabel23);
            KRtabPage1.Controls.Add(DonutKRBox);
            KRtabPage1.Controls.Add(linkLabel24);
            KRtabPage1.Controls.Add(SAINKRBox);
            KRtabPage1.Location = new Point(4, 44);
            KRtabPage1.Name = "KRtabPage1";
            KRtabPage1.Padding = new Padding(3);
            KRtabPage1.Size = new Size(435, 270);
            KRtabPage1.TabIndex = 0;
            KRtabPage1.Text = "1페이지";
            KRtabPage1.UseVisualStyleBackColor = true;
            // 
            // linkLabel26
            // 
            linkLabel26.AutoSize = true;
            linkLabel26.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel26.LinkColor = Color.Black;
            linkLabel26.Location = new Point(253, 194);
            linkLabel26.Name = "linkLabel26";
            linkLabel26.Size = new Size(150, 42);
            linkLabel26.TabIndex = 93;
            linkLabel26.TabStop = true;
            linkLabel26.Text = "Audio Accessibility\r\nIndicators - KR";
            // 
            // AudioKRBox
            // 
            AudioKRBox.AutoSize = true;
            AudioKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            AudioKRBox.Location = new Point(232, 200);
            AudioKRBox.Name = "AudioKRBox";
            AudioKRBox.Size = new Size(15, 14);
            AudioKRBox.TabIndex = 92;
            AudioKRBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel32
            // 
            linkLabel32.AutoSize = true;
            linkLabel32.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel32.LinkColor = Color.Black;
            linkLabel32.Location = new Point(30, 193);
            linkLabel32.Name = "linkLabel32";
            linkLabel32.Size = new Size(181, 21);
            linkLabel32.TabIndex = 63;
            linkLabel32.TabStop = true;
            linkLabel32.Text = "Grenade Indicator - KR";
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
            // linkLabel12
            // 
            linkLabel12.AutoSize = true;
            linkLabel12.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel12.LinkColor = Color.Black;
            linkLabel12.Location = new Point(253, 163);
            linkLabel12.Name = "linkLabel12";
            linkLabel12.Size = new Size(167, 21);
            linkLabel12.TabIndex = 61;
            linkLabel12.TabStop = true;
            linkLabel12.Text = "Personal Trainer - KR";
            // 
            // TrainerKRBox
            // 
            TrainerKRBox.AutoSize = true;
            TrainerKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            TrainerKRBox.Location = new Point(232, 169);
            TrainerKRBox.Name = "TrainerKRBox";
            TrainerKRBox.Size = new Size(15, 14);
            TrainerKRBox.TabIndex = 60;
            TrainerKRBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel13
            // 
            linkLabel13.AutoSize = true;
            linkLabel13.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel13.LinkColor = Color.Black;
            linkLabel13.Location = new Point(30, 163);
            linkLabel13.Name = "linkLabel13";
            linkLabel13.Size = new Size(181, 21);
            linkLabel13.TabIndex = 59;
            linkLabel13.TabStop = true;
            linkLabel13.Text = "Dad Gamer Mode - KR";
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
            // linkLabel14
            // 
            linkLabel14.AutoSize = true;
            linkLabel14.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel14.LinkColor = Color.Black;
            linkLabel14.Location = new Point(253, 131);
            linkLabel14.Name = "linkLabel14";
            linkLabel14.Size = new Size(183, 21);
            linkLabel14.TabIndex = 57;
            linkLabel14.TabStop = true;
            linkLabel14.Text = "Fontaine's FOV Fix - KR";
            // 
            // FOVFixKRBox
            // 
            FOVFixKRBox.AutoSize = true;
            FOVFixKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            FOVFixKRBox.Location = new Point(232, 137);
            FOVFixKRBox.Name = "FOVFixKRBox";
            FOVFixKRBox.Size = new Size(15, 14);
            FOVFixKRBox.TabIndex = 56;
            FOVFixKRBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel15
            // 
            linkLabel15.AutoSize = true;
            linkLabel15.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel15.LinkColor = Color.Black;
            linkLabel15.Location = new Point(30, 131);
            linkLabel15.Name = "linkLabel15";
            linkLabel15.Size = new Size(143, 21);
            linkLabel15.TabIndex = 55;
            linkLabel15.TabStop = true;
            linkLabel15.Text = "Boss Notifier - KR";
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
            // linkLabel17
            // 
            linkLabel17.AutoSize = true;
            linkLabel17.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel17.LinkColor = Color.Black;
            linkLabel17.Location = new Point(253, 101);
            linkLabel17.Name = "linkLabel17";
            linkLabel17.Size = new Size(140, 21);
            linkLabel17.TabIndex = 53;
            linkLabel17.TabStop = true;
            linkLabel17.Text = "De-Clutterer - KR";
            // 
            // CluttererKRBox
            // 
            CluttererKRBox.AutoSize = true;
            CluttererKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            CluttererKRBox.Location = new Point(232, 107);
            CluttererKRBox.Name = "CluttererKRBox";
            CluttererKRBox.Size = new Size(15, 14);
            CluttererKRBox.TabIndex = 52;
            CluttererKRBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel18
            // 
            linkLabel18.AutoSize = true;
            linkLabel18.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel18.LinkColor = Color.Black;
            linkLabel18.Location = new Point(30, 101);
            linkLabel18.Name = "linkLabel18";
            linkLabel18.Size = new Size(181, 21);
            linkLabel18.TabIndex = 51;
            linkLabel18.TabStop = true;
            linkLabel18.Text = "Game Pannel Hud - KR";
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
            // linkLabel19
            // 
            linkLabel19.AutoSize = true;
            linkLabel19.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel19.LinkColor = Color.Black;
            linkLabel19.Location = new Point(253, 68);
            linkLabel19.Name = "linkLabel19";
            linkLabel19.Size = new Size(177, 21);
            linkLabel19.TabIndex = 49;
            linkLabel19.TabStop = true;
            linkLabel19.Text = "Amanda Graphics - KR";
            // 
            // GraphicsKRBox
            // 
            GraphicsKRBox.AutoSize = true;
            GraphicsKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            GraphicsKRBox.Location = new Point(232, 74);
            GraphicsKRBox.Name = "GraphicsKRBox";
            GraphicsKRBox.Size = new Size(15, 14);
            GraphicsKRBox.TabIndex = 48;
            GraphicsKRBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel20
            // 
            linkLabel20.AutoSize = true;
            linkLabel20.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel20.LinkColor = Color.Black;
            linkLabel20.Location = new Point(30, 68);
            linkLabel20.Name = "linkLabel20";
            linkLabel20.Size = new Size(156, 21);
            linkLabel20.TabIndex = 47;
            linkLabel20.TabStop = true;
            linkLabel20.Text = "Dynamic Maps - KR";
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
            // linkLabel21
            // 
            linkLabel21.AutoSize = true;
            linkLabel21.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel21.LinkColor = Color.Black;
            linkLabel21.Location = new Point(253, 36);
            linkLabel21.Name = "linkLabel21";
            linkLabel21.Size = new Size(152, 21);
            linkLabel21.TabIndex = 45;
            linkLabel21.TabStop = true;
            linkLabel21.Text = "Questing Bots - KR";
            // 
            // QuestingBotsKRBox
            // 
            QuestingBotsKRBox.AutoSize = true;
            QuestingBotsKRBox.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            QuestingBotsKRBox.Location = new Point(232, 42);
            QuestingBotsKRBox.Name = "QuestingBotsKRBox";
            QuestingBotsKRBox.Size = new Size(15, 14);
            QuestingBotsKRBox.TabIndex = 44;
            QuestingBotsKRBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel22
            // 
            linkLabel22.AutoSize = true;
            linkLabel22.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel22.LinkColor = Color.Black;
            linkLabel22.Location = new Point(30, 36);
            linkLabel22.Name = "linkLabel22";
            linkLabel22.Size = new Size(143, 34);
            linkLabel22.TabIndex = 43;
            linkLabel22.TabStop = true;
            linkLabel22.Text = "SPT Realism Mod - KR\r\n(수동 설치)";
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
            // linkLabel23
            // 
            linkLabel23.AutoSize = true;
            linkLabel23.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel23.LinkColor = Color.Black;
            linkLabel23.Location = new Point(253, 6);
            linkLabel23.Name = "linkLabel23";
            linkLabel23.Size = new Size(93, 21);
            linkLabel23.TabIndex = 41;
            linkLabel23.TabStop = true;
            linkLabel23.Text = "Donut - KR";
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
            // linkLabel24
            // 
            linkLabel24.AutoSize = true;
            linkLabel24.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel24.LinkColor = Color.Black;
            linkLabel24.Location = new Point(30, 6);
            linkLabel24.Name = "linkLabel24";
            linkLabel24.Size = new Size(84, 21);
            linkLabel24.TabIndex = 39;
            linkLabel24.TabStop = true;
            linkLabel24.Text = "SAIN - KR";
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
            KRtabPage2.Controls.Add(linkLabel36);
            KRtabPage2.Controls.Add(BloodyKRBox);
            KRtabPage2.Controls.Add(linkLabel29);
            KRtabPage2.Controls.Add(ModdingKRBox);
            KRtabPage2.Controls.Add(linkLabel31);
            KRtabPage2.Controls.Add(VisceralBox);
            KRtabPage2.Controls.Add(linkLabel34);
            KRtabPage2.Controls.Add(FireSupportKRBox);
            KRtabPage2.Location = new Point(4, 44);
            KRtabPage2.Name = "KRtabPage2";
            KRtabPage2.Padding = new Padding(3);
            KRtabPage2.Size = new Size(435, 270);
            KRtabPage2.TabIndex = 1;
            KRtabPage2.Text = "2페이지";
            KRtabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabel36
            // 
            linkLabel36.AutoSize = true;
            linkLabel36.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel36.LinkColor = Color.Black;
            linkLabel36.Location = new Point(31, 95);
            linkLabel36.Name = "linkLabel36";
            linkLabel36.Size = new Size(254, 42);
            linkLabel36.TabIndex = 87;
            linkLabel36.TabStop = true;
            linkLabel36.Text = "Borkel's Bloody Bullet Wounds +\r\nParticles + Splatters - KR";
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
            // linkLabel29
            // 
            linkLabel29.AutoSize = true;
            linkLabel29.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel29.LinkColor = Color.Black;
            linkLabel29.Location = new Point(34, 46);
            linkLabel29.Name = "linkLabel29";
            linkLabel29.Size = new Size(251, 42);
            linkLabel29.TabIndex = 89;
            linkLabel29.TabStop = true;
            linkLabel29.Text = "Trader Modding and \r\nImproved Weapon Building - KR\r\n";
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
            // linkLabel31
            // 
            linkLabel31.AutoSize = true;
            linkLabel31.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel31.LinkColor = Color.Black;
            linkLabel31.Location = new Point(31, 146);
            linkLabel31.Name = "linkLabel31";
            linkLabel31.Size = new Size(237, 42);
            linkLabel31.TabIndex = 87;
            linkLabel31.TabStop = true;
            linkLabel31.Text = "Visceral Dismemberment\r\n(포팅 - 한글화 포함, 수동 설치)";
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
            // linkLabel34
            // 
            linkLabel34.AutoSize = true;
            linkLabel34.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            linkLabel34.LinkColor = Color.Black;
            linkLabel34.Location = new Point(34, 4);
            linkLabel34.Name = "linkLabel34";
            linkLabel34.Size = new Size(233, 21);
            linkLabel34.TabIndex = 85;
            linkLabel34.TabStop = true;
            linkLabel34.Text = "SamSWAT's Fire Support - KR";
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
        private LinkLabel linkLabel1;
        private CheckBox TrainerBox;
        private LinkLabel linkLabel2;
        private CheckBox DadGamerBox;
        private LinkLabel linkLabel3;
        private CheckBox FOVFixBox;
        private LinkLabel linkLabel4;
        private CheckBox NotifierBox;
        private LinkLabel linkLabel5;
        private CheckBox CluttererBox;
        private LinkLabel linkLabel6;
        private CheckBox HudBox;
        private LinkLabel linkLabel7;
        private CheckBox GraphicsBox;
        private LinkLabel linkLabel8;
        private CheckBox MapsBox;
        private LinkLabel linkLabel9;
        private CheckBox QuestingBotsBox;
        private LinkLabel linkLabel10;
        private CheckBox RealismBox;
        private LinkLabel linkLabel11;
        private CheckBox DonutBox;
        private LinkLabel linkLabel16;
        private CheckBox SAINBox;
        private TabPage ModtabPage2;
        private CheckBox checkBox26;
        private LinkLabel linkLabel28;
        private CheckBox GrenadeBox;
        private CheckBox checkBox30;
        private LinkLabel linkLabel25;
        private CheckBox AudioBox;
        private Panel panel3;
        private TabControl KRtabControl;
        private TabPage KRtabPage1;
        private TabPage KRtabPage2;
        private LinkLabel linkLabel26;
        private CheckBox AudioKRBox;
        private LinkLabel linkLabel32;
        private CheckBox GrenadeKRBox;
        private LinkLabel linkLabel12;
        private CheckBox TrainerKRBox;
        private LinkLabel linkLabel13;
        private CheckBox DadGamerKRBox;
        private LinkLabel linkLabel14;
        private CheckBox FOVFixKRBox;
        private LinkLabel linkLabel15;
        private CheckBox NotifierKRBox;
        private LinkLabel linkLabel17;
        private CheckBox CluttererKRBox;
        private LinkLabel linkLabel18;
        private CheckBox HudKRBox;
        private LinkLabel linkLabel19;
        private CheckBox GraphicsKRBox;
        private LinkLabel linkLabel20;
        private CheckBox MapsKRBox;
        private LinkLabel linkLabel21;
        private CheckBox QuestingBotsKRBox;
        private LinkLabel linkLabel22;
        private CheckBox RealismKRBox;
        private LinkLabel linkLabel23;
        private CheckBox DonutKRBox;
        private LinkLabel linkLabel24;
        private CheckBox SAINKRBox;
        private LinkLabel linkLabel27;
        private CheckBox ContextMenuBox;
        private LinkLabel linkLabel30;
        private CheckBox ModdingBox;
        private LinkLabel linkLabel35;
        private CheckBox FireSupportBox;
        private LinkLabel linkLabel29;
        private CheckBox ModdingKRBox;
        private LinkLabel linkLabel31;
        private CheckBox VisceralBox;
        private LinkLabel linkLabel34;
        private CheckBox FireSupportKRBox;
        private LinkLabel linkLabel33;
        private CheckBox BloodyBox;
        private LinkLabel linkLabel36;
        private CheckBox BloodyKRBox;
        private Label label1;
        private Label label2;
        private LinkLabel linkLabel37;
        private CheckBox SPTTexKRBox;
        private LinkLabel linkLabel38;
        private CheckBox SPTLogoKRBox;
        private LinkLabel linkLabel39;
        private CheckBox SPTKRBox;
        private Label label3;
        private RadioButton SPTTexDefaultBtn;
        private RadioButton SPTTex4096Btn;
        private LinkLabel linkLabel40;
    }
}
