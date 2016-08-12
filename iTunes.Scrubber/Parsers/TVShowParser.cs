using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Web;
using iTunes.Scrubber.DataSources;

namespace iTunes.Scrubber.Parsers
{
    public class TVShowParser : BaseClasses.ParserBase<MediaItems.TVShowItem>
    {
        public override IEnumerable<Delegates.Parser<MediaItems.TVShowItem>> AllParsers
        {
            get
            {
                yield return FileNameParser;
                yield return MetaDataParser;
                yield return TVDBParser;
                yield return IMDBParser;
                yield return WikiParser;
                // TODO: Add more parsers here
            }
        }

        /// <summary>
        /// Attempt to determine as much as possible about the show from it's filename using regex strings.
        /// </summary>
        /// <param name="mediaItem">The mediaItem we're trying to update.</param>
        /// <returns>A modified copy of the mediaItem.</returns>
        public MediaItems.TVShowItem FileNameParser(MediaItems.TVShowItem mediaItem)
        {
            // Attempt to match the file to the Season##Episode## pattern
            Match match = Regex.Match(mediaItem.Title, @"Season\s+(\d{1,2})\s+Episode\s+(\d{1,2})", RegexOptions.IgnoreCase);

            // Attempt to match the file to the S##E## pattern
            if (!match.Success)
                match = Regex.Match(mediaItem.Title, @"S(\d{1,2})E(\d{1,2})", RegexOptions.IgnoreCase);

            // Attempt to match the file to the ##x## or ##_## patterns
            if (!match.Success)
                match = Regex.Match(mediaItem.Title, @"(\d{1,2})[x_.](\d{1,2})", RegexOptions.IgnoreCase);

            // Attempt to match the file to the #### pattern that isn't in the 1900-2099 range
            if (!match.Success)
            {
                match = Regex.Match(mediaItem.Title, @"[^0-9x](\d{1,2})(\d{2})([^0-9p].+)?$", RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    Int32 value = Int32.Parse(match.Groups[1].Value) * 100 + Int32.Parse(match.Groups[2].Value);

                    if ((1900 <= value && value <= 2099 && value != 1080 && value != 264 && value != 720) || (mediaItem.Season > 0) && (mediaItem.Episode > 0))
                        match = Regex.Match("a", "b");
                }
            }

            // Set the Season and Episode if found
            if (match.Success)
            {
                mediaItem.Season = Int32.Parse(match.Groups[1].Value);
                mediaItem.Episode = Int32.Parse(match.Groups[2].Value);

                mediaItem.IsDirty = true;
            }

            // Attempt to match the file to an existing TV Series
            if (String.IsNullOrWhiteSpace(mediaItem.Show))
            {
                String localSeries = String.Format(".{0}.", Regex.Replace(mediaItem.Title ?? String.Empty, "[^a-z]", ".", RegexOptions.IgnoreCase).ToLowerInvariant());

                mediaItem.Show = (from tvSeries in DataSources.ITunesSource.Instance.AllSeries
                                    let remoteSeries = String.Format(".{0}.", Regex.Replace(tvSeries, "[^a-z]", ".", RegexOptions.IgnoreCase).ToLowerInvariant())
                                    where localSeries.Contains(remoteSeries)
                                    select tvSeries).FirstOrDefault<String>();

                mediaItem.IsDirty |= !String.IsNullOrWhiteSpace(mediaItem.Show);
            }

            return mediaItem;
        }

        /// <summary>
        /// Attempt to determine as much as possible about the show from it's metadata using regex strings.
        /// </summary>
        /// <param name="mediaItem">The mediaItem we're trying to update.</param>
        /// <returns>A modified copy of the mediaItem.</returns>
        public MediaItems.TVShowItem MetaDataParser(MediaItems.TVShowItem mediaItem)
        {
            Match match = Regex.Match(mediaItem.LocalTrack.EpisodeID ?? "", @"S(\d+)E(\d+)", RegexOptions.IgnoreCase);

            if (match.Success)
            {
                mediaItem.Season = Int32.Parse(match.Groups[1].Value);
                mediaItem.Episode = Int32.Parse(match.Groups[2].Value);
            }

            return mediaItem;
        }

        /// <summary>
        /// Attempt to lookup TVDB data about a TVShow
        /// </summary>
        /// <param name="mediaItem">The mediaItem we're trying to update.</param>
        /// <returns>A modified copy of the mediaItem.</returns>
        public MediaItems.TVShowItem TVDBParser(MediaItems.TVShowItem mediaItem)
        {
            if (String.IsNullOrWhiteSpace(mediaItem.IMDB_ID))
            {
                DataSources.TVDBSource.TVDBData tvdbData = DataSources.TVDBSource.Instance[mediaItem.IMDB_ID];

                if (tvdbData != null)
                {
                    mediaItem.IMDB_ID = tvdbData.IMDB_ID;

                    // TODO: Implement TVDB lookups

                    mediaItem.IsDirty |= true;
                }
            }

            return mediaItem;
        }

        /// <summary>
        /// Attempt to lookup IMDB data about a TVShow
        /// </summary>
        /// <param name="mediaItem">The mediaItem we're trying to update.</param>
        /// <returns>A modified copy of the mediaItem.</returns>
        public MediaItems.TVShowItem IMDBParser(MediaItems.TVShowItem mediaItem)
        {
            if (mediaItem.Year < 1990)
                mediaItem.Year = null;

            if (String.IsNullOrWhiteSpace(mediaItem.IMDB_ID))
            {
                IMDBAPISource.IMDBData searchAPI = DataSources.IMDBAPISource.Instance[mediaItem.Show, mediaItem.Year];

                if (searchAPI != null && !String.IsNullOrWhiteSpace(searchAPI.title))
                    mediaItem.IMDB_ID = searchAPI.IMDB_ID;
            }

            if (!String.IsNullOrWhiteSpace(mediaItem.IMDB_ID))
            {
                imdbTVSource imdbItem = imdbTVSource.Instance[mediaItem.IMDB_ID, mediaItem.Season, mediaItem.Episode];

                mediaItem.Title = imdbItem.Name;
                mediaItem.Year = imdbItem.Year;
                mediaItem.Description = imdbItem.Description;
                mediaItem.ImageURL = imdbItem.ImageURL;

                if (imdbItem.Genres.Count > 0)
                    mediaItem.Genre = imdbItem.Genres[0];

                mediaItem.Cast = String.Join(", ", imdbItem.Cast);
                mediaItem.Director = String.Join(", ", imdbItem.Directors);
                mediaItem.Writers = String.Join(", ", imdbItem.Writers);
                mediaItem.Grouping = String.Join(", ", imdbItem.Genres);

                mediaItem.EpisodeID = imdbItem.EpisodeID;
                if (imdbItem.AirDate != String.Empty) mediaItem.AirDate = DateTime.Parse(imdbItem.AirDate);
                
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

                mediaItem.IsDirty |= true;
            }

            return mediaItem;
        }

        /// <summary>
        /// Attempt to lookup Wikipedia data about a TVShow
        /// </summary>
        /// <param name="mediaItem">The mediaItem we're trying to update.</param>
        /// <returns>A modified copy of the mediaItem.</returns>
        public MediaItems.TVShowItem WikiParser(MediaItems.TVShowItem mediaItem)
        {
            // TODO: Implement Wikipedia lookups

            return mediaItem;
        }
    }
}