using System;
using System.Runtime.InteropServices;
using PInvoker.Marshal;

namespace iTunes.Scrubber
{
    public static class libmp4v2
    {
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4Close(IntPtr file);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4LogSetLevel(int logLevel);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern IntPtr MP4Modify(string filename, int verbosity, int flags);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern bool MP4Optimize(string filename, string newname, int verbosity);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern IntPtr MP4Read(string filename);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsRemoveArtwork(IntPtr tags, int flags);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetAlbum(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetAlbumArtist(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetArtist(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetCategory(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetComments(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetCompilation(IntPtr tags, ref byte id);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetContentID(IntPtr tags, ref int id);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetContentRating(IntPtr tags, ref byte id);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetCopyright(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetDescription(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetDisk(IntPtr tags, ref trackDisk id);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetEncodingTool(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetGapless(IntPtr tags, ref byte id);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetGenre(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetGrouping(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetHDVideo(IntPtr tags, ref byte id);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetKeywords(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetLongDescription(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetMediaType(IntPtr tags, ref byte id);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetName(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetPodcast(IntPtr tags, ref byte id);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetReleaseDate(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetSortAlbum(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetSortAlbumArtist(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetSortArtist(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetSortName(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetSortTVShow(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetTrack(IntPtr tags, ref trackDisk id);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetTVEpisode(IntPtr tags, ref int id);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetTVEpisodeID(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetTVNetwork(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetTVSeason(IntPtr tags, ref int id);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsSetTVShow(IntPtr tags, string name);
        [DllImport("libmp4v2.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void MP4TagsStore(IntPtr tags, IntPtr file);
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void VBMP4ClearCompilation();
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void VBMP4ClearContentRating();
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void VBMP4ClearGapless();
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void VBMP4ClearPodcast();
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void VBMP4FreeChapterData();
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern string VBMP4GetChapterData(IntPtr file);
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void VBMP4GetChapterInfo(IntPtr file, ref ChapterInfo ci);
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern int VBMP4GetCoverArt(byte[] buff);
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern bool VBMP4SetChapterData(IntPtr file, string[] ci, long[] dur, int numChaps);
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void VBMP4SetCoverArt(byte[] buff, int len);
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern int VBMP4SetDebugLevel(int dl);
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void VBMP4SetKind(byte[] buff, IntPtr file);
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void VBMP4SetMOVI(byte[] buff, IntPtr file);
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void VBMP4SetRating(byte[] buff, IntPtr file);
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern IntPtr VBMP4TagsAlloc();
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void VBMP4TagsFetch(ref MP4Tags vb, IntPtr file);
        [DllImport("MP4V2VBWrapper.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern void VBMP4TagsFree(ref MP4Tags vb);

        [StructLayout(LayoutKind.Sequential)]
        public struct trackDisk
        {
            public short index;
            public short total;
        }

        //[StructLayout(LayoutKind.Sequential)]
        //internal struct VBChapterData : IComparable
        //{
        //    internal int number;
        //    internal string title;
        //    internal TimeSpan duration;
        //    public int CompareTo(object x)
        //    {
        //        Global.chapterData data = (Global.chapterData)x;
        //        if (this.number > data.number)
        //        {
        //            return 1;
        //        }
        //        if (this.number < data.number)
        //        {
        //            return -1;
        //        }
        //        return 0;
        //    }
        //}

        [StructLayout(LayoutKind.Sequential)]
        public struct ChapterInfo
        {
            public int numSamples;
            public int timeScale;
            public long duration;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Chapters
        {
            public int numSamples;
            public int timeScale;
            public long movieDuration;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MP4Tags
        {
            public string name;
            public string artist;
            public string albumArtist;
            public string album;
            public string grouping;
            public string comment;
            public string genre;
            public string releaseDate;
            public string kind;
            public libmp4v2.trackDisk track;
            public libmp4v2.trackDisk disk;
            public byte compilation;
            public byte advisory;
            public string tvShow;
            public string tvNetwork;
            public string tvEpisodeID;
            public int tvSeason;
            public int tvEpisode;
            public string description;
            public string longDescription;
            public string contentRating;
            public string MOVI;
            public string sortName;
            public string sortArtist;
            public string sortAlbumArtist;
            public string sortAlbum;
            public string sortTVShow;
            public string copyright;
            public string encodingTool;
            public byte podcast;
            public string keywords;
            public string category;
            public byte gapless;
            public byte HD;
            public int ContentID;
        }
    }
}