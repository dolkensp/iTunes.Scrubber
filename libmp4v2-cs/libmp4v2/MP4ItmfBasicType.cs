namespace libmp4v2
{
    using PInvoker.Marshal;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=4)]
    public struct MP4ItmfBasicType : ITypedef<MP4ItmfBasicType_e>
    {
        private MP4ItmfBasicType_e _value;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_IMPLICIT;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_UTF8;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_UTF16;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_SJIS;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_HTML;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_XML;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_UUID;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_ISRC;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_MI3P;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_GIF;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_JPEG;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_PNG;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_URL;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_DURATION;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_DATETIME;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_GENRES;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_INTEGER;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_RIAA_PA;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_UPC;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_BMP;
        public static readonly MP4ItmfBasicType_e MP4_ITMF_BT_UNDEFINED;

        public MP4ItmfBasicType(MP4ItmfBasicType_e value)
        {
            this._value = value;
        }

        public static implicit operator MP4ItmfBasicType(MP4ItmfBasicType_e _e1)
        {
            return new MP4ItmfBasicType(_e1);
        }

        public static implicit operator MP4ItmfBasicType_e(MP4ItmfBasicType type1)
        {
            return type1.Value;
        }

        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        public override bool Equals(object value)
        {
            if (value.GetType() == typeof(MP4ItmfBasicType))
            {
                return (this._value == ((MP4ItmfBasicType) value)._value);
            }
            return ((value.GetType() == typeof(MP4ItmfBasicType_e)) && this._value.Equals(value));
        }

        public override string ToString()
        {
            return this._value.ToString();
        }

        
        static MP4ItmfBasicType()
        {
            MP4_ITMF_BT_IMPLICIT = MP4ItmfBasicType_e.MP4_ITMF_BT_IMPLICIT;
            MP4_ITMF_BT_UTF8 = MP4ItmfBasicType_e.MP4_ITMF_BT_UTF8;
            MP4_ITMF_BT_UTF16 = MP4ItmfBasicType_e.MP4_ITMF_BT_UTF16;
            MP4_ITMF_BT_SJIS = MP4ItmfBasicType_e.MP4_ITMF_BT_SJIS;
            MP4_ITMF_BT_HTML = MP4ItmfBasicType_e.MP4_ITMF_BT_HTML;
            MP4_ITMF_BT_XML = MP4ItmfBasicType_e.MP4_ITMF_BT_XML;
            MP4_ITMF_BT_UUID = MP4ItmfBasicType_e.MP4_ITMF_BT_UUID;
            MP4_ITMF_BT_ISRC = MP4ItmfBasicType_e.MP4_ITMF_BT_ISRC;
            MP4_ITMF_BT_MI3P = MP4ItmfBasicType_e.MP4_ITMF_BT_MI3P;
            MP4_ITMF_BT_GIF = MP4ItmfBasicType_e.MP4_ITMF_BT_GIF;
            MP4_ITMF_BT_JPEG = MP4ItmfBasicType_e.MP4_ITMF_BT_JPEG;
            MP4_ITMF_BT_PNG = MP4ItmfBasicType_e.MP4_ITMF_BT_PNG;
            MP4_ITMF_BT_URL = MP4ItmfBasicType_e.MP4_ITMF_BT_URL;
            MP4_ITMF_BT_DURATION = MP4ItmfBasicType_e.MP4_ITMF_BT_DURATION;
            MP4_ITMF_BT_DATETIME = MP4ItmfBasicType_e.MP4_ITMF_BT_DATETIME;
            MP4_ITMF_BT_GENRES = MP4ItmfBasicType_e.MP4_ITMF_BT_GENRES;
            MP4_ITMF_BT_INTEGER = MP4ItmfBasicType_e.MP4_ITMF_BT_INTEGER;
            MP4_ITMF_BT_RIAA_PA = MP4ItmfBasicType_e.MP4_ITMF_BT_RIAA_PA;
            MP4_ITMF_BT_UPC = MP4ItmfBasicType_e.MP4_ITMF_BT_UPC;
            MP4_ITMF_BT_BMP = MP4ItmfBasicType_e.MP4_ITMF_BT_BMP;
            MP4_ITMF_BT_UNDEFINED = MP4ItmfBasicType_e.MP4_ITMF_BT_UNDEFINED;
        }

        public MP4ItmfBasicType_e Value
        {
            get { return this._value; }
        }
    }
}

