namespace libmp4v2.Internal
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=8)]
    public struct MP4FileProvider_s
    {
        public IntPtr open;
        public IntPtr seek;
        public IntPtr read;
        public IntPtr write;
        public IntPtr close;
    }
}

