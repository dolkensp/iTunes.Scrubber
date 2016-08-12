namespace libmp4v2.Internal
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=8)]
    public struct mp4v2_ismacryp_session_params
    {
        public int scheme_type;
        public short scheme_version;
        public byte key_ind_len;
        public byte iv_len;
        public byte selective_enc;
        public IntPtr kms_uri;
    }
}

