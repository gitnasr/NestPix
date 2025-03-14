using NestPix.Services;

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
            // Get Directories and Sub Directories
            string FolderPath = PathTextBox.Text;

            FilesService FilesService = new FilesService(FolderPath);


            var result = await FilesService.GetAllImages(UpdateUI);

            PathTextBox.Enabled = true;

            MessageBox.Show(result.Count.ToString());



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

        private void StartScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
