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
        public static Delegates.Filter<T> TimeSpanFilter(TimeSpan timeSpan) { return (T mediaItem) => (DateTime.Now - (mediaItem.DateModified ?? DateTime.Now)) < timeSpan || (DateTime.Now - (mediaItem.DateAdded ?? DateTime.Now)) < timeSpan; }
        
        /// <summary>
        /// Filter items to only show items modified on a certain date.
        /// </summary>
        /// <param name="date">The date to filter by.</param>
        /// <returns>True if an item was modified on the specified date.</returns>
        public static Delegates.Filter<T> DateModfiedFilter(DateTime date) { return (T mediaItem) => (mediaItem.DateModified ?? DateTime.Now).Date == date.Date; }

        /// <summary>
        /// Filter items to only show items aded on a certain date.
        /// </summary>
        /// <param name="date">The date to filter by.</param>
        /// <returns>True if an item was added on the specified date.</returns>
        public static Delegates.Filter<T> DateAddedFilter(DateTime date) { return (T mediaItem) => (mediaItem.DateAdded ?? DateTime.Now).Date == date.Date; }

        /// <summary>
        /// Combines filters with AND logic.
        /// </summary>
        /// <param name="filters">The list of filters to apply</param>
        /// <returns>True if all filter are true.</returns>
        public static Delegates.Filter<T> And(params Delegates.Filter<T>[] filters)
        {
            return (T mediaItem) =>
            {
                Boolean result = false;

                foreach (Delegates.Filter<T> filter in filters)
                    result &= filter(mediaItem);

                return result;
            };
        }

        /// <summary>
        /// Combines filters with OR logic.
        /// </summary>
        /// <param name="filters">The list of filters to apply</param>
        /// <returns>True if any filter is true.</returns>
        public static Delegates.Filter<T> Or(params Delegates.Filter<T>[] filters)
        {
            return (T mediaItem) =>
            {
                Boolean result = false;

                foreach (Delegates.Filter<T> filter in filters)
                    result |= filter(mediaItem);

                return result;
            };
        }
    }
}
