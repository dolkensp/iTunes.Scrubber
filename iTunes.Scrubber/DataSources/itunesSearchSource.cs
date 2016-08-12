//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Web;
//using HtmlAgilityPack;

//namespace iTunes.Scrubber.DataSources
//{
//    public class iTunesSearchSource : BaseClasses.SingletonBase<iTunesSearchSource>, Interfaces.IDataSource
//    {
//        // https://itunes.apple.com/search?term=batman&media=movie
//        // https://itunes.apple.com/search?term=breaking%20bad&media=tvShow&entity=tvSeason

//        /// <summary>
//        /// Mapping of IMDB_IDs to cached Episode Lists
//        /// </summary>
//        internal static Dictionary<String, HtmlDocument> _episodeLists;
//        /// <summary>
//        /// Mapping of IMDB_IDs to cached titles
//        /// </summary>
//        internal static Dictionary<String, HtmlDocument> _titles;

//        private Dictionary<Tuple<String, Int32?>, IMDBData> _searches;

//        /// <summary>
//        /// Constructor for the IMDB DataSource.
//        /// </summary>
//        public iTunesSearchSource()
//        {
//            IMDBSource._episodeLists = new Dictionary<String, HtmlDocument>();
//            IMDBSource._titles = new Dictionary<String, HtmlDocument>();
//            this._searches = new Dictionary<Tuple<String, Int32?>, IMDBData>();
//        }

//        /// <summary>
//        /// Clean up any open object references.
//        /// </summary>
//        public void Dispose() { }

//        /// <summary>
//        /// Search for, or return cached instance of data about a series,
//        /// obtained by scraping the IMDB site.
//        /// </summary>
//        /// <param name="imdb_id">The ID of the IMDB content to load.</param>
//        /// <returns>IMDBData containing the results of the search.</returns>
//        public itunesData this[String imdb_id]
//        {
//            get
//            {
//                if (String.IsNullOrWhiteSpace(imdb_id))
//                    return null;

//                return new IMDBData() { IMDB_ID = imdb_id };
//            }
//        }

//        public iTunesData this[String searchTerm, Int32? year]
//        {
//            get
//            {
//                if (year < 1950)
//                    year = null;

//                Tuple<String, Int32?> key = new Tuple<String, Int32?>(searchTerm, year);

//                IMDBData result = null;
                
//                if (!this._searches.TryGetValue(key, out result))
//                {
//                    Console.WriteLine("Loading [{0} ({1})] from IMDB", searchTerm, year);

//                    HtmlDocument html = new HtmlDocument();

//                    html.LoadHtml(Helpers.FileHelper.HttpGet(String.Format("http://www.imdb.com/search/title?release_date={1},{1}&title={0}&title_type=feature&view=simple", HttpUtility.UrlEncode(searchTerm), year)));

//                    HtmlNodeCollection results = html.DocumentNode.SelectNodes("//table[@class='results']//td[@class='title']/a");

//                    if (results == null || results.Count == 0)
//                    {
//                        html.LoadHtml(Helpers.FileHelper.HttpGet(String.Format("http://www.imdb.com/search/title?release_date={1},{1}&title={0}&title_type=feature&view=simple", HttpUtility.UrlEncode(searchTerm), null)));

//                        results = html.DocumentNode.SelectNodes("//table[@class='results']//td[@class='title']/a");
//                    }

//                    if (results == null || results.Count == 0)
//                    {
//                        html.LoadHtml(Helpers.FileHelper.HttpGet(String.Format("http://www.imdb.com/search/title?release_date={1},{1}&title={0}&view=simple", HttpUtility.UrlEncode(searchTerm), year)));

//                        results = html.DocumentNode.SelectNodes("//table[@class='results']//td[@class='title']/a");
//                    }

//                    if (results == null || results.Count == 0)
//                    {
//                        html.LoadHtml(Helpers.FileHelper.HttpGet(String.Format("http://www.imdb.com/search/title?release_date={1},{1}&title={0}&view=simple", HttpUtility.UrlEncode(searchTerm), null)));

