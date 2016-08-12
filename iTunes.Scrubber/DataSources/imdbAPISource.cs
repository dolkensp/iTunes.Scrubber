using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using Newtonsoft.Json;
using System.Threading;
using System.Text.RegularExpressions;

namespace iTunes.Scrubber.DataSources
{
    public class IMDBAPISource : BaseClasses.SingletonBase<IMDBAPISource>, Interfaces.IDataSource
    {
        public class IMDBData
        {
            public String title { get; set; }
            public String imdburl { get; set; }
            public String country { get; set; }
            public String languages { get; set; }
            public String genres { get; set; }
            public String rating { get; set; }
            public String votes { get; set; }
            public String usascreens { get; set; }
            public String ukscreens { get; set; }
            public String year { get; set; }
            public String stv { get; set; }
            public String series { get; set; }
            public String error { get; set; }

            private String _imdb_id;
            /// <summary>
            /// The IMDB_ID of the returned series.
            /// </summary>
            public String IMDB_ID
            {
                get
                {
                    this._imdb_id = this._imdb_id ?? Regex.Match(imdburl, @"/title/(tt\d+)/").Groups[1].Value;

                    return this._imdb_id;
                }
            }
        }

        /// <summary>
        /// Mapping of Series to cached Searches
        /// </summary>
        private Dictionary<String, IMDBData> _imdbSearches;

        /// <summary>
        /// Indicates if we've been throttled yet
        /// </summary>
        private Boolean _throttled = false;

        /// <summary>
        /// Constructor for the IMDBAPI DataSource.
        /// </summary>
        public IMDBAPISource()
        {
            this._imdbSearches = new Dictionary<String, IMDBData>();
        }

        /// <summary>
        /// Clean up any open object references.
        /// </summary>
        public void Dispose() { }

        /// <summary>
        /// Search for, or return cached instance of data about a movie,
        /// obtained from the DeanClatworthy IMDB JSON API.
        /// </summary>
        /// <param name="query">The movie to search for.</param>
        /// <param name="year">The year the movie came out.</param>
        /// <returns>IMDBData containing the result of the search.</returns>
        public IMDBData this[String query, Int32? year]
        {
            get
            {
                if (String.IsNullOrWhiteSpace(query))
                    return null;

                if (!this._imdbSearches.ContainsKey(query))
                {
                    if (this._throttled)
                        return null;

                    Console.WriteLine("Loading [{0}] from DeanClatworthy", query);

                    try
                    {
                        String data = year.HasValue ?
                            Helpers.FileHelper.HttpGet(String.Format("http://www.deanclatworthy.com/imdb/?q={0}&year={1}", HttpUtility.UrlEncode(query), year)) :
                            Helpers.FileHelper.HttpGet(String.Format("http://www.deanclatworthy.com/imdb/?q={0}&yg=0", HttpUtility.UrlEncode(query)));

                        if (!String.IsNullOrWhiteSpace(data))
                        {
                            IMDBData movieSearch = JsonConvert.DeserializeObject<IMDBData>(data);

                            if (!String.IsNullOrWhiteSpace(movieSearch.error))
                                return (this._throttled = true) ?
                                       (null as IMDBData) :
                                       (null as IMDBData);

                            this._imdbSearches[query] = movieSearch;
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }

                if (!this._imdbSearches.ContainsKey(query))
                    return null;

                return this._imdbSearches[query];
            }
        }
    }
}