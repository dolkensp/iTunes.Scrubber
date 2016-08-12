using System;

namespace iTunes.Scrubber
{
    public abstract class Delegates
    {
        /// <summary>
        /// Attempt to convert a string / filename into media data for the specified mediaItem.
        /// </summary>
        /// <typeparam name="T">The type of the mediaItem.</typeparam>
        /// <param name="mediaItem">The mediaItem we're trying to update.</param>
        /// <returns>A modified copy of the mediaItem.</returns>
        public delegate T Parser<T>(T mediaItem) where T : Interfaces.IMediaItem;

        /// <summary>
        /// Check to see if a specified mediaItem meets pre-defined criteria.
        /// </summary>
        /// <typeparam name="T">The type of the mediaItem/</typeparam>
        /// <param name="mediaItem">The mediaItem we're trying to check.</param>
        /// <returns>True if the mediaItem meets the pre-defined criteria. False otherwise.</returns>
        public delegate Boolean Filter<T>(T mediaItem) where T : Interfaces.IMediaItem;

        /// <summary>
        /// Generate a sortable hashcode for a specified mediaItem.
        /// </summary>
        /// <typeparam name="T">The type of the mediaItem/</typeparam>
        /// <param name="mediaItem">The mediaItem we're trying to sort.</param>
        /// <returns>A sortable hashcode for the specified mediaItem.</returns>
        public delegate Object Sorter<T>(T mediaItem) where T : Interfaces.IMediaItem;

        /// <summary>
        /// Attempt to convert a mediaItem into something more search-friendly.
        /// </summary>
        /// <typeparam name="T">The type of the mediaItem/</typeparam>
        /// <param name="mediaItem">The mediaItem we're trying to sort.</param>
        /// <returns>A sortable hashcode for the specified mediaItem.</returns>
        public delegate T Transformer<T>(T mediaItem) where T : Interfaces.IMediaItem;
    }
}
