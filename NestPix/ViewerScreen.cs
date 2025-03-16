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

        private ConfigService Config = new ConfigService();



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
                label1.Text = NS.GetCurrentDir();
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
                    label1.Text = NS.GetCurrentDir();

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
                NextImage next = NS.GetNext();

                MainImage.Image = Image.FromFile(next.ImagePath);
                if (next.NextPreview != null)
                {
                    OverlyPictureBox.Parent = MainImage;
                    label1.Text = NS.GetCurrentDir();
                    OverlyPictureBox.Image = Image.FromFile(next.NextPreview);

                }
            }
            else if (e.KeyCode == Config.Shortcuts["Previous"])
            {
                NextImage next = NS.GetPrevious();
                MainImage.Image = Image.FromFile(next.ImagePath);
                if (next.NextPreview != null)
                {
                    OverlyPictureBox.Parent = MainImage;
                    label1.Text = NS.GetCurrentDir();
                    OverlyPictureBox.Image = Image.FromFile(next.NextPreview);

                }

            }
        }
    }
}
