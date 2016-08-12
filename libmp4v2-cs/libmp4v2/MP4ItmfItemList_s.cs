namespace libmp4v2
{
    using libmp4v2.Internal;
    using PInvoker.Marshal;
    using System;
    using System.Reflection;

    public sealed class MP4ItmfItemList_s : StructPtr<libmp4v2.Internal.MP4ItmfItemList_s>
    {
        public MP4ItmfItemList_s()
        {
        }

        public MP4ItmfItemList_s(libmp4v2.Internal.MP4ItmfItemList_s value) : base(value)
        {
        }

        internal MP4ItmfItemList_s(StructPtr<libmp4v2.Internal.MP4ItmfItemList_s> other) : base(other)
        {
        }

        public MP4ItmfItemList_s(libmp4v2.Internal.MP4ItmfItemList_s[] value) : base(value)
        {
        }

        public MP4ItmfItemList_s(int arraySize) : base(arraySize)
        {
        }

        public MP4ItmfItemList_s(IntPtr value) : base(value)
        {
        }

        protected override StructPtr<libmp4v2.Internal.MP4ItmfItemList_s> CreateInstance(IntPtr pointer)
        {
            return new libmp4v2.MP4ItmfItemList_s(pointer);
        }

        public static implicit operator libmp4v2.MP4ItmfItemList_s(libmp4v2.Internal.MP4ItmfItemList_s value)
        {
            return new libmp4v2.MP4ItmfItemList_s(value);
        }

        public static implicit operator libmp4v2.MP4ItmfItemList_s(IntPtr value)
        {
            return new libmp4v2.MP4ItmfItemList_s(value);
        }

        public MP4ItmfItem elements
        {
            get
            {
                return base.GetPinnableFromIntPtrField<MP4ItmfItem>(0L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0L, (IPinnable) value);
            }
        }

        public libmp4v2.MP4ItmfItemList_s this[int index]
        {
            get
            {
                return (libmp4v2.MP4ItmfItemList_s) base.GetAtIndex(index);
            }
        }

        public UInt32 size
        {
            get
            {
                return base.ReadStructFromField<UInt32>(4L);
            }
            set
            {
                base.WriteStructToField<UInt32>(4L, value);
            }
        }
    }
}

