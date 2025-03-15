using NestPix.Services;
using NestPix.Types;

namespace NestPix
{
    public partial class ViewerScreen : Form
    {
        NavigationService NS = new NavigationService();
        DraggablePictureBox OverlyPictureBox = new DraggablePictureBox
        {
            SizeMode = PictureBoxSizeMode.Zoom,

            Size = new Size(250, 250),
            BackColor = Color.Transparent,

        };



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
                OverlyPictureBox.Parent = MainImage;

                OverlyPictureBox.Image = Image.FromFile(next.NextPreview);

            }

            MainImage.Controls.Add(OverlyPictureBox);

        }

        private void MainImage_MouseClick(object sender, MouseEventArgs e)
        {
            NextImage next = NS.GetNext();
            if (next.ImagePath != null)
            {
                MainImage.Image = Image.FromFile(next.ImagePath);
                if (next.NextPreview != null)
                {
                    OverlyPictureBox.Image = Image.FromFile(next.NextPreview);

                }
            }
            if (!next.IsHasNext)
            {
                MessageBox.Show("EOF");
            }


        }


    }
}
