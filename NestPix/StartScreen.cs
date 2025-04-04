using NestPix.Services;
using NestPix.UI;

namespace NestPix
{
    public partial class StartScreen : Form
    {
        Action<string> UpdateUI;

        public StartScreen()
        {

            InitializeComponent();
            UpdateUI = (string status) =>
            {
                this.Invoke(() =>
                {
                    StatusLabel.Text = status;
                });
            };
        }

        private async void start_Click(object sender, EventArgs e)
        {
            PathTextBox.Enabled = false;
            string FolderPath = PathTextBox.Text;

            FilesService FilesService = new FilesService(FolderPath);


            await FilesService.GetAllImages(UpdateUI);

            PathTextBox.Enabled = true;

            new ViewerScreen(FolderPath).Show();


        }

        private void PathTextBox_TextChanged(object sender, EventArgs e)
        {
            string Path = PathTextBox.Text;

            bool isNull = Path == string.Empty || Path == null;
            if (!isNull && Directory.Exists(Path))
            {
                start.Enabled = true;
            }
            else
            {
                start.Enabled = false;
            }
        }

        private void editKeybindgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditShortcuts EditShortcuts = new EditShortcuts();
            EditShortcuts.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
