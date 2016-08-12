using System;
using System.Text.RegularExpressions;

namespace iTunes.Scrubber
{
    public static partial class Filters<T> where T : Interfaces.IMediaItem
    {
        /// <summary>
        /// Filter items to only show items with IMDB_ID set.
        /// </summary>
        /// <param name="result">The result to return if the IMDB_ID is set.</param>
        /// <returns>result if IMDB_ID is set, or !result otherwise</returns>
        public static Delegates.Filter<MediaItems.MovieItem> CompleteMetaFilter_Movie(Boolean result = true) { return (MediaItems.MovieItem mediaItem) => Regex.Match(mediaItem.IMDB_ID, @"tt\d+", RegexOptions.IgnoreCase).Success ? result : !result; }
    }
}
