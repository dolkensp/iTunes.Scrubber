namespace libmp4v2.Internal
{
    using System;
    using System.Runtime.InteropServices;
    using PInvoker.Marshal;

    [StructLayout(LayoutKind.Sequential, Pack=8)]
    public struct MP4TagArtwork_s
    {
        public ByteArrayPtr data;
        public int size;
        public int type;
    }
}

