using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;

namespace iTunes.Scrubber.DataSources
{
    public class TVDBSource : BaseClasses.SingletonBase<TVDBSource>, Interfaces.IDataSource
    {
        /// <summary>
        /// Mapping of Series to cached Searches
        /// </summary>
        private Dictionary<String, XmlDocument> _seriesSearches;

        /// <summary>
        /// Constructor for the TVDB DataSource.
        /// </summary>
        public TVDBSource()
        {
            this._seriesSearches = new Dictionary<String, XmlDocument>();
        }

        /// <summary>
        /// Clean up any open object references.
        /// </summary>
        public void Dispose() { }

        /// <summary>
        /// Search for, or return cached instance of data about a series,
        /// obtained from the TVDB XML API.
        /// </summary>
        /// <param name="series">The series to search for.</param>
        /// <returns>TVDBData containing the result of the search.</returns>
        public TVDBData this[String series]
        {
            get
            {
                if (String.IsNullOrWhiteSpace(series))
                    return null;

                if (!this._seriesSearches.ContainsKey(series))
                {
                    Console.WriteLine("Loading [{0}] from TVDB", series);

                    XmlDocument seriesSearch = new XmlDocument();
                    seriesSearch.LoadXml(Helpers.FileHelper.HttpGet(String.Format("http://thetvdb.com/api/GetSeries.php?seriesname={0}", HttpUtility.UrlEncode(series))).ToLowerInvariant());

                    this._seriesSearches[series] = seriesSearch;
                }

                if (!this._seriesSearches.ContainsKey(series))
                    return null;

                return new TVDBData()
                {
                    Series = series,
                    SeriesSearchPage = this._seriesSearches[series]
                };
            }
        }

        public class TVDBData
        {
            /// <summary>
            /// The series being returned.
            /// </summary>
            public String Series { get; set; }

            private String _imdb_id;
            /// <summary>
            /// The IMDB_ID of the returned series.
            /// </summary>
            public String IMDB_ID
            {
                get
                {
                    if (String.IsNullOrWhiteSpace(this._imdb_id))
                    {
                        XmlNode selectedSeries = this.SeriesSearchPage.SelectSingleNode(String.Format(@"Data/Series[SeriesName=""{0}""]/IMDB_ID", this.Series).ToLowerInvariant());

                        if (selectedSeries == null)
                            selectedSeries = this.SeriesSearchPage.SelectSingleNode(String.Format(@"Data/Series[SeriesName=""The {0}""]/IMDB_ID", this.Series).ToLowerInvariant());

                        if (selectedSeries != null)
                            this._imdb_id = selectedSeries.InnerText;
                    }

                    return this._imdb_id;
                }
            }

            /// <summary>
            /// The content of the XML response to the search for the series.
            /// </summary>
            public XmlDocument SeriesSearchPage { get; set; }
        }
    }
}