using System;

namespace iTunes.Scrubber.MediaItems
{
    public class MusicItem : BaseClasses.MediaBase<MusicItem>
    {
        public override MusicItem UpdateMetaData(libmp4v2.MP4Tags tags)
        {
            throw new NotImplementedException();
        }
    }
}
