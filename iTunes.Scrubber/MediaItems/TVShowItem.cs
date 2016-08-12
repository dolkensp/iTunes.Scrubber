using System;
using System.IO;
using iTunesLib;
using PInvoker.Marshal;
using System.Text;

namespace iTunes.Scrubber.MediaItems
{
    public class TVShowItem : BaseClasses.MediaBase<TVShowItem>
    {
        public DateTime? AirDate { get; set; }
        public String EpisodeID { get; set; }
        public String Show { get; set; }

        public Int32? Season { get; set; }
        public Int32? Episode { get; set; }

        public String Description { get; set; }
        public String ShortDescription
        {
            get
            {
                this.Description = this.Description ?? String.Empty;
                return this.Description.Substring(0, Math.Min(255, this.Description.Length));
            }
        }

        public String Cast { get; set; }
        public String Director { get; set; }
        public String Producer { get; set; }
        public String Writers { get; set; }
        public String Studio { get; set; }

        public String Grouping { get; set; }

        public Enums.QualityEnum Quality { get; set; }

        public override TVShowItem UpdateMetaData(libmp4v2.MP4Tags tags)
        {
            Console.WriteLine("Updating: {0}\r\n\t{1} {2:D2}x{3:D2} - {4}", this.Location, this.Show, this.Season, this.Episode, this.Title);

            // Set HD Flag
            libmp4v2.NativeFunctions.MP4TagsSetHDVideo(tags, (Byte)this.Quality);

            // Set More Genres
            libmp4v2.NativeFunctions.MP4TagsSetGrouping(tags, this.Grouping);

            // Set ShortDescription
            if (!String.IsNullOrWhiteSpace(this.ShortDescription))
                libmp4v2.NativeFunctions.MP4TagsSetDescription(tags, this.ShortDescription);

            // Set LongDescription
            if (!String.IsNullOrWhiteSpace(this.Description))
                libmp4v2.NativeFunctions.MP4TagsSetLongDescription(tags, this.Description);

            // Set Show
            if (!String.IsNullOrWhiteSpace(this.Show))
                libmp4v2.NativeFunctions.MP4TagsSetTVShow(tags, this.Show);

            // Set Season
            libmp4v2.NativeFunctions.MP4TagsSetTVSeason(tags, this.Season);

            // Set Episode
            libmp4v2.NativeFunctions.MP4TagsSetTVEpisode(tags, this.Episode);

            // TODO: Enabled this again
            // Update TV Flag
            // this.LocalTrack.VideoKind = ITVideoKind.ITVideoKindTVShow;

            // Set EpisodeID
            libmp4v2.NativeFunctions.MP4TagsSetTVEpisodeID(tags, String.Format("S{0:00}E{1:00}", this.Season, this.Episode));

            // Set Comments
            libmp4v2.NativeFunctions.MP4TagsSetComments(tags, String.Format("Series: {0}\r\nEpisode: {1}\r\nAirDate: {2:d MMMM yyyy}", this.IMDB_ID, this.EpisodeID, this.AirDate));

            // TODO: Enabled this again
            // Update TrackNo
            // if (this.Episode.HasValue)
            //     this.LocalTrack.TrackNumber = this.Episode.Value;

            return this;
        }

        public override TVShowItem UpdateMetaData(IntPtr fileHandle)
        {
            #region iTunMOVI

            String iTunes = this.CreateITUNAtom();

            libmp4v2.MP4ItmfItem itmf = libmp4v2.NativeFunctions.MP4ItmfItemAlloc("----", 1);
            itmf.mean = "com.apple.iTunes";
            itmf.name = "iTunMOVI";
            itmf.dataList.elements[0].typeSetIdentifier = 0;
            itmf.dataList.elements[0].typeCode = libmp4v2.MP4ItmfBasicType.MP4_ITMF_BT_UTF8;
            itmf.dataList.elements[0].locale = 0;
            itmf.dataList.elements[0].value = iTunes;
            itmf.dataList.elements[0].valueSize = (UInt32)iTunes.Length;
            
            libmp4v2.NativeFunctions.MP4ItmfAddItem(fileHandle, itmf);
            
            libmp4v2.NativeFunctions.MP4ItmfItemFree(itmf);

            #endregion

            return this;
        }

        public override Boolean UpdateITUNAtom(StringBuilder sb)
        {
            Boolean flag = false;

            if (!String.IsNullOrWhiteSpace(this.Cast))
            {
                CreatePartialAtom(sb, "cast", this.Cast);
                flag = true;
            }
            if (!String.IsNullOrWhiteSpace(this.Director))
            {
                flag = true;
                CreatePartialAtom(sb, "directors", this.Director);
            }
            if (!String.IsNullOrWhiteSpace(this.Producer))
            {
                flag = true;
                CreatePartialAtom(sb, "producers", this.Producer);
            }
            if (!String.IsNullOrWhiteSpace(this.Writers))
            {
                flag = true;
                CreatePartialAtom(sb, "screenwriters", this.Writers);
            }
            if (!String.IsNullOrWhiteSpace(this.Studio))
            {
                flag = true;
                myWriteElementString(sb, "key", "studio", false);
                myWriteElementString(sb, "string", this.Studio, false);
            }

            return flag;
        }
    }
}
