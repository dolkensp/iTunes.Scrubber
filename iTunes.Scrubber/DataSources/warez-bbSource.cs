using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;
using System.Threading;
using System.Text.RegularExpressions;
using System.Web;
namespace iTunes.Scrubber.DataSources
{
    public class Warez_BBSource : BaseClasses.SingletonBase<Warez_BBSource>, Interfaces.IDataSource
    {
        private Helpers.FileHelper.SimpleWebResponse _login;

        private DateTime _lastSearch;

        private Dictionary<Tuple<Enums.ForumEnum, String>, Warez_BBData> _searches;

        private Dictionary<String, Warez_BBData> _topics;

        public Warez_BBSource()
        {
            this._lastSearch = DateTime.MinValue;
            this._searches = new Dictionary<Tuple<Enums.ForumEnum, String>, Warez_BBData>();
            this._topics = new Dictionary<String, Warez_BBData>();
        }

        /// <summary>
        /// Login to the warez-bb website, and obtain session cookies
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Boolean Login(String username, String password)
        {
            Console.WriteLine("Logging in to warez-bb as [{0}]", username);

            this._login = Helpers.FileHelper.HttpPost(
                "http://www.warez-bb.org/login.php",
                null,
                null,
                new Dictionary<String, String>() {
                    { "username", username },
                    { "password", password },
                    { "login", "login" }
                },
                null);

            return this._login.Content.Contains("You have successfully logged in");
        }

        /// <summary>
        /// Returns Warez_BBData containing info about the specified topic link
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public Warez_BBData this[String topic]
        {
            get
            {
                Warez_BBData result = null;

                if (!this._topics.TryGetValue(topic, out result))
                {
                    Console.WriteLine("Loading [{0}] from warez-bb", topic);

                    String search = Helpers.FileHelper.HttpGet(
                        String.Format("http://www.warez-bb.org/{0}", topic),
                        null,
                        null,
                        _login.Cookies);

                    if (String.IsNullOrWhiteSpace(search))
                        return null;

                    HtmlDocument topicHTML = new HtmlDocument();

                    topicHTML.LoadHtml(search);

                    result = new Warez_BBData() { HTMLPage = topicHTML };

                    this._topics.Add(topic, result);
                }
                
                return result;
            }
        }

        /// <summary>
        /// Search Warez-bb for the specified item.
        /// </summary>
        /// <param name="searchTerm">The search term to use.</param>
        /// <param name="searchForum">The forum to search.</param>
        /// <returns></returns>
        public Warez_BBData Search(String searchTerm, Enums.ForumEnum searchForum)
        {
            Warez_BBData result = null;

            if (!this._searches.TryGetValue(new Tuple<Enums.ForumEnum, String>(searchForum, searchTerm), out result))
            {
                Int32 timeOut = (Int32)(1 + Constants.WAREZBB_THROTTLE - (DateTime.Now - this._lastSearch).TotalSeconds) * 1000;

                if (timeOut > 0)
                    Thread.Sleep(timeOut);

                Console.WriteLine("Searching for [{0}] on warez-bb", searchTerm);

                Helpers.FileHelper.SimpleWebResponse search = Helpers.FileHelper.HttpPost(
                    "http://www.warez-bb.org/search.php",
                    null,
                    null,
                    new Dictionary<String, String>() { 
                        { "search_keywords", searchTerm },
                        { "search_forum[]", ((Int32)searchForum).ToString() },
                        { "search_terms", "all" },
                        { "search_fields", "firstpost" },
                        { "search_time", "0" },
                        { "sort_by", "0" },
                        { "sort_dir", "DESC" },
                        { "return_chars", "-1" },
                        { "show_results", "topics" }
                    },
                    this._login.Cookies
                );

                this._lastSearch = DateTime.Now;

                if (search == null || String.IsNullOrWhiteSpace(search.Content))
                    return new Warez_BBData() { };
                
                HtmlDocument searchHTML = new HtmlDocument();

                searchHTML.LoadHtml(search.Content);

                result = new Warez_BBData() { HTMLPage = searchHTML };

                this._searches[new Tuple<Enums.ForumEnum, String>(searchForum, searchTerm)] = result;
            }

            return result;
        }

        public void Dispose() { }

