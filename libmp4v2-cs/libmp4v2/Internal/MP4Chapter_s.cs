namespace libmp4v2.Internal
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=8)]
    public struct MP4Chapter_s
    {
        public long duration;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x400)]
        public byte[] title;
    }
}

