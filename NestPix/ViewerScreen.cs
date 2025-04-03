using NestPix.Services;
using NestPix.Types;
using System.Diagnostics;

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



            Pix next = NS.GetNext();
            if (next.ImagePath != null)
                MainImage.Image = Image.FromFile(next.ImagePath);

            if (next.Preview != null)
            {
                OverlyPictureBox.Parent = MainImage;
                OverlyPictureBox.Image = Image.FromFile(next.Preview);

            }

            MainImage.Controls.Add(OverlyPictureBox);

        }



        private void ViewerScreen_KeyDown(object sender, KeyEventArgs e)
        {
            Pix? Pixy = null;

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            Debug.WriteLine(Config.Shortcuts.Count);

            if (e.KeyCode == Config.Shortcuts[Actions.Next])
            {
                Pixy = NS.GetNext();

            }

            if (e.KeyCode == Config.Shortcuts[Actions.Previous])
            {
                Pixy = NS.GetPrevious();

            }

            if (e.KeyCode == Config.Shortcuts[Actions.Delete])
            {
                // Delete Action
                MessageBox.Show("Delete Action");
            }
            if (Pixy == null)
            {
                return;
            }
            if (Pixy.ImagePath != null)
            {
                MainImage.Image = Image.FromFile(Pixy.ImagePath);
                if (Pixy.Preview != null)
                {
                    OverlyPictureBox.Image = Image.FromFile(Pixy.Preview);
                }
            }



        }

        private void MainImage_Click(object sender, EventArgs e)
        {
            OverlyPictureBox.Show();
        }
    }
}
