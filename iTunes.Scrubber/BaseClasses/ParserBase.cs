using System.Collections.Generic;
using System.Linq;

namespace iTunes.Scrubber.BaseClasses
{
    public abstract class ParserBase<T> : Interfaces.IParser<T>
        where T : MediaBase<T>, new()
    {
        /// <summary>
        /// Return an ordered IEnumerable of all parsers available for a specified content type
        /// </summary>
        public virtual IEnumerable<Delegates.Parser<T>> AllParsers
        {
            get { return Enumerable.Empty<Delegates.Parser<T>>(); }
        }

        /// <summary>
        /// Attempt to parse a mediaItem to provide more accurate details
        /// about the content it contains.
        /// </summary>
        /// <param name="mediaItem">The mediaItem to parse.</param>
        /// <returns>A modified copy of the mediaItem.</returns>
        public virtual T Parse(T mediaItem)
        {
            T parsedMedia = mediaItem;

            foreach (Delegates.Parser<T> parser in this.AllParsers)
                parsedMedia = parser(parsedMedia);

            return parsedMedia;
        }
    }
}
