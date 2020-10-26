namespace Labb5___web_crawler
{
    partial class Scraper
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
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.extractButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.numberOfURLLabel = new System.Windows.Forms.Label();
            this.urlListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // URLTextBox
            // 
            this.URLTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.URLTextBox.Location = new System.Drawing.Point(13, 13);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.Size = new System.Drawing.Size(775, 22);
            this.URLTextBox.TabIndex = 0;
            this.URLTextBox.Text = "https://www.gp.se/";
            // 
            // extractButton
            // 
            this.extractButton.Location = new System.Drawing.Point(13, 42);
            this.extractButton.Name = "extractButton";
            this.extractButton.Size = new System.Drawing.Size(75, 23);
            this.extractButton.TabIndex = 1;
            this.extractButton.Text = "Extract";
            this.extractButton.UseVisualStyleBackColor = true;
            this.extractButton.Click += new System.EventHandler(this.extractButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(680, 41);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(107, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save images";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // numberOfURLLabel
            // 
            this.numberOfURLLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numberOfURLLabel.AutoSize = true;
            this.numberOfURLLabel.Location = new System.Drawing.Point(12, 448);
            this.numberOfURLLabel.Name = "numberOfURLLabel";
            this.numberOfURLLabel.Size = new System.Drawing.Size(0, 17);
            this.numberOfURLLabel.TabIndex = 4;
            // 
            // urlListBox
            // 
            this.urlListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlListBox.FormattingEnabled = true;
            this.urlListBox.ItemHeight = 16;
            this.urlListBox.Location = new System.Drawing.Point(15, 72);
            this.urlListBox.Name = "urlListBox";
            this.urlListBox.Size = new System.Drawing.Size(772, 372);
            this.urlListBox.TabIndex = 5;
            // 
            // Scraper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 474);
            this.Controls.Add(this.urlListBox);
            this.Controls.Add(this.numberOfURLLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.extractButton);
            this.Controls.Add(this.URLTextBox);
            this.Name = "Scraper";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox URLTextBox;
        private System.Windows.Forms.Button extractButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label numberOfURLLabel;
        private System.Windows.Forms.ListBox urlListBox;
    }
}

