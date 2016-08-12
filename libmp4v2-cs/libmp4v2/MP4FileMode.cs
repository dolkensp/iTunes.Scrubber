namespace libmp4v2
{
    using PInvoker.Marshal;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=4)]
    public struct MP4FileMode : ITypedef<MP4FileMode_e>
    {
        private MP4FileMode_e _value;
        public static readonly MP4FileMode_e FILEMODE_UNDEFINED;
        public static readonly MP4FileMode_e FILEMODE_READ;
        public static readonly MP4FileMode_e FILEMODE_MODIFY;
        public static readonly MP4FileMode_e FILEMODE_CREATE;
        public MP4FileMode(MP4FileMode_e value)
        {
            this._value = value;
        }

        public static implicit operator MP4FileMode(MP4FileMode_e _e1)
        {
            return new MP4FileMode(_e1);
        }

        public static implicit operator MP4FileMode_e(MP4FileMode mode1)
        {
            return mode1.Value;
        }

        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        public override bool Equals(object value)
        {
            if (value.GetType() == typeof(MP4FileMode))
            {
                return (this._value == ((MP4FileMode) value)._value);
            }
            return ((value.GetType() == typeof(MP4FileMode_e)) && this._value.Equals(value));
        }

        public override string ToString()
        {
            return this._value.ToString();
        }

        static MP4FileMode()
        {
            FILEMODE_UNDEFINED = MP4FileMode_e.FILEMODE_UNDEFINED;
            FILEMODE_READ = MP4FileMode_e.FILEMODE_READ;
            FILEMODE_MODIFY = MP4FileMode_e.FILEMODE_MODIFY;
            FILEMODE_CREATE = MP4FileMode_e.FILEMODE_CREATE;
        }

        public MP4FileMode_e Value
        {
            get { return this._value; }
        }
    }
}

