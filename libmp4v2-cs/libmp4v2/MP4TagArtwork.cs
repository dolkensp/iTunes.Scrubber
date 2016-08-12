namespace libmp4v2
{
    using libmp4v2.Internal;
    using PInvoker.Marshal;
    using System;
    using System.Reflection;

    public sealed class MP4TagArtwork : StructPtr<libmp4v2.Internal.MP4TagArtwork_s>
    {
        public MP4TagArtwork()
        {
        }

        public MP4TagArtwork(libmp4v2.Internal.MP4TagArtwork_s value) : base(value)
        {
        }

        internal MP4TagArtwork(StructPtr<libmp4v2.Internal.MP4TagArtwork_s> other) : base(other)
        {
        }

        public MP4TagArtwork(libmp4v2.Internal.MP4TagArtwork_s[] value) : base(value)
        {
        }

        public MP4TagArtwork(int arraySize) : base(arraySize)
        {
        }

        public MP4TagArtwork(IntPtr value) : base(value)
        {
        }

        protected override StructPtr<libmp4v2.Internal.MP4TagArtwork_s> CreateInstance(IntPtr pointer)
        {
            return new MP4TagArtwork(pointer);
        }

        public static implicit operator MP4TagArtwork(libmp4v2.Internal.MP4TagArtwork_s value)
        {
            return new MP4TagArtwork(value);
        }

        public static implicit operator MP4TagArtwork(IntPtr value)
        {
            return new MP4TagArtwork(value);
        }

        public ByteArrayPtr data
        {
            get
            {
                return base.GetPinnableFromIntPtrField<ByteArrayPtr>(0L);
            }
            set
            {
                base.SetPinnableToIntPtrField(0L, (IPinnable) value);
            }
        }

        public MP4TagArtwork this[int index]
        {
            get
            {
                return (MP4TagArtwork) base.GetAtIndex(index);
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

        public MP4TagArtworkType type
        {
            get
            {
                return base.ReadStructFromField<MP4TagArtworkType>(8L);
            }
            set
            {
                base.WriteStructToField<MP4TagArtworkType>(8L, value);
            }
        }
    }
}

