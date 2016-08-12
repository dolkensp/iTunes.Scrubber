namespace iTunes.Scrubber.GUI
{
    partial class frmMain
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
            this.btnMovieScrubber = new System.Windows.Forms.Button();
            this.btnMusicScrubber = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMovieScrubber
            // 
            this.btnMovieScrubber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMovieScrubber.Location = new System.Drawing.Point(12, 12);
            this.btnMovieScrubber.Name = "btnMovieScrubber";
            this.btnMovieScrubber.Size = new System.Drawing.Size(261, 53);
            this.btnMovieScrubber.TabIndex = 0;
            this.btnMovieScrubber.Text = "Mo&vie Scrubber";
            this.btnMovieScrubber.UseVisualStyleBackColor = true;
            this.btnMovieScrubber.Click += new System.EventHandler(this.btnMovieScrubber_Click);
            // 
            // btnMusicScrubber
            // 
            this.btnMusicScrubber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMusicScrubber.Enabled = false;
            this.btnMusicScrubber.Location = new System.Drawing.Point(12, 71);
            this.btnMusicScrubber.Name = "btnMusicScrubber";
            this.btnMusicScrubber.Size = new System.Drawing.Size(261, 53);
            this.btnMusicScrubber.TabIndex = 1;
            this.btnMusicScrubber.Text = "&Music Scrubber";
            this.btnMusicScrubber.UseVisualStyleBackColor = true;
            this.btnMusicScrubber.Click += new System.EventHandler(this.btnMusicScrubber_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 137);
            this.Controls.Add(this.btnMusicScrubber);
            this.Controls.Add(this.btnMovieScrubber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iTunes Scrubber GUI - Main Menu";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMovieScrubber;
        private System.Windows.Forms.Button btnMusicScrubber;
    }
}