using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System;
using iTunes.Scrubber.DataSources;
using HtmlAgilityPack;
using System.Web;

namespace iTunes.Scrubber.Parsers
{
    public class MovieParser : BaseClasses.ParserBase<MediaItems.MovieItem>
    {
        public override IEnumerable<Delegates.Parser<MediaItems.MovieItem>> AllParsers
        {
            get
            {
                yield return FileNameParser;
                yield return IMDBParser;
                // TODO: Add more parsers here
            }
        }

        /// <summary>
        /// Attempt to determine as much about the show as possible using regex strings.
        /// </summary>
        /// <param name="mediaItem">The mediaItem we're trying to update.</param>
        /// <returns>A modified copy of the mediaItem.</returns>
        public MediaItems.MovieItem FileNameParser(MediaItems.MovieItem mediaItem)
        {
            String fullTitle = mediaItem.Title;

            #region Extract Year From Title

            Match match = Regex.Match(mediaItem.Title, @"(?:^|[^0-9])((?:19|20)\d{2})(?:[^0-9].*?|$)$", RegexOptions.IgnoreCase);

            if (match.Success)
                mediaItem.Year = Int32.Parse(match.Groups[1].Captures[0].Value);

            #endregion

            #region Strip Rip-Type Off Title

            match = Regex.Match(mediaItem.Title, @"(.*?)[^a-z0-9]*(?:BRRip|DVD|HDDVD|BluRay|R5|DIVX|x264|h264).*", RegexOptions.IgnoreCase);

            if (match.Success)
                mediaItem.Title = match.Groups[1].Value;

            #endregion

            #region Strip Resolution And Year Off End Of Title

            String numberPattern = "720|1080";

            if ((mediaItem.Year ?? 0) > 1900)
                numberPattern += "|" + mediaItem.Year.ToString();

            match = Regex.Match(mediaItem.Title, @"(.*?)[^a-z0-9]*(?:" + numberPattern + ").*", RegexOptions.IgnoreCase);

            if (match.Success)
                mediaItem.Title = match.Groups[1].Value;

            #endregion

            #region Convert Special Characters To Spaces

            mediaItem.Title = mediaItem.Title.Replace('.', ' ');
            // mediaItem.Title = mediaItem.Title.Replace('_', ' ');

            #endregion

            if (String.IsNullOrWhiteSpace(mediaItem.Title))
                mediaItem.Title = fullTitle;

            mediaItem.IsDirty |= mediaItem.Title != fullTitle;

            return mediaItem;
        }

