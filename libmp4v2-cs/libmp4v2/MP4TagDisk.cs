namespace libmp4v2
{
    using libmp4v2.Internal;
    using PInvoker.Marshal;
    using System;
    using System.Reflection;

    public sealed class MP4TagDisk : StructPtr<libmp4v2.Internal.MP4TagDisk_s>
    {
        public MP4TagDisk()
        {
        }

        public MP4TagDisk(libmp4v2.Internal.MP4TagDisk_s value) : base(value)
        {
        }

        internal MP4TagDisk(StructPtr<libmp4v2.Internal.MP4TagDisk_s> other) : base(other)
        {
        }

        public MP4TagDisk(libmp4v2.Internal.MP4TagDisk_s[] value) : base(value)
        {
        }

        public MP4TagDisk(int arraySize) : base(arraySize)
        {
        }

        public MP4TagDisk(IntPtr value) : base(value)
        {
        }

        protected override StructPtr<libmp4v2.Internal.MP4TagDisk_s> CreateInstance(IntPtr pointer)
        {
            return new MP4TagDisk(pointer);
        }

        public static implicit operator MP4TagDisk(libmp4v2.Internal.MP4TagDisk_s value)
        {
            return new MP4TagDisk(value);
        }

        public static implicit operator MP4TagDisk(IntPtr value)
        {
            return new MP4TagDisk(value);
        }

        public UInt16 index
        {
            get
            {
                return base.ReadStructFromField<UInt16>(0L);
            }
            set
            {
                base.WriteStructToField<UInt16>(0L, value);
            }
        }

        public MP4TagDisk this[int index]
        {
            get
            {
                return (MP4TagDisk) base.GetAtIndex(index);
            }
        }

        public UInt16 total
        {
            get
            {
                return base.ReadStructFromField<UInt16>(2L);
            }
            set
            {
                base.WriteStructToField<UInt16>(2L, value);
            }
        }
    }
}

