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
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)MainImage).BeginInit();
            SuspendLayout();
            // 
            // MainImage
            // 
            MainImage.Location = new Point(6, 8);
            MainImage.Name = "MainImage";
            MainImage.Size = new Size(1154, 1142);
            MainImage.SizeMode = PictureBoxSizeMode.Zoom;
            MainImage.TabIndex = 0;
            MainImage.TabStop = false;
            MainImage.MouseClick += MainImage_MouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 1185);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // ViewerScreen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1172, 1312);
            Controls.Add(label1);
            Controls.Add(MainImage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ViewerScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViewerScreen";
            Load += ViewerScreen_Load;
            KeyDown += ViewerScreen_KeyDown;
            ((System.ComponentModel.ISupportInitialize)MainImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox MainImage;
        private Label label1;
    }
}