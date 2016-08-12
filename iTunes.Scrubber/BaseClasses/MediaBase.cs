using System;
using System.Collections.Generic;
using iTunesLib;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using PInvoker.Marshal;
// using Newtonsoft.Json;
using System.Xml;
using System.Text.RegularExpressions;

namespace iTunes.Scrubber.BaseClasses
{
    public abstract class MediaBase : Interfaces.IMediaItem, IComparable, IComparable<MediaBase>, IComparer<MediaBase>
    {
        public IITFileOrCDTrack LocalTrack { get { return DataSources.ITunesSource.Instance.GetTrackByPersistentID(this.PersistentID) as IITFileOrCDTrack; } }

        public UInt64 PersistentID { get; set; }

        private String _imdb_id;
        public String IMDB_ID
        {
            get { return this._imdb_id; }
            set
            {
                if (Regex.IsMatch(value, @"tt\d+"))
                    this._imdb_id = value;
            }
        }

        public Int32? Year { get; set; }

        public String Location { get; set; }

        public String Rating { get; set; }

        public String FriendlyRating
        {
            get
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(this.Rating))
                        return String.Empty;

                    return this.Rating.Split('|')[1];
                }
                catch (Exception)
                {
                    return "Unknown";
                }
            }
        }

        public String Title { get; set; }
        public String Comments { get; set; }
        public String Genre { get; set; }

        public String ImageURL { get; set; }

        public Enums.MediaKindEnum MediaKind { get; set; }

        public DateTime? DateModified { get; set; }
        public DateTime? DateAdded { get; set; }

        private Boolean _isDirty = false;
        public Boolean IsDirty { get { return this._isDirty; } set { this._isDirty = value; } }

        #region IComparable and IComparer Implementation

        public Int32 CompareTo(MediaBase other) { return this.PersistentID.CompareTo(other.PersistentID); }

        public Int32 Compare(MediaBase x, MediaBase y) { return x.PersistentID.CompareTo(y.PersistentID); }

        public Int32 CompareTo(Object obj) { return this.PersistentID.CompareTo((obj as MediaBase).PersistentID); }

        #endregion

        public override string ToString()
        {
            return String.Format("[{1}] {2}{0}", this.Title, Enum.GetName(typeof(Enums.MediaKindEnum), this.MediaKind), this.IsDirty ? "+" : "-");
        }

        /*
        internal static Enums.MediaKindEnum GetKind<T>() where T : IMediaItem
        {
            if (typeof(T) == typeof(TVShowItem))
                return Enums.MediaKindEnum.TVShow;
            if (typeof(T) == typeof(MovieItem))
                return Enums.MediaKindEnum.Movie;
            if (typeof(T) == typeof(MusicItem))
                return Enums.MediaKindEnum.Music;
            if (typeof(T) == typeof(MusicVideoItem))
                return Enums.MediaKindEnum.MusicVideo;
            return Enums.MediaKindEnum.None;
        }
        */
    }

    public abstract class MediaBase<T> : MediaBase where T : MediaBase<T>
    {
        public abstract T UpdateMetaData(libmp4v2.MP4Tags tagsHandle);

        public virtual T UpdateMetaData(IntPtr fileHandle) { return (T)this; }

        public T UpdateMetaData()
        {
            if (Constants.NOCHANGES || !this.IsDirty)
            {
                Console.WriteLine("Stubbing: {0}\r\n\t[{2}] {1} - ({4}) {3} {5}", this.Location, this.Title, this.Year, this.Genre, this.FriendlyRating, this.IMDB_ID);

                return (T)this;
            }

            if (this is MediaItems.TVShowItem && (this as MediaItems.TVShowItem).Show == "Seinfeld")
            {
                Console.WriteLine("Skipping: {0}\r\n\t[{2}] {1} - ({4}) {3} {5}", this.Location, this.Title, this.Year, this.Genre, this.FriendlyRating, this.IMDB_ID);

                return (T)this;
            }

            try
            {
                MemoryStream stream = new MemoryStream();

                try
                {
                    // Get Handle To The Media File
                    IntPtr fileHandle = libmp4v2.NativeFunctions.MP4Modify(this.Location, 0);

                    if (fileHandle != new IntPtr(0))
                    {
                        // Allocate Memory For Tags Struct
                        libmp4v2.MP4Tags tagsHandle = libmp4v2.NativeFunctions.MP4TagsAlloc();

                        try
                        {
                            // Get Current Tags
                            libmp4v2.NativeFunctions.MP4TagsFetch(tagsHandle, fileHandle);

                            // Set Title
                            if (!String.IsNullOrWhiteSpace(this.Title))
                                libmp4v2.NativeFunctions.MP4TagsSetName(tagsHandle, this.Title);

                            // Store IMDB ID
                            libmp4v2.NativeFunctions.MP4TagsSetTVEpisodeID(tagsHandle, this.IMDB_ID);

                            // Set Explicit
                            libmp4v2.NativeFunctions.MP4TagsSetContentRating(tagsHandle, ((Char)0).ToString());

                            // Set Genre
                            if (!String.IsNullOrWhiteSpace(this.Genre))
                                libmp4v2.NativeFunctions.MP4TagsSetGenre(tagsHandle, this.Genre);

                            // Set Comments
                            if (!String.IsNullOrWhiteSpace(this.Comments))
                                libmp4v2.NativeFunctions.MP4TagsSetComments(tagsHandle, this.Comments);

                            // TODO: Enable this again
                            // Set Media Type
                            // libmp4v2.MP4TagsSetMediaType(tags, ((Char)Enums.MediaKindEnum.TVShow).ToString());
                            // libmp4v2.NativeFunctions.MP4TagsSetMediaType(tags, 

                            // Set the media-specific tags
                            this.UpdateMetaData(tagsHandle);

                            // Set Rating
                            if (String.IsNullOrWhiteSpace(this.Rating))
                                this.Rating = "au-movie|Unrated|???|This content is unrated";

                            // This is explicit / clean, not R+ etc
                            // libmp4v2.NativeFunctions.MP4TagsSetContentRating(tagsHandle, this.Rating);

                            if (this.LocalTrack.Artwork.Count < 1 || !Constants.CHANGEART)
                            {
                                // Remove Cover Art
                                libmp4v2.NativeFunctions.MP4TagsRemoveArtwork(tagsHandle, 0);

                                // Apply Cover Art
                                if (!String.IsNullOrWhiteSpace(this.ImageURL))
                                {
                                    Bitmap image = Helpers.FileHelper.HttpGetBitmap(this.ImageURL);

                                    if (image != null)
                                    {
                                        image.Save(stream, ImageFormat.Jpeg);
                                        byte[] buff = stream.GetBuffer();

                                        libmp4v2.NativeFunctions.MP4TagsAddArtwork(tagsHandle, new libmp4v2.MP4TagArtwork
                                        {
                                            size = (UInt32)buff.Length,
                                            type = libmp4v2.MP4TagArtworkType_e.MP4_ART_JPEG,
                                            data = new ByteArrayPtr(buff)
                                        });
                                    }
                                }
                            }

                            // Save The Tags
                            libmp4v2.NativeFunctions.MP4TagsStore(tagsHandle, fileHandle);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        // DeAllocate Tag Struct
                        libmp4v2.NativeFunctions.MP4TagsFree(tagsHandle);

                        #region Rating
                        
                        libmp4v2.MP4ItmfItem itmf = libmp4v2.NativeFunctions.MP4ItmfItemAlloc("----", 1);
                        itmf.mean = "com.apple.iTunes";
                        itmf.name = "iTunEXTC";
                        itmf.dataList.elements[0].typeSetIdentifier = 0;
                        itmf.dataList.elements[0].typeCode = libmp4v2.MP4ItmfBasicType.MP4_ITMF_BT_UTF8;
                        itmf.dataList.elements[0].locale = 0;
                        itmf.dataList.elements[0].value = this.Rating;
                        itmf.dataList.elements[0].valueSize = (UInt32)this.Rating.Length;
                        
                        libmp4v2.NativeFunctions.MP4ItmfAddItem(fileHandle, itmf);
                        
                        libmp4v2.NativeFunctions.MP4ItmfItemFree(itmf);
                        
                        #endregion

                        // Set the media-specific custom tags
                        this.UpdateMetaData(fileHandle);
                    }

                    // Close The File
                    libmp4v2.NativeFunctions.MP4Close(fileHandle, 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // Refresh iTunes
                this.LocalTrack.UpdateInfoFromFile();

                // Genre
                if (!String.IsNullOrWhiteSpace(this.Genre))
                    this.LocalTrack.Genre = this.Genre;

                // TODO: Enabled this again
                // Update TV Flag
                // this.LocalTrack.VideoKind = ITVideoKind.ITVideoKindTVShow;

                if (this.Year.HasValue)
                    this.LocalTrack.Year = this.Year.Value;

                this.IsDirty = false;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return (T)this;
        }

        internal Int32 tabDepth;
        internal string tabSource = "\t\t\t\t\t\t\t\t\t";

        internal string CreateITUNAtom()
        {
            bool flag = false;
            StringBuilder builder2 = new StringBuilder();
            StringWriterWithEncoding w = new StringWriterWithEncoding(builder2, Encoding.UTF8);
            XmlTextWriter writer = new XmlTextWriter(w);
            StringBuilder sb = new StringBuilder();
            writer.Formatting = Formatting.None;
            writer.IndentChar = '\t';
            writer.WriteStartDocument();
            writer.WriteRaw("\n");
            writer.WriteDocType("plist", "-//Apple//DTD PLIST 1.0//EN", "http://www.apple.com/DTDs/PropertyList-1.0.dtd", null);
            writer.WriteRaw("\n");
            writer.WriteStartElement("plist version=\"1.0\"");
            writer.WriteRaw("\n");
            writer.WriteStartElement("dict");
            writer.WriteRaw("\n");
            tabDepth = 1;

            flag |= this.UpdateITUNAtom(sb);

            writer.WriteRaw(sb.ToString());
            writer.WriteEndElement();
            writer.WriteRaw("\n");
            writer.WriteEndDocument();
            writer.WriteRaw("\n");
            writer.Close();
            string str2 = w.ToString();
            w.Close();
            str2 = str2.Replace("/plist version=\"1.0\"", "/plist").Replace("utf", "UTF");

            if (flag)
                return str2;

            return null;
        }

        public virtual Boolean UpdateITUNAtom(StringBuilder sb) {
            return false;
        }

        public class StringWriterWithEncoding : StringWriter
        {
            public System.Text.Encoding MyEncoding;

            public StringWriterWithEncoding(StringBuilder builder, System.Text.Encoding mye)
            {
                this.MyEncoding = mye;
            }

            public override System.Text.Encoding Encoding
            {
                get
                {
                    return this.MyEncoding;
                }
            }
        }

        internal void CreatePartialAtom(StringBuilder sb, string s, string names)
        {
            myWriteElementString(sb, "key", s, false);
            myWriteStartElement(sb, "array", true);
            foreach (string str in names.Split(new char[] { ',' }))
            {
                myWriteStartElement(sb, "dict", true);
                myWriteElementString(sb, "key", "name", false);
                myWriteElementString(sb, "string", str.Trim(), false);
                tabDepth--;
                myWriteEndElement(sb, "dict", false);
            }
            tabDepth--;
            myWriteEndElement(sb, "array", false);
        }

        internal void myWriteStartElement(StringBuilder sb, string name, bool addTab)
        {
            string str = "";
            if (tabDepth > 0)
            {
                str = tabSource.Substring(0, tabDepth);
            }
            if (addTab)
            {
                tabDepth++;
            }
            sb.Append(str + "<" + name + ">\n");
        }

        internal void myWriteElementString(StringBuilder sb, string name, string value, bool addTab)
        {
            string str = "";
            if (tabDepth > 0)
            {
                str = tabSource.Substring(0, tabDepth);
            }
            if (addTab)
            {
                tabDepth++;
            }
            sb.Append(str + "<" + name + ">" + value + "</" + name + ">\n");
        }

        internal void myWriteEndElement(StringBuilder sb, string name, bool removeTab)
        {
            string str = "";
            if (tabDepth > 0)
            {
                str = tabSource.Substring(0, tabDepth);
            }
            if (removeTab && (tabDepth > 0))
            {
                tabDepth--;
            }
            sb.Append(str + "</" + name + ">\n");
        }

    }
}