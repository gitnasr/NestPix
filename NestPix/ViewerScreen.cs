using NestPix.Services;

namespace NestPix
{
    public partial class ViewerScreen : Form
    {
        NavigationService NS = new NavigationService();
        DraggablePictureBox OverlyPictureBox = new DraggablePictureBox
        {
            SizeMode = PictureBoxSizeMode.Zoom,
            Size = new Size(450, 450),
            BackColor = Color.Transparent,
        };

        private ConfigService Config = new ConfigService();



        public ViewerScreen()
        {
            InitializeComponent();
        }

        private void ViewerScreen_Load(object sender, EventArgs e)
        {



            Types.Pix next = NS.GetNext();
            MainImage.Image = System.Drawing.Image.FromFile(next.ImagePath);

            if (next.NextPreview != null)
            {
                OverlyPictureBox.Parent = MainImage;
                OverlyPictureBox.Image = System.Drawing.Image.FromFile(next.NextPreview);

            }

            MainImage.Controls.Add(OverlyPictureBox);

        }

        private void MainImage_MouseClick(object sender, MouseEventArgs e)
        {
            Types.Pix next = NS.GetNext();
            if (next.ImagePath != null)
            {
                MainImage.Image = System.Drawing.Image.FromFile(next.ImagePath);
                if (next.NextPreview != null)
                {
                    OverlyPictureBox.Image = System.Drawing.Image.FromFile(next.NextPreview);

                }
            }
            if (!next.IsHasNext)
            {
                MessageBox.Show("EOF");
            }


        }

        private void ViewerScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Config.Shortcuts["Delete"])
            {
            }
            else if (e.KeyCode == Config.Shortcuts["Next"])
            {
                Types.Pix next = NS.GetNext();

                MainImage.Image = System.Drawing.Image.FromFile(next.ImagePath);
                if (next.NextPreview != null)
                {
                    OverlyPictureBox.Parent = MainImage;
                    OverlyPictureBox.Image = System.Drawing.Image.FromFile(next.NextPreview);

                }
            }
            else if (e.KeyCode == Config.Shortcuts["Previous"])
            {
                Types.Pix next = NS.GetPrevious();
                MainImage.Image = System.Drawing.Image.FromFile(next.ImagePath);
                if (next.NextPreview != null)
                {
                    OverlyPictureBox.Parent = MainImage;
                    OverlyPictureBox.Image = System.Drawing.Image.FromFile(next.NextPreview);

                }

            }
        }
    }
}