//                        results = html.DocumentNode.SelectNodes("//table[@class='results']//td[@class='title']/a");
//                    }

//                    if (results == null || results.Count == 0)
//                        return result;

//                    if (results.Count > 0)
//                        result = new IMDBData() { IMDB_ID = Regex.Match(results[0].Attributes["href"].Value, @"/title/(tt\d+)/").Groups[1].Value };

//                    for (Int32 i = results.Count; i > 0; i--)
//                    {
//                        if (String.Compare(results[i - 1].InnerText, searchTerm, true) == 0)
//                            result.IMDB_ID = Regex.Match(results[i - 1].Attributes["href"].Value, @"/title/(tt\d+)/").Groups[1].Value;
//                    }

//                    this._searches[key] = result;
//                }

//                return result;
//            }
//        }

//        public class IMDBData
//        {
//            /// <summary>
//            /// The IMDB_ID of the current data.
//            /// </summary>
//            public String IMDB_ID { get; set; }

//            /// <summary>
//            /// The content of the HTML response to the search for the series.
//            /// </summary>
//            public HtmlDocument EpisodeListPage(Int32 season)
//            {
//                String key = String.Format("{0}:{1}", this.IMDB_ID, season);

//                if (!IMDBSource._episodeLists.ContainsKey(key))
//                {
//                    Console.WriteLine("Loading [{0}] from IMDB", key);

//                    String search = Helpers.FileHelper.HttpGet(String.Format("http://www.imdb.com/title/{0}/episodes?season={1}", this.IMDB_ID, season));

//                    if (String.IsNullOrWhiteSpace(search))
//                        return null;
                    
//                    HtmlDocument imdb = new HtmlDocument();

//                    imdb.LoadHtml(search);

//                    IMDBSource._episodeLists[key] = imdb;
//                }

//                return IMDBSource._episodeLists[key];
//            }

//            /// <summary>
//            /// The content of the HTML response to the main title page.
//            /// </summary>
//            public HtmlDocument TitlePage
//            {
//                get
//                {
//                    if (!IMDBSource._titles.ContainsKey(this.IMDB_ID))
//                    {
//                        Console.WriteLine("Loading [{0}] from IMDB", this.IMDB_ID);

//                        String search = Helpers.FileHelper.HttpGet(String.Format("http://www.imdb.com/title/{0}/", this.IMDB_ID));

//                        if (String.IsNullOrWhiteSpace(search))
//                            return null;

//                        HtmlDocument imdb = new HtmlDocument();

//                        imdb.LoadHtml(search);

//                        IMDBSource._titles[this.IMDB_ID] = imdb;
//                    }

//                    return IMDBSource._titles[this.IMDB_ID];
//                }
//            }
//        }

//        public IEnumerable<MediaItems.TVShowItem> GetEpisodes(String series, Delegates.Filter<MediaItems.TVShowItem> filter = null, Delegates.Sorter<MediaItems.TVShowItem> sorter = null)
//        {
//            yield break;

//            //String imdb_id = DataSources.TVDBSource.Instance[series].IMDB_ID;

//            //if (imdb_id == null)
//            //    return Enumerable.Empty<MediaItems.TVShowItem>();

//            //// TODO: Update this to get all seasons instead of just first
//            //return (from episode in this[imdb_id].EpisodeListPage(1).DocumentNode.SelectNodes(Constants.IMDB_EPISODE)
//            //        let match = Regex.Match(HttpUtility.HtmlDecode(episode.ParentNode.InnerText), @"Season (\d+), Episode (\d+): (.*)", RegexOptions.IgnoreCase)
//            //        where match.Success
//            //        let mediaItem = new MediaItems.TVShowItem()
//            //        {
//            //            IMDB_ID = imdb_id,
//            //            Show = series,
//            //            Season = Int32.Parse(match.Groups[1].Value),
//            //            Episode = Int32.Parse(match.Groups[2].Value),
//            //            Title = match.Groups[3].Value
//            //        }
//            //        orderby sorter == null ? mediaItem : sorter(mediaItem)
//            //        select mediaItem);
//        }
//    }
//}
