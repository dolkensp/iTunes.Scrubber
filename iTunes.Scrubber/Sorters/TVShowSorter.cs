using System;

namespace iTunes.Scrubber
{
    public static partial class Sorters<T> where T : BaseClasses.MediaBase<T>
    {
        /// <summary>
        /// Sort items based on the Show Season Episode of the tvShow.
        /// </summary>
        public static Delegates.Sorter<MediaItems.TVShowItem> ShowSorter { get { return (MediaItems.TVShowItem tvShow) => String.Format("{0} [{1:D2}x{2:D2}]", tvShow.Show, tvShow.Season ?? 0, tvShow.Episode ?? 0); } }
    }
}
