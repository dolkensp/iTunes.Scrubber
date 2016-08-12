namespace libmp4v2
{
    using libmp4v2.Internal;
    using PInvoker.Marshal;
    using System;
    using System.Reflection;

    public sealed class MP4TagArtwork_s : StructPtr<libmp4v2.Internal.MP4TagArtwork_s>
    {
        public MP4TagArtwork_s()
        {
        }

        public MP4TagArtwork_s(libmp4v2.Internal.MP4TagArtwork_s value) : base(value)
        {
        }

        internal MP4TagArtwork_s(StructPtr<libmp4v2.Internal.MP4TagArtwork_s> other) : base(other)
        {
        }

        public MP4TagArtwork_s(libmp4v2.Internal.MP4TagArtwork_s[] value) : base(value)
        {
        }

        public MP4TagArtwork_s(int arraySize) : base(arraySize)
        {
        }

        public MP4TagArtwork_s(IntPtr value) : base(value)
        {
        }

        protected override StructPtr<libmp4v2.Internal.MP4TagArtwork_s> CreateInstance(IntPtr pointer)
        {
            return new libmp4v2.MP4TagArtwork_s(pointer);
        }

        public static implicit operator libmp4v2.MP4TagArtwork_s(libmp4v2.Internal.MP4TagArtwork_s value)
        {
            return new libmp4v2.MP4TagArtwork_s(value);
        }

        public static implicit operator libmp4v2.MP4TagArtwork_s(IntPtr value)
        {
            return new libmp4v2.MP4TagArtwork_s(value);
        }

        public IntPtr data
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

        public libmp4v2.MP4TagArtwork_s this[int index]
        {
            get
            {
                return (libmp4v2.MP4TagArtwork_s) base.GetAtIndex(index);
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

