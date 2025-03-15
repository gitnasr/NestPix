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
            MainImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)MainImage).BeginInit();
            SuspendLayout();
            // 
            // MainImage
            // 
            MainImage.Location = new Point(6, 8);
            MainImage.Name = "MainImage";
            MainImage.Size = new Size(1166, 1142);
            MainImage.TabIndex = 0;
            MainImage.TabStop = false;
            MainImage.Click += MainImage_Click;
            MainImage.MouseClick += MainImage_MouseClick;
            // 
            // ViewerScreen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1183, 1312);
            Controls.Add(MainImage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ViewerScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViewerScreen";
            Load += ViewerScreen_Load;
            ((System.ComponentModel.ISupportInitialize)MainImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox MainImage;
    }
}