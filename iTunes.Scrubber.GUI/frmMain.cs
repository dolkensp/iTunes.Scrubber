using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iTunes.Scrubber.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Program.CurrentForm = Enums.FormEnum.None;
        }

        private void btnMovieScrubber_Click(object sender, EventArgs e)
        {
            Program.CurrentForm = Enums.FormEnum.Movie;

            this.Close();
        }

        private void btnMusicScrubber_Click(object sender, EventArgs e)
        {
            Program.CurrentForm = Enums.FormEnum.Music;

            this.Close();
        }
    }
}
