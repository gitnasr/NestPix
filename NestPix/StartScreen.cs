using NestPix.Services;
using System.Text.Json;

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

            string json = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });

            string filePath = "data.json";
            File.WriteAllText(filePath, json);


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
