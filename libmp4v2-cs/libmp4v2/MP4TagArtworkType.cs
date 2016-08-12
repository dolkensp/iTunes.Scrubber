namespace libmp4v2
{
    using PInvoker.Marshal;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=4)]
    public struct MP4TagArtworkType : ITypedef<MP4TagArtworkType_e>
    {
        private MP4TagArtworkType_e _value;
        public static readonly MP4TagArtworkType_e MP4_ART_UNDEFINED;
        public static readonly MP4TagArtworkType_e MP4_ART_BMP;
        public static readonly MP4TagArtworkType_e MP4_ART_GIF;
        public static readonly MP4TagArtworkType_e MP4_ART_JPEG;
        public static readonly MP4TagArtworkType_e MP4_ART_PNG;
        public MP4TagArtworkType(MP4TagArtworkType_e value)
        {
            this._value = value;
        }

        public static implicit operator MP4TagArtworkType(MP4TagArtworkType_e _e1)
        {
            return new MP4TagArtworkType(_e1);
        }

        public static implicit operator MP4TagArtworkType_e(MP4TagArtworkType type1)
        {
            return type1.Value;
        }

        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        public override bool Equals(object value)
        {
            if (value.GetType() == typeof(MP4TagArtworkType))
            {
                return (this._value == ((MP4TagArtworkType) value)._value);
            }
            return ((value.GetType() == typeof(MP4TagArtworkType_e)) && this._value.Equals(value));
        }

        public override string ToString()
        {
            return this._value.ToString();
        }

        static MP4TagArtworkType()
        {
            MP4_ART_UNDEFINED = MP4TagArtworkType_e.MP4_ART_UNDEFINED;
            MP4_ART_BMP = MP4TagArtworkType_e.MP4_ART_BMP;
            MP4_ART_GIF = MP4TagArtworkType_e.MP4_ART_GIF;
            MP4_ART_JPEG = MP4TagArtworkType_e.MP4_ART_JPEG;
            MP4_ART_PNG = MP4TagArtworkType_e.MP4_ART_PNG;
        }

        public MP4TagArtworkType_e Value
        {
            get { return this._value; }
        }
    }
}

