using System;

namespace iTunes.Scrubber.Factories
{
    public class ScrubberFactory : IDisposable
    {
        private Scrubbers.TVShowScrubber _tvShowScrubber;
        /// <summary>
        /// Returns an instance of the TVShowScrubber.
        /// </summary>
        public Scrubbers.TVShowScrubber TVShowScrubber
        {
            get { this._tvShowScrubber = this._tvShowScrubber ?? new Scrubbers.TVShowScrubber(); return this._tvShowScrubber; }
            private set { this._tvShowScrubber = value; }
        }

        private Scrubbers.MovieScrubber _movieScrubber;
        /// <summary>
        /// Returns an instance of the MovieScrubber.
        /// </summary>
        public Scrubbers.MovieScrubber MovieScrubber
        {
            get { this._movieScrubber = this._movieScrubber ?? new Scrubbers.MovieScrubber(); return this._movieScrubber; }
            private set { this._movieScrubber = value; }
        }

        private Scrubbers.MusicVideoScrubber _musicVideoScrubber;
        /// <summary>
        /// Returns an instance of the MusicVideoScrubber.
        /// </summary>
        public Scrubbers.MusicVideoScrubber MusicVideoScrubber
        {
            get { this._musicVideoScrubber = this._musicVideoScrubber ?? new Scrubbers.MusicVideoScrubber(); return this._musicVideoScrubber; }
            private set { this._musicVideoScrubber = value; }
        }

        private Scrubbers.MusicScrubber _musicScrubber;
        /// <summary>
        /// Returns an instance of the MusicScrubber.
        /// </summary>
        public Scrubbers.MusicScrubber MusicScrubber
        {
            get { this._musicScrubber = this._musicScrubber ?? new Scrubbers.MusicScrubber(); return this._musicScrubber; }
            private set { this._musicScrubber = value; }
        }

        public ScrubberFactory() { }

        public void Dispose()
        {
            #region Dispose of Local Objects

            this.MovieScrubber.Dispose();
            this.MusicScrubber.Dispose();
            this.MusicVideoScrubber.Dispose();
            this.TVShowScrubber.Dispose();

            #endregion

            DataSources.ITunesSource.Instance.Dispose();
            DataSources.WikipediaSource.Instance.Dispose();
            DataSources.Warez_BBSource.Instance.Dispose();
            DataSources.TVDBSource.Instance.Dispose();
            DataSources.IMDBSource.Instance.Dispose();
            DataSources.RapidshareSource.Instance.Dispose();
        }
    }
}
