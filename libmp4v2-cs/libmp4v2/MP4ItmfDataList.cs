namespace libmp4v2
{
    using libmp4v2.Internal;
    using PInvoker.Marshal;
    using System;
    using System.Reflection;

    public sealed class MP4ItmfDataList : StructPtr<libmp4v2.Internal.MP4ItmfDataList_s>
    {
        public MP4ItmfDataList()
        {
        }

        public MP4ItmfDataList(libmp4v2.Internal.MP4ItmfDataList_s value) : base(value)
        {
        }

        internal MP4ItmfDataList(StructPtr<libmp4v2.Internal.MP4ItmfDataList_s> other) : base(other)
        {
        }

        public MP4ItmfDataList(libmp4v2.Internal.MP4ItmfDataList_s[] value) : base(value)
        {
        }

        public MP4ItmfDataList(int arraySize) : base(arraySize)
        {
        }

        public MP4ItmfDataList(IntPtr value) : base(value)
        {
        }

        protected override StructPtr<libmp4v2.Internal.MP4ItmfDataList_s> CreateInstance(IntPtr pointer)
        {
            return new MP4ItmfDataList(pointer);
        }

        public static implicit operator MP4ItmfDataList(libmp4v2.Internal.MP4ItmfDataList_s value)
        {
            return new MP4ItmfDataList(value);
        }

        public static implicit operator MP4ItmfDataList(IntPtr value)
        {
            return new MP4ItmfDataList(value);
        }

        public MP4ItmfData elements
        {
            get
            {
                return base.GetPinnableFromIntPtrField<MP4ItmfData>(0L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0L, (IPinnable) value);
            }
        }

        public MP4ItmfDataList this[int index]
        {
            get
            {
                return (MP4ItmfDataList) base.GetAtIndex(index);
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

