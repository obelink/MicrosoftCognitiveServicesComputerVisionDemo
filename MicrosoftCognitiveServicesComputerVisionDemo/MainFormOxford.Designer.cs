namespace MicrosoftCognitiveServicesComputerVisionDemo
{
    partial class MainFormOxford
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
            this.imageFilePathTextBox = new System.Windows.Forms.TextBox();
            this.selectImageFilePathButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imageFilePathTextBox
            // 
            this.imageFilePathTextBox.Location = new System.Drawing.Point(22, 20);
            this.imageFilePathTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imageFilePathTextBox.Multiline = true;
            this.imageFilePathTextBox.Name = "imageFilePathTextBox";
            this.imageFilePathTextBox.ReadOnly = true;
            this.imageFilePathTextBox.Size = new System.Drawing.Size(408, 28);
            this.imageFilePathTextBox.TabIndex = 0;
            // 
            // selectImageFilePathButton
            // 
            this.selectImageFilePathButton.Location = new System.Drawing.Point(432, 20);
            this.selectImageFilePathButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectImageFilePathButton.Name = "selectImageFilePathButton";
            this.selectImageFilePathButton.Size = new System.Drawing.Size(41, 27);
            this.selectImageFilePathButton.TabIndex = 1;
            this.selectImageFilePathButton.Text = "...";
            this.selectImageFilePathButton.UseVisualStyleBackColor = true;
            this.selectImageFilePathButton.Click += new System.EventHandler(this.selectImageFilePathButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(20, 56);
            this.resultTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resultTextBox.Size = new System.Drawing.Size(453, 32);
            this.resultTextBox.TabIndex = 3;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(20, 103);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(450, 450);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // MainFormOxford
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 577);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.selectImageFilePathButton);
            this.Controls.Add(this.imageFilePathTextBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainFormOxford";
            this.Text = "Computer Vision Api - Demo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox imageFilePathTextBox;
        private System.Windows.Forms.Button selectImageFilePathButton;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