        public class Warez_BBData
        {
            /// <summary>
            /// Extract topic links from the current HTMLPage
            /// </summary>
            /// <param name="tvShow">The tvShow to filter links by</param>
            /// <returns></returns>
            public IEnumerable<Warez_BBData> GetTopics(MediaItems.TVShowItem tvShow)
            {
                yield break;

                //if (this.HTMLPage == null)
                //    return Enumerable.Empty<Warez_BBData>();

                //return (from topic in (this.HTMLPage.DocumentNode.SelectNodes("//span[@class='topictitle']/a") ?? Enumerable.Empty<HtmlNode>())
                //        where   Regex.Match(topic.InnerText, String.Format(@"\[.*?({0}|Multi).*?\]\s*{1}\s*.*(Season|Series)\s*.*({2}|-)", Constants.WAREZBB_TAGS, tvShow.Show, tvShow.Season), RegexOptions.IgnoreCase).Success ||
                //                Regex.Match(topic.InnerText, String.Format(@"\[.*?({0}|Multi).*?\]\s*{1}\s*.*(Season|Series)\s*.*({2}|-)", Constants.WAREZBB_TAGS, tvShow.Show.Replace("'", ""), tvShow.Season), RegexOptions.IgnoreCase).Success
                //        orderby Int32.Parse(String.Format("{0:D3}{1:D3}{2:D3}", topic.InnerText.IndexOf("1080p"), topic.InnerText.IndexOf("720p"), topic.InnerText.IndexOf("m-HD")).Replace("-", "")) descending
                //        select Warez_BBSource.Instance[topic.Attributes["href"].Value]);
            }

            /// <summary>
            /// Extract rapidshare links from the current HTMLPage
            /// </summary>
            /// <param name="tvShow">The tvShow to filter links by</param>
            /// <returns></returns>
            public IEnumerable<IEnumerable<String>> GetLinks(MediaItems.TVShowItem tvShow)
            {
                yield break;
                //foreach (HtmlNode post in this.HTMLPage.DocumentNode.SelectNodes(@"//td[@class='postbody']") ?? Enumerable.Empty<HtmlNode>())
                //{
                //    IEnumerable<String> links = (from link in (post.SelectNodes(@".//td[@class='code']") ?? Enumerable.Empty<HtmlNode>())
                //                                 select HttpUtility.HtmlDecode(link.InnerText));

                //    // Match files in the form: rapidshare.com/12345/House.S01E02.avi.rar
                //    String pattern1 = String.Format(@"(http://(www.|)({0}).com/.*?S{2:D2}E{3:D2}.*?)(\s|$)", Constants.WAREZBB_HOSTS, tvShow.Show, tvShow.Season, tvShow.Episode);
                //    // Match files in the form: rapidshare.com/12345/House.01x02.avi.rar
                //    String pattern2 = String.Format(@"(http://(www.|)({0}).com/.*?[^0-9]{2:D2}[x_]{3:D2}[^0-9].*?)(\s|$)", Constants.WAREZBB_HOSTS, tvShow.Show, tvShow.Season, tvShow.Episode);
                //    // Match files in the form: rapidshare.com/12345/House.102.avi.rar
                //    String pattern3 = String.Format(@"(http://(www.|)({0}).com/.*?[^0-9]{2}{3:D2}[^0-9].*?)(\s|$)", Constants.WAREZBB_HOSTS, tvShow.Show, tvShow.Season, tvShow.Episode);

                //    List<String> hits = new List<String>();

                //    foreach (String link in links)
                //    {
                //        MatchCollection parsedLinks = Regex.Matches(link, pattern1, RegexOptions.IgnoreCase);

                //        if (parsedLinks.Count == 0)
                //            parsedLinks = Regex.Matches(link, pattern2, RegexOptions.IgnoreCase);

                //        if (parsedLinks.Count == 0)
                //            parsedLinks = Regex.Matches(link, pattern3, RegexOptions.IgnoreCase);

                //        if (parsedLinks.Count > 0)
                //            foreach (Match parsedLink in parsedLinks)
                //                hits.Add(parsedLink.Captures[0].Value.Trim());
                //    }

                //    if (hits.Count > 0)
                //        yield return hits.Distinct<String>();
                //}
            }

            /// <summary>
            /// The content of the HTML response provided by Warez_BB
            /// </summary>
            public HtmlDocument HTMLPage { get; set; }
        }
    }
}
