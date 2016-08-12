using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using HtmlAgilityPack;
using iTunesLib;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;

namespace iTunes.Scrubber
{
    public class MetaScrub : IDisposable
    {
        /// <summary>
        /// A delegate used to filter lists of tv shows.
        /// </summary>
        /// <param name="show">An instance of a TVShow to check for elegibility.</param>
        /// <returns>True if the specified episode is a valid show, false otherwise.</returns>
        public delegate Boolean TVShowFilter(TVShow show);
        /// <summary>
        /// A delegate used to sort lists of tv shows.
        /// </summary>
        /// <param name="show">An instance of a TVShow to generate a sort hash from.</param>
        /// <returns>A sortable object.</returns>
        public delegate Object TVShowSorter(TVShow show);
        /// <summary>
        /// A delegate used to parse a TVShow into a format suitable for searching.
        /// </summary>
        /// <param name="show">The show to parse</param>
        /// <returns>The result</returns>
        public delegate TVShow TVShowParser(TVShow show);

        /// <summary>
        /// A delegate used to filter lists of movies.
        /// </summary>
        /// <param name="show">An instance of a Movie to check for elegibility.</param>
        /// <returns>True if the specified movie valid, false otherwise.</returns>
        public delegate Boolean MovieFilter(Movie movie);
        /// <summary>
        /// A delegate used to sort lists of movies.
        /// </summary>
        /// <param name="show">An instance of a Movie to generate a sort hash from.</param>
        /// <returns>A sortable object.</returns>
        public delegate Object MovieSorter(Movie movie);
        /// <summary>
        /// A delegate used to parse a Movie into a format suitable for searching.
        /// </summary>
        /// <param name="show">The movie to parse</param>
        /// <returns>The result</returns>
        public delegate Movie MovieParser(Movie movie);


        #region IMDB Cache

        /// <summary>
        /// Cache of IMDB identifiers, categorized by show.
        /// </summary>
        private Dictionary<String, String> _imdbList = new Dictionary<String, String>();
        /// <summary>
        /// Cache of IMDB pages, categorized by show.
        /// </summary>
        private Dictionary<String, HtmlDocument> _imdbPages = new Dictionary<String, HtmlDocument>();

        #endregion

        #region iTunes COM

        /// <summary>
        /// Link to the master iTunes object
        /// </summary>
        private iTunesApp _iTunes;
        /// <summary>
        /// Link to the iTunes library object
        /// </summary>
        private IITLibraryPlaylist _mainLibrary;
        /// <summary>
        /// Link to the iTunes track collection
        /// </summary>
        private IITTrackCollection _tracks;

        /// <summary>
        /// Parsed version of iTunes library XML file.
        /// </summary>
        private XmlDocument _library = new XmlDocument();

        #endregion

        #region warez-bb Cache

        public const Int32 SEARCH_TIMEOUT = 20;

        /// <summary>
        /// Response to the warez-bb login request
        /// </summary>
        private SimpleWebResponse _login;
        /// <summary>
        /// Cache of warez-bb searches, categorized by show and season
        /// </summary>
        private Dictionary<String, Dictionary<Int32?, HtmlDocument>> _search;
        /// <summary>
        /// Cache of warez-bb topics, categorized by url path
        /// </summary>
        private Dictionary<String, HtmlDocument> _topics;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Constructor
        /// 
        /// Initializes COM connections and loads master XML file
        /// </summary>
        public MetaScrub()
        {
            this._iTunes = new iTunesApp();

            this._mainLibrary = this._iTunes.LibraryPlaylist;
            this._tracks = this._mainLibrary.Tracks;

            this._library.Load(this._iTunes.LibraryXMLPath);

            // TODO: Check the LibraryXMLPath vs the iT*.tmp files - they are more recent than the LibraryXMLPath file
        }

        /// <summary>
        /// Dispose of the iTunes COM objects properly
        /// </summary>
        public void Dispose()
        {
            Marshal.ReleaseComObject(this._iTunes);
            this._iTunes = null;
            GC.Collect();
        }

        #endregion

        #region warez-bb Search Methods

