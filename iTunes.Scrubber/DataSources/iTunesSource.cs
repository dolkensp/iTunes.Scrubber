using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;
using iTunesLib;
using System.Text.RegularExpressions;

namespace iTunes.Scrubber.DataSources
{
    public class ITunesSource : BaseClasses.SingletonBase<ITunesSource>, Interfaces.IDataSource
    {
        private iTunesApp _iTunes;
        private XmlDocument _library;

        public ITunesSource()
        {
            Console.WriteLine("Loading iTunes XML Library");
            this._iTunes = new iTunesApp();
            this._library = new XmlDocument();
            this._library.Load(this._iTunes.LibraryXMLPath);
        }

        public void Dispose()
        {
            Marshal.ReleaseComObject(this._iTunes);
            this._iTunes = null;
            GC.Collect();
        }

        /// <summary>
        /// Force DataSource to initialize track collections.
        /// </summary>
        public void Initialize()
        {
            this._tracks = this.Tracks;
            this._xmlTracks = this.XMLTracks;
        }

        /// <summary>
        /// Force DataSource to re-initialize track collections.
        /// </summary>
        public void Reset()
        {
            this._tracks = null;
            this._xmlTracks = null;
        }

        internal IEnumerable<T> GetMedia<T>(Delegates.Filter<T> filter = null, Delegates.Sorter<T> sorter = null) where T : BaseClasses.MediaBase
        {
            return (from remoteTrack in this.Tracks.Values.AsParallel()
                    let localTrack     = remoteTrack as T
                    where localTrack  != null
                    where (filter     == null) || filter(localTrack)
                    orderby sorter    == null ? localTrack as BaseClasses.MediaBase : sorter(localTrack)
                    select localTrack);
        }

        internal IEnumerable<String> AllSeries
        {
            get
            {
                return (from track in this.Tracks.Values.AsParallel()
                        let tvShow = track as MediaItems.TVShowItem
                        where tvShow != null
                        where !String.IsNullOrWhiteSpace(tvShow.Show)
                        select tvShow.Show).Distinct<String>();
            }
        }

        private Dictionary<UInt64, BaseClasses.MediaBase> _tracks;
        private Dictionary<UInt64, BaseClasses.MediaBase> Tracks
        {
            get
            {
                this._tracks = this._tracks ?? (from IITTrack remoteTrack in this._iTunes.LibraryPlaylist.Tracks.AsParallel()
                                                let localTrack    = this.GetTrack(remoteTrack)
                                                where localTrack != null
                                                select localTrack).ToDictionary<BaseClasses.MediaBase, UInt64>(track => track.PersistentID);
                
                return this._tracks;
            }
        }

        private Dictionary<UInt64, XmlTrack> _xmlTracks;
        private Dictionary<UInt64, XmlTrack> XMLTracks
        {
            get
            {
                this._xmlTracks = this._xmlTracks ?? (from XmlNode node in this._library.SelectNodes("plist/dict/dict/dict[key='Persistent ID']").AsParallel()
                                                      let videoWidth = node.SelectSingleNode("./key[text() = 'Video Width']/following-sibling::integer[position()=1]")
                                                      let videoHeight = node.SelectSingleNode("./key[text() = 'Video Height']/following-sibling::integer[position()=1]")
                                                      let persistentId = node.SelectSingleNode("./key[text() = 'Persistent ID']/following-sibling::string[position()=1]")
                                                      let isTVShow = node.SelectSingleNode("./key[text() = 'TV Show']")
                                                      let isMovie = node.SelectSingleNode("./key[text() = 'Movie']")
                                                      let isMusicVideo = node.SelectSingleNode("./key[text() = 'Music Video']")
                                                      let track = new XmlTrack()
                                                      {
                                                          VideoHeight      = videoHeight != null ? Int32.Parse(videoHeight.InnerXml) : null as Int32?,
                                                          VideoWidth       = videoWidth != null ? Int32.Parse(videoWidth.InnerXml) : null as Int32?,
                                                          IsTVShow         = (isTVShow != null),
                                                          IsMovie          = (isMovie != null),
                                                          IsMusicVideo     = (isMusicVideo != null),
                                                          PersistentID     = Convert.ToUInt64(persistentId.InnerXml, 16)
                                                      }
                                                      select track).ToDictionary<XmlTrack, UInt64>(track => track.PersistentID);

                return this._xmlTracks;
            }
        }

        internal IEnumerable<Int32> AllSeasons(String series)
        {
            return (from track in this.Tracks.Values.AsParallel()
                    let tvShow = track as MediaItems.TVShowItem
                    where tvShow != null
                    where !String.IsNullOrWhiteSpace(tvShow.Show)
                    where tvShow.Show == series
                    where tvShow.Season.HasValue
                    select tvShow.Season.Value).Distinct<Int32>();
        }

