namespace NestPix
{
    partial class StartScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            PathTextBox = new TextBox();
            panel1 = new Panel();
            start = new Button();
            StatusBar = new StatusStrip();
            StatusBarLabel = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            editKeybindgToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            StatusBar.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 16);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 0;
            label1.Text = "Folder Path";
            label1.TextAlign = ContentAlignment.BottomRight;
            // 
            // PathTextBox
            // 
            PathTextBox.BorderStyle = BorderStyle.FixedSingle;
            PathTextBox.Location = new Point(110, 14);
            PathTextBox.Name = "PathTextBox";
            PathTextBox.Size = new Size(459, 31);
            PathTextBox.TabIndex = 1;
            PathTextBox.TextChanged += PathTextBox_TextChanged;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(start);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(PathTextBox);
            panel1.Location = new Point(0, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(794, 51);
            panel1.TabIndex = 3;
            // 
            // start
            // 
            start.Enabled = false;
            start.Location = new Point(575, 14);
            start.Name = "start";
            start.Size = new Size(213, 34);
            start.TabIndex = 2;
            start.Text = "Go";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // StatusBar
            // 
            StatusBar.ImageScalingSize = new Size(24, 24);
            StatusBar.Items.AddRange(new ToolStripItem[] { StatusBarLabel });
            StatusBar.Location = new Point(0, 106);
            StatusBar.Name = "StatusBar";
            StatusBar.RenderMode = ToolStripRenderMode.Professional;
            StatusBar.Size = new Size(794, 32);
            StatusBar.TabIndex = 4;
            StatusBar.Text = "statusStrip1";
            // 
            // StatusBarLabel
            // 
            StatusBarLabel.Name = "StatusBarLabel";
            StatusBarLabel.Size = new Size(179, 25);
            StatusBarLabel.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, editKeybindgToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(794, 33);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(55, 29);
            toolStripMenuItem1.Text = "&Exit";
            // 
            // editKeybindgToolStripMenuItem
            // 
            editKeybindgToolStripMenuItem.Name = "editKeybindgToolStripMenuItem";
            editKeybindgToolStripMenuItem.Size = new Size(138, 29);
            editKeybindgToolStripMenuItem.Text = "Edit Keybindg";
            // 
            // StartScreen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(794, 138);
            Controls.Add(menuStrip1);
            Controls.Add(StatusBar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "StartScreen";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NestPix";
            TopMost = true;
            Load += StartScreen_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            StatusBar.ResumeLayout(false);
            StatusBar.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox PathTextBox;
        private Panel panel1;
        private Button start;
        private StatusStrip StatusBar;
        private ToolStripStatusLabel StatusBarLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem editKeybindgToolStripMenuItem;
    }
}
