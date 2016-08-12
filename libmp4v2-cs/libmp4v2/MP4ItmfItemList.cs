namespace libmp4v2
{
    using libmp4v2.Internal;
    using PInvoker.Marshal;
    using System;
    using System.Reflection;

    public sealed class MP4ItmfItemList : StructPtr<libmp4v2.Internal.MP4ItmfItemList_s>
    {
        public MP4ItmfItemList()
        {
        }

        public MP4ItmfItemList(libmp4v2.Internal.MP4ItmfItemList_s value) : base(value)
        {
        }

        internal MP4ItmfItemList(StructPtr<libmp4v2.Internal.MP4ItmfItemList_s> other) : base(other)
        {
        }

        public MP4ItmfItemList(libmp4v2.Internal.MP4ItmfItemList_s[] value) : base(value)
        {
        }

        public MP4ItmfItemList(int arraySize) : base(arraySize)
        {
        }

        public MP4ItmfItemList(IntPtr value) : base(value)
        {
        }

        protected override StructPtr<libmp4v2.Internal.MP4ItmfItemList_s> CreateInstance(IntPtr pointer)
        {
            return new MP4ItmfItemList(pointer);
        }

        public static implicit operator MP4ItmfItemList(libmp4v2.Internal.MP4ItmfItemList_s value)
        {
            return new MP4ItmfItemList(value);
        }

        public static implicit operator MP4ItmfItemList(IntPtr value)
        {
            return new MP4ItmfItemList(value);
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

        public MP4ItmfItemList this[int index]
        {
            get
            {
                return (MP4ItmfItemList) base.GetAtIndex(index);
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

