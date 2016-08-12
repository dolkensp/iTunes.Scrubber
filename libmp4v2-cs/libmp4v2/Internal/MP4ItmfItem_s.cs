namespace libmp4v2.Internal
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=8)]
    public struct MP4ItmfItem_s
    {
        public IntPtr __handle;
        public IntPtr code;
        public IntPtr mean;
        public IntPtr name;
        public MP4ItmfDataList_s dataList;
    }
}

