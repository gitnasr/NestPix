using NestPix.Services;

namespace NestPix
{
    public partial class ViewerScreen : Form
    {
        NavigationService NS = new NavigationService();


        public ViewerScreen()
        {
            InitializeComponent();
        }

        private void ViewerScreen_Load(object sender, EventArgs e)
        {



            MainImage.Image = Image.FromFile(NS.GetNext());

        }

        private void MainImage_Click(object sender, EventArgs e)
        {
            MainImage.Image = Image.FromFile(NS.GetNext());
        }
    }
}
