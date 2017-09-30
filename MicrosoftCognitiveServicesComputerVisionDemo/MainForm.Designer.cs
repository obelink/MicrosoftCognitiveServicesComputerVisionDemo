namespace MicrosoftCognitiveServicesComputerVisionDemo
{
    partial class MainForm
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
            this.jsonResultTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // imageFilePathTextBox
            // 
            this.imageFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageFilePathTextBox.Location = new System.Drawing.Point(40, 37);
            this.imageFilePathTextBox.Multiline = true;
            this.imageFilePathTextBox.Name = "imageFilePathTextBox";
            this.imageFilePathTextBox.ReadOnly = true;
            this.imageFilePathTextBox.Size = new System.Drawing.Size(745, 49);
            this.imageFilePathTextBox.TabIndex = 0;
            // 
            // selectImageFilePathButton
            // 
            this.selectImageFilePathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectImageFilePathButton.Location = new System.Drawing.Point(792, 37);
            this.selectImageFilePathButton.Name = "selectImageFilePathButton";
            this.selectImageFilePathButton.Size = new System.Drawing.Size(75, 49);
            this.selectImageFilePathButton.TabIndex = 1;
            this.selectImageFilePathButton.Text = "...";
            this.selectImageFilePathButton.UseVisualStyleBackColor = true;
            this.selectImageFilePathButton.Click += new System.EventHandler(this.selectImageFilePathButton_Click);
            // 
            // jsonResultTextBox
            // 
            this.jsonResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jsonResultTextBox.Font = new System.Drawing.Font("Consolas", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jsonResultTextBox.Location = new System.Drawing.Point(40, 105);
            this.jsonResultTextBox.Multiline = true;
            this.jsonResultTextBox.Name = "jsonResultTextBox";
            this.jsonResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.jsonResultTextBox.Size = new System.Drawing.Size(827, 581);
            this.jsonResultTextBox.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 709);
            this.Controls.Add(this.jsonResultTextBox);
            this.Controls.Add(this.selectImageFilePathButton);
            this.Controls.Add(this.imageFilePathTextBox);
            this.Name = "MainForm";
            this.Text = "Computer Vision Api - Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox imageFilePathTextBox;
        private System.Windows.Forms.Button selectImageFilePathButton;
        private System.Windows.Forms.TextBox jsonResultTextBox;
    }
}

