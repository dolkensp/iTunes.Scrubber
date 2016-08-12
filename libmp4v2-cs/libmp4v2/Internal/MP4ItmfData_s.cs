namespace libmp4v2.Internal
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=8)]
    public struct MP4ItmfData_s
    {
        public byte typeSetIdentifier;
        public int typeCode;
        public int locale;
        public IntPtr value;
        public int valueSize;
    }
}

