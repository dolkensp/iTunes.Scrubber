using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Web;

namespace iTunes.Scrubber.DataSources
{
    public class imdbTVSource : BaseClasses.SingletonBase<imdbTVSource>, Interfaces.IDataSource
    {
        #region Private Static Fields

        private static Dictionary<String, String> _seasonCache = new Dictionary<String, String>();
        private static Dictionary<String, imdbTVSource> _cache = new Dictionary<String, imdbTVSource>();
        private static Dictionary<String, Object> _cacheLock = new Dictionary<String, Object>();
        private static Object _masterLock = new Object();
        private static Regex _titleReplace = new Regex(@"/title/(.*)/", RegexOptions.IgnoreCase);
        private static Regex _imageReplace = new Regex(@"^(.*)\._.*_(\.[a-zA-Z]{3}$)", RegexOptions.IgnoreCase);

        #endregion

        #region Constructor/Destructors

        public imdbTVSource()
        {
            this.Cast = new List<String>();
            this.Directors = new List<String>();
            this.Genres = new List<String>();
            this.Writers = new List<String>();
            this.Ratings = new Dictionary<String, String>();
        }

        public void Dispose() { }

        #endregion

        private imdbTVSource this[String imdbId]
        {
            get
            {
                String cackeKey = String.Format("{0}::", imdbId);

                if (!_cache.ContainsKey(cackeKey))
                {
                    lock (_masterLock)
                        _cacheLock[cackeKey] = new Object();

                    lock (_cacheLock[cackeKey])
                    {
                        if (!_cache.ContainsKey(cackeKey))
                        {
                            imdbTVSource buffer = new imdbTVSource
                            {
                                EpisodeID = imdbId
                            };
                            
                            HtmlDocument html = new HtmlDocument();
                            List<HtmlNode> nodes;

                            #region Overview

                            try
                            {
                                Console.WriteLine("Loading [http://www.imdb.com/title/{0}/]", imdbId);

                                html.LoadHtml(Helpers.FileHelper.HttpGet(String.Format("http://www.imdb.com/title/{0}/", imdbId)));

                                nodes = html.DocumentNode.QuerySelectorAll("img[itemprop='image']").ToList();
                                if (nodes.Count > 0)
                                    buffer.ImageURL = _imageReplace.Replace(nodes[0].Attributes["src"].Value.Trim(), "$1");

                                // Console.WriteLine("Parsing [http://www.imdb.com/title/{0}/]", imdbId);

                                nodes = html.DocumentNode.QuerySelectorAll("div[itemprop='actors'] span[itemprop='name']").ToList();
                                if (nodes.Count > 0)
                                    buffer.Cast = (from actor in nodes select HttpUtility.HtmlDecode(actor.FirstChild.InnerText.Trim())).ToList();
                                
                                nodes = html.DocumentNode.QuerySelectorAll("div[itemprop='director'] span[itemprop='name']").ToList();
                                if (nodes.Count > 0)
                                    buffer.Directors = (from actor in nodes select HttpUtility.HtmlDecode(actor.FirstChild.InnerText.Trim())).ToList();
                                
                                nodes = html.DocumentNode.QuerySelectorAll("div[itemprop='creator'] span[itemprop='name']").ToList();
                                if (nodes.Count > 0)
                                    buffer.Writers = (from actor in nodes select HttpUtility.HtmlDecode(actor.FirstChild.InnerText.Trim())).ToList();

                                nodes = html.DocumentNode.QuerySelectorAll("span[itemprop='genre'] a").ToList();
                                if (nodes.Count > 0)
                                    buffer.Genres = (from genre in nodes select genre.FirstChild.InnerText.Trim()).ToList();

                                nodes = html.DocumentNode.QuerySelectorAll("div#titleDetails div.txt-block h4.inline").Where(x => x.InnerText.Trim() == "Release Date:").Select(x => x.ParentNode).ToList();
                                if (nodes.Count > 0)
                                    buffer.AirDate = nodes[0].InnerText.Trim();
                                
                                nodes = (from node in html.DocumentNode.QuerySelectorAll("p[itemprop='description']")
                                         where !node.InnerText.ToLowerInvariant().Contains("see full summary")
                                         select node).ToList();

                                if (nodes.Count > 0)
                                    buffer.Description = (from node in nodes
                                                          let description = HttpUtility.HtmlDecode(node.InnerText.Trim())
                                                          orderby Math.Abs(200 - description.Length) ascending
                                                          select description).First();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("[{0}] Overview: {1}", imdbId, ex.Message);
                            }

                            #endregion
                            
                            #region Parental Guide

                            try
                            {
                                Console.WriteLine("Loading [http://www.imdb.com/title/{0}/parentalguide]", imdbId);

                                html.LoadHtml(Helpers.FileHelper.HttpGet(String.Format("http://www.imdb.com/title/{0}/parentalguide", imdbId)));

                                // Console.WriteLine("Parsing [http://www.imdb.com/title/{0}/parentalguide]", imdbId);

                                Regex ccRegex = new Regex(".*=([a-z0-9+_-]*):([a-z0-9+_-]*)$", RegexOptions.IgnoreCase);

                                nodes = html.DocumentNode.QuerySelectorAll("a[href^='/search/title?certificates']").ToList();

                                foreach (var rating in (from node in nodes
                                                        let href = node.Attributes["href"].Value.Trim()
                                                        let match = ccRegex.Match(href)
                                                        where match.Success
                                                        let countryCode = match.Groups[1].Captures[0].Value
                                                        where new String[] { "au", "gb", "nz", "us" }.Contains(countryCode)
                                                        let rating = match.Groups[2].Captures[0].Value
                                                        select new { countryCode, rating }))
                                    buffer.Ratings[rating.countryCode] = rating.rating;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("[{0}] Parental Guide: {1}", imdbId, ex.Message);
                            }

                            #endregion

                            _cache[cackeKey] = buffer;
                        }
                    }

                    lock (_masterLock)
                        _cacheLock.Remove(cackeKey);
                }

                return _cache[cackeKey];
            }
        }

