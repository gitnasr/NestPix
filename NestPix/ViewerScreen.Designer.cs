namespace NestPix
{
    partial class ViewerScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            MainImage = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            RemaingCountLabel = new Label();
            CurrentFolderLabel = new Label();
            MainFolderLabel = new Label();
            CurrentFileLink = new LinkLabel();
            AlreadySeenCountLabel = new Label();
            SaveButton = new Button();
            IdleTimer = new System.Windows.Forms.Timer(components);
            OpenDestroyFolderButton = new Button();
            ((System.ComponentModel.ISupportInitialize)MainImage).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // MainImage
            // 
            MainImage.Dock = DockStyle.Top;
            MainImage.Location = new Point(0, 0);
            MainImage.Name = "MainImage";
            MainImage.Size = new Size(1210, 1296);
            MainImage.SizeMode = PictureBoxSizeMode.Zoom;
            MainImage.TabIndex = 0;
            MainImage.TabStop = false;
            MainImage.Click += MainImage_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.636364F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.0909081F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.272728F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 329F));
            tableLayoutPanel1.Controls.Add(RemaingCountLabel, 1, 1);
            tableLayoutPanel1.Controls.Add(CurrentFolderLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(MainFolderLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(CurrentFileLink, 2, 0);
            tableLayoutPanel1.Controls.Add(AlreadySeenCountLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(SaveButton, 3, 1);
            tableLayoutPanel1.Controls.Add(OpenDestroyFolderButton, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 1328);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1210, 81);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // RemaingCountLabel
            // 
            RemaingCountLabel.AutoSize = true;
            RemaingCountLabel.Location = new Point(123, 25);
            RemaingCountLabel.Name = "RemaingCountLabel";
            RemaingCountLabel.Size = new Size(170, 25);
            RemaingCountLabel.TabIndex = 4;
            RemaingCountLabel.Text = "RemaingCountLabel";
            // 
            // CurrentFolderLabel
            // 
            CurrentFolderLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CurrentFolderLabel.AutoSize = true;
            CurrentFolderLabel.Location = new Point(123, 0);
            CurrentFolderLabel.Name = "CurrentFolderLabel";
            CurrentFolderLabel.Size = new Size(514, 25);
            CurrentFolderLabel.TabIndex = 1;
            CurrentFolderLabel.Text = "CurrentFolderLabel";
            CurrentFolderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainFolderLabel
            // 
            MainFolderLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            MainFolderLabel.AutoSize = true;
            MainFolderLabel.Location = new Point(3, 0);
            MainFolderLabel.Name = "MainFolderLabel";
            MainFolderLabel.Size = new Size(106, 25);
            MainFolderLabel.TabIndex = 0;
            MainFolderLabel.Text = "Main Folder";
            MainFolderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CurrentFileLink
            // 
            CurrentFileLink.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CurrentFileLink.AutoSize = true;
            CurrentFileLink.Location = new Point(643, 0);
            CurrentFileLink.Name = "CurrentFileLink";
            CurrentFileLink.Size = new Size(234, 25);
            CurrentFileLink.TabIndex = 2;
            CurrentFileLink.TabStop = true;
            CurrentFileLink.Text = "CurrentFileLink";
            CurrentFileLink.TextAlign = ContentAlignment.MiddleCenter;
            CurrentFileLink.LinkClicked += CurrentFileLink_LinkClicked;
            // 
            // AlreadySeenCountLabel
            // 
            AlreadySeenCountLabel.AutoSize = true;
            AlreadySeenCountLabel.Location = new Point(3, 25);
            AlreadySeenCountLabel.Name = "AlreadySeenCountLabel";
            AlreadySeenCountLabel.Size = new Size(110, 50);
            AlreadySeenCountLabel.TabIndex = 3;
            AlreadySeenCountLabel.Text = "AlreadySeenCountLabel";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(883, 28);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(324, 50);
            SaveButton.TabIndex = 5;
            SaveButton.Text = "Save Changes";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // IdleTimer
            // 
            IdleTimer.Enabled = true;
            IdleTimer.Interval = 5000;
            IdleTimer.Tick += IdleTimer_Tick;
            // 
            // OpenDestroyFolderButton
            // 
            OpenDestroyFolderButton.Location = new Point(643, 28);
            OpenDestroyFolderButton.Name = "OpenDestroyFolderButton";
            OpenDestroyFolderButton.Size = new Size(234, 50);
            OpenDestroyFolderButton.TabIndex = 2;
            OpenDestroyFolderButton.Text = "Open Destroy Folder?";
            OpenDestroyFolderButton.UseVisualStyleBackColor = true;
            OpenDestroyFolderButton.Click += OpenDestroyFolderButton_Click;
            // 
            // ViewerScreen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1210, 1409);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(MainImage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "ViewerScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViewerScreen";
            FormClosing += ViewerScreen_FormClosing;
            FormClosed += ViewerScreen_FormClosed;
            Load += ViewerScreen_Load;
            KeyDown += ViewerScreen_KeyDown;
            ((System.ComponentModel.ISupportInitialize)MainImage).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox MainImage;
        private TableLayoutPanel tableLayoutPanel1;
        private Label CurrentFolderLabel;
        private Label MainFolderLabel;
        private LinkLabel CurrentFileLink;
        private Label RemaingCountLabel;
        private Label AlreadySeenCountLabel;
        private Button SaveButton;
        private System.Windows.Forms.Timer IdleTimer;
        private Button OpenDestroyFolderButton;
    }
}