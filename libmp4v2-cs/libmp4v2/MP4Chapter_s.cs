namespace libmp4v2
{
    using libmp4v2.Internal;
    using PInvoker.Marshal;
    using System;
    using System.Reflection;

    public sealed class MP4Chapter_s : StructPtr<libmp4v2.Internal.MP4Chapter_s>
    {
        public MP4Chapter_s()
        {
        }

        public MP4Chapter_s(libmp4v2.Internal.MP4Chapter_s value) : base(value)
        {
        }

        internal MP4Chapter_s(StructPtr<libmp4v2.Internal.MP4Chapter_s> other) : base(other)
        {
        }

        public MP4Chapter_s(libmp4v2.Internal.MP4Chapter_s[] value) : base(value)
        {
        }

        public MP4Chapter_s(int arraySize) : base(arraySize)
        {
        }

        public MP4Chapter_s(IntPtr value) : base(value)
        {
        }

        protected override StructPtr<libmp4v2.Internal.MP4Chapter_s> CreateInstance(IntPtr pointer)
        {
            return new libmp4v2.MP4Chapter_s(pointer);
        }

        public static implicit operator libmp4v2.MP4Chapter_s(libmp4v2.Internal.MP4Chapter_s value)
        {
            return new libmp4v2.MP4Chapter_s(value);
        }

        public static implicit operator libmp4v2.MP4Chapter_s(IntPtr value)
        {
            return new libmp4v2.MP4Chapter_s(value);
        }

        public Int64 duration
        {
            get
            {
                return base.ReadStructFromField<Int64>(0L);
            }
            set
            {
                base.WriteStructToField<Int64>(0L, value);
            }
        }

        public libmp4v2.MP4Chapter_s this[int index]
        {
            get
            {
                return (libmp4v2.MP4Chapter_s) base.GetAtIndex(index);
            }
        }

        public ByteArrayPtr title
        {
            get
            {
                return base.GetPinnableFromField<ByteArrayPtr>(8L);
            }
        }
    }
}

