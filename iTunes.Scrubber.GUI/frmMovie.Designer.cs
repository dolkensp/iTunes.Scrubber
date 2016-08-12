namespace iTunes.Scrubber.GUI
{
    partial class frmMovie
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
            this.lstMovies = new System.Windows.Forms.CheckedListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtOriginalTitle = new System.Windows.Forms.TextBox();
            this.txtParsedTitle = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtOriginalYear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOriginalGenre = new System.Windows.Forms.TextBox();
            this.txtParsedYear = new System.Windows.Forms.TextBox();
            this.txtParsedGenre = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnLoadAll = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstMovies
            // 
            this.lstMovies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMovies.CheckOnClick = true;
            this.lstMovies.ColumnWidth = 300;
            this.lstMovies.FormattingEnabled = true;
            this.lstMovies.Location = new System.Drawing.Point(12, 12);
            this.lstMovies.MultiColumn = true;
            this.lstMovies.Name = "lstMovies";
            this.lstMovies.Size = new System.Drawing.Size(410, 244);
            this.lstMovies.TabIndex = 0;
            this.lstMovies.SelectedIndexChanged += new System.EventHandler(this.lstMovies_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(9, 281);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title";
            // 
            // txtOriginalTitle
            // 
            this.txtOriginalTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOriginalTitle.Location = new System.Drawing.Point(51, 278);
            this.txtOriginalTitle.Name = "txtOriginalTitle";
            this.txtOriginalTitle.ReadOnly = true;
            this.txtOriginalTitle.Size = new System.Drawing.Size(162, 20);
            this.txtOriginalTitle.TabIndex = 4;
            // 
            // txtParsedTitle
            // 
            this.txtParsedTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParsedTitle.Location = new System.Drawing.Point(219, 278);
            this.txtParsedTitle.Name = "txtParsedTitle";
            this.txtParsedTitle.Size = new System.Drawing.Size(203, 20);
            this.txtParsedTitle.TabIndex = 5;
            // 
            // lblYear
            // 
            this.lblYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(9, 307);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 6;
            this.lblYear.Text = "Year";
            // 
            // txtOriginalYear
            // 
            this.txtOriginalYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOriginalYear.Location = new System.Drawing.Point(51, 304);
            this.txtOriginalYear.Name = "txtOriginalYear";
            this.txtOriginalYear.ReadOnly = true;
            this.txtOriginalYear.Size = new System.Drawing.Size(162, 20);
            this.txtOriginalYear.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Genre";
            // 
            // txtOriginalGenre
            // 
            this.txtOriginalGenre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOriginalGenre.Location = new System.Drawing.Point(51, 330);
            this.txtOriginalGenre.Name = "txtOriginalGenre";
            this.txtOriginalGenre.ReadOnly = true;
            this.txtOriginalGenre.Size = new System.Drawing.Size(162, 20);
            this.txtOriginalGenre.TabIndex = 9;
            // 
            // txtParsedYear
            // 
            this.txtParsedYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParsedYear.Location = new System.Drawing.Point(220, 305);
            this.txtParsedYear.Name = "txtParsedYear";
            this.txtParsedYear.Size = new System.Drawing.Size(202, 20);
            this.txtParsedYear.TabIndex = 10;
            // 
            // txtParsedGenre
            // 
            this.txtParsedGenre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParsedGenre.Location = new System.Drawing.Point(220, 330);
            this.txtParsedGenre.Name = "txtParsedGenre";
            this.txtParsedGenre.Size = new System.Drawing.Size(202, 20);
            this.txtParsedGenre.TabIndex = 11;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(347, 356);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 12;
            this.btnApply.Text = "&Apply Changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnLoadAll
            // 
            this.btnLoadAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadAll.Location = new System.Drawing.Point(13, 356);
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(75, 23);
            this.btnLoadAll.TabIndex = 13;
            this.btnLoadAll.Text = "&Load All";
            this.btnLoadAll.UseVisualStyleBackColor = true;
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheckAll.Location = new System.Drawing.Point(94, 356);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(75, 23);
            this.btnCheckAll.TabIndex = 14;
            this.btnCheckAll.Text = "&Check All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // frmMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 386);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.btnLoadAll);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtParsedGenre);
            this.Controls.Add(this.txtParsedYear);
            this.Controls.Add(this.txtOriginalGenre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOriginalYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtParsedTitle);
            this.Controls.Add(this.txtOriginalTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lstMovies);
            this.MinimumSize = new System.Drawing.Size(450, 400);
            this.Name = "frmMovie";
            this.Text = "iTunes Scrubber GUI - Movie Scrubber";
            this.Load += new System.EventHandler(this.frmMovie_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstMovies;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtOriginalTitle;
        private System.Windows.Forms.TextBox txtParsedTitle;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtOriginalYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOriginalGenre;
        private System.Windows.Forms.TextBox txtParsedYear;
        private System.Windows.Forms.TextBox txtParsedGenre;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnLoadAll;
        private System.Windows.Forms.Button btnCheckAll;
    }
}