using System;

namespace iTunes.Scrubber.MediaItems
{
    public class MusicVideoItem : BaseClasses.MediaBase<MusicVideoItem>
    {
        public Enums.QualityEnum Quality { get; set; }
        
        public override MusicVideoItem UpdateMetaData(libmp4v2.MP4Tags tags)
        {
            throw new NotImplementedException();
        }
    }
}
