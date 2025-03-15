using NestPix.Services;
using NestPix.Types;

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
            NextImage next = NS.GetNext();
            MainImage.Image = Image.FromFile(next.ImagePath);

            if (next.NextPreview != null)
            {
                PreviewImage.Image = Image.FromFile(next.NextPreview);

            }


        }

        private void MainImage_MouseClick(object sender, MouseEventArgs e)
        {
            NextImage next = NS.GetNext();
            if (next.ImagePath != null)
            {
                MainImage.Image = Image.FromFile(next.ImagePath);
                if (next.NextPreview != null)
                {
                    PreviewImage.Image = Image.FromFile(next.NextPreview);

                }
            }
            if (!next.IsHasNext)
            {
                MessageBox.Show("EOF");
            }


        }


    }
}
