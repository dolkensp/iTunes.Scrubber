using System.Collections.Generic;

namespace iTunes.Scrubber.Interfaces
{
    public interface IParser<T> where T : IMediaItem
    {
        IEnumerable<Delegates.Parser<T>> AllParsers { get; }
        T Parse(T mediaItem);
    }
}
