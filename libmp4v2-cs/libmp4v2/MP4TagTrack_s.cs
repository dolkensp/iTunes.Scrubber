namespace libmp4v2
{
    using libmp4v2.Internal;
    using PInvoker.Marshal;
    using System;
    using System.Reflection;

    public sealed class MP4TagTrack_s : StructPtr<libmp4v2.Internal.MP4TagTrack_s>
    {
        public MP4TagTrack_s()
        {
        }

        public MP4TagTrack_s(libmp4v2.Internal.MP4TagTrack_s value) : base(value)
        {
        }

        internal MP4TagTrack_s(StructPtr<libmp4v2.Internal.MP4TagTrack_s> other) : base(other)
        {
        }

        public MP4TagTrack_s(libmp4v2.Internal.MP4TagTrack_s[] value) : base(value)
        {
        }

        public MP4TagTrack_s(int arraySize) : base(arraySize)
        {
        }

        public MP4TagTrack_s(IntPtr value) : base(value)
        {
        }

        protected override StructPtr<libmp4v2.Internal.MP4TagTrack_s> CreateInstance(IntPtr pointer)
        {
            return new libmp4v2.MP4TagTrack_s(pointer);
        }

        public static implicit operator libmp4v2.MP4TagTrack_s(libmp4v2.Internal.MP4TagTrack_s value)
        {
            return new libmp4v2.MP4TagTrack_s(value);
        }

        public static implicit operator libmp4v2.MP4TagTrack_s(IntPtr value)
        {
            return new libmp4v2.MP4TagTrack_s(value);
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

        public libmp4v2.MP4TagTrack_s this[int index]
        {
            get
            {
                return (libmp4v2.MP4TagTrack_s) base.GetAtIndex(index);
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

