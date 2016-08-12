namespace libmp4v2.Internal
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=8)]
    public struct MP4TagDisk_s
    {
        public short index;
        public short total;
    }
}

