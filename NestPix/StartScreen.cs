using NestPix.Services;

namespace NestPix
{
    public partial class StartScreen : Form
    {

        public StartScreen()
        {

            InitializeComponent();
            StatusBarLabel.Text = "Waiting For start...";
        }

        private void start_Click(object sender, EventArgs e)
        {
            // Get Directories and Sub Directories
            string Path = PathTextBox.Text;
            FilesService FilesService = new FilesService(Path);

            FilesService.GetAllImages();

            //ScanService Scanner = new ScanService(Path);


            //Scanner.GetAllDirectories();
            //Scanner.Dirs.ForEach(dir => MessageBox.Show(dir));
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