        /// <summary>
        /// Attempt to lookup IMDB data about a Movie
        /// </summary>
        /// <param name="mediaItem">The mediaItem we're trying to update.</param>
        /// <returns>A modified copy of the mediaItem.</returns>
        public MediaItems.MovieItem IMDBParser(MediaItems.MovieItem mediaItem)
        {
            if (mediaItem.Year < 1990)
                mediaItem.Year = null;

            if (String.IsNullOrWhiteSpace(mediaItem.IMDB_ID))
            {
                IMDBAPISource.IMDBData searchAPI = DataSources.IMDBAPISource.Instance[mediaItem.Title, mediaItem.Year];

                if ((searchAPI == null || String.IsNullOrWhiteSpace(searchAPI.title)) && (Regex.Replace(mediaItem.Title, "[^a-z0-9 ]", "", RegexOptions.IgnoreCase) != mediaItem.Title))
                    searchAPI = DataSources.IMDBAPISource.Instance[Regex.Replace(mediaItem.Title, "[^a-z0-9 ]", "", RegexOptions.IgnoreCase), mediaItem.Year];

                if (searchAPI != null && !String.IsNullOrWhiteSpace(searchAPI.title))
                    mediaItem.IMDB_ID = searchAPI.IMDB_ID;
            }

            if (!String.IsNullOrWhiteSpace(mediaItem.IMDB_ID))
            {
                imdbMovieSource imdbItem = imdbMovieSource.Instance[mediaItem.IMDB_ID];

                mediaItem.Title = imdbItem.Name;
                mediaItem.Year = imdbItem.Year;
                mediaItem.Description = imdbItem.Description;
                mediaItem.ImageURL = imdbItem.ImageURL;

                if (imdbItem.Genres.Count > 0)
                    mediaItem.Genre = imdbItem.Genres[0];

                mediaItem.Cast     = String.Join(", ", imdbItem.Cast);
                mediaItem.Director = String.Join(", ", imdbItem.Directors);
                mediaItem.Writers  = String.Join(", ", imdbItem.Writers);
                mediaItem.Grouping = String.Join(", ", imdbItem.Genres);
                
                if (imdbItem.Ratings.ContainsKey("au"))
                    mediaItem.Rating = Helpers.RatingHelper.GetAURating("au", imdbItem.Ratings["au"]);
                else if (imdbItem.Ratings.ContainsKey("nz"))
                    mediaItem.Rating = Helpers.RatingHelper.GetAURating("nz", imdbItem.Ratings["nz"]);
                else if (imdbItem.Ratings.ContainsKey("uk"))
                    mediaItem.Rating = Helpers.RatingHelper.GetAURating("uk", imdbItem.Ratings["uk"]);
                else if (imdbItem.Ratings.ContainsKey("gb"))
                    mediaItem.Rating = Helpers.RatingHelper.GetAURating("gb", imdbItem.Ratings["gb"]);
                else if (imdbItem.Ratings.ContainsKey("us"))
                    mediaItem.Rating = Helpers.RatingHelper.GetAURating("us", imdbItem.Ratings["us"]);
            }

            //IMDBSource.IMDBData searchIMDB = null;

            //if (!String.IsNullOrWhiteSpace(mediaItem.IMDB_ID))
            //    searchIMDB = DataSources.IMDBSource.Instance[mediaItem.IMDB_ID];

            //if (searchIMDB == null)
            //{
                //IMDBAPISource.IMDBData searchAPI = DataSources.IMDBAPISource.Instance[mediaItem.Title, mediaItem.Year];

            //    if ((searchAPI == null || String.IsNullOrWhiteSpace(searchAPI.title)) && (Regex.Replace(mediaItem.Title, "[^a-z0-9 ]", "", RegexOptions.IgnoreCase) != mediaItem.Title))
            //        searchAPI = DataSources.IMDBAPISource.Instance[Regex.Replace(mediaItem.Title, "[^a-z0-9 ]", "", RegexOptions.IgnoreCase), mediaItem.Year];

            //    if (searchAPI != null && !String.IsNullOrWhiteSpace(searchAPI.title))
            //    {
            //        mediaItem.Genre = searchAPI.genres.Split(',').FirstOrDefault<String>();
            //        mediaItem.Grouping = searchAPI.genres.Replace(',', ' ').Replace("  ", " ").Trim();
            //        mediaItem.Title = searchAPI.title;
            //        mediaItem.Rating = searchAPI.rating;

            //        Int32 year;
            //        if (Int32.TryParse(searchAPI.year, out year))
            //            mediaItem.Year = year;

            //        mediaItem.IMDB_ID = searchAPI.IMDB_ID;
            //    }

            //    if (searchAPI == null || String.IsNullOrWhiteSpace(searchAPI.IMDB_ID))
            //        searchIMDB = DataSources.IMDBSource.Instance[mediaItem.Title, mediaItem.Year];
            //    else
            //        searchIMDB = DataSources.IMDBSource.Instance[searchAPI.IMDB_ID];

            //    if ((searchIMDB == null) && (Regex.Replace(mediaItem.Title, "[^a-z0-9 ]", "", RegexOptions.IgnoreCase) != mediaItem.Title))
            //        searchIMDB = DataSources.IMDBSource.Instance[Regex.Replace(mediaItem.Title, "[^a-z0-9 ]", "", RegexOptions.IgnoreCase), mediaItem.Year];

            //}
            
            //if (searchIMDB != null)
            //{
            //    #region Title

            //    HtmlNode currentNode = searchIMDB.TitlePage.DocumentNode.SelectSingleNode(Constants.IMDB_MOVIETITLE);
            //    String title = currentNode == null ? mediaItem.Title : currentNode.FirstChild.InnerText.Trim();

            //    #endregion

            //    #region Rating

            //    currentNode = searchIMDB.TitlePage.DocumentNode.SelectSingleNode(Constants.IMDB_MOVIERATING);
            //    String rating = currentNode == null ? String.Empty : currentNode.Attributes["title"].Value.Trim();

            //    #endregion

            //    #region Advanced Genres

            //    HtmlNodeCollection currentNodes = searchIMDB.TitlePage.DocumentNode.SelectNodes(Constants.IMDB_MOVIEGENRES);
            //    String genre = currentNodes == null ? String.Empty : currentNodes.FirstOrDefault<HtmlNode>().InnerText.Trim();
            //    String grouping = String.Join(" ", (from node in currentNodes select node.InnerText.Replace(',', ' ').Replace("  ", " ").Trim()));
                
            //    #endregion

            //    #region Description

            //    String desc = String.Empty;
            //    currentNodes = searchIMDB.TitlePage.DocumentNode.SelectNodes(Constants.IMDB_MOVIESYNOPSIS);
            //    if (currentNodes != null && currentNodes.Count > 0)
            //        desc = String.Join("\r\n", (from node in currentNodes select node.InnerText.Trim()));

            //    #endregion

            //    #region Year

            //    currentNode = searchIMDB.TitlePage.DocumentNode.SelectSingleNode(Constants.IMDB_MOVIEYEAR);
            //    Int32 year = currentNode == null ? 0 : Int32.Parse(Regex.Replace(currentNode.InnerText, "[^0-9]", "", RegexOptions.IgnoreCase));

            //    #endregion

            //    //String genres = String.Join(",",
            //    //    (from node in searchIMDB.TitlePage.DocumentNode.SelectNodes(Constants.IMDB_MOVIEGENRES)
            //    //     let genre = node.InnerText
            //    //     select genre));

            //    mediaItem.Title = HttpUtility.HtmlDecode(title);
            //    mediaItem.Year = year > 1900 ? year : null as Int32?;
            //    mediaItem.Genre = HttpUtility.HtmlDecode(genre);
            //    mediaItem.Grouping = grouping;
            //    mediaItem.Rating = rating;
            //    mediaItem.Description = HttpUtility.HtmlDecode(desc);
            //    mediaItem.IMDB_ID = searchIMDB.IMDB_ID;
            //}

            return mediaItem;
        }
    }
}