        public imdbTVSource this[String imdbId, Int32? seasonNo, Int32? episodeNo]
        {
            get
            {
                String cackeKey = String.Format("{0}:{1}:{2}", imdbId, seasonNo, episodeNo);
                String seasonKey = String.Format("{0}:{1}", imdbId, seasonNo);

                if (!_cache.ContainsKey(cackeKey))
                {
                    lock (_masterLock)
                        _cacheLock[cackeKey] = new Object();

                    lock (_cacheLock[cackeKey])
                    {
                        if (!_cache.ContainsKey(cackeKey))
                        {
                            imdbTVSource buffer = this[imdbId];

                            buffer.Name = String.Empty;
                            buffer.Description = String.Empty;
                            buffer.EpisodeID = imdbId;
                            
                            HtmlDocument html = new HtmlDocument();
                            List<HtmlNode> nodes;

                            #region Episode List

                            try
                            {
                                if (_seasonCache.ContainsKey(seasonKey))
                                    html.LoadHtml(_seasonCache[seasonKey]);
                                else
                                {
                                    Console.WriteLine("Loading [http://www.imdb.com/title/{0}/episodes?season={1}]", imdbId, seasonNo);
                                    html.LoadHtml(Helpers.FileHelper.HttpGet(String.Format("http://www.imdb.com/title/{0}/episodes?season={1}", imdbId, seasonNo)));
                                    _seasonCache[seasonKey] = html.DocumentNode.InnerHtml;
                                }
                                
                                var episodeNode = html.DocumentNode.QuerySelector(String.Format("meta[itemprop='episodeNumber'][content='{0}']", episodeNo));

                                if (episodeNode != null)
                                {
                                    episodeNode = episodeNode.ParentNode.ParentNode;

                                    nodes = (from node in episodeNode.QuerySelectorAll("div[itemprop='description']")
                                             where !node.InnerText.ToLowerInvariant().Contains("see full summary")
                                             where node.InnerText.ToLowerInvariant().Trim().Length > 20
                                             select node).ToList();

                                    if (nodes.Count > 0)
                                        buffer.Description = (from node in nodes
                                                              let description = HttpUtility.HtmlDecode(node.InnerText.Trim())
                                                              orderby Math.Abs(200 - description.Length) ascending
                                                              select description).First();

                                    nodes = episodeNode.QuerySelectorAll("a[itemprop='url']").ToList();
                                    if (nodes.Count > 0)
                                        buffer.EpisodeID = _titleReplace.Replace(nodes[0].Attributes["href"].Value, "$1");

                                    nodes = episodeNode.QuerySelectorAll("[itemprop='name']").ToList();
                                    if (nodes.Count > 0)
                                        buffer.Name = nodes[0].InnerText.Trim();

                                    nodes = html.DocumentNode.QuerySelectorAll("div.airdate").ToList();
                                    if (nodes.Count > 0)
                                        buffer.AirDate = nodes[0].InnerText.Trim();

                                    // nodes = episodeNode.QuerySelectorAll("img").ToList();
                                    // if (nodes.Count > 0)
                                    //     buffer.ImageURL = _imageReplace.Replace(nodes[0].Attributes["src"].Value.Trim(), "$1");

                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("[{0}] Episode list: {1}", imdbId, ex.Message);
                            }

                            #endregion

                            #region Episode Detail

                            try
                            {
                                if (buffer.EpisodeID != imdbId)
                                {
                                    Console.WriteLine("Loading [http://www.imdb.com/title/{0}/]", buffer.EpisodeID);

                                    html.LoadHtml(Helpers.FileHelper.HttpGet(String.Format("http://www.imdb.com/title/{0}/", buffer.EpisodeID)));

                                    // nodes = html.DocumentNode.QuerySelectorAll("img[itemprop='image']").ToList();
                                    // if (nodes.Count > 0)
                                    //     buffer.ImageURL = _imageReplace.Replace(nodes[0].Attributes["src"].Value.Trim(), "$1");

                                    // Console.WriteLine("Parsing [http://www.imdb.com/title/{0}/]", imdbId);

                                    nodes = html.DocumentNode.QuerySelectorAll("h1 span[itemprop='name']").ToList();
                                    if (nodes.Count > 0)
                                        buffer.Name = HttpUtility.HtmlDecode(nodes[0].FirstChild.InnerText.Trim());

                                    nodes = html.DocumentNode.QuerySelectorAll("div[itemprop='actors'] span[itemprop='name']").ToList();
                                    if (nodes.Count > 0)
                                        buffer.Cast = (from actor in nodes select HttpUtility.HtmlDecode(actor.FirstChild.InnerText.Trim())).ToList();

                                    nodes = html.DocumentNode.QuerySelectorAll("div[itemprop='director'] span[itemprop='name']").ToList();
                                    if (nodes.Count > 0)
                                        buffer.Directors = (from actor in nodes select HttpUtility.HtmlDecode(actor.FirstChild.InnerText.Trim())).ToList();

                                    nodes = html.DocumentNode.QuerySelectorAll("div[itemprop='creator'] span[itemprop='name']").ToList();
                                    if (nodes.Count > 0)
                                        buffer.Writers = (from actor in nodes select HttpUtility.HtmlDecode(actor.FirstChild.InnerText.Trim())).ToList();

                                    nodes = html.DocumentNode.QuerySelectorAll("a span[itemprop='genre']").ToList();
                                    if (nodes.Count > 0)
                                        buffer.Genres = (from genre in nodes select genre.FirstChild.InnerText.Trim()).ToList();

                                    nodes = html.DocumentNode.QuerySelectorAll("div#titleDetails div.txt-block h4.inline").Where(x => x.InnerText.Trim() == "Release Date:").Select(x => x.ParentNode).ToList();
                                    if (nodes.Count > 0)
                                        buffer.AirDate = nodes[0].InnerText.Trim();

                                    nodes = (from node in html.DocumentNode.QuerySelectorAll("p[itemprop='description']")
                                             where !node.InnerText.ToLowerInvariant().Contains("see full summary")
                                             select node).ToList();

                                    if (nodes.Count > 0)
                                        buffer.Description = (from node in nodes
                                                              let description = HttpUtility.HtmlDecode(node.InnerText.Trim())
                                                              orderby Math.Abs(200 - description.Length) ascending
                                                              select description).First();

                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("[{0}] Episode list: {1}", imdbId, ex.Message);
                            }

                            #endregion

                            #region Parental Guide

                            try
                            {
                                if (imdbId != buffer.EpisodeID)
                                {
                                    Console.WriteLine("Loading [http://www.imdb.com/title/{0}/parentalguide]", buffer.EpisodeID);

                                    html.LoadHtml(Helpers.FileHelper.HttpGet(String.Format("http://www.imdb.com/title/{0}/parentalguide", buffer.EpisodeID)));

                                    // Console.WriteLine("Parsing [http://www.imdb.com/title/{0}/parentalguide]", imdbId);

                                    Regex ccRegex = new Regex(".*=([a-z0-9+_-]*):([a-z0-9+_-]*)$", RegexOptions.IgnoreCase);

                                    nodes = html.DocumentNode.QuerySelectorAll("a[href^='/search/title?certificates']").ToList();

                                    foreach (var rating in (from node in nodes
                                                            let href = node.Attributes["href"].Value.Trim()
                                                            let match = ccRegex.Match(href)
                                                            where match.Success
                                                            let countryCode = match.Groups[1].Captures[0].Value
                                                            where new String[] { "au", "gb", "nz", "us" }.Contains(countryCode)
                                                            let rating = match.Groups[2].Captures[0].Value
                                                            select new { countryCode, rating }))
                                        buffer.Ratings[rating.countryCode] = rating.rating;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("[{0}] Parental Guide: {1}", imdbId, ex.Message);
                            }

                            #endregion

                            _cache[cackeKey] = buffer;
                        }
                    }

                    lock (_masterLock)
                        _cacheLock.Remove(cackeKey);
                }

                return _cache[cackeKey];
            }
        }

        #region Public Properties

        public String EpisodeID { get; set; }

        public String Name { get; set; }

        public List<String> Cast { get; set; }
        public List<String> Directors { get; set; }
        public List<String> Genres { get; set; }
        public List<String> Writers { get; set; }

        public Int32? Year { get; set; }

        public String Description { get; set; }

        public Dictionary<String, String> Ratings { get; set; }

        public String ImageURL { get; set; }

        private String _airDate;
        public String AirDate
        {
            get { return this._airDate; }
            set
            {
                this._airDate = value;

                DateTime temp;
                Match regexMatch;

                if (DateTime.TryParse(this._airDate, out temp))
                {
                    this._airDate = temp.ToString("yyyy-MM-dd");
                    this.Year = temp.Year;
                    return;
                }

                regexMatch = Regex.Match(this._airDate, @"Release Date\: (.*?) \(.*\)");
                if (regexMatch.Success && DateTime.TryParse(regexMatch.Groups[1].Value, out temp))
                {
                    this._airDate = temp.ToString("yyyy-MM-dd");
                    this.Year = temp.Year;
                    return;
                }

                regexMatch = Regex.Match(this._airDate, @"(\d{4}) \(.*\)");
                if (regexMatch.Success)
                {
                    this._airDate = regexMatch.Groups[1].Value;
                    this.Year = Int32.Parse(this._airDate);
                    return;
                }

                regexMatch = Regex.Match(this._airDate, @"\((\d{4})[-–][0-9 ]{1,4}\)");
                if (regexMatch.Success)
                {
                    this._airDate = regexMatch.Groups[1].Value;
                    this.Year = Int32.Parse(this._airDate);
                    return;
                }

                this._airDate = String.Empty;
            }
        }

        #endregion
    }
}