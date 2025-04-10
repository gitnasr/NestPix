using NestPix.Services;
using NestPix.UI;
using System.Diagnostics;

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
                Invoke(() =>
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

            new ViewerScreen().Show();
            Hide();


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


        private void openDeleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", ConfigService.DeleteFolderPath);
        }

        private async void StartScreen_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                var update = new UpdateService();
                await update.CheckForUpdateAsync();
                var updateAvailable = update.IsUpdateAvailable();

                if (updateAvailable && update.LatestVersionUrl is not null)
                {
                    var result = MessageBox.Show("An update is available. ", "Update Available", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        var update_url = update.DownloadUpdate();


                        Process.Start(new ProcessStartInfo(update_url) { UseShellExecute = true });

                    }
                    Application.Exit();


                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error while update check", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();

            }


        }
    }
}
