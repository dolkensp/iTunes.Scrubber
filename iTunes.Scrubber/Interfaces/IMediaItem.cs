using System;
using iTunesLib;

namespace iTunes.Scrubber.Interfaces
{
    public interface IMediaItem
    {
        IITFileOrCDTrack LocalTrack { get; }

        UInt64 PersistentID { get; set; }

        String IMDB_ID { get; set; }

        Int32? Year { get; set; }

        String Location { get; set; }

        String Title { get; set; }
        String Comments { get; set; }
        String Genre { get; set; }

        Enums.MediaKindEnum MediaKind { get; set; }

        DateTime? DateModified { get; set; }
        DateTime? DateAdded { get; set; }
    }
}
