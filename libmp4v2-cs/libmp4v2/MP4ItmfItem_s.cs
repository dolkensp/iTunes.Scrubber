namespace libmp4v2
{
    using libmp4v2.Internal;
    using PInvoker.Marshal;
    using System;
    using System.Reflection;

    public sealed class MP4ItmfItem_s : StructPtr<libmp4v2.Internal.MP4ItmfItem_s>
    {
        public MP4ItmfItem_s()
        {
        }

        public MP4ItmfItem_s(libmp4v2.Internal.MP4ItmfItem_s value) : base(value)
        {
        }

        internal MP4ItmfItem_s(StructPtr<libmp4v2.Internal.MP4ItmfItem_s> other) : base(other)
        {
        }

        public MP4ItmfItem_s(libmp4v2.Internal.MP4ItmfItem_s[] value) : base(value)
        {
        }

        public MP4ItmfItem_s(int arraySize) : base(arraySize)
        {
        }

        public MP4ItmfItem_s(IntPtr value) : base(value)
        {
        }

        protected override StructPtr<libmp4v2.Internal.MP4ItmfItem_s> CreateInstance(IntPtr pointer)
        {
            return new libmp4v2.MP4ItmfItem_s(pointer);
        }

        public static implicit operator libmp4v2.MP4ItmfItem_s(libmp4v2.Internal.MP4ItmfItem_s value)
        {
            return new libmp4v2.MP4ItmfItem_s(value);
        }

        public static implicit operator libmp4v2.MP4ItmfItem_s(IntPtr value)
        {
            return new libmp4v2.MP4ItmfItem_s(value);
        }

        public IntPtr __handle
        {
            get
            {
                return base.ReadIntPtrFromField(0L);
            }
            set
            {
                base.WriteIntPtrToField(0L, value);
            }
        }

        public ByteArrayPtr code
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(4L);
            }
            set
            {
                base.SetPinnableToIntPtrField(4L, (IPinnable) value);
            }
        }

        public MP4ItmfDataList dataList
        {
            get
            {
                return base.GetPinnableFromField<MP4ItmfDataList>(0x10L);
            }
        }

        public libmp4v2.MP4ItmfItem_s this[int index]
        {
            get
            {
                return (libmp4v2.MP4ItmfItem_s) base.GetAtIndex(index);
            }
        }

        public ByteArrayPtr mean
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(8L);
            }
            set
            {
                base.SetPinnableToIntPtrField(8L, (IPinnable) value);
            }
        }

        public ByteArrayPtr name
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(12L);
            }
            set
            {
                base.SetPinnableToIntPtrField(12L, (IPinnable) value);
            }
        }
    }
}

