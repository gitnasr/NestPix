using NestPix.Helpers;
using NestPix.Services;
using NestPix.Types;
using System.Diagnostics;

namespace NestPix
{
    public partial class ViewerScreen : Form
    {
        NavigationService NS;
        DraggablePictureBox OverlyPictureBox = new DraggablePictureBox
        {
            SizeMode = PictureBoxSizeMode.Zoom,
            Size = new Size(450, 450),
            BackColor = Color.Transparent,
        };

        private ConfigService Config = new ConfigService();
        private Pix Pixy;
        private int RemainingCount = 0;

        private int MarkedAsDeletedCount = 0;



        private void RenderLabels()
        {

            CurrentFileLink.Text = Pixy.ImageName;
            CurrentFolderLabel.Text = Pixy.CurrentDir;
        }

        public ViewerScreen()
        {
            InitializeComponent();

            NS = new NavigationService();
            MainFolderLabel.Text = SessionService.CurrentSession.Folder;
            AlreadySeenCountLabel.Text = $"Already Seen: {SessionService.CurrentSession.AlreadySeenCount}";
            RemainingCount = SessionService.CurrentSession.FolderCount - SessionService.CurrentSession.AlreadySeenCount;
            RemaingCountLabel.Text = $"Remaining: {RemainingCount.ToString("N0")}";

        }
        private Image LoadImage(string path)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                throw new FileNotFoundException("Image not found", path);
            }
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {

                using (var tempImage = Image.FromStream(stream))
                {
                    return new Bitmap(tempImage);
                }
            }
        }
        private void ViewerScreen_Load(object sender, EventArgs e)
        {



            Pixy = NS.GetNext();

            if (Pixy.ImagePath != null)
            {

                MainImage.Image = LoadImage(Pixy.ImagePath);
            }
            else
            {
                MessageBox.Show("Nothing to more show... ", "End of Images", MessageBoxButtons.OK);
                Application.Exit();
            }

            if (Pixy.Preview != null)
            {
                OverlyPictureBox.Parent = MainImage;
                OverlyPictureBox.Image = LoadImage(Pixy.Preview);

            }

            RenderLabels();

            MainImage.Controls.Add(OverlyPictureBox);

        }
        void OpenInExplorer(string path)
        {
            if (path != null)
            {

                Process.Start("explorer.exe", $"/select, \"{path}\"");
            }
        }

        private void HandleNavigation(KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Escape)
            {
                HandleDelete();

                Application.Exit();
            }


            if (e.KeyCode == Config.Shortcuts[Actions.Next])
            {

                NS.AddToCache(Pixy, Actions.Next);

                var pixy = NS.GetNext();
                if (pixy.IsValid)
                {
                    RemaingCountLabel.Text = $"Remaining: {--RemainingCount}";
                    Pixy = pixy;
                }
                else
                {
                    MessageBox.Show("Nothing to more show... ", "End of Images", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HandleDelete();
                    Application.Exit();

                }



            }

            if (e.KeyCode == Config.Shortcuts[Actions.Previous])
            {

                var pixy = NS.GetPrevious();
                if (pixy.IsValid)
                {
                    Pixy = pixy;
                    RemaingCountLabel.Text = $"Remaining: {++RemainingCount}";

                }

            }

            if (e.KeyCode == Config.Shortcuts[Actions.Delete])
            {

                NS.AddToCache(Pixy, Actions.Delete);
                var pixy = NS.GetNext();
                if (!pixy.IsValid)
                {
                    MessageBox.Show("Nothing to more show... ", "End of Images", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    HandleDelete();
                    return;
                }
                else
                {
                    Pixy = pixy;
                    RemaingCountLabel.Text = $"Remaining: {--RemainingCount}";
                }


                SaveButton.Enabled = true;
                MarkedAsDeletedCount++;


            }

            if (Pixy.ImagePath is not null
                && string.IsNullOrEmpty(Pixy.ImagePath) == false
                && string.IsNullOrWhiteSpace(Pixy.ImagePath) == false
                && File.Exists(Pixy.ImagePath) == true)
            {
                MainImage.Image = LoadImage(Pixy.ImagePath);

                if (Pixy.Preview != null) OverlyPictureBox.Image = LoadImage(Pixy.Preview);

            }
            RenderLabels();

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.Right)
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void ViewerScreen_KeyDown(object sender, KeyEventArgs e)
        {

            HandleNavigation(e);
        }

        private void HandleDelete()
        {
            _ = NS.DeleteAll();
            SaveButton.Enabled = false;
            MarkedAsDeletedCount = 0;
        }

        private void MainImage_Click(object sender, EventArgs e)
        {
            OverlyPictureBox.Show();
        }

        private void CurrentFileLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Pixy is not null && Pixy.ImagePath is not null)
            {
                OpenInExplorer(Pixy.ImagePath);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                   $"You're about to delete about {MarkedAsDeletedCount} photos. \n" +
                   $"It won't be deleted permanently, Photos will be moved to Deleted Folder. \n" +
                   $"You can recover them later.", "Confirm Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                HandleDelete();
            }
        }

        private void IdleTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan idle = IdleHook.GetIdleTime();
            if (idle.TotalSeconds >= ConfigService.IdleTimeInSeconds && MarkedAsDeletedCount > 0)
            {
                HandleDelete();
                MessageBox.Show(
                   $"You've been idle for more than {ConfigService.IdleTime} minutes\n" +
                   $"As a result we auto saved your progress since we don't lose the progress :D"
                  , "We got your back", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
    }
}
