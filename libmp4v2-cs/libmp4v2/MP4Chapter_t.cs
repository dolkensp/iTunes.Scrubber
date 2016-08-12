namespace libmp4v2
{
    using libmp4v2.Internal;
    using PInvoker.Marshal;
    using System;
    using System.Reflection;

    public sealed class MP4Chapter_t : StructPtr<libmp4v2.Internal.MP4Chapter_s>
    {
        public MP4Chapter_t()
        {
        }

        public MP4Chapter_t(libmp4v2.Internal.MP4Chapter_s value) : base(value)
        {
        }

        internal MP4Chapter_t(StructPtr<libmp4v2.Internal.MP4Chapter_s> other) : base(other)
        {
        }

        public MP4Chapter_t(libmp4v2.Internal.MP4Chapter_s[] value) : base(value)
        {
        }

        public MP4Chapter_t(int arraySize) : base(arraySize)
        {
        }

        public MP4Chapter_t(IntPtr value) : base(value)
        {
        }

        protected override StructPtr<libmp4v2.Internal.MP4Chapter_s> CreateInstance(IntPtr pointer)
        {
            return new MP4Chapter_t(pointer);
        }

        public static implicit operator MP4Chapter_t(libmp4v2.Internal.MP4Chapter_s value)
        {
            return new MP4Chapter_t(value);
        }

        public static implicit operator MP4Chapter_t(IntPtr value)
        {
            return new MP4Chapter_t(value);
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

        public MP4Chapter_t this[int index]
        {
            get
            {
                return (MP4Chapter_t) base.GetAtIndex(index);
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

