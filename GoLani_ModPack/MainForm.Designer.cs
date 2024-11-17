namespace GoLani_ModPack
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MenuPanel = new Panel();
            ModInfoBtn = new Button();
            InstallBtn = new Button();
            DeleteModBtn = new Button();
            HomeBtn = new Button();
            LogoPanel = new Panel();
            MainPanel = new Panel();
            MainFramePanel = new TableLayoutPanel();
            TopTextpanel = new Panel();
            MenuPanel.SuspendLayout();
            MainFramePanel.SuspendLayout();
            SuspendLayout();
            // 
            // MenuPanel
            // 
            MenuPanel.BackColor = Color.FromArgb(229, 230, 228);
            MenuPanel.Controls.Add(ModInfoBtn);
            MenuPanel.Controls.Add(InstallBtn);
            MenuPanel.Controls.Add(DeleteModBtn);
            MenuPanel.Controls.Add(HomeBtn);
            MenuPanel.Controls.Add(LogoPanel);
            MenuPanel.Dock = DockStyle.Left;
            MenuPanel.Location = new Point(0, 0);
            MenuPanel.Margin = new Padding(0);
            MenuPanel.Name = "MenuPanel";
            MenuPanel.Size = new Size(250, 761);
            MenuPanel.TabIndex = 0;
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
            ModInfoBtn.Size = new Size(247, 75);
            ModInfoBtn.TabIndex = 5;
            ModInfoBtn.Text = "모드 설명\r\n(추가 예정)";
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
            InstallBtn.Size = new Size(247, 75);
            InstallBtn.TabIndex = 3;
            InstallBtn.Text = "모드 설치";
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
            DeleteModBtn.Size = new Size(247, 75);
            DeleteModBtn.TabIndex = 2;
            DeleteModBtn.Text = "모드 초기화\r\n(추가 예정)";
            DeleteModBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
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
            HomeBtn.Size = new Size(247, 75);
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
            LogoPanel.Size = new Size(250, 100);
            LogoPanel.TabIndex = 0;
            // 
            // MainPanel
            // 
            MainPanel.Location = new Point(0, 100);
            MainPanel.Margin = new Padding(0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(934, 661);
            MainPanel.TabIndex = 2;
            // 
            // MainFramePanel
            // 
            MainFramePanel.ColumnCount = 1;
            MainFramePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            MainFramePanel.Controls.Add(MainPanel, 0, 1);
            MainFramePanel.Controls.Add(TopTextpanel, 0, 0);
            MainFramePanel.Dock = DockStyle.Fill;
            MainFramePanel.Location = new Point(250, 0);
            MainFramePanel.Margin = new Padding(0);
            MainFramePanel.Name = "MainFramePanel";
            MainFramePanel.RowCount = 2;
            MainFramePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            MainFramePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 661F));
            MainFramePanel.Size = new Size(934, 761);
            MainFramePanel.TabIndex = 1;
            // 
            // TopTextpanel
            // 
            TopTextpanel.BackColor = Color.FromArgb(229, 230, 228);
            TopTextpanel.Dock = DockStyle.Fill;
            TopTextpanel.Location = new Point(0, 0);
            TopTextpanel.Margin = new Padding(0);
            TopTextpanel.Name = "TopTextpanel";
            TopTextpanel.Size = new Size(934, 100);
            TopTextpanel.TabIndex = 3;
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
            Text = "고라니 모드팩";
            Load += StartLoadForm;
            MenuPanel.ResumeLayout(false);
            MainFramePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel MenuPanel;
        private Panel LogoPanel;
        private Button HomeBtn;
        private Button InstallBtn;
        private Button DeleteModBtn;
        private Button ModInfoBtn;
        private Panel MainPanel;
        private TableLayoutPanel MainFramePanel;
        private Panel TopTextpanel;
    }
}
