namespace libmp4v2.Internal
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=8)]
    public struct MP4Tags_s
    {
        public IntPtr __handle;
        public IntPtr name;
        public IntPtr artist;
        public IntPtr albumArtist;
        public IntPtr album;
        public IntPtr grouping;
        public IntPtr composer;
        public IntPtr comments;
        public IntPtr genre;
        public IntPtr genreType;
        public IntPtr releaseDate;
        public IntPtr track;
        public IntPtr disk;
        public IntPtr tempo;
        public IntPtr compilation;
        public IntPtr tvShow;
        public IntPtr tvNetwork;
        public IntPtr tvEpisodeID;
        public IntPtr tvSeason;
        public IntPtr tvEpisode;
        public IntPtr description;
        public IntPtr longDescription;
        public IntPtr lyrics;
        public IntPtr sortName;
        public IntPtr sortArtist;
        public IntPtr sortAlbumArtist;
        public IntPtr sortAlbum;
        public IntPtr sortComposer;
        public IntPtr sortTVShow;
        public IntPtr artwork;
        public int artworkCount;
        public IntPtr copyright;
        public IntPtr encodingTool;
        public IntPtr encodedBy;
        public IntPtr purchaseDate;
        public IntPtr podcast;
        public IntPtr keywords;
        public IntPtr category;
        public IntPtr hdVideo;
        public IntPtr mediaType;
        public IntPtr contentRating;
        public IntPtr gapless;
        public IntPtr iTunesAccount;
        public IntPtr iTunesAccountType;
        public IntPtr iTunesCountry;
        public IntPtr contentID;
        public IntPtr artistID;
        public IntPtr playlistID;
        public IntPtr genreID;
        public IntPtr composerID;
        public IntPtr xid;
    }
}

