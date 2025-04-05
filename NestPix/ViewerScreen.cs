﻿using NestPix.Services;
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
        private Pix? Pixy;
        private int RemainingCount = 0;

        public ViewerScreen(string ParentPath)
        {
            InitializeComponent();

            NS = new NavigationService(ParentPath);
            MainFolderLabel.Text = SessionService.CurrentSession.Folder;
            AlreadySeenCountLabel.Text = "Already Seen: " + SessionService.CurrentSession.AlreadySeenCount;
            RemainingCount = (SessionService.CurrentSession.FolderCount - SessionService.CurrentSession.AlreadySeenCount);
            RemaingCountLabel.Text = "Remaining: " + RemainingCount;

            Focus();
        }

        private void ViewerScreen_Load(object sender, EventArgs e)
        {



            Pixy = NS.GetNext();
            if (Pixy.ImagePath != null)
            { MainImage.Image = Image.FromFile(Pixy.ImagePath); }
            else
            {
                MessageBox.Show("All Images done");
                this.Close();
            }

            if (Pixy.Preview != null)
            {
                OverlyPictureBox.Parent = MainImage;
                OverlyPictureBox.Image = Image.FromFile(Pixy.Preview);

            }

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
            if (Pixy is not null && !Pixy.IsHasNext)
            {
                Pixy = null;
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }


            if (e.KeyCode == Config.Shortcuts[Actions.Next])
            {

                if (Pixy != null)
                {

                    NS.AddToCache(Pixy, Actions.Next);

                    Pixy = NS.GetNext();
                    RemaingCountLabel.Text = "Remaining: " + --RemainingCount;
                    CurrentFileLink.Text = Pixy.ImagePath;



                }




            }

            if (e.KeyCode == Config.Shortcuts[Actions.Previous])
            {

                Pixy = NS.GetPrevious();
                RemaingCountLabel.Text = "Remaining: " + ++RemainingCount;
                CurrentFileLink.Text = Pixy.ImagePath;

            }

            if (e.KeyCode == Config.Shortcuts[Actions.Delete])
            {
                if (Pixy != null)
                {
                    NS.AddToCache(Pixy, Actions.Delete);
                    Pixy = NS.GetNext();
                    RemaingCountLabel.Text = "Remaining: " + --RemainingCount;
                    CurrentFileLink.Text = Pixy.ImagePath;

                }
            }
            if (Pixy != null)
            {
                if (Pixy.ImagePath != null)
                {
                    MainImage.Image = Image.FromFile(Pixy.ImagePath);
                    if (Pixy.Preview != null)
                    {
                        OverlyPictureBox.Image = Image.FromFile(Pixy.Preview);
                    }
                }
                else
                {
                    MessageBox.Show("All Images done");
                    this.Close();
                }
            }
        }

        private void ViewerScreen_KeyDown(object sender, KeyEventArgs e)
        {


            HandleNavigation(e);

        }

        private void MainImage_Click(object sender, EventArgs e)
        {
            OverlyPictureBox.Show();
        }

        private void CurrentFileLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Pixy != null && Pixy.ImagePath is not null)
            {
                OpenInExplorer(Pixy.ImagePath);
            }
        }
    }
}
