namespace GoLani_ModPack.Pages
{
    partial class HomePage
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
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(31, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(864, 302);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(31, 331);
            panel2.Name = "panel2";
            panel2.Size = new Size(864, 302);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.Location = new Point(17, 8);
            label1.Name = "label1";
            label1.Size = new Size(86, 32);
            label1.TabIndex = 0;
            label1.Text = "인사말";
            // 
            // panel3
            // 
            panel3.BackColor = Color.MidnightBlue;
            panel3.Location = new Point(17, 43);
            panel3.Name = "panel3";
            panel3.Size = new Size(824, 5);
            panel3.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.MidnightBlue;
            panel4.Location = new Point(17, 44);
            panel4.Name = "panel4";
            panel4.Size = new Size(824, 5);
            panel4.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label2.Location = new Point(17, 9);
            label2.Name = "label2";
            label2.Size = new Size(86, 32);
            label2.TabIndex = 2;
            label2.Text = "인사말";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label3.Location = new Point(17, 105);
            label3.Name = "label3";
            label3.Size = new Size(556, 21);
            label3.TabIndex = 2;
            label3.Text = "안녕하세요! 현재 아카라이브 SPT 채널에서 활동하고 있는 _고라니_ 입니다.\r\n";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 129);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(17, 51);
            label4.Name = "label4";
            label4.Size = new Size(817, 37);
            label4.TabIndex = 3;
            label4.Text = "** 테스트 버전입니다. 기능 및 여러 문제가 발생할 수 있습니다. **";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label5.Location = new Point(17, 62);
            label5.Name = "label5";
            label5.Size = new Size(42, 21);
            label5.TabIndex = 4;
            label5.Text = "아아";
            // 
            // HomePage
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(0);
            Name = "HomePage";
            Size = new Size(934, 661);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Panel panel3;
        private Label label1;
        private Panel panel2;
        private Panel panel4;
        private Label label2;
        private Label label4;
        private Label label5;
    }
}
