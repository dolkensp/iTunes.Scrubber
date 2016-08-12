using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTunes.Scrubber.Helpers;
using System.Threading;

namespace iTunes.Scrubber.GUI
{
    public partial class frmMovie : Form
    {
        delegate void DisplayDelegate();

        #region Public Properties

        private List<MediaItems.MovieItem> _movies;
        public List<MediaItems.MovieItem> Movies
        {
            get
            {
                this._movies = this._movies ?? Program.ScrubberFactory.MovieScrubber.GetMedia(
                    filter: (movie) => Program.Filter(movie),
                    sorter: (movie) => movie.Title
                ).ToList<MediaItems.MovieItem>();

                return this._movies;
            }
        }

        private Parsers.MovieParser _movieParser;
        public Parsers.MovieParser MovieParser
        {
            get
            {
                this._movieParser = this._movieParser ?? new Parsers.MovieParser();

                return this._movieParser;
            }
        }

        private Boolean? _done;
        public Boolean Done
        {
            get
            {
                this._done = this._done ?? false;

                return this._done.Value;
            }
            set
            {
                this._done = value;
            }
        }

        private CountdownEvent _threadCount;
        public CountdownEvent ThreadCount
        {
            get
            {
                this._threadCount = this._threadCount ?? new CountdownEvent(1);

                return this._threadCount;
            }
            set
            {
                this._threadCount = value;
            }
        }

        public frmSplash LoadingForm { get; set; }

        #endregion

        #region Constructor

        public frmMovie()
        {
            InitializeComponent();
        }

        #endregion

        #region Protected Methods

        private void frmMovie_Load(object sender, EventArgs e)
        {
            ThreadPool.SetMaxThreads(100, 100);

            #region Initialize Variables

            Boolean done = false;

            #endregion

            #region Loading Dialog

            ThreadPool.QueueUserWorkItem((x) =>
            {
                if (LoadingForm == null)
                {
                    LoadingForm = new frmSplash();

                    LoadingForm.Show();
                }

                while (!done)
                    Application.DoEvents();

                if (ThreadCount.CurrentCount == 1)
                    LoadingForm.Close();
            });

            #endregion

            #region Processing

            lstMovies.Items.AddRange((from movie in this.Movies
                                      let clone = movie.Clone<MediaItems.MovieItem>(new MediaItems.MovieItem())
                                      select new ParsedMediaItem<MediaItems.MovieItem>
                                      {
                                          Original = clone,
                                          Parsed = movie
                                      }
                                      ).ToArray<Object>());

            done = true;

            #endregion
        }

        protected override void OnResize(EventArgs e)
        {
            // Int32 numColumns = lstMovies.Width / 300;

            lstMovies.ColumnWidth = 300; // this.Width / numColumns - lstMovies.Left * 2;

            base.OnResize(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Done = true;

            Program.CurrentForm = Enums.FormEnum.Main;

            lock (ThreadCount)
                ThreadCount.Signal();

            ThreadCount.Wait();

            LoadingForm.Close();

            base.OnClosing(e);
        }

        protected void lstMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Initialize Variables

            Boolean done = false;
            CheckedListBox lstMovies = (sender as CheckedListBox);
            Int32 index = lstMovies.SelectedIndex;

            ParsedMediaItem<MediaItems.MovieItem> data = new ParsedMediaItem<MediaItems.MovieItem>()
            {
                Original = new MediaItems.MovieItem(),
                Parsed = new MediaItems.MovieItem()
            };

            #endregion

            if (data.Parsed.IsDirty)
            {
                this.Update();
                return;
            }

            #region Loading Dialog

            ThreadPool.QueueUserWorkItem((x) =>
            {
                if (LoadingForm == null)
                {
                    LoadingForm = new frmSplash();

                    LoadingForm.Show();
                }

                while (!done)
                    Application.DoEvents();

                if (ThreadCount.CurrentCount == 1)
                    LoadingForm.Close();
            });

            #endregion

            #region Processing
            
            ThreadPool.QueueUserWorkItem((x) =>
            {
                lock(ThreadCount)
                    ThreadCount.AddCount();

                try
                {
                    if (index > -1)
                        data = lstMovies.Items[index] as ParsedMediaItem<MediaItems.MovieItem>;

                    if (!data.Parsed.IsDirty)
                        data.Parsed = this.MovieParser.Parse(data.Parsed);

                    data.Parsed.IsDirty = true;

                    if (data.Parsed.Year < 1900)
                        data.Parsed.Year = null;
                }
                catch (Exception) { }

                done = true;

                lock (ThreadCount)
                    ThreadCount.Signal();
                
                if (this.InvokeRequired)
                    this.Invoke(new DisplayDelegate(this.Update));
                else
                    this.Update();
                
            });

            #endregion
        }

        private delegate void CloseDelegate();

        protected void btnApply_Click(object sender, EventArgs e)
        {
            #region Initialize Variables

            Boolean done = false;

            #endregion

            #region Loading Dialog

            ThreadPool.QueueUserWorkItem((x) =>
            {
                if (LoadingForm == null)
                {
                    LoadingForm = new frmSplash();

                    LoadingForm.Show();
                }

                while (!done)
                    Application.DoEvents();

                if (ThreadCount.CurrentCount == 1)
                    LoadingForm.Close();
            });

            #endregion

            #region Processing

            CloseDelegate closeMethod = this.Close;

            ThreadPool.QueueUserWorkItem((x) =>
            {
                foreach (ParsedMediaItem<MediaItems.MovieItem> parsedMediaItem in lstMovies.CheckedItems)
                    parsedMediaItem.Parsed.UpdateMetaData();

                done = true;
                
                this.Invoke(closeMethod);
            });

            this.Hide();

            #endregion
        }

        protected void btnLoadAll_Click(object sender, EventArgs e)
        {
            #region Processing

            ThreadPool.QueueUserWorkItem((x) =>
            {
                lock (ThreadCount)
                    ThreadCount.AddCount();

                for (Int32 i = 0, j = lstMovies.Items.Count; !Done && i < j; i++)
                {
                    ParsedMediaItem<MediaItems.MovieItem> parsedMediaItem = (lstMovies.Items[i] as ParsedMediaItem<MediaItems.MovieItem>);
                    parsedMediaItem.Parsed = this.MovieParser.Parse(parsedMediaItem.Parsed);
                }

                lock (ThreadCount)
                    ThreadCount.Signal();
            });

            #endregion
        }

        private void Update()
        {
            ParsedMediaItem<MediaItems.MovieItem> data = this.lstMovies.SelectedItem as ParsedMediaItem<MediaItems.MovieItem>;

            txtOriginalTitle.Text = txtParsedTitle.Text = data.Original.Title;
            txtOriginalGenre.Text = txtParsedGenre.Text = data.Original.Genre;
            txtOriginalYear.Text = txtParsedYear.Text = data.Original.Year.ToString();

            txtParsedTitle.Text = data.Parsed.Title;
            txtParsedGenre.Text = data.Parsed.Genre;
            txtParsedYear.Text = data.Parsed.Year.ToString();
        }

        #endregion

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            for (Int32 i = 0, j = lstMovies.Items.Count; i < j; i++)
                lstMovies.SetItemChecked(i, true);
        }
    }
}
