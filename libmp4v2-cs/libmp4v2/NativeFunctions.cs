namespace libmp4v2
{
    using PInvoker.Marshal;
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public static class NativeFunctions
    {
        internal static class Imports
        {
            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddAC3AudioTrack([In] IntPtr hFile, [In] UInt32 samplingRate, [In] Byte fscod, [In] Byte bsid, [In] Byte bsmod, [In] Byte acmod, [In] Byte lfeon, [In] Byte bit_rate_code);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddALawAudioTrack([In] IntPtr hFile, [In] UInt32 timeScale);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddAmrAudioTrack([In] IntPtr hFile, [In] UInt32 timeScale, [In] UInt16 modeSet, [In] Byte modeChangePeriod, [In] Byte framesPerSample, [In, MarshalAs(UnmanagedType.I1)] bool isAmrWB);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddAudioTrack([In] IntPtr hFile, [In] UInt32 timeScale, [In] Int64 sampleDuration, [In] Byte audioType);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern void MP4AddChapter([In] IntPtr hFile, [In] Int32 chapterTrackId, [In] Int64 chapterDuration, [In] IntPtr chapterTitle);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddChapterTextTrack([In] IntPtr hFile, [In] Int32 refTrackId, [In] UInt32 timescale);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddColr([In] IntPtr hFile, [In] Int32 refTrackId, [In] UInt16 primary, [In] UInt16 transfer, [In] UInt16 matrix);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern Int32 MP4AddEncAudioTrack([In] IntPtr hFile, [In] UInt32 timeScale, [In] Int64 sampleDuration, [In] IntPtr icPp, [In] Byte audioType);
            
            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern Int32 MP4AddEncH264VideoTrack([In] IntPtr dstFile, [In] UInt32 timeScale, [In] Int64 sampleDuration, [In] UInt16 width, [In] UInt16 height, [In] IntPtr srcFile, [In] Int32 srcTrackId, [In] IntPtr icPp);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern Int32 MP4AddEncVideoTrack([In] IntPtr hFile, [In] UInt32 timeScale, [In] Int64 sampleDuration, [In] UInt16 width, [In] UInt16 height, [In] IntPtr icPp, [In] Byte videoType, [In] IntPtr oFormat);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddH263VideoTrack([In] IntPtr hFile, [In] UInt32 timeScale, [In] Int64 sampleDuration, [In] UInt16 width, [In] UInt16 height, [In] Byte h263Level, [In] Byte h263Profile, [In] UInt32 avgBitrate, [In] UInt32 maxBitrate);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern void MP4AddH264PictureParameterSet([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr pPict, [In] UInt16 pictLen);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern void MP4AddH264SequenceParameterSet([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr pSequence, [In] UInt16 sequenceLen);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddH264VideoTrack([In] IntPtr hFile, [In] UInt32 timeScale, [In] Int64 sampleDuration, [In] UInt16 width, [In] UInt16 height, [In] Byte AVCProfileIndication, [In] Byte profile_compat, [In] Byte AVCLevelIndication, [In] Byte sampleLenFieldSizeMinusOne);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddHintTrack([In] IntPtr hFile, [In] Int32 refTrackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern Int32 MP4AddHrefTrack([In] IntPtr hFile, [In] UInt32 timeScale, [In] Int64 sampleDuration, [In] IntPtr base_url);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4AddIPodUUID([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern void MP4AddNeroChapter([In] IntPtr hFile, [In] Int64 chapterStart, [In] IntPtr chapterTitle);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddODTrack([In] IntPtr hFile);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddPixelAspectRatio([In] IntPtr hFile, [In] Int32 refTrackId, [In] UInt32 hSpacing, [In] UInt32 vSpacing);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4AddRtpESConfigurationPacket([In] IntPtr hFile, [In] Int32 hintTrackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4AddRtpHint([In] IntPtr hFile, [In] Int32 hintTrackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4AddRtpImmediateData([In] IntPtr hFile, [In] Int32 hintTrackId, [In] IntPtr pSBytes, [In] UInt32 numSBytes);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4AddRtpPacket([In] IntPtr hFile, [In] Int32 hintTrackId, [In, MarshalAs(UnmanagedType.I1)] bool setMbit, [In] Int32 transmitOffset);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4AddRtpSampleData([In] IntPtr hFile, [In] Int32 hintTrackId, [In] Int32 sampleId, [In] UInt32 dataOffset, [In] UInt32 dataLength);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4AddRtpVideoHint([In] IntPtr hFile, [In] Int32 hintTrackId, [In, MarshalAs(UnmanagedType.I1)] bool isBframe, [In] UInt32 timestampOffset);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddSceneTrack([In] IntPtr hFile);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddSubpicTrack([In] IntPtr hFile, [In] UInt32 timescale, [In] UInt16 width, [In] UInt16 height);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddSubtitleTrack([In] IntPtr hFile, [In] UInt32 timescale, [In] UInt16 width, [In] UInt16 height);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern Int32 MP4AddSystemsTrack([In] IntPtr hFile, [In] IntPtr type);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddTextTrack([In] IntPtr hFile, [In] Int32 refTrackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern Int32 MP4AddTrack([In] IntPtr hFile, [In] IntPtr type, [In] UInt32 timeScale);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddTrackEdit([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 editId, [In] Int64 startTime, [In] Int64 duration, [In, MarshalAs(UnmanagedType.I1)] bool dwell);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddULawAudioTrack([In] IntPtr hFile, [In] UInt32 timeScale);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4AddVideoTrack([In] IntPtr hFile, [In] UInt32 timeScale, [In] Int64 sampleDuration, [In] UInt16 width, [In] UInt16 height, [In] Byte videoType);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4AppendHintTrackSdp([In] IntPtr hFile, [In] Int32 hintTrackId, [In] IntPtr sdpString);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4AppendSessionSdp([In] IntPtr hFile, [In] IntPtr sdpString);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4BinaryToBase16([In] IntPtr pData, [In] UInt32 dataSize);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4BinaryToBase64([In] IntPtr pData, [In] UInt32 dataSize);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern void MP4ChangeMovieTimeScale([In] IntPtr hFile, [In] UInt32 value);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4CloneTrack([In] IntPtr srcFile, [In] Int32 srcTrackId, [In] IntPtr dstFile, [In] Int32 dstHintTrackReferenceTrack);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern MP4ChapterType MP4ConvertChapters([In] IntPtr hFile, [In] MP4ChapterType toChapterType);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern UInt64 MP4ConvertFromMovieDuration([In] IntPtr hFile, [In] Int64 duration, [In] UInt32 timeScale);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern UInt64 MP4ConvertFromTrackDuration([In] IntPtr hFile, [In] Int32 trackId, [In] Int64 duration, [In] UInt32 timeScale);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern UInt64 MP4ConvertFromTrackTimestamp([In] IntPtr hFile, [In] Int32 trackId, [In] Int64 timeStamp, [In] UInt32 timeScale);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int64 MP4ConvertToTrackDuration([In] IntPtr hFile, [In] Int32 trackId, [In] UInt64 duration, [In] UInt32 timeScale);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int64 MP4ConvertToTrackTimestamp([In] IntPtr hFile, [In] Int32 trackId, [In] UInt64 timeStamp, [In] UInt32 timeScale);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4CopySample([In] IntPtr srcFile, [In] Int32 srcTrackId, [In] Int32 srcSampleId, [In] IntPtr dstFile, [In] Int32 dstTrackId, [In] Int64 dstSampleDuration);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4CopyTrack([In] IntPtr srcFile, [In] Int32 srcTrackId, [In] IntPtr dstFile, [In, MarshalAs(UnmanagedType.I1)] bool applyEdits, [In] Int32 dstHintTrackReferenceTrack);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4Create([In] IntPtr fileName, [In] UInt32 flags);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4CreateEx([In] IntPtr fileName, [In] UInt32 flags, [In] int add_ftyp, [In] int add_iods, [In] IntPtr majorBrand, [In] UInt32 minorVersion, [In] IntPtr compatibleBrands, [In] UInt32 compatibleBrandsCount);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4DefaultISMACrypParams([In] IntPtr ptr);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern MP4ChapterType MP4DeleteChapters([In] IntPtr hFile, [In] MP4ChapterType chapterType, [In] Int32 chapterTrackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4DeleteTrack([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4DeleteTrackEdit([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 editId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4Dump([In] IntPtr hFile, [In, MarshalAs(UnmanagedType.I1)] bool dumpImplicits);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern Int32 MP4EncAndCloneTrack([In] IntPtr srcFile, [In] Int32 srcTrackId, [In] IntPtr icPp, [In] IntPtr dstFile, [In] Int32 dstHintTrackReferenceTrack);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4FileInfo([In] IntPtr fileName, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern Int32 MP4FindTrackId([In] IntPtr hFile, [In] UInt16 index, [In] IntPtr type, [In] Byte subType);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern UInt16 MP4FindTrackIndex([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern void MP4Free([In] IntPtr p);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern UInt16 MP4GetAmrModeSet([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Byte MP4GetAudioProfileLevel([In] IntPtr hFile);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4GetFilename([In] IntPtr hFile);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetSBytesProperty([In] IntPtr hFile, [In] IntPtr propName, [In] IntPtr ppValue, [In] IntPtr pValueSize);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern MP4ChapterType MP4GetChapters([In] IntPtr hFile, [In] IntPtr chapterList, [In] IntPtr chapterCount, [In] MP4ChapterType chapterType);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int64 MP4GetDuration([In] IntPtr hFile);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetFloatProperty([In] IntPtr hFile, [In] IntPtr propName, [In] IntPtr retvalue);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Byte MP4GetGraphicsProfileLevel([In] IntPtr hFile);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4GetHintTrackReferenceTrackId([In] IntPtr hFile, [In] Int32 hintTrackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetHintTrackRtpPayload([In] IntPtr hFile, [In] Int32 hintTrackId, [In] IntPtr ppPayloadName, [In] IntPtr pPayloadNumber, [In] IntPtr pMaxPayloadSize, [In] IntPtr ppEncodingParams);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4GetHintTrackSdp([In] IntPtr hFile, [In] Int32 hintTrackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4GetHrefTrackBaseUrl([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetIntegerProperty([In] IntPtr hFile, [In] IntPtr propName, [In] IntPtr retval);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern UInt32 MP4GetNumberOfTracks([In] IntPtr hFile, [In] IntPtr type, [In] Byte subType);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Byte MP4GetODProfileLevel([In] IntPtr hFile);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern UInt16 MP4GetRtpHintNumberOfPackets([In] IntPtr hFile, [In] Int32 hintTrackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern SByte MP4GetRtpPacketBFrame([In] IntPtr hFile, [In] Int32 hintTrackId, [In] UInt16 packetIndex);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4GetRtpPacketTransmitOffset([In] IntPtr hFile, [In] Int32 hintTrackId, [In] UInt16 packetIndex);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int64 MP4GetRtpTimestampStart([In] IntPtr hFile, [In] Int32 hintTrackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int64 MP4GetSampleDuration([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 sampleId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern Int32 MP4GetSampleIdFromEditTime([In] IntPtr hFile, [In] Int32 trackId, [In] Int64 when, [In] IntPtr pStartTime, [In] IntPtr pDuration);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4GetSampleIdFromTime([In] IntPtr hFile, [In] Int32 trackId, [In] Int64 when, [In, MarshalAs(UnmanagedType.I1)] bool wantSyncSample);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int64 MP4GetSampleRenderingOffset([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 sampleId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern UInt32 MP4GetSampleSize([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 sampleId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern SByte MP4GetSampleSync([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 sampleId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int64 MP4GetSampleTime([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 sampleId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Byte MP4GetSceneProfileLevel([In] IntPtr hFile);
    
            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4GetSessionSdp([In] IntPtr hFile);
    
            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetStringProperty([In] IntPtr hFile, [In] IntPtr propName, [In] IntPtr retvalue);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern UInt32 MP4GetTimeScale([In] IntPtr hFile);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern int MP4GetTrackAudioChannels([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Byte MP4GetTrackAudioMpeg4Type([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern UInt32 MP4GetTrackBitRate([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetTrackSBytesProperty([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr propName, [In] IntPtr ppValue, [In] IntPtr pValueSize);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int64 MP4GetTrackDuration([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetTrackDurationPerChunk([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr duration);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int64 MP4GetTrackEditDuration([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 editId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern SByte MP4GetTrackEditDwell([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 editId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int64 MP4GetTrackEditMediaStart([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 editId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int64 MP4GetTrackEditTotalDuration([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 editId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetTrackESConfiguration([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr ppConfig, [In] IntPtr pConfigSize);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Byte MP4GetTrackEsdsObjectTypeId([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int64 MP4GetTrackFixedSampleDuration([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetTrackFloatProperty([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr propName, [In] IntPtr ret_value);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetTrackH264LengthSize([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr pLength);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetTrackH264ProfileLevel([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr pProfile, [In] IntPtr pLevel);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetTrackH264SeqPictHeaders([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr pSeqHeaders, [In] IntPtr pSeqHeaderSize, [In] IntPtr pPictHeader, [In] IntPtr pPictHeaderSize);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetTrackIntegerProperty([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr propName, [In] IntPtr retvalue);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetTrackLanguage([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr code);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern UInt32 MP4GetTrackMaxSampleSize([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4GetTrackMediaDataName([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetTrackMediaDataOriginalFormat([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr originalFormat, [In] UInt32 buflen);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetTrackName([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr name);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern UInt32 MP4GetTrackNumberOfEdits([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Int32 MP4GetTrackNumberOfSamples([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetTrackStringProperty([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr propName, [In] IntPtr retvalue);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern UInt32 MP4GetTrackTimeScale([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4GetTrackType([In] IntPtr hFile, [In] Int32 trackId);
    
            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern double MP4GetTrackVideoFrameRate([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern UInt16 MP4GetTrackVideoHeight([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4GetTrackVideoMetadata([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr ppConfig, [In] IntPtr pConfigSize);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern UInt16 MP4GetTrackVideoWidth([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern Byte MP4GetVideoProfileLevel([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4HaveAtom([In] IntPtr hFile, [In] IntPtr atomName);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4HaveTrackAtom([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr atomname);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4Info([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4IsIsmaCrypMediaTrack([In] IntPtr hFile, [In] Int32 trackId);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4ItmfAddItem([In] IntPtr hFile, [In] IntPtr item);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4ItmfGetItems([In] IntPtr hFile);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4ItmfGetItemsByCode([In] IntPtr hFile, [In] IntPtr code);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4ItmfGetItemsByMeaning([In] IntPtr hFile, [In] IntPtr meaning, [In] IntPtr name);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4ItmfItemAlloc([In] IntPtr code, [In] UInt32 numData);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern void MP4ItmfItemFree([In] IntPtr item);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern void MP4ItmfItemListFree([In] IntPtr itemList);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4ItmfRemoveItem([In] IntPtr hFile, [In] IntPtr item);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4ItmfSetItem([In] IntPtr hFile, [In] IntPtr item);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern MP4LogLevel MP4LogGetLevel();

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern void MP4LogSetLevel([In] MP4LogLevel verbosity);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4Make3GPCompliant([In] IntPtr fileName, [In] IntPtr majorBrand, [In] UInt32 minorVersion, [In] IntPtr supportedBrands, [In] UInt32 supportedBrandsCount, [In, MarshalAs(UnmanagedType.I1)] bool deleteIodsAtom);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4MakeIsmaCompliant([In] IntPtr fileName, [In, MarshalAs(UnmanagedType.I1)] bool addIsmaComplianceSdp);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4MakeIsmaSdpIod([In] Byte videoProfile, [In] UInt32 videoBitrate, [In] IntPtr videoConfig, [In] UInt32 videoConfigLength, [In] Byte audioProfile, [In] UInt32 audioBitrate, [In] IntPtr audioConfig, [In] UInt32 audioConfigLength);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4Modify([In] IntPtr fileName, [In] UInt32 flags);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4Optimize([In] IntPtr fileName, [In] IntPtr newFileName);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4Read([In] IntPtr fileName);
           
            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4ReadRtpHint([In] IntPtr hFile, [In] Int32 hintTrackId, [In] Int32 hintSampleId, [In] IntPtr pNumPackets);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4ReadRtpPacket([In] IntPtr hFile, [In] Int32 hintTrackId, [In] UInt16 packetIndex, [In] IntPtr ppSBytes, [In] IntPtr pNumSBytes, [In] UInt32 ssrc, [In, MarshalAs(UnmanagedType.I1)] bool includeHeader, [In, MarshalAs(UnmanagedType.I1)] bool includePayload);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4ReadSample([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 sampleId, [In] IntPtr ppSBytes, [In] IntPtr pNumSBytes, [In] IntPtr pStartTime, [In] IntPtr pDuration, [In] IntPtr pRenderingOffset, [In] IntPtr pIsSyncSample);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4ReadSampleFromEditTime([In] IntPtr hFile, [In] Int32 trackId, [In] Int64 when, [In] IntPtr ppSBytes, [In] IntPtr pNumSBytes, [In] IntPtr pStartTime, [In] IntPtr pDuration, [In] IntPtr pRenderingOffset, [In] IntPtr pIsSyncSample);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4ReadSampleFromTime([In] IntPtr hFile, [In] Int32 trackId, [In] Int64 when, [In] IntPtr ppSBytes, [In] IntPtr pNumSBytes, [In] IntPtr pStartTime, [In] IntPtr pDuration, [In] IntPtr pRenderingOffset, [In] IntPtr pIsSyncSample);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4ReferenceSample([In] IntPtr srcFile, [In] Int32 srcTrackId, [In] Int32 srcSampleId, [In] IntPtr dstFile, [In] Int32 dstTrackId, [In] Int64 dstSampleDuration);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern void MP4SetAmrDecoderVersion([In] IntPtr hFile, [In] Int32 trackId, [In] Byte decoderVersion);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern void MP4SetAmrModeSet([In] IntPtr hFile, [In] Int32 trakId, [In] UInt16 modeSet);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern void MP4SetAmrVendor([In] IntPtr hFile, [In] Int32 trackId, [In] UInt32 vendor);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern void MP4SetAudioProfileLevel([In] IntPtr hFile, [In] Byte value);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4SetSBytesProperty([In] IntPtr hFile, [In] IntPtr propName, [In] IntPtr pValue, [In] UInt32 valueSize);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern MP4ChapterType MP4SetChapters([In] IntPtr hFile, [In] IntPtr chapterList, [In] UInt32 chapterCount, [In] MP4ChapterType chapterType);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4SetFloatProperty([In] IntPtr hFile, [In] IntPtr propName, [In] float value);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4SetGraphicsProfileLevel([In] IntPtr hFile, [In] Byte value);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern void MP4SetH263Bitrates([In] IntPtr hFile, [In] Int32 trackId, [In] UInt32 avgBitrate, [In] UInt32 maxBitrate);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern void MP4SetH263DecoderVersion([In] IntPtr hFile, [In] Int32 trackId, [In] Byte decoderVersion);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern void MP4SetH263Vendor([In] IntPtr hFile, [In] Int32 trackId, [In] UInt32 vendor);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4SetHintTrackRtpPayload([In] IntPtr hFile, [In] Int32 hintTrackId, [In] IntPtr pPayloadName, [In] IntPtr pPayloadNumber, [In] UInt16 maxPayloadSize, [In] IntPtr encode_params, [In, MarshalAs(UnmanagedType.I1)] bool include_rtp_map, [In, MarshalAs(UnmanagedType.I1)] bool include_mpeg4_esid);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4SetHintTrackSdp([In] IntPtr hFile, [In] Int32 hintTrackId, [In] IntPtr sdpString);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4SetIntegerProperty([In] IntPtr hFile, [In] IntPtr propName, [In] Int64 value);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4SetODProfileLevel([In] IntPtr hFile, [In] Byte value);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4SetRtpTimestampStart([In] IntPtr hFile, [In] Int32 hintTrackId, [In] Int64 rtpStart);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4SetSampleRenderingOffset([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 sampleId, [In] Int64 renderingOffset);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4SetSceneProfileLevel([In] IntPtr hFile, [In] Byte value);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4SetSessionSdp([In] IntPtr hFile, [In] IntPtr sdpString);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4SetStringProperty([In] IntPtr hFile, [In] IntPtr propName, [In] IntPtr value);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4SetTimeScale([In] IntPtr hFile, [In] UInt32 value);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4SetTrackSBytesProperty([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr propName, [In] IntPtr pValue, [In] UInt32 valueSize);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4SetTrackDurationPerChunk([In] IntPtr hFile, [In] Int32 trackId, [In] Int64 duration);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4SetTrackEditDuration([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 editId, [In] Int64 duration);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4SetTrackEditDwell([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 editId, [In, MarshalAs(UnmanagedType.I1)] bool dwell);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4SetTrackEditMediaStart([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 editId, [In] Int64 startTime);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4SetTrackESConfiguration([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr pConfig, [In] UInt32 configSize);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4SetTrackFloatProperty([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr propName, [In] float value);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4SetTrackIntegerProperty([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr propName, [In] Int64 value);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4SetTrackLanguage([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr code);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4SetTrackName([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr name);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4SetTrackStringProperty([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr propName, [In] IntPtr value);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4SetTrackTimeScale([In] IntPtr hFile, [In] Int32 trackId, [In] UInt32 value);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern void MP4SetVideoProfileLevel([In] IntPtr hFile, [In] Byte value);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern IntPtr MP4TagsAlloc();
    
            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsAddArtwork([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsFetch([In] IntPtr tags, [In] IntPtr hFile);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern void MP4TagsFree([In] IntPtr tags);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsHasMetadata([In] IntPtr tags, [In] IntPtr hasMetadata);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsRemoveArtwork([In] IntPtr parameter1, [In] UInt32 parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetAlbum([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetAlbumArtist([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetArtist([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetArtistID([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetArtwork([In] IntPtr parameter1, [In] UInt32 parameter2, [In] IntPtr parameter3);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetCategory([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetComments([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetCompilation([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetComposer([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetComposerID([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetContentID([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetContentRating([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetCopyright([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetDescription([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetDisk([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetEncodedBy([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetEncodingTool([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetGapless([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetGenre([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetGenreID([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetGenreType([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetGrouping([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetHDVideo([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetITunesAccount([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetITunesAccountType([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetITunesCountry([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetKeywords([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetLongDescription([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetLyrics([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetMediaType([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetName([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetPlaylistID([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetPodcast([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetPurchaseDate([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetReleaseDate([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetSortAlbum([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetSortAlbumArtist([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetSortArtist([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetSortComposer([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetSortName([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetSortTVShow([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetTempo([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetTrack([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetTVEpisode([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetTVEpisodeID([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetTVNetwork([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetTVSeason([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetTVShow([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsSetXID([In] IntPtr parameter1, [In] IntPtr parameter2);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4TagsStore([In] IntPtr tags, [In] IntPtr hFile);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern bool MP4WriteRtpHint([In] IntPtr hFile, [In] Int32 hintTrackId, [In] Int64 duration, [In, MarshalAs(UnmanagedType.I1)] bool isSyncSample);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4WriteSample([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr pSBytes, [In] UInt32 numSBytes, [In] Int64 duration, [In] Int64 renderingOffset, [In, MarshalAs(UnmanagedType.I1)] bool isSyncSample);

            [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
            internal static extern bool MP4WriteSampleDependency([In] IntPtr hFile, [In] Int32 trackId, [In] IntPtr pSBytes, [In] UInt32 numSBytes, [In] Int64 duration, [In] Int64 renderingOffset, [In, MarshalAs(UnmanagedType.I1)] bool isSyncSample, [In] UInt32 dependencyFlags);        
        }

        public static void MP4AddChapter([In] IntPtr hFile, [In] Int32 chapterTrackId, [In] Int64 chapterDuration, [In] ByteArrayPtr chapterTitle)
        {
            IPin pin = null;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = chapterTitle;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                Imports.MP4AddChapter(hFile, chapterTrackId, chapterDuration, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
        }

        public static Int32 MP4AddEncAudioTrack([In] IntPtr hFile, [In] UInt32 timeScale, [In] Int64 sampleDuration, [In] mp4v2_ismacrypParams icPp, [In] Byte audioType)
        {
            IPin pin = null;
            Int32 id;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = icPp;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                id = Imports.MP4AddEncAudioTrack(hFile, timeScale, sampleDuration, pointer, audioType);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return id;
        }

        public static Int32 MP4AddEncH264VideoTrack([In] IntPtr dstFile, [In] UInt32 timeScale, [In] Int64 sampleDuration, [In] UInt16 width, [In] UInt16 height, [In] IntPtr srcFile, [In] Int32 srcTrackId, [In] mp4v2_ismacrypParams icPp)
        {
            IPin pin = null;
            Int32 id;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = icPp;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                id = Imports.MP4AddEncH264VideoTrack(dstFile, timeScale, sampleDuration, width, height, srcFile, srcTrackId, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return id;
        }

        public static Int32 MP4AddEncVideoTrack([In] IntPtr hFile, [In] UInt32 timeScale, [In] Int64 sampleDuration, [In] UInt16 width, [In] UInt16 height, [In] mp4v2_ismacrypParams icPp, [In] Byte videoType, [In] ByteArrayPtr oFormat)
        {
            IPin pin = null;
            IPin pin2 = null;
            Int32 id;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = icPp;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = oFormat;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                id = Imports.MP4AddEncVideoTrack(hFile, timeScale, sampleDuration, width, height, pointer, videoType, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return id;
        }

        public static void MP4AddH264PictureParameterSet([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr pPict, [In] UInt16 pictLen)
        {
            IPin pin = null;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = pPict;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                Imports.MP4AddH264PictureParameterSet(hFile, trackId, pointer, pictLen);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
        }

        public static void MP4AddH264SequenceParameterSet([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr pSequence, [In] UInt16 sequenceLen)
        {
            IPin pin = null;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = pSequence;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                Imports.MP4AddH264SequenceParameterSet(hFile, trackId, pointer, sequenceLen);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
        }

        public static Int32 MP4AddHrefTrack([In] IntPtr hFile, [In] UInt32 timeScale, [In] Int64 sampleDuration, [In] ByteArrayPtr base_url)
        {
            IPin pin = null;
            Int32 id;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = base_url;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                id = Imports.MP4AddHrefTrack(hFile, timeScale, sampleDuration, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return id;
        }

        public static void MP4AddNeroChapter([In] IntPtr hFile, [In] Int64 chapterStart, [In] ByteArrayPtr chapterTitle)
        {
            IPin pin = null;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = chapterTitle;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                Imports.MP4AddNeroChapter(hFile, chapterStart, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
        }

        public static bool MP4AddRtpImmediateData([In] IntPtr hFile, [In] Int32 hintTrackId, [In] ByteArrayPtr pSBytes, [In] UInt32 numSBytes)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = pSBytes;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4AddRtpImmediateData(hFile, hintTrackId, pointer, numSBytes);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static Int32 MP4AddSystemsTrack([In] IntPtr hFile, [In] ByteArrayPtr type)
        {
            IPin pin = null;
            Int32 id;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = type;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                id = Imports.MP4AddSystemsTrack(hFile, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return id;
        }

        public static Int32 MP4AddTrack([In] IntPtr hFile, [In] ByteArrayPtr type, [In] UInt32 timeScale)
        {
            IPin pin = null;
            Int32 id;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = type;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                id = Imports.MP4AddTrack(hFile, pointer, timeScale);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return id;
        }

        public static bool MP4AppendHintTrackSdp([In] IntPtr hFile, [In] Int32 hintTrackId, [In] ByteArrayPtr sdpString)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = sdpString;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4AppendHintTrackSdp(hFile, hintTrackId, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4AppendSessionSdp([In] IntPtr hFile, [In] ByteArrayPtr sdpString)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = sdpString;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4AppendSessionSdp(hFile, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static ByteArrayPtr MP4BinaryToBase16([In] ByteArrayPtr pData, [In] UInt32 dataSize)
        {
            IPin pin = null;
            ByteArrayPtr ptr2 = new ByteArrayPtr();
            try
            {
                IntPtr ptr = IntPtr.Zero;
                
                IPinnable pinnable = pData;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    ptr = pin.Pointer;
                }
                IntPtr pointer = Imports.MP4BinaryToBase16(ptr, dataSize);
                if (!(pointer == IntPtr.Zero))
                {
                    ptr2 = new ByteArrayPtr(pointer);
                }
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return ptr2;
        }

        public static ByteArrayPtr MP4BinaryToBase64([In] ByteArrayPtr pData, [In] UInt32 dataSize)
        {
            IPin pin = null;
            ByteArrayPtr ptr2 = new ByteArrayPtr();
            try
            {
                IntPtr ptr = IntPtr.Zero;
                
                IPinnable pinnable = pData;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    ptr = pin.Pointer;
                }
                IntPtr pointer = Imports.MP4BinaryToBase64(ptr, dataSize);
                if (!(pointer == IntPtr.Zero))
                {
                    ptr2 = new ByteArrayPtr(pointer);
                }
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return ptr2;
        }

        public static IntPtr MP4Create([In] ByteArrayPtr fileName, [In] UInt32 flags)
        {
            IPin pin = null;
            IntPtr handle;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = fileName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                handle = Imports.MP4Create(pointer, flags);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return handle;
        }

        public static IntPtr MP4CreateEx([In] ByteArrayPtr fileName, [In] UInt32 flags, [In] int add_ftyp, [In] int add_iods, [In] ByteArrayPtr majorBrand, [In] UInt32 minorVersion, [In] ArrayPtr<ByteArrayPtr> compatibleBrands, [In] UInt32 compatibleBrandsCount)
        {
            IPin pin = null;
            IPin pin2 = null;
            IPin pin3 = null;
            IntPtr handle;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                IntPtr ptr3 = IntPtr.Zero;
                
                IPinnable pinnable = fileName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = majorBrand;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                IPinnable pinnable3 = compatibleBrands;
                if (pinnable3 != null)
                {
                    pin3 = pinnable3.Pin();
                    ptr3 = pin3.Pointer;
                }
                handle = Imports.MP4CreateEx(pointer, flags, add_ftyp, add_iods, ptr2, minorVersion, ptr3, compatibleBrandsCount);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
                if (pin3 != null)
                {
                    pin3.Dispose();
                }
            }
            return handle;
        }

        public static Int32 MP4EncAndCloneTrack([In] IntPtr srcFile, [In] Int32 srcTrackId, [In] mp4v2_ismacrypParams icPp, [In] IntPtr dstFile, [In] Int32 dstHintTrackReferenceTrack)
        {
            IPin pin = null;
            Int32 id;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = icPp;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                id = Imports.MP4EncAndCloneTrack(srcFile, srcTrackId, pointer, dstFile, dstHintTrackReferenceTrack);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return id;
        }

        public static ByteArrayPtr MP4FileInfo([In] ByteArrayPtr fileName, [In] Int32 trackId)
        {
            IPin pin = null;
            ByteArrayPtr ptr2 = new ByteArrayPtr();
            try
            {
                IntPtr ptr = IntPtr.Zero;
                
                IPinnable pinnable = fileName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    ptr = pin.Pointer;
                }
                IntPtr pointer = Imports.MP4FileInfo(ptr, trackId);
                if (!(pointer == IntPtr.Zero))
                {
                    ptr2 = new ByteArrayPtr(pointer);
                }
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return ptr2;
        }

        public static Int32 MP4FindTrackId([In] IntPtr hFile, [In] UInt16 index, [In] ByteArrayPtr type, [In] Byte subType)
        {
            IPin pin = null;
            Int32 id;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = type;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                id = Imports.MP4FindTrackId(hFile, index, pointer, subType);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return id;
        }

        public static bool MP4GetSBytesProperty([In] IntPtr hFile, [In] ByteArrayPtr propName, [In] ByteArrayPtr ppValue, [In] ArrayPtr<UInt32> pValueSize)
        {
            IPin pin = null;
            IPin pin2 = null;
            IPin pin3 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                IntPtr ptr3 = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = ppValue;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                IPinnable pinnable3 = pValueSize;
                if (pinnable3 != null)
                {
                    pin3 = pinnable3.Pin();
                    ptr3 = pin3.Pointer;
                }
                flag = Imports.MP4GetSBytesProperty(hFile, pointer, ptr2, ptr3);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
                if (pin3 != null)
                {
                    pin3.Dispose();
                }
            }
            return flag;
        }

        public static MP4ChapterType MP4GetChapters([In] IntPtr hFile, [In] ArrayPtr<MP4Chapter_t> chapterList, [In] ArrayPtr<UInt32> chapterCount, [In] MP4ChapterType chapterType)
        {
            IPin pin = null;
            IPin pin2 = null;
            MP4ChapterType type;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = chapterList;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = chapterCount;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                type = Imports.MP4GetChapters(hFile, pointer, ptr2, chapterType);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return type;
        }

        public static ByteArrayPtr MP4GetFilename([In] IntPtr hFile)
        {
            ByteArrayPtr ptr = null;
            try
            {
                IntPtr pointer = Imports.MP4GetFilename(hFile);
                if (!(pointer == IntPtr.Zero))
                {
                    ptr = new ByteArrayPtr(pointer);
                }
            }
            finally
            {
            }
            return ptr;
        }

        public static bool MP4GetFloatProperty([In] IntPtr hFile, [In] ByteArrayPtr propName, [In] ArrayPtr<float> retvalue)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = retvalue;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4GetFloatProperty(hFile, pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4GetHintTrackRtpPayload([In] IntPtr hFile, [In] Int32 hintTrackId, [In] ArrayPtr<ByteArrayPtr> ppPayloadName, [In] ByteArrayPtr pPayloadNumber, [In] ShortArrayPtr pMaxPayloadSize, [In] ArrayPtr<ByteArrayPtr> ppEncodingParams)
        {
            IPin pin = null;
            IPin pin2 = null;
            IPin pin3 = null;
            IPin pin4 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                IntPtr ptr3 = IntPtr.Zero;
                IntPtr ptr4 = IntPtr.Zero;
                
                IPinnable pinnable = ppPayloadName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = pPayloadNumber;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                IPinnable pinnable3 = pMaxPayloadSize;
                if (pinnable3 != null)
                {
                    pin3 = pinnable3.Pin();
                    ptr3 = pin3.Pointer;
                }
                IPinnable pinnable4 = ppEncodingParams;
                if (pinnable4 != null)
                {
                    pin4 = pinnable4.Pin();
                    ptr4 = pin4.Pointer;
                }
                flag = Imports.MP4GetHintTrackRtpPayload(hFile, hintTrackId, pointer, ptr2, ptr3, ptr4);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
                if (pin3 != null)
                {
                    pin3.Dispose();
                }
                if (pin4 != null)
                {
                    pin4.Dispose();
                }
            }
            return flag;
        }

        public static ByteArrayPtr MP4GetHintTrackSdp([In] IntPtr hFile, [In] Int32 hintTrackId)
        {
            ByteArrayPtr ptr = null;
            try
            {
                IntPtr pointer = Imports.MP4GetHintTrackSdp(hFile, hintTrackId);
                if (!(pointer == IntPtr.Zero))
                {
                    ptr = new ByteArrayPtr(pointer);
                }
            }
            finally
            {
            }
            return ptr;
        }

        public static ByteArrayPtr MP4GetHrefTrackBaseUrl([In] IntPtr hFile, [In] Int32 trackId)
        {
            ByteArrayPtr ptr = null;
            try
            {
                IntPtr pointer = Imports.MP4GetHrefTrackBaseUrl(hFile, trackId);
                if (!(pointer == IntPtr.Zero))
                {
                    ptr = new ByteArrayPtr(pointer);
                }
            }
            finally
            {
            }
            return ptr;
        }

        public static bool MP4GetIntegerProperty([In] IntPtr hFile, [In] ByteArrayPtr propName, [In] ArrayPtr<UInt64> retval)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = retval;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4GetIntegerProperty(hFile, pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static UInt32 MP4GetNumberOfTracks([In] IntPtr hFile, [In] ByteArrayPtr type, [In] Byte subType)
        {
            IPin pin = null;
            UInt32 _t;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = type;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                _t = Imports.MP4GetNumberOfTracks(hFile, pointer, subType);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return _t;
        }

        public static Int32 MP4GetSampleIdFromEditTime([In] IntPtr hFile, [In] Int32 trackId, [In] Int64 when, [In] ArrayPtr<Int64> pStartTime, [In] ArrayPtr<Int64> pDuration)
        {
            IPin pin = null;
            IPin pin2 = null;
            Int32 id;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = pStartTime;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = pDuration;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                id = Imports.MP4GetSampleIdFromEditTime(hFile, trackId, when, pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return id;
        }

        public static ByteArrayPtr MP4GetSessionSdp([In] IntPtr hFile)
        {
            ByteArrayPtr ptr = null;
            try
            {
                IntPtr pointer = Imports.MP4GetSessionSdp(hFile);
                if (!(pointer == IntPtr.Zero))
                {
                    ptr = new ByteArrayPtr(pointer);
                }
            }
            finally
            {
            }
            return ptr;
        }


        public static bool MP4GetStringProperty([In] IntPtr hFile, [In] ByteArrayPtr propName, [In] ArrayPtr<ByteArrayPtr> retvalue)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = retvalue;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4GetStringProperty(hFile, pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4GetTrackSBytesProperty([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr propName, [In] ByteArrayPtr ppValue, [In] ArrayPtr<UInt32> pValueSize)
        {
            IPin pin = null;
            IPin pin2 = null;
            IPin pin3 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                IntPtr ptr3 = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = ppValue;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                IPinnable pinnable3 = pValueSize;
                if (pinnable3 != null)
                {
                    pin3 = pinnable3.Pin();
                    ptr3 = pin3.Pointer;
                }
                flag = Imports.MP4GetTrackSBytesProperty(hFile, trackId, pointer, ptr2, ptr3);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
                if (pin3 != null)
                {
                    pin3.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4GetTrackDurationPerChunk([In] IntPtr hFile, [In] Int32 trackId, [In] ArrayPtr<Int64> duration)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = duration;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4GetTrackDurationPerChunk(hFile, trackId, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4GetTrackESConfiguration([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr ppConfig, [In] ArrayPtr<UInt32> pConfigSize)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = ppConfig;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = pConfigSize;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4GetTrackESConfiguration(hFile, trackId, pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4GetTrackFloatProperty([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr propName, [In] ArrayPtr<float> ret_value)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = ret_value;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4GetTrackFloatProperty(hFile, trackId, pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }
        
        public static bool MP4GetTrackH264LengthSize([In] IntPtr hFile, [In] Int32 trackId, [In] ArrayPtr<UInt32> pLength)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = pLength;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4GetTrackH264LengthSize(hFile, trackId, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4GetTrackH264ProfileLevel([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr pProfile, [In] ByteArrayPtr pLevel)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = pProfile;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = pLevel;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4GetTrackH264ProfileLevel(hFile, trackId, pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4GetTrackH264SeqPictHeaders([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr pSeqHeaders, [In] ArrayPtr<ArrayPtr<UInt32>> pSeqHeaderSize, [In] ByteArrayPtr pPictHeader, [In] ArrayPtr<ArrayPtr<UInt32>> pPictHeaderSize)
        {
            IPin pin = null;
            IPin pin2 = null;
            IPin pin3 = null;
            IPin pin4 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                IntPtr ptr3 = IntPtr.Zero;
                IntPtr ptr4 = IntPtr.Zero;
                
                IPinnable pinnable = pSeqHeaders;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = pSeqHeaderSize;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                IPinnable pinnable3 = pPictHeader;
                if (pinnable3 != null)
                {
                    pin3 = pinnable3.Pin();
                    ptr3 = pin3.Pointer;
                }
                IPinnable pinnable4 = pPictHeaderSize;
                if (pinnable4 != null)
                {
                    pin4 = pinnable4.Pin();
                    ptr4 = pin4.Pointer;
                }
                flag = Imports.MP4GetTrackH264SeqPictHeaders(hFile, trackId, pointer, ptr2, ptr3, ptr4);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
                if (pin3 != null)
                {
                    pin3.Dispose();
                }
                if (pin4 != null)
                {
                    pin4.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4GetTrackIntegerProperty([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr propName, [In] ArrayPtr<UInt64> retvalue)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = retvalue;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4GetTrackIntegerProperty(hFile, trackId, pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4GetTrackLanguage([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr code)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = code;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4GetTrackLanguage(hFile, trackId, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static ByteArrayPtr MP4GetTrackMediaDataName([In] IntPtr hFile, [In] Int32 trackId)
        {
            ByteArrayPtr ptr = null;
            try
            {
                IntPtr pointer = Imports.MP4GetTrackMediaDataName(hFile, trackId);
                if (!(pointer == IntPtr.Zero))
                {
                    ptr = new ByteArrayPtr(pointer);
                }
            }
            finally
            {
            }
            return ptr;
        }

        public static bool MP4GetTrackMediaDataOriginalFormat([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr originalFormat, [In] UInt32 buflen)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = originalFormat;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4GetTrackMediaDataOriginalFormat(hFile, trackId, pointer, buflen);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4GetTrackName([In] IntPtr hFile, [In] Int32 trackId, [In] ArrayPtr<ByteArrayPtr> name)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = name;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4GetTrackName(hFile, trackId, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4GetTrackStringProperty([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr propName, [In] ArrayPtr<ByteArrayPtr> retvalue)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = retvalue;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4GetTrackStringProperty(hFile, trackId, pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static ByteArrayPtr MP4GetTrackType([In] IntPtr hFile, [In] Int32 trackId)
        {
            ByteArrayPtr ptr = null;
            try
            {
                IntPtr pointer = Imports.MP4GetTrackType(hFile, trackId);
                if (!(pointer == IntPtr.Zero))
                {
                    ptr = new ByteArrayPtr(pointer);
                }
            }
            finally
            {
            }
            return ptr;
        }

        public static bool MP4GetTrackVideoMetadata([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr ppConfig, [In] ArrayPtr<UInt32> pConfigSize)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = ppConfig;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = pConfigSize;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4GetTrackVideoMetadata(hFile, trackId, pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4HaveAtom([In] IntPtr hFile, [In] ByteArrayPtr atomName)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = atomName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4HaveAtom(hFile, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4HaveTrackAtom([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr atomname)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = atomname;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4HaveTrackAtom(hFile, trackId, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static ByteArrayPtr MP4Info([In] IntPtr hFile, [In] Int32 trackId)
        {
            ByteArrayPtr ptr = null;
            try
            {
                IntPtr pointer = Imports.MP4Info(hFile, trackId);
                if (!(pointer == IntPtr.Zero))
                {
                    ptr = new ByteArrayPtr(pointer);
                }
            }
            finally
            {
            }
            return ptr;
        }

        public static bool MP4ItmfAddItem([In] IntPtr hFile, [In] MP4ItmfItem item)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = item;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4ItmfAddItem(hFile, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static MP4ItmfItemList MP4ItmfGetItems([In] IntPtr hFile)
        {
            MP4ItmfItemList list = new MP4ItmfItemList();
            try
            {
                list = Imports.MP4ItmfGetItems(hFile);
            }
            finally
            {
            }
            return list;
        }

        public static MP4ItmfItemList MP4ItmfGetItemsByCode([In] IntPtr hFile, [In] ByteArrayPtr code)
        {
            IPin pin = null;
            MP4ItmfItemList list = new MP4ItmfItemList();
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = code;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IntPtr ptr2 = Imports.MP4ItmfGetItemsByCode(hFile, pointer);
                if (!(ptr2 == IntPtr.Zero))
                {
                    list = new MP4ItmfItemList(ptr2);
                }
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return list;
        }

        public static MP4ItmfItemList MP4ItmfGetItemsByMeaning([In] IntPtr hFile, [In] ByteArrayPtr meaning, [In] ByteArrayPtr name)
        {
            IPin pin = null;
            IPin pin2 = null;
            MP4ItmfItemList list = new MP4ItmfItemList();
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = meaning;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = name;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                IntPtr ptr3 = Imports.MP4ItmfGetItemsByMeaning(hFile, pointer, ptr2);
                if (!(ptr3 == IntPtr.Zero))
                {
                    list = new MP4ItmfItemList(ptr3);
                }
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return list;
        }

        public static MP4ItmfItem MP4ItmfItemAlloc([In] ByteArrayPtr code, [In] UInt32 numData)
        {
            IPin pin = null;
            MP4ItmfItem item = new MP4ItmfItem();
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = code;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IntPtr ptr2 = Imports.MP4ItmfItemAlloc(pointer, numData);
                if (!(ptr2 == IntPtr.Zero))
                {
                    item = new MP4ItmfItem(ptr2);
                }
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return item;
        }

        public static void MP4ItmfItemFree([In] MP4ItmfItem item)
        {
            System.Console.WriteLine("WARNING: Memory Leak Here");

            return;

            IPin pin = null;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = item;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                Imports.MP4ItmfItemFree(pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
        }

        public static void MP4ItmfItemListFree([In] MP4ItmfItemList itemList)
        {
            IPin pin = null;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = itemList;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                Imports.MP4ItmfItemListFree(pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
        }

        public static bool MP4ItmfRemoveItem([In] IntPtr hFile, [In] MP4ItmfItem item)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = item;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4ItmfRemoveItem(hFile, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4ItmfSetItem([In] IntPtr hFile, [In] MP4ItmfItem item)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = item;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4ItmfSetItem(hFile, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4Make3GPCompliant([In] ByteArrayPtr fileName, [In] ByteArrayPtr majorBrand, [In] UInt32 minorVersion, [In] ArrayPtr<ByteArrayPtr> supportedBrands, [In] UInt32 supportedBrandsCount, [In, MarshalAs(UnmanagedType.I1)] bool deleteIodsAtom)
        {
            IPin pin = null;
            IPin pin2 = null;
            IPin pin3 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                IntPtr ptr3 = IntPtr.Zero;
                
                IPinnable pinnable = fileName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = majorBrand;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                IPinnable pinnable3 = supportedBrands;
                if (pinnable3 != null)
                {
                    pin3 = pinnable3.Pin();
                    ptr3 = pin3.Pointer;
                }
                flag = Imports.MP4Make3GPCompliant(pointer, ptr2, minorVersion, ptr3, supportedBrandsCount, deleteIodsAtom);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
                if (pin3 != null)
                {
                    pin3.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4MakeIsmaCompliant([In] ByteArrayPtr fileName, [In, MarshalAs(UnmanagedType.I1)] bool addIsmaComplianceSdp)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = fileName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4MakeIsmaCompliant(pointer, addIsmaComplianceSdp);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static ByteArrayPtr MP4MakeIsmaSdpIod([In] Byte videoProfile, [In] UInt32 videoBitrate, [In] ByteArrayPtr videoConfig, [In] UInt32 videoConfigLength, [In] Byte audioProfile, [In] UInt32 audioBitrate, [In] ByteArrayPtr audioConfig, [In] UInt32 audioConfigLength)
        {
            IPin pin = null;
            IPin pin2 = null;
            ByteArrayPtr ptr3 = new ByteArrayPtr();
            try
            {
                IntPtr ptr = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = videoConfig;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    ptr = pin.Pointer;
                }
                IPinnable pinnable2 = audioConfig;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                IntPtr pointer = Imports.MP4MakeIsmaSdpIod(videoProfile, videoBitrate, ptr, videoConfigLength, audioProfile, audioBitrate, ptr2, audioConfigLength);
                if (!(pointer == IntPtr.Zero))
                {
                    ptr3 = new ByteArrayPtr(pointer);
                }
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return ptr3;
        }

        public static IntPtr MP4Modify([In] ByteArrayPtr fileName, [In] UInt32 flags)
        {
            IPin pin = null;
            IntPtr handle;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = fileName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                handle = Imports.MP4Modify(pointer, flags);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return handle;
        }

        public static bool MP4Optimize([In] ByteArrayPtr fileName, [In] ByteArrayPtr newFileName)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = fileName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = newFileName;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4Optimize(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static IntPtr MP4Read([In] ByteArrayPtr fileName)
        {
            IPin pin = null;
            IntPtr handle;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = fileName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                handle = Imports.MP4Read(pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return handle;
        }

        public static bool MP4ReadRtpHint([In] IntPtr hFile, [In] Int32 hintTrackId, [In] Int32 hintSampleId, [In] ShortArrayPtr pNumPackets)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = pNumPackets;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4ReadRtpHint(hFile, hintTrackId, hintSampleId, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4ReadRtpPacket([In] IntPtr hFile, [In] Int32 hintTrackId, [In] UInt16 packetIndex, [In] ByteArrayPtr ppSBytes, [In] ArrayPtr<UInt32> pNumSBytes, [In] UInt32 ssrc, [In, MarshalAs(UnmanagedType.I1)] bool includeHeader, [In, MarshalAs(UnmanagedType.I1)] bool includePayload)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = ppSBytes;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = pNumSBytes;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4ReadRtpPacket(hFile, hintTrackId, packetIndex, pointer, ptr2, ssrc, includeHeader, includePayload);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4ReadSample([In] IntPtr hFile, [In] Int32 trackId, [In] Int32 sampleId, [In] ByteArrayPtr ppSBytes, [In] ArrayPtr<UInt32> pNumSBytes, [In] ArrayPtr<Int64> pStartTime, [In] ArrayPtr<Int64> pDuration, [In] ArrayPtr<Int64> pRenderingOffset, [In] ArrayPtr<bool> pIsSyncSample)
        {
            IPin pin = null;
            IPin pin2 = null;
            IPin pin3 = null;
            IPin pin4 = null;
            IPin pin5 = null;
            IPin pin6 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                IntPtr ptr3 = IntPtr.Zero;
                IntPtr ptr4 = IntPtr.Zero;
                IntPtr ptr5 = IntPtr.Zero;
                IntPtr ptr6 = IntPtr.Zero;
                
                IPinnable pinnable = ppSBytes;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = pNumSBytes;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                IPinnable pinnable3 = pStartTime;
                if (pinnable3 != null)
                {
                    pin3 = pinnable3.Pin();
                    ptr3 = pin3.Pointer;
                }
                IPinnable pinnable4 = pDuration;
                if (pinnable4 != null)
                {
                    pin4 = pinnable4.Pin();
                    ptr4 = pin4.Pointer;
                }
                IPinnable pinnable5 = pRenderingOffset;
                if (pinnable5 != null)
                {
                    pin5 = pinnable5.Pin();
                    ptr5 = pin5.Pointer;
                }
                IPinnable pinnable6 = pIsSyncSample;
                if (pinnable6 != null)
                {
                    pin6 = pinnable6.Pin();
                    ptr6 = pin6.Pointer;
                }
                flag = Imports.MP4ReadSample(hFile, trackId, sampleId, pointer, ptr2, ptr3, ptr4, ptr5, ptr6);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
                if (pin3 != null)
                {
                    pin3.Dispose();
                }
                if (pin4 != null)
                {
                    pin4.Dispose();
                }
                if (pin5 != null)
                {
                    pin5.Dispose();
                }
                if (pin6 != null)
                {
                    pin6.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4ReadSampleFromEditTime([In] IntPtr hFile, [In] Int32 trackId, [In] Int64 when, [In] ByteArrayPtr ppSBytes, [In] ArrayPtr<UInt32> pNumSBytes, [In] ArrayPtr<Int64> pStartTime, [In] ArrayPtr<Int64> pDuration, [In] ArrayPtr<Int64> pRenderingOffset, [In] ArrayPtr<bool> pIsSyncSample)
        {
            IPin pin = null;
            IPin pin2 = null;
            IPin pin3 = null;
            IPin pin4 = null;
            IPin pin5 = null;
            IPin pin6 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                IntPtr ptr3 = IntPtr.Zero;
                IntPtr ptr4 = IntPtr.Zero;
                IntPtr ptr5 = IntPtr.Zero;
                IntPtr ptr6 = IntPtr.Zero;
                
                IPinnable pinnable = ppSBytes;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = pNumSBytes;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                IPinnable pinnable3 = pStartTime;
                if (pinnable3 != null)
                {
                    pin3 = pinnable3.Pin();
                    ptr3 = pin3.Pointer;
                }
                IPinnable pinnable4 = pDuration;
                if (pinnable4 != null)
                {
                    pin4 = pinnable4.Pin();
                    ptr4 = pin4.Pointer;
                }
                IPinnable pinnable5 = pRenderingOffset;
                if (pinnable5 != null)
                {
                    pin5 = pinnable5.Pin();
                    ptr5 = pin5.Pointer;
                }
                IPinnable pinnable6 = pIsSyncSample;
                if (pinnable6 != null)
                {
                    pin6 = pinnable6.Pin();
                    ptr6 = pin6.Pointer;
                }
                flag = Imports.MP4ReadSampleFromEditTime(hFile, trackId, when, pointer, ptr2, ptr3, ptr4, ptr5, ptr6);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
                if (pin3 != null)
                {
                    pin3.Dispose();
                }
                if (pin4 != null)
                {
                    pin4.Dispose();
                }
                if (pin5 != null)
                {
                    pin5.Dispose();
                }
                if (pin6 != null)
                {
                    pin6.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4ReadSampleFromTime([In] IntPtr hFile, [In] Int32 trackId, [In] Int64 when, [In] ByteArrayPtr ppSBytes, [In] ArrayPtr<UInt32> pNumSBytes, [In] ArrayPtr<Int64> pStartTime, [In] ArrayPtr<Int64> pDuration, [In] ArrayPtr<Int64> pRenderingOffset, [In] ArrayPtr<bool> pIsSyncSample)
        {
            IPin pin = null;
            IPin pin2 = null;
            IPin pin3 = null;
            IPin pin4 = null;
            IPin pin5 = null;
            IPin pin6 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                IntPtr ptr3 = IntPtr.Zero;
                IntPtr ptr4 = IntPtr.Zero;
                IntPtr ptr5 = IntPtr.Zero;
                IntPtr ptr6 = IntPtr.Zero;
                
                IPinnable pinnable = ppSBytes;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = pNumSBytes;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                IPinnable pinnable3 = pStartTime;
                if (pinnable3 != null)
                {
                    pin3 = pinnable3.Pin();
                    ptr3 = pin3.Pointer;
                }
                IPinnable pinnable4 = pDuration;
                if (pinnable4 != null)
                {
                    pin4 = pinnable4.Pin();
                    ptr4 = pin4.Pointer;
                }
                IPinnable pinnable5 = pRenderingOffset;
                if (pinnable5 != null)
                {
                    pin5 = pinnable5.Pin();
                    ptr5 = pin5.Pointer;
                }
                IPinnable pinnable6 = pIsSyncSample;
                if (pinnable6 != null)
                {
                    pin6 = pinnable6.Pin();
                    ptr6 = pin6.Pointer;
                }
                flag = Imports.MP4ReadSampleFromTime(hFile, trackId, when, pointer, ptr2, ptr3, ptr4, ptr5, ptr6);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
                if (pin3 != null)
                {
                    pin3.Dispose();
                }
                if (pin4 != null)
                {
                    pin4.Dispose();
                }
                if (pin5 != null)
                {
                    pin5.Dispose();
                }
                if (pin6 != null)
                {
                    pin6.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4SetSBytesProperty([In] IntPtr hFile, [In] ByteArrayPtr propName, [In] ByteArrayPtr pValue, [In] UInt32 valueSize)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = pValue;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4SetSBytesProperty(hFile, pointer, ptr2, valueSize);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static MP4ChapterType MP4SetChapters([In] IntPtr hFile, [In] MP4Chapter_t chapterList, [In] UInt32 chapterCount, [In] MP4ChapterType chapterType)
        {
            IPin pin = null;
            MP4ChapterType type;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = chapterList;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                type = Imports.MP4SetChapters(hFile, pointer, chapterCount, chapterType);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return type;
        }

        public static bool MP4SetFloatProperty([In] IntPtr hFile, [In] ByteArrayPtr propName, [In] float value)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4SetFloatProperty(hFile, pointer, value);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4SetHintTrackRtpPayload([In] IntPtr hFile, [In] Int32 hintTrackId, [In] ByteArrayPtr pPayloadName, [In] ByteArrayPtr pPayloadNumber, [In] UInt16 maxPayloadSize, [In] ByteArrayPtr encode_params, [In, MarshalAs(UnmanagedType.I1)] bool include_rtp_map, [In, MarshalAs(UnmanagedType.I1)] bool include_mpeg4_esid)
        {
            IPin pin = null;
            IPin pin2 = null;
            IPin pin3 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                IntPtr ptr3 = IntPtr.Zero;
                
                IPinnable pinnable = pPayloadName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = pPayloadNumber;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                IPinnable pinnable3 = encode_params;
                if (pinnable3 != null)
                {
                    pin3 = pinnable3.Pin();
                    ptr3 = pin3.Pointer;
                }
                flag = Imports.MP4SetHintTrackRtpPayload(hFile, hintTrackId, pointer, ptr2, maxPayloadSize, ptr3, include_rtp_map, include_mpeg4_esid);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
                if (pin3 != null)
                {
                    pin3.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4SetHintTrackSdp([In] IntPtr hFile, [In] Int32 hintTrackId, [In] ByteArrayPtr sdpString)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = sdpString;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4SetHintTrackSdp(hFile, hintTrackId, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4SetIntegerProperty([In] IntPtr hFile, [In] ByteArrayPtr propName, [In] Int64 value)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4SetIntegerProperty(hFile, pointer, value);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4SetSessionSdp([In] IntPtr hFile, [In] ByteArrayPtr sdpString)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = sdpString;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4SetSessionSdp(hFile, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4SetStringProperty([In] IntPtr hFile, [In] ByteArrayPtr propName, [In] ByteArrayPtr value)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = value;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4SetStringProperty(hFile, pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4SetTrackSBytesProperty([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr propName, [In] ByteArrayPtr pValue, [In] UInt32 valueSize)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = pValue;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4SetTrackSBytesProperty(hFile, trackId, pointer, ptr2, valueSize);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4SetTrackESConfiguration([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr pConfig, [In] UInt32 configSize)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = pConfig;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4SetTrackESConfiguration(hFile, trackId, pointer, configSize);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4SetTrackFloatProperty([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr propName, [In] float value)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4SetTrackFloatProperty(hFile, trackId, pointer, value);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4SetTrackIntegerProperty([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr propName, [In] Int64 value)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4SetTrackIntegerProperty(hFile, trackId, pointer, value);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4SetTrackLanguage([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr code)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = code;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4SetTrackLanguage(hFile, trackId, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4SetTrackName([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr name)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = name;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4SetTrackName(hFile, trackId, pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4SetTrackStringProperty([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr propName, [In] ByteArrayPtr value)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = propName;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = value;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4SetTrackStringProperty(hFile, trackId, pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsAddArtwork([In] MP4Tags tags, [In] MP4TagArtwork parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsAddArtwork(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static MP4Tags MP4TagsAlloc()
        {
            MP4Tags tags;
            try
            {
                tags = Imports.MP4TagsAlloc();
            }
            finally
            {
            }
            return tags;
        }

        public static bool MP4TagsFetch([In] MP4Tags tags, [In] IntPtr hFile)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4TagsFetch(pointer, hFile);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static void MP4TagsFree([In] MP4Tags tags)
        {
            IPin pin = null;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                Imports.MP4TagsFree(pointer);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
        }

        public static bool MP4TagsHasMetadata([In] MP4Tags tags, [In] ArrayPtr<bool> hasMetadata)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;
                
                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = hasMetadata;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsHasMetadata(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsRemoveArtwork([In] MP4Tags tags, [In] UInt32 parameter2)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4TagsRemoveArtwork(pointer, parameter2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetAlbum([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetAlbum(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetAlbumArtist([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetAlbumArtist(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetArtist([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetArtist(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetArtistID([In] MP4Tags tags, [In] ArrayPtr<UInt32> parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetArtistID(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetArtwork([In] MP4Tags tags, [In] UInt32 parameter2, [In] MP4TagArtwork parameter3)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter3;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetArtwork(pointer, parameter2, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetCategory([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetCategory(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetComments([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetComments(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetCompilation([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetCompilation(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetComposer([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetComposer(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetComposerID([In] MP4Tags tags, [In] ArrayPtr<UInt32> parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetComposerID(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetContentID([In] MP4Tags tags, [In] ArrayPtr<UInt32> parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetContentID(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetContentRating([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetContentRating(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetCopyright([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetCopyright(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetDescription([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetDescription(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetDisk([In] MP4Tags tags, [In] MP4TagDisk parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetDisk(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetEncodedBy([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetEncodedBy(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetEncodingTool([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetEncodingTool(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetGapless([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetGapless(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetGenre([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetGenre(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetGenreID([In] MP4Tags tags, [In] ArrayPtr<UInt32> parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetGenreID(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetGenreType([In] MP4Tags tags, [In] ShortArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetGenreType(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetGrouping([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetGrouping(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static void MP4TagsSetHDVideo([In] MP4Tags tags, [In] Byte quality)
        {
            ByteArrayPtr ptr;

            ptr = new ByteArrayPtr(1);
            ptr[0] = quality;

            MP4TagsSetHDVideo(tags, ptr);
        }

        public static void MP4TagsSetHDVideo([In] MP4Tags parameter1, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = parameter1;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                Imports.MP4TagsSetHDVideo(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
        }

        public static bool MP4TagsSetITunesAccount([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetITunesAccount(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetITunesAccountType([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetITunesAccountType(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetITunesCountry([In] MP4Tags tags, [In] ArrayPtr<UInt32> parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetITunesCountry(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetKeywords([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetKeywords(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetLongDescription([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetLongDescription(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetLyrics([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetLyrics(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetMediaType([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetMediaType(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetName([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetName(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetPlaylistID([In] MP4Tags tags, [In] ArrayPtr<UInt64> parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetPlaylistID(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetPodcast([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetPodcast(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetPurchaseDate([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetPurchaseDate(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetReleaseDate([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetReleaseDate(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetSortAlbum([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetSortAlbum(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetSortAlbumArtist([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetSortAlbumArtist(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetSortArtist([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetSortArtist(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetSortComposer([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetSortComposer(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetSortName([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetSortName(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetSortTVShow([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetSortTVShow(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetTempo([In] MP4Tags tags, [In] ShortArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetTempo(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetTrack([In] MP4Tags tags, [In] MP4TagTrack parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetTrack(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static void MP4TagsSetTrack([In] MP4Tags tags, [In] Int32? track)
        {
            if (track.HasValue)
            {
                ByteArrayPtr ptr;

                ptr = new ByteArrayPtr(1);
                ptr[0] = (Byte)track.Value;

                MP4TagsSetTrack(tags, ptr);
            }
        }

        public static void MP4TagsSetTrack([In] MP4Tags parameter1, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = parameter1;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                Imports.MP4TagsSetTrack(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
        }

        public static void MP4TagsSetTVEpisode([In] MP4Tags tags, [In] Int32? episode)
        {
            if (episode.HasValue)
            {
                ByteArrayPtr ptr;

                ptr = new ByteArrayPtr(1);
                ptr[0] = (Byte)episode.Value;

                MP4TagsSetTVEpisode(tags, ptr);
            }
        }

        public static void MP4TagsSetTVEpisode([In] MP4Tags parameter1, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = parameter1;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                Imports.MP4TagsSetTVEpisode(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
        }

        public static bool MP4TagsSetTVEpisodeID([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetTVEpisodeID(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetTVNetwork([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetTVNetwork(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static void MP4TagsSetTVSeason([In] MP4Tags tags, [In] Int32? season)
        {
            if (season.HasValue)
        {
                ByteArrayPtr ptr;

                ptr = new ByteArrayPtr(1);
                ptr[0] = (Byte)season.Value;

                MP4TagsSetTVSeason(tags, ptr);
            }
        }

        public static void MP4TagsSetTVSeason([In] MP4Tags parameter1, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = parameter1;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                Imports.MP4TagsSetTVSeason(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
        }

        public static bool MP4TagsSetTVShow([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetTVShow(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsSetXID([In] MP4Tags tags, [In] ByteArrayPtr parameter2)
        {
            IPin pin = null;
            IPin pin2 = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                IntPtr ptr2 = IntPtr.Zero;

                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                IPinnable pinnable2 = parameter2;
                if (pinnable2 != null)
                {
                    pin2 = pinnable2.Pin();
                    ptr2 = pin2.Pointer;
                }
                flag = Imports.MP4TagsSetXID(pointer, ptr2);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
                if (pin2 != null)
                {
                    pin2.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4TagsStore([In] MP4Tags tags, [In] IntPtr hFile)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = tags;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4TagsStore(pointer, hFile);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4WriteSample([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr pSBytes, [In] UInt32 numSBytes, [In] Int64 duration, [In] Int64 renderingOffset, [In, MarshalAs(UnmanagedType.I1)] bool isSyncSample)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = pSBytes;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4WriteSample(hFile, trackId, pointer, numSBytes, duration, renderingOffset, isSyncSample);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        public static bool MP4WriteSampleDependency([In] IntPtr hFile, [In] Int32 trackId, [In] ByteArrayPtr pSBytes, [In] UInt32 numSBytes, [In] Int64 duration, [In] Int64 renderingOffset, [In, MarshalAs(UnmanagedType.I1)] bool isSyncSample, [In] UInt32 dependencyFlags)
        {
            IPin pin = null;
            bool flag;
            try
            {
                IntPtr pointer = IntPtr.Zero;
                
                IPinnable pinnable = pSBytes;
                if (pinnable != null)
                {
                    pin = pinnable.Pin();
                    pointer = pin.Pointer;
                }
                flag = Imports.MP4WriteSampleDependency(hFile, trackId, pointer, numSBytes, duration, renderingOffset, isSyncSample, dependencyFlags);
            }
            finally
            {
                if (pin != null)
                {
                    pin.Dispose();
                }
            }
            return flag;
        }

        #region Exposed Methods

        [DllImport("libmp4v2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern void MP4Close([In] IntPtr hFile, [In] UInt32 flags);

        #endregion
    }
}