        /// <summary>
        /// Search warez-bb.org for rapidshare links for all missing TV Episodes
        /// </summary>
        /// <param name="filter">Delegate used to filter the TV Episodes to search for</param>
        /// <param name="sortBy"></param>
        /// <param name="parsers"></param>
        /// <returns>An enumeration of enumerations of collections of links to the found episodes</returns>
        public IEnumerable<IEnumerable<List<String>>> FindSeriesLinks(String series, TVShowFilter filter = null, TVShowSorter sortBy = null, params TVShowParser[] parsers)
        {
            String lastSeries = String.Empty;
            Int32? lastSeason = null;
            DateTime lastSearch = DateTime.MinValue;

            foreach (TVShow missingShow in this.FindEpisodes(series, filter, sortBy))
            {
                TVShow currentShow = missingShow;

                foreach (TVShowParser parser in parsers)
                    currentShow = parser(missingShow);

                #region Throttle

                if ((currentShow.Series != lastSeries) || (currentShow.Season != lastSeason))
                {
                    Int32 timeOut = (Int32)(1 + SEARCH_TIMEOUT - (DateTime.Now - lastSearch).TotalSeconds) * 1000;

                    if (timeOut > 0)
                    {
                        Console.WriteLine("Pausing For:   {0:#.0} Seconds", timeOut / 1000);

                        Thread.Sleep(timeOut);
                    }

                    lastSeries = currentShow.Series;
                    lastSeason = currentShow.Season;
                    lastSearch = DateTime.Now;
                }

                #endregion

                yield return this.FindEpisode(currentShow);
            }
        }

        /// <summary>
        /// Search warez-bb.org for rapidshare links for all missing TV Episodes
        /// </summary>
        /// <param name="filter">Delegate used to filter the TV Episodes to search for</param>
        /// <param name="sortBy"></param>
        /// <param name="parsers"></param>
        /// <returns>An enumeration of enumerations of collections of links to the found episodes</returns>
        public IEnumerable<IEnumerable<List<String>>> FindMissingEpisodeLinks(TVShowFilter filter = null, TVShowSorter sortBy = null, params TVShowParser[] parsers)
        {
            String lastSeries = String.Empty;
            Int32? lastSeason = null;
            DateTime lastSearch = DateTime.MinValue;

            foreach (TVShow missingShow in this.FindMissingEpisodes(filter, sortBy))
            {
                TVShow currentShow = missingShow;

                foreach (TVShowParser parser in parsers)
                    currentShow = parser(missingShow);

                #region Throttle

                if ((currentShow.Series != lastSeries) || (currentShow.Season != lastSeason))
                {
                    Int32 timeOut = (Int32)(1 + SEARCH_TIMEOUT - (DateTime.Now - lastSearch).TotalSeconds) * 1000;

                    if (timeOut > 0)
                    {
                        Console.WriteLine("Pausing For:   {0:#.0} Seconds", timeOut / 1000);

                        Thread.Sleep(timeOut);
                    }

                    lastSeries = currentShow.Series;
                    lastSeason = currentShow.Season;
                    lastSearch = DateTime.Now;
                }

                #endregion

                yield return this.FindEpisode(currentShow);
            }
        }

