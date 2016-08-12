namespace libmp4v2
{
    using libmp4v2.Internal;
    using PInvoker.Marshal;
    using System;
    using System.Reflection;

    public sealed class MP4TagTrack : StructPtr<libmp4v2.Internal.MP4TagTrack_s>
    {
        public MP4TagTrack()
        {
        }

        public MP4TagTrack(libmp4v2.Internal.MP4TagTrack_s value) : base(value)
        {
        }

        internal MP4TagTrack(StructPtr<libmp4v2.Internal.MP4TagTrack_s> other) : base(other)
        {
        }

        public MP4TagTrack(libmp4v2.Internal.MP4TagTrack_s[] value) : base(value)
        {
        }

        public MP4TagTrack(int arraySize) : base(arraySize)
        {
        }

        public MP4TagTrack(IntPtr value) : base(value)
        {
        }

        protected override StructPtr<libmp4v2.Internal.MP4TagTrack_s> CreateInstance(IntPtr pointer)
        {
            return new MP4TagTrack(pointer);
        }

        public static implicit operator MP4TagTrack(libmp4v2.Internal.MP4TagTrack_s value)
        {
            return new MP4TagTrack(value);
        }

        public static implicit operator MP4TagTrack(IntPtr value)
        {
            return new MP4TagTrack(value);
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

        public MP4TagTrack this[int index]
        {
            get
            {
                return (MP4TagTrack) base.GetAtIndex(index);
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

