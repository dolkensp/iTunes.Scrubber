using System.Collections.Generic;
using System.Linq;

namespace iTunes.Scrubber.BaseClasses
{
    public abstract class ScrubberBase<U, T> : Interfaces.IScrubber<T>
        where T : MediaBase<T>, new()
        where U : class, Interfaces.IParser<T>, new()
    {
        public IEnumerable<T> GetMedia(Delegates.Filter<T> filter = null, Delegates.Sorter<T> sorter = null)
        {
            return (from mediaItem in DataSources.ITunesSource.Instance.GetMedia<T>(filter, sorter)
                    select mediaItem);
        }

        public IEnumerable<T> Clean(Delegates.Filter<T> filter = null, Delegates.Sorter<T> sorter = null)
        {
            IEnumerable<T> mediaItems = (from mediaItem in DataSources.ITunesSource.Instance.GetMedia<T>(filter, sorter)
                                         let parsedItem = SingletonBase<U>.Instance.Parse(mediaItem)
                                         where parsedItem.IsDirty
                                         select parsedItem.UpdateMetaData()).ToList<T>();

            return mediaItems;
        }

        public virtual void Dispose() { }
    }
}
