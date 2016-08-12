using System;
using System.Collections.Generic;

namespace iTunes.Scrubber.Interfaces
{
    public interface IScrubber<T> : IDisposable where T : IMediaItem
    {
        IEnumerable<T> Clean(Delegates.Filter<T> filter = null, Delegates.Sorter<T> sorter = null);
    }
}