        /// <summary>
        /// Search warez-bb.org for rapidshare links for the specified TV Episode
        /// </summary>
        /// <param name="show">The show we're searching for</param>
        /// <returns>An enumeration of collections of links to the specified episode</returns>
        public IEnumerable<List<String>> FindEpisode(TVShow show)
        {
            String username = "username";
            String password = "password";

            Console.WriteLine("Searching For: {0} [{1}x{2}]", show.Series, show.Season, show.Episode);

            if (_login == null)
            {
                Console.WriteLine("Logging In As: {0}|{1}", username, password);

                _login = FileHelper.HttpPost("http://www.warez-bb.org/login.php", null, null, new Dictionary<String, String>() { { "username", username }, { "password", password }, { "login", "login" } }, null);
            }

            if (_search == null)
                _search = new Dictionary<String, Dictionary<Int32?, HtmlDocument>>();

            if (_topics == null)
                _topics = new Dictionary<String, HtmlDocument>();

            if (!_search.ContainsKey(show.Series))
                _search[show.Series] = new Dictionary<Int32?, HtmlDocument>();

            HtmlDocument resultsPage;

            if (!_search[show.Series].ContainsKey(show.Season))
            {
                Console.WriteLine("Searching For: {0} Season {1}", show.Series, show.Season, show.Episode);

                SimpleWebResponse search = FileHelper.HttpPost("http://www.warez-bb.org/search.php", null, null, new Dictionary<String, String>() { { "search_keywords", String.Format("RS {0} Season {1}", show.Series, show.Season) },
                                                                                                                                                    { "search_forum[]", "57" },
                                                                                                                                                    { "search_terms", "all" },
                                                                                                                                                    { "search_fields", "firstpost" },
                                                                                                                                                    { "search_time", "0" },
                                                                                                                                                    { "sort_by", "0" },
                                                                                                                                                    { "sort_dir", "DESC" },
                                                                                                                                                    { "return_chars", "-1" },
                                                                                                                                                    { "show_results", "topics" }
                }, _login.Cookies);

                if (search == null)
                    return null;

                resultsPage = new HtmlDocument();

                resultsPage.LoadHtml(search.Content);

                _search[show.Series][show.Season] = resultsPage;
            }
            else
                resultsPage = _search[show.Series][show.Season];

            IEnumerable<HtmlNode> matches = (from topic
                                                 in resultsPage.DocumentNode.SelectNodes("//span[@class='topictitle']/a") ?? Enumerable.Empty<HtmlNode>()
                                             where Regex.Match(topic.InnerText, String.Format(@"\[.*?RS.*?\]\s*{0}\s*.*Season\s*.*({1}|-)", show.Series, show.Season), RegexOptions.IgnoreCase).Success
                                             orderby Int32.Parse(String.Format("{0:D3}{1:D3}{2:D3}", topic.InnerText.IndexOf("1080p"), topic.InnerText.IndexOf("720p"), topic.InnerText.IndexOf("m-HD")).Replace("-", "")) descending
                                             select topic);

            foreach (HtmlNode match in matches)
            {
                HtmlDocument topic = null;

                if (!_topics.ContainsKey(String.Format("http://www.warez-bb.org/{0}", match.Attributes["href"].Value)))
                {
                    try
                    {
                        topic = new HtmlDocument();

                        Console.WriteLine("Loading Topic: {0}", match.InnerText);

                        String search = FileHelper.HttpGet(String.Format("http://www.warez-bb.org/{0}", match.Attributes["href"].Value), null, null, _login.Cookies);

                        if (String.IsNullOrWhiteSpace(search))
                            continue;

                        topic.LoadHtml(search);

                        _topics[String.Format("http://www.warez-bb.org/{0}", match.Attributes["href"].Value)] = topic;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (topic == null)
                    topic = _topics[String.Format("http://www.warez-bb.org/{0}", match.Attributes["href"].Value)];

                if (topic.DocumentNode != null)
                    foreach (HtmlNode post in topic.DocumentNode.SelectNodes(@"//td[@class='postbody']") ?? Enumerable.Empty<HtmlNode>())
                    {
                        IEnumerable<String> links = (from link
                                            in post.SelectNodes(@".//td[@class='code']") ?? Enumerable.Empty<HtmlNode>()
                                                     select HttpUtility.HtmlDecode(link.InnerText));

                        // Match files in the form: rapidshare.com/12345/House.S01E02.avi.rar
                        String pattern1 = String.Format(@"(http://rapidshare.com/files/\d+/.*?S{1:D2}E{2:D2}.*?)(\s|$)", show.Series, show.Season, show.Episode);
                        // Match files in the form: rapidshare.com/12345/House.01x02.avi.rar
                        String pattern2 = String.Format(@"(http://rapidshare.com/files/\d+/.*?[^0-9]{1:D2}[x_]{2:D2}[^0-9].*?)(\s|$)", show.Series, show.Season, show.Episode);
                        // Match files in the form: rapidshare.com/12345/House.102.avi.rar
                        String pattern3 = String.Format(@"(http://rapidshare.com/files/\d+/.*?[^0-9]{1}{2:D2}[^0-9].*?)(\s|$)", show.Series, show.Season, show.Episode);

                        List<String> hits = new List<String>();

                        foreach (String link in links)
                        {
                            MatchCollection parsedLinks = Regex.Matches(link, pattern1, RegexOptions.IgnoreCase);

                            if (parsedLinks.Count == 0)
                                parsedLinks = Regex.Matches(link, pattern2, RegexOptions.IgnoreCase);

                            if (parsedLinks.Count == 0)
                                parsedLinks = Regex.Matches(link, pattern3, RegexOptions.IgnoreCase);

                            if (parsedLinks.Count > 0)
                                foreach (Match parsedLink in parsedLinks)
                                    hits.Add(parsedLink.Captures[0].Value.Trim());
                        }

                        if (hits.Count > 0)
                            yield return hits;
                    }
            }
        }

        #endregion

        #region Metadata Update Methods

        /// <summary>
        /// Scrub the metadata for all TVShows in the library
        /// </summary>
        /// <param name="filter">Delegate used to filter the TV Episodes to process</param>
        public void ProcessTVShows(TVShowFilter filter = null, TVShowSorter sortBy = null)
        {
            foreach (TVShow tvShow in this.GetTVShows(filter, sortBy))
            {
                Boolean result = false;

                result = result ||
                    this.ProcessEpisodeBySSE(this._tracks.get_ItemByPersistentID(tvShow.PersistentHigh.Value, tvShow.PersistentLow.Value) as IITFileOrCDTrack, tvShow) ||
                    this.ProcessEpisodeBySN(this._tracks.get_ItemByPersistentID(tvShow.PersistentHigh.Value, tvShow.PersistentLow.Value) as IITFileOrCDTrack, tvShow);

                if (Console.KeyAvailable)
                    return;
            }
        }

        /// <summary>
        /// Gets an IEnumerable of TVShows generated from the iTunes XML library,
        /// sorted and filtered as specified.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public IEnumerable<TVShow> GetTVShows(TVShowFilter filter = null, TVShowSorter sortBy = null)
        {
            // Set a default filter     - Filter by nothing
            if (filter == null)
                filter = (TVShowFilter)(delegate(TVShow show) { return true; });

            // Set a default sort order - Sort by Series | Season | Episode Combination
            if (sortBy == null)
                sortBy = (TVShowSorter)(delegate(TVShow show) { return String.Format("{0}:{1:D2}:{2:D2}", show.Series, show.Season, show.Episode); });

            return (from XmlNode node in this._library.SelectNodes("plist/dict/dict/dict[key='TV Show']")
                    let series       = node.SelectSingleNode("./key[text() = 'Series']/following-sibling::string[position()=1]")
                    let season       = node.SelectSingleNode("./key[text() = 'Season']/following-sibling::integer[position()=1]")
                    let episode      = node.SelectSingleNode("./key[text() = 'Episode Order']/following-sibling::integer[position()=1]")
                    let name         = node.SelectSingleNode("./key[text() = 'Name']/following-sibling::string[position()=1]")
                    let persistentId = node.SelectSingleNode("./key[text() = 'Persistent ID']/following-sibling::string[position()=1]")
                    let videoWidth   = node.SelectSingleNode("./key[text() = 'Video Width']/following-sibling::integer[position()=1]")
                    let dateAdded    = node.SelectSingleNode("./key[text() = 'Date Added']/following-sibling::date[position()=1]")
                    let dateModified = node.SelectSingleNode("./key[text() = 'Date Modified']/following-sibling::date[position()=1]")
                    let show         = new TVShow()
                    {
                        PersistentHigh = persistentId != null ? Int32.Parse(persistentId.InnerXml.Substring(0, 8), System.Globalization.NumberStyles.HexNumber) : 0,
                        PersistentLow  = persistentId != null ? Int32.Parse(persistentId.InnerXml.Substring(8, 8), System.Globalization.NumberStyles.HexNumber) : 0,
                        Title          = name         != null ? name.InnerXml                         : "",
                        Series         = series       != null ? series.InnerXml                       : "",
                        Season         = season       != null ? Int32.Parse(season.InnerXml)          : null as Int32?,
                        Episode        = episode      != null ? Int32.Parse(episode.InnerXml)         : null as Int32?,
                        VideoWidth     = videoWidth   != null ? Int32.Parse(videoWidth.InnerXml)      : null as Int32?,
                        DateModified   = dateModified != null ? DateTime.Parse(dateModified.InnerXml) : null as DateTime?,
                        DateAdded      = dateAdded    != null ? DateTime.Parse(dateAdded.InnerXml)    : null as DateTime?,
                    }
                    where filter(show)
                    orderby sortBy(show)
                    select show);
        }

        /// <summary>
        /// Gets an IEnumerable of TVShows generated from the iTunes XML library,
        /// sorted and filtered as specified.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public IEnumerable<Movie> GetMovies(MovieFilter filter = null, MovieSorter sortBy = null)
        {
            // Set a default filter     - Filter by nothing
            if (filter == null)
                filter = (MovieFilter)(delegate(Movie movie) { return true; });

            // Set a default sort order - Sort by Series | Season | Episode Combination
            if (sortBy == null)
                sortBy = (MovieSorter)(delegate(Movie movie) { return String.Format("{0:D4}:{1}", movie.Year, movie.Title); });

            return (from XmlNode node in this._library.SelectNodes("plist/dict/dict/dict[key='Movie']")
                    let name = node.SelectSingleNode("./key[text() = 'Name']/following-sibling::string[position()=1]")
                    let persistentId = node.SelectSingleNode("./key[text() = 'Persistent ID']/following-sibling::string[position()=1]")
                    let videoWidth = node.SelectSingleNode("./key[text() = 'Video Width']/following-sibling::integer[position()=1]")
                    let dateAdded = node.SelectSingleNode("./key[text() = 'Date Added']/following-sibling::date[position()=1]")
                    let dateModified = node.SelectSingleNode("./key[text() = 'Date Modified']/following-sibling::date[position()=1]")
                    let show = new Movie()
                    {
                        PersistentHigh = persistentId != null ? Int32.Parse(persistentId.InnerXml.Substring(0, 8), System.Globalization.NumberStyles.HexNumber) : 0,
                        PersistentLow = persistentId != null ? Int32.Parse(persistentId.InnerXml.Substring(8, 8), System.Globalization.NumberStyles.HexNumber) : 0,
                        Title = name != null ? name.InnerXml : "",
                        VideoWidth = videoWidth != null ? Int32.Parse(videoWidth.InnerXml) : null as Int32?,
                        DateModified = dateModified != null ? DateTime.Parse(dateModified.InnerXml) : null as DateTime?,
                        DateAdded = dateAdded != null ? DateTime.Parse(dateAdded.InnerXml) : null as DateTime?,
                    }
                    where filter(show)
                    orderby sortBy(show)
                    select show);
        }

        /// <summary>
        /// Updates the metadata for an iTunes video / movie / tvShow.
        /// </summary>
        /// <param name="episode">The iTunes entity to update</param>
        /// <param name="metaData">The new metadata to save</param>
        private void SetMetaData(IITFileOrCDTrack episode, MetaData metaData)
        {
            try
            {
                Console.WriteLine(@"{0} -> {1}\{2}\{3}\{4}", episode.Location, metaData.Show, metaData.Season, metaData.Episode, metaData.Title);

                MemoryStream stream = new MemoryStream();

                try
                {
                    // Get Handle To The Media File
                    IntPtr ptr = libmp4v2.MP4Modify(episode.Location, new libmp4v2.UInt32(0), new libmp4v2.UInt32(0));

                    if (ptr.Value != new IntPtr(0))
                    {
                        // Allocate Memory For Tags Struct
                        libmp4v2.MP4Tags tags = libmp4v2.MP4TagsAlloc();

                        try
                        {
                            // Get Current Tags
                            libmp4v2.MP4TagsFetch(tags, ptr);

                            #region TV Related MetaData

                            // Set Show
                            if (!String.IsNullOrWhiteSpace(metaData.Show))
                                libmp4v2.MP4TagsSetTVShow(tags, metaData.Show);

                            // Set Season
                            libmp4v2.MP4TagsSetTVSeason(tags, metaData.Season);

                            // Set Episode
                            libmp4v2.MP4TagsSetTVEpisode(tags, metaData.Episode);

                            #endregion

                            // Set Title
                            if (!String.IsNullOrWhiteSpace(metaData.Title))
                                libmp4v2.MP4TagsSetName(tags, metaData.Title);

                            // Set ShortDescription
                            if (!String.IsNullOrWhiteSpace(metaData.ShortDescription))
                                libmp4v2.MP4TagsSetDescription(tags, metaData.ShortDescription);

                            // Set LongDescription
                            if (!String.IsNullOrWhiteSpace(metaData.Description))
                                libmp4v2.MP4TagsSetLongDescription(tags, metaData.Description);

                            // Set HD Flag
                            libmp4v2.MP4TagsSetHDVideo(tags, metaData.IsHDVideo);

                            // Save The Tags
                            libmp4v2.MP4TagsStore(tags, ptr);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        // DeAllocate Tag Struct
                        libmp4v2.MP4TagsFree(tags);
                    }

                    // Close The File
                    libmp4v2.MP4Close(ptr);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // Refresh iTunes
                episode.UpdateInfoFromFile();

                // Update TrackNo
                if (metaData.TrackNo.HasValue)
                    episode.TrackNumber = metaData.TrackNo.Value;

                // Update TV Flag
                if (metaData.IsTVShow)
                    episode.VideoKind = ITVideoKind.ITVideoKindTVShow;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        #endregion

        #region IMDB Search Methods

        /// <summary>
        /// Search for TV Shows in which IMDB has a record of episodes we do not have locally.
        /// </summary>
        /// <param name="series"></param>
        /// <param name="filter">Delegate used to filter the TV Episodes to search for</param>
        /// <param name="sortBy"></param>
        /// <returns>An enumerable collection of TVShows</returns>
        public IEnumerable<TVShow> FindEpisodes(String show, TVShowFilter filter, TVShowSorter sortBy)
        {
            if (!_imdbPages.ContainsKey(show))
                this.AddToPages(show);

            if (_imdbPages.ContainsKey(show))
            {
                HtmlNodeCollection episodes = _imdbPages[show].DocumentNode.SelectNodes("//div/div//h3[contains(text(), 'Episode')]/a");

                foreach (HtmlNode episode in episodes)
                {
                    Match match = Regex.Match(HttpUtility.HtmlDecode(episode.ParentNode.InnerText), @"Season (\d+), Episode (\d+): (.*)", RegexOptions.IgnoreCase);

                    if (match.Success)
                    {
                        Int32 seasonNo = Int32.Parse(match.Groups[1].Value);
                        Int32 episodeNo = Int32.Parse(match.Groups[2].Value);
                        String title = match.Groups[3].Value;

                            yield return new TVShow()
                            {
                                Series = show,
                                Season = seasonNo,
                                Episode = episodeNo,
                                Title = title
                            };
                    }
                }
            }
        }

        /// <summary>
        /// Search for TV Shows in which IMDB has a record of episodes we do not have locally.
        /// </summary>
        /// <param name="filter">Delegate used to filter the TV Episodes to search for</param>
        /// <returns>An enumerable collection of TVShows</returns>
        public IEnumerable<TVShow> FindMissingEpisodes(TVShowFilter filter = null, TVShowSorter sortBy = null)
        {
            IEnumerable<TVShow> tvShows = this.GetTVShows(filter, sortBy);

            IEnumerable<String> shows = (from tvShow
                                             in tvShows
                                         select tvShow.Series).Distinct<String>();

            return (from series in this.GetTVShows(filter, sortBy).Select<TVShow, String>(s => s.Series).Distinct<String>()
                    from tvShow in this.FindEpisodes(series, filter, sortBy)
                    where (from show in this.GetTVShows(filter, sortBy) where show.Series == tvShow.Series && show.Episode == tvShow.Episode && show.Season == tvShow.Season select true).Count<Boolean>() == 0
                    select tvShow);
        }

        /// <summary>
        /// Scrub the metadata for a single TV episode, matching on the Show, and attempting to extract the SeriesNo and EpisodeNo from the name.
        /// </summary>
        /// <param name="episode">The episode to correct metadata for.</param>
        /// <param name="tvShow">Details about the file, pulled from the XML library.</param>
        /// <returns>True if an IMDB match is found, False otherwise.</returns>
        private Boolean ProcessEpisodeBySN(IITFileOrCDTrack episode, TVShow tvShow)
        {
            String location = episode.Location;
            String show = episode.Show;
            String name = episode.Name;
            Int32? episodeNo = episode.EpisodeNumber;
            Int32? seasonNo = episode.SeasonNumber;
            String blurb = episode.Description;

            if (String.IsNullOrWhiteSpace(show))
                foreach (String currentShow in (from existingShow in this.GetTVShows() select existingShow.Series).Distinct<String>())
                    if (!String.IsNullOrWhiteSpace(currentShow) && Regex.Replace(tvShow.Title, "[^a-z]", "", RegexOptions.IgnoreCase).ToLowerInvariant().Contains(Regex.Replace(currentShow, "[^a-z]", "", RegexOptions.IgnoreCase).ToLowerInvariant()))
                    {
                        show = currentShow;

                        break;
                    }

            if (String.IsNullOrWhiteSpace(show))
            {
                Console.WriteLine("Unable to find a match for: [{0}] [{1}x{2}] {3}", show, seasonNo ?? 0, episodeNo ?? 0, name);

                return false;
            }

            if (seasonNo == 0)
                seasonNo = null;

            if (episodeNo == 0)
                episodeNo = null;

            if (!String.IsNullOrWhiteSpace(episode.LongDescription))
                blurb = episode.LongDescription;

            if (!_imdbPages.ContainsKey(show))
                this.AddToPages(show);

            if (_imdbPages.ContainsKey(show))
            {
                Match match = Regex.Match(name, @"(\d{1,2})x(\d{1,2})", RegexOptions.IgnoreCase);

                if (!match.Success)
                    match = Regex.Match(name, @"S(\d{1,2})E(\d{1,2})", RegexOptions.IgnoreCase);

                if (!match.Success)
                    match = Regex.Match(name, @"Season\s+(\d{1,2})\s+Episode\s+(\d{1,2})", RegexOptions.IgnoreCase);

                if (!match.Success)
                    match = Regex.Match(name, @"(\d{1,2})_(\d{1,2})", RegexOptions.IgnoreCase);

                if (!match.Success) {
                    match = Regex.Match(name, @"[^0-9x](\d{1,2})(\d{2})([^0-9p].*)?", RegexOptions.IgnoreCase);

                    if (Regex.Match(name, @"[^0-9](19|20)(\d{2})[^0-9]", RegexOptions.IgnoreCase).Success)
                    {
                        Console.WriteLine("Unable to extract Season / Episode from name: {0}", name);

                        return false;
                    }
                }

                if (!match.Success)
                {
                    Console.WriteLine("Unable to extract Season / Episode from name: {0}", name);

                    return false;
                }

                episode.SeasonNumber = Int32.Parse(match.Groups[1].Value);
                episode.EpisodeNumber = Int32.Parse(match.Groups[2].Value);

                ProcessEpisodeBySSE(episode, tvShow);
            }

            return false;
        }

        /// <summary>
        /// Scrub the metadata for a single TV episode, matching on the Show, SeriesNo, and EpisodeNo.
        /// </summary>
        /// <param name="episode">The episode to correct metadata for.</param>
        /// <param name="tvShow">Details about the file, pulled from the XML library.</param>
        /// <returns>True if an IMDB match is found, False otherwise.</returns>
        private Boolean ProcessEpisodeBySSE(IITFileOrCDTrack episode, TVShow tvShow)
        {
            String location = episode.Location;
            String show = episode.Show;
            String name = episode.Name;
            Int32? episodeNo = episode.EpisodeNumber;
            Int32? seasonNo = episode.SeasonNumber;
            String blurb = episode.Description;

            if (String.IsNullOrWhiteSpace(show))
                foreach (String currentShow in (from existingShow in this.GetTVShows() select existingShow.Series).Distinct<String>())
                    if (!String.IsNullOrWhiteSpace(currentShow) && Regex.Replace(tvShow.Title, "[^a-z]", "", RegexOptions.IgnoreCase).ToLowerInvariant().Contains(Regex.Replace(currentShow, "[^a-z]", "", RegexOptions.IgnoreCase).ToLowerInvariant()))
                    {
                        show = currentShow;

                        break;
                    }

            if (String.IsNullOrWhiteSpace(show))
            {
                Console.WriteLine("Unable to find a match for: [{0}] [{1}x{2}] {3}", show, seasonNo ?? 0, episodeNo ?? 0, name);

                return false;
            }

            if (!String.IsNullOrWhiteSpace(episode.LongDescription))
                blurb = episode.LongDescription;

            if (!_imdbPages.ContainsKey(show))
                this.AddToPages(show);

            if (seasonNo == 0)
                seasonNo = null;

            if (episodeNo == 0)
                episodeNo = null;

            if (_imdbPages.ContainsKey(show))
            {
                HtmlNode titleNode = _imdbPages[show].DocumentNode.SelectSingleNode(String.Format("//div[@class='season-filter-all filter-season-{0}']/div//h3[contains(text(), 'Episode {1}')]/a", seasonNo ?? -1, episodeNo ?? -1));
                HtmlNode descNode = _imdbPages[show].DocumentNode.SelectSingleNode(String.Format("//div[@class='season-filter-all filter-season-{0}']/div//h3[contains(text(), 'Episode {1}')]/..", seasonNo ?? -1, episodeNo ?? -1));

                if (titleNode == null)
                {
                    Console.WriteLine("Unable to find a match for: [{0}] [{1}x{2}] {3}", show, seasonNo ?? 0, episodeNo ?? 0, name);

                    return false;
                }

                String title = HttpUtility.HtmlDecode(titleNode.InnerText);

                String desc = String.Empty;

                if ((descNode != null) && (descNode.ChildNodes.Count > 2))
                    desc = HttpUtility.HtmlDecode(descNode.ChildNodes[3].InnerText.Trim());

                try
                {
                    this.SetMetaData(episode, new MetaData()
                    {
                        Title = title,
                        Show = show,
                        Season = seasonNo,
                        Episode = episodeNo,
                        TrackNo = (Int16?)episodeNo,
                        Description = desc,
                        IsTVShow = true,
                        IsHDVideo = (tvShow.VideoWidth ?? 0) >= 1280
                    });
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

                return true;
            }
            else
                Console.WriteLine("Unable to find a match for: [{0}] [{1}x{2}] {3}", show, seasonNo ?? 0, episodeNo ?? 0, name);

            return false;
        }

        private void AddToPages(String show)
        {
            if (!_imdbList.ContainsKey(show))
                this.AddToList(show);

            if (!_imdbList.ContainsKey(show))
                return;

            Console.Write("Searching for series via imdb feed: [{0}] ...", show);

            try
            {
                HtmlDocument imdb = new HtmlDocument();
                imdb.LoadHtml(FileHelper.HttpGet(String.Format("http://www.imdb.com/title/{0}/episodes", _imdbList[show])));
                _imdbPages[show] = imdb;
            }
            catch (Exception) { }

            Console.WriteLine(" Done.");
        }

        private void AddToList(String show)
        {
            Console.Write("Searching for series via tvdb feed: [{0}] ...", show);

            try
            {
                XmlDocument seriesSearch = new XmlDocument();
                seriesSearch.LoadXml(FileHelper.HttpGet(String.Format("http://thetvdb.com/api/GetSeries.php?seriesname={0}", HttpUtility.HtmlEncode(show))).ToLowerInvariant());

                XmlNode selectedSeries = seriesSearch.SelectSingleNode(String.Format("Data/Series[SeriesName='{0}']/IMDB_ID", show).ToLowerInvariant());

                if (selectedSeries == null)
                    selectedSeries = seriesSearch.SelectSingleNode(String.Format("Data/Series[SeriesName='The {0}']/IMDB_ID", show).ToLowerInvariant());

                if (selectedSeries != null)
                    _imdbList[show] = selectedSeries.InnerText;
            }
            catch (Exception) { }

            Console.WriteLine(" Done.");
        }

        #endregion
    }
}