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
    public class imdbMovieSource : BaseClasses.SingletonBase<imdbMovieSource>, Interfaces.IDataSource
    {
        #region Private Static Fields

        private static Dictionary<String, imdbMovieSource> _cache = new Dictionary<String, imdbMovieSource>();
        private static Dictionary<String, Object> _cacheLock = new Dictionary<String, Object>();
        private static Object _masterLock = new Object();

        #endregion

        #region Constructor/Destructors

        public imdbMovieSource()
        {
            this.Cast = new List<String>();
            this.Directors = new List<String>();
            this.Genres = new List<String>();
            this.Writers = new List<String>();
            this.Ratings = new Dictionary<String, String>();
        }

        public void Dispose() { }

        #endregion

        public imdbMovieSource this[String imdbId]
        {
            get
            {
                if (!_cache.ContainsKey(imdbId))
                {
                    lock (_masterLock)
                        _cacheLock[imdbId] = new Object();

                    lock (_cacheLock[imdbId])
                    {
                        if (!_cache.ContainsKey(imdbId))
                        {
                            imdbMovieSource buffer = new imdbMovieSource
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

                                // Console.WriteLine("Parsing [http://www.imdb.com/title/{0}/]", imdbId);

                                nodes = html.DocumentNode.QuerySelectorAll("h1 span[itemprop='name']").ToList();
                                if (nodes.Count > 0)
                                    buffer.Name = HttpUtility.HtmlDecode(nodes[0].FirstChild.InnerText.Trim());

                                nodes = html.DocumentNode.QuerySelectorAll("div[itemprop='actors'] span[itemprop='name']").ToList();
                                buffer.Cast = (from actor in nodes select HttpUtility.HtmlDecode(actor.FirstChild.InnerText.Trim())).ToList();
                                nodes = html.DocumentNode.QuerySelectorAll("div[itemprop='director'] span[itemprop='name']").ToList();
                                buffer.Directors = (from director in nodes select HttpUtility.HtmlDecode(director.FirstChild.InnerText.Trim())).ToList();
                                nodes = html.DocumentNode.QuerySelectorAll("div[itemprop='genre'] a").ToList();
                                buffer.Genres = (from genre in nodes select genre.FirstChild.InnerText.Trim()).ToList();

                                nodes = html.DocumentNode.QuerySelectorAll("meta[itemprop='datePublished']").ToList();
                                if (nodes.Count > 0)
                                    buffer.Year = DateTime.Parse(nodes[0].Attributes["content"].Value).Year;

                                nodes = html.DocumentNode.QuerySelectorAll("img[itemprop='image']").ToList();
                                if (nodes.Count > 0)
                                    buffer.ImageURL = nodes[0].Attributes["src"].Value.Trim().Replace("SX214", "");

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

                            #region Plot Summary

                            try
                            {
                                Console.WriteLine("Loading [http://www.imdb.com/title/{0}/plotsummary]", imdbId);

                                html.LoadHtml(Helpers.FileHelper.HttpGet(String.Format("http://www.imdb.com/title/{0}/plotsummary", imdbId)));

                                // Console.WriteLine("Parsing [http://www.imdb.com/title/{0}/plotsummary]", imdbId);

                                nodes = html.DocumentNode.QuerySelectorAll("p[class='plotpar']").ToList();
                                if (nodes.Count > 0)
                                    buffer.Description = (from node in nodes
                                                          let description = HttpUtility.HtmlDecode(node.FirstChild.InnerText.Trim())
                                                          orderby Math.Abs(200 - description.Length) ascending
                                                          select description).First();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("[{0}] Plot Summary: {1}", imdbId, ex.Message);
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

                            #region Release Info // TODO: Complete this if needed

                            try
                            {
                                // Console.WriteLine("Loading [http://www.imdb.com/title/{0}/releaseinfo]", imdbId);

                                // html.LoadHtml(Helpers.FileHelper.HttpGet(String.Format("http://www.imdb.com/title/{0}/releaseinfo", imdbId)));

                                // Console.WriteLine("Parsing [http://www.imdb.com/title/{0}/releaseinfo]", imdbId);

                                // nodes = html.DocumentNode.QuerySelectorAll("a[name='akas']").ToList();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("[{0}] Release Info: {1}", imdbId, ex.Message);
                            }

                            #endregion

                            _cache[imdbId] = buffer;
                        }
                    }

                    lock (_masterLock)
                        _cacheLock.Remove(imdbId);
                }

                return _cache[imdbId];
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

        #endregion
    }
}