        private BaseClasses.MediaBase GetTrack(IITTrack track)
        {
            BaseClasses.MediaBase mediaItem = null;

            IITFileOrCDTrack localTrack = (track as IITFileOrCDTrack);

            UInt64 persistentId = ((UInt64)this._iTunes.get_ITObjectPersistentIDHigh(track) << 32) + (UInt32)this._iTunes.get_ITObjectPersistentIDLow(track);

            if (localTrack != null)
            {
                XmlTrack xmlTrack = null;

                this.XMLTracks.TryGetValue(persistentId, out xmlTrack);

                String name = localTrack.Name;

                if (xmlTrack != null)
                    if (xmlTrack.IsTVShow)
                    {
                        mediaItem = new MediaItems.TVShowItem()
                        {
                            IMDB_ID = localTrack.EpisodeID ?? String.Empty,
                            MediaKind = Enums.MediaKindEnum.TVShow,
                            Season = localTrack.SeasonNumber,
                            Show = localTrack.Show,
                            Episode = localTrack.EpisodeNumber,
                            Description = localTrack.Description,
                            Quality = xmlTrack.VideoWidth >= 1900 ? Enums.QualityEnum.HD_1080 : (
                                          xmlTrack.VideoWidth >= 1200 ? Enums.QualityEnum.HD_720 :
                                          Enums.QualityEnum.SD)
                            // TODO: Fill TV Show metadata
                        };
                        if (!String.IsNullOrWhiteSpace(localTrack.Comment))
                        {
                            Match match = Regex.Match(localTrack.Comment, @"Series: (tt\d+)\s+Episode: (tt\d+)\s+AirDate: (\d{1,2} .*? \d{4})", RegexOptions.Multiline);
                            if (match.Success)
                            {
                                ((MediaItems.TVShowItem)mediaItem).IMDB_ID = match.Groups[1].Value;
                                ((MediaItems.TVShowItem)mediaItem).EpisodeID = match.Groups[2].Value;
                                // TODO: Enable airdate support
                                // ((MediaItems.TVShowItem)mediaItem).AirDate = DateTime.Parse(match.Groups[3].Value);
                            }
                        }
                    }
                    else if (xmlTrack.IsMovie)
                        mediaItem = new MediaItems.MovieItem()
                        {
                            IMDB_ID = localTrack.EpisodeID ?? String.Empty,
                            MediaKind = Enums.MediaKindEnum.Movie,
                            Quality = xmlTrack.VideoWidth >= 1900 ? Enums.QualityEnum.HD_1080 : (
                                        xmlTrack.VideoWidth >= 1200 ? Enums.QualityEnum.HD_720 :
                                        Enums.QualityEnum.SD)
                            // TODO: Fill Movie metadata
                        };
                    else if (xmlTrack.IsMusicVideo)
                        mediaItem = new MediaItems.MusicVideoItem()
                        {
                            MediaKind = Enums.MediaKindEnum.MusicVideo,
                            Quality = xmlTrack.VideoWidth >= 1900 ? Enums.QualityEnum.HD_1080 : (
                                        xmlTrack.VideoWidth >= 1200 ? Enums.QualityEnum.HD_720 :
                                        Enums.QualityEnum.SD)
                            // TODO: Fill Music Video metadata
                        };
                    else
                        switch (localTrack.KindAsString)
                        {
                            case "Apple Lossless audio file":
                            case "MPEG audio file":
                                mediaItem = new MediaItems.MusicItem()
                                {
                                    MediaKind = Enums.MediaKindEnum.Music,
                                    // TODO: Fill Music metadata
                                };
                                break;
                        }
            
                if (mediaItem != null)
                {
                    mediaItem.PersistentID = persistentId;
                    mediaItem.Location     = localTrack.Location;
                    mediaItem.Comments     = localTrack.Comment;
                    mediaItem.DateAdded    = localTrack.DateAdded;
                    mediaItem.DateModified = localTrack.ModificationDate;
                    mediaItem.Genre        = localTrack.Genre;
                    mediaItem.Title        = localTrack.Name;
                    mediaItem.Year         = localTrack.Year;
                }
            }

            return mediaItem;
        }

        private class XmlTrack
        {
            public Int32 TrackID { get; set; }
            public UInt64 PersistentID { get; set; }
            public Int32? VideoWidth { get; set; }
            public Int32? VideoHeight { get; set; }
            public Boolean IsTVShow { get; set; }
            public Boolean IsMovie { get; set; }
            public Boolean IsMusicVideo { get; set; }
        }

        public IITTrack GetTrackByPersistentID(UInt64 persistentID)
        {
            return this._iTunes.LibraryPlaylist.Tracks.get_ItemByPersistentID((Int32)(persistentID >> 32), (Int32)(persistentID & 0xFFFFFFFF));
        }
    }
}
