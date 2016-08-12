using System;
using System.Linq;

namespace iTunes.Scrubber
{
    public static partial class Filters<T> where T : Interfaces.IMediaItem
    {
        /// <summary>
        /// Filter items to only show items added or modified within the specified timespan.
        /// </summary>
        /// <param name="timeSpan">The timespan to filter by.</param>
        /// <returns>True if an item was added or modified within the specified timespan.</returns>
        public static Delegates.Filter<MediaItems.TVShowItem> SeriesFilter(params String[] series) { return (MediaItems.TVShowItem mediaItem) => series.Select<String, String>(s => s.ToLowerInvariant()).Contains<String>((mediaItem.Show ?? String.Empty).ToLowerInvariant()); }

        /// <summary>
        /// Filter items to only show items with complete Series, Season, Episode metadata.
        /// </summary>
        /// <param name="result">The result to return if all 3 fields are filled.</param>
        /// <returns>result if all 3 fields are filled, or !result otherwise</returns>
        public static Delegates.Filter<MediaItems.TVShowItem> CompleteMetaFilter_TV(Boolean result = true) { return (MediaItems.TVShowItem mediaItem) => (!String.IsNullOrWhiteSpace(mediaItem.Show) && mediaItem.Season.HasValue && mediaItem.Episode.HasValue) ? result : !result; }
    }
}
