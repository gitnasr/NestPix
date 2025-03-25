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


            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            Debug.WriteLine(Config.Shortcuts.Count);

            if (e.KeyCode == Config.Shortcuts[Actions.Next])
            {
                Pix next = NS.GetNext();
                if (next.ImagePath != null)
                {
                    MainImage.Image = Image.FromFile(next.ImagePath);
                    if (next.Preview != null)
                    {
                        OverlyPictureBox.Image = Image.FromFile(next.Preview);
                    }
                }
            }

            if (e.KeyCode == Config.Shortcuts[Actions.Previous])
            {
                Pix Previous = NS.GetPrevious();
                if (Previous.ImagePath != null)
                {
                    MainImage.Image = Image.FromFile(Previous.ImagePath);
                    if (Previous.Preview != null)
                    {
                        OverlyPictureBox.Image = Image.FromFile(Previous.Preview);
                    }
                }
            }

            if (e.KeyCode == Config.Shortcuts[Actions.Delete])
            {
                // Delete Action
                MessageBox.Show("Delete Action");
            }




        }

        private void MainImage_Click(object sender, EventArgs e)
        {
            OverlyPictureBox.Show();
        }
    }
}
