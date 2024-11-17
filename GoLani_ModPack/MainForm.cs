using GoLani_ModPack.Pages;

namespace GoLani_ModPack
{
    public partial class MainForm : Form
    {
        private UserControl[] pages;

        public MainForm()
        {
            InitializeComponent();

            pages = new UserControl[] { new HomePage(), new ModInfomationPage(), new InstallModPage(), new DeleteModPage(), };

        }

        private void StartLoadForm(object sender, EventArgs e)
        {
            MainPanel.Controls.Add(pages[0]);
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
    }
}
