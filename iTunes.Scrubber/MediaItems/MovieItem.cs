using System;
using System.Linq;
using System.IO;
using PInvoker.Marshal;
using System.Text;
using iTunesLib;
using System.Xml;
using Json = Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace iTunes.Scrubber.MediaItems
{
    public class MovieItem : BaseClasses.MediaBase<MovieItem>
    {
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

        public override MovieItem UpdateMetaData(libmp4v2.MP4Tags tags)
        {
            Console.WriteLine("Updating: {0}\r\n\t[{2}] {1} - ({4}) {3}", this.Location, this.Title, this.Year, this.Genre, this.FriendlyRating);

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

            return this;
        }

        public override MovieItem UpdateMetaData(IntPtr fileHandle)
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