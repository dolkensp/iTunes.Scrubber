namespace libmp4v2.Internal
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=8)]
    public struct MP4ItmfItemList_s
    {
        public IntPtr elements;
        public int size;
    }
}

