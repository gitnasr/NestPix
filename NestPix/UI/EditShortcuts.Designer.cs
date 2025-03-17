namespace NestPix.UI
{
    partial class EditShortcuts
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GoNextButton = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            GoBackButton = new Button();
            groupBox3 = new GroupBox();
            DeleteButton = new Button();
            statusStrip1 = new StatusStrip();
            StautsBarLabel = new ToolStripStatusLabel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // GoNextButton
            // 
            GoNextButton.Location = new Point(22, 39);
            GoNextButton.Name = "GoNextButton";
            GoNextButton.Size = new Size(217, 68);
            GoNextButton.TabIndex = 0;
            GoNextButton.Text = "____";
            GoNextButton.UseVisualStyleBackColor = true;
            GoNextButton.Click += GoNextButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(GoNextButton);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(275, 135);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Go Next";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(GoBackButton);
            groupBox2.Location = new Point(284, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(275, 135);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Go Back";
            // 
            // GoBackButton
            // 
            GoBackButton.Location = new Point(22, 39);
            GoBackButton.Name = "GoBackButton";
            GoBackButton.Size = new Size(217, 68);
            GoBackButton.TabIndex = 0;
            GoBackButton.Text = "____";
            GoBackButton.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(DeleteButton);
            groupBox3.Location = new Point(565, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(275, 135);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Delete";
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(22, 39);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(217, 68);
            DeleteButton.TabIndex = 0;
            DeleteButton.Text = "____";
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { StautsBarLabel });
            statusStrip1.Location = new Point(0, 143);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(852, 32);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // StautsBarLabel
            // 
            StautsBarLabel.Name = "StautsBarLabel";
            StautsBarLabel.Size = new Size(77, 25);
            StautsBarLabel.Text = "Ready ...";
            // 
            // EditShortcuts
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(852, 175);
            Controls.Add(statusStrip1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EditShortcuts";
            StartPosition = FormStartPosition.CenterScreen;
            Load += EditShortcuts_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GoNextButton;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button GoBackButton;
        private GroupBox groupBox3;
        private Button DeleteButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StautsBarLabel;
    }
}
