using System;

namespace iTunes.Scrubber
{
    public static partial class Sorters<T> where T : BaseClasses.MediaBase<T>
    {
        /// <summary>
        /// Sort items based on the title of the mediaItem.
        /// </summary>
        public static Delegates.Sorter<T> TitleSorter { get { return (T mediaItem) => mediaItem.Title; } }

        /// <summary>
        /// Sort items based on the modified date of the mediaItem.
        /// </summary>
        public static Delegates.Sorter<T> DateModfiedSorter { get { return (T mediaItem) => mediaItem.DateModified; } }

        /// <summary>
        /// Sort items based on the added date of the mediaItem.
        /// </summary>
        public static Delegates.Sorter<T> DateAddedSorter { get { return (T mediaItem) => mediaItem.DateAdded; } }
    }
}
