namespace GoLani_ModPack
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MenuPanel = new Panel();
            SPTVersionlabel = new Label();
            downloadProgressBar = new ProgressBar();
            VersionLabel = new Label();
            ModInfoBtn = new Button();
            InstallBtn = new Button();
            DeleteModBtn = new Button();
            HomeBtn = new Button();
            LogoPanel = new Panel();
            MainPanel = new Panel();
            MainFramePanel = new TableLayoutPanel();
            TopTextpanel = new Panel();
            label2 = new Label();
            MenuPanel.SuspendLayout();
            MainFramePanel.SuspendLayout();
            TopTextpanel.SuspendLayout();
            SuspendLayout();
            // 
            // MenuPanel
            // 
            MenuPanel.BackColor = Color.FromArgb(229, 230, 228);
            MenuPanel.Controls.Add(SPTVersionlabel);
            MenuPanel.Controls.Add(downloadProgressBar);
            MenuPanel.Controls.Add(VersionLabel);
            MenuPanel.Controls.Add(ModInfoBtn);
            MenuPanel.Controls.Add(InstallBtn);
            MenuPanel.Controls.Add(DeleteModBtn);
            MenuPanel.Controls.Add(HomeBtn);
            MenuPanel.Controls.Add(LogoPanel);
            MenuPanel.Dock = DockStyle.Left;
            MenuPanel.Location = new Point(0, 0);
            MenuPanel.Margin = new Padding(0);
            MenuPanel.Name = "MenuPanel";
            MenuPanel.Size = new Size(187, 761);
            MenuPanel.TabIndex = 0;
            // 
            // SPTVersionlabel
            // 
            SPTVersionlabel.AutoSize = true;
            SPTVersionlabel.Location = new Point(12, 737);
            SPTVersionlabel.Name = "SPTVersionlabel";
            SPTVersionlabel.Size = new Size(55, 15);
            SPTVersionlabel.TabIndex = 9;
            SPTVersionlabel.Text = "SPT 버전";
            // 
            // downloadProgressBar
            // 
            downloadProgressBar.Location = new Point(12, 688);
            downloadProgressBar.Name = "downloadProgressBar";
            downloadProgressBar.Size = new Size(163, 20);
            downloadProgressBar.TabIndex = 8;
            downloadProgressBar.Visible = false;
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.Location = new Point(12, 716);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(71, 15);
            VersionLabel.TabIndex = 6;
            VersionLabel.Text = "모드팩 버전";
            // 
            // ModInfoBtn
            // 
            ModInfoBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ModInfoBtn.Enabled = false;
            ModInfoBtn.FlatAppearance.BorderSize = 0;
            ModInfoBtn.FlatStyle = FlatStyle.Flat;
            ModInfoBtn.Font = new Font("맑은 고딕", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModInfoBtn.ForeColor = SystemColors.ControlText;
            ModInfoBtn.Image = (Image)resources.GetObject("ModInfoBtn.Image");
            ModInfoBtn.ImageAlign = ContentAlignment.MiddleLeft;
            ModInfoBtn.Location = new Point(0, 178);
            ModInfoBtn.Margin = new Padding(0);
            ModInfoBtn.Name = "ModInfoBtn";
            ModInfoBtn.Size = new Size(187, 75);
            ModInfoBtn.TabIndex = 5;
            ModInfoBtn.Text = "   모드 설명   \r\n(추가 예정)";
            ModInfoBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            ModInfoBtn.UseVisualStyleBackColor = true;
            ModInfoBtn.Click += ModInfoBtn_Click;
            // 
            // InstallBtn
            // 
            InstallBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            InstallBtn.FlatAppearance.BorderSize = 0;
            InstallBtn.FlatStyle = FlatStyle.Flat;
            InstallBtn.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            InstallBtn.ForeColor = SystemColors.ControlText;
            InstallBtn.Image = (Image)resources.GetObject("InstallBtn.Image");
            InstallBtn.ImageAlign = ContentAlignment.MiddleLeft;
            InstallBtn.Location = new Point(0, 253);
            InstallBtn.Margin = new Padding(0);
            InstallBtn.Name = "InstallBtn";
            InstallBtn.Size = new Size(187, 75);
            InstallBtn.TabIndex = 3;
            InstallBtn.Text = "    모드 설치";
            InstallBtn.UseVisualStyleBackColor = true;
            InstallBtn.Click += InstallBtn_Click;
            // 
            // DeleteModBtn
            // 
            DeleteModBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DeleteModBtn.Enabled = false;
            DeleteModBtn.FlatAppearance.BorderSize = 0;
            DeleteModBtn.FlatStyle = FlatStyle.Flat;
            DeleteModBtn.Font = new Font("맑은 고딕", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            DeleteModBtn.ForeColor = SystemColors.ControlText;
            DeleteModBtn.Image = (Image)resources.GetObject("DeleteModBtn.Image");
            DeleteModBtn.ImageAlign = ContentAlignment.MiddleLeft;
            DeleteModBtn.Location = new Point(0, 328);
            DeleteModBtn.Margin = new Padding(0);
            DeleteModBtn.Name = "DeleteModBtn";
            DeleteModBtn.Size = new Size(187, 75);
            DeleteModBtn.TabIndex = 2;
            DeleteModBtn.Text = "   모드 초기화\r (추가 예정)";
            DeleteModBtn.UseVisualStyleBackColor = true;
            DeleteModBtn.Click += DeleteModBtn_Click;
            // 
            // HomeBtn
            // 
            HomeBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            HomeBtn.FlatAppearance.BorderSize = 0;
            HomeBtn.FlatStyle = FlatStyle.Flat;
            HomeBtn.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            HomeBtn.ForeColor = SystemColors.ControlText;
            HomeBtn.Image = (Image)resources.GetObject("HomeBtn.Image");
            HomeBtn.ImageAlign = ContentAlignment.MiddleLeft;
            HomeBtn.Location = new Point(0, 103);
            HomeBtn.Margin = new Padding(0);
            HomeBtn.Name = "HomeBtn";
            HomeBtn.Size = new Size(187, 75);
            HomeBtn.TabIndex = 1;
            HomeBtn.Text = "홈";
            HomeBtn.UseVisualStyleBackColor = true;
            HomeBtn.Click += HomeBtn_Click;
            // 
            // LogoPanel
            // 
            LogoPanel.BackColor = SystemColors.Control;
            LogoPanel.BackgroundImage = (Image)resources.GetObject("LogoPanel.BackgroundImage");
            LogoPanel.Dock = DockStyle.Top;
            LogoPanel.Location = new Point(0, 0);
            LogoPanel.Margin = new Padding(0);
            LogoPanel.Name = "LogoPanel";
            LogoPanel.Size = new Size(187, 100);
            LogoPanel.TabIndex = 0;
            // 
            // MainPanel
            // 
            MainPanel.Location = new Point(0, 100);
            MainPanel.Margin = new Padding(0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(997, 661);
            MainPanel.TabIndex = 2;
            // 
            // MainFramePanel
            // 
            MainFramePanel.ColumnCount = 1;
            MainFramePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            MainFramePanel.Controls.Add(MainPanel, 0, 1);
            MainFramePanel.Controls.Add(TopTextpanel, 0, 0);
            MainFramePanel.Dock = DockStyle.Fill;
            MainFramePanel.Location = new Point(187, 0);
            MainFramePanel.Margin = new Padding(0);
            MainFramePanel.Name = "MainFramePanel";
            MainFramePanel.RowCount = 2;
            MainFramePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            MainFramePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 661F));
            MainFramePanel.Size = new Size(997, 761);
            MainFramePanel.TabIndex = 1;
            // 
            // TopTextpanel
            // 
            TopTextpanel.BackColor = Color.FromArgb(229, 230, 228);
            TopTextpanel.Controls.Add(label2);
            TopTextpanel.Dock = DockStyle.Fill;
            TopTextpanel.Location = new Point(0, 0);
            TopTextpanel.Margin = new Padding(0);
            TopTextpanel.Name = "TopTextpanel";
            TopTextpanel.Size = new Size(997, 100);
            TopTextpanel.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Lime;
            label2.Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label2.Location = new Point(87, 5);
            label2.Name = "label2";
            label2.Size = new Size(775, 90);
            label2.TabIndex = 0;
            label2.Text = "** 현재 SPT 3.10 버전으로 업데이트되었습니다.\r\n잠겨있는 모드 설치시 오류가 발생할 수 있습니다. **\r\n";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(110, 114, 113);
            ClientSize = new Size(1184, 761);
            Controls.Add(MainFramePanel);
            Controls.Add(MenuPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "고라니 한글화 모드 간편설치기";
            Load += StartLoadForm;
            MenuPanel.ResumeLayout(false);
            MenuPanel.PerformLayout();
            MainFramePanel.ResumeLayout(false);
            TopTextpanel.ResumeLayout(false);
            TopTextpanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel MenuPanel;
        private Button HomeBtn;
        private Button InstallBtn;
        private Button DeleteModBtn;
        private Button ModInfoBtn;
        private Panel MainPanel;
        private TableLayoutPanel MainFramePanel;
        private Panel TopTextpanel;
        private Label VersionLabel;
        private ProgressBar downloadProgressBar;
        private Label label2;
        private Panel LogoPanel;
        private Label SPTVersionlabel;
    }
}
