namespace libmp4v2
{
    using libmp4v2.Internal;
    using PInvoker.Marshal;
    using System;
    using System.Reflection;

    public sealed class MP4ItmfData_s : StructPtr<libmp4v2.Internal.MP4ItmfData_s>
    {
        public MP4ItmfData_s()
        {
        }

        public MP4ItmfData_s(libmp4v2.Internal.MP4ItmfData_s value) : base(value)
        {
        }

        internal MP4ItmfData_s(StructPtr<libmp4v2.Internal.MP4ItmfData_s> other) : base(other)
        {
        }

        public MP4ItmfData_s(libmp4v2.Internal.MP4ItmfData_s[] value) : base(value)
        {
        }

        public MP4ItmfData_s(int arraySize) : base(arraySize)
        {
        }

        public MP4ItmfData_s(IntPtr value) : base(value)
        {
        }

        protected override StructPtr<libmp4v2.Internal.MP4ItmfData_s> CreateInstance(IntPtr pointer)
        {
            return new libmp4v2.MP4ItmfData_s(pointer);
        }

        public static implicit operator libmp4v2.MP4ItmfData_s(libmp4v2.Internal.MP4ItmfData_s value)
        {
            return new libmp4v2.MP4ItmfData_s(value);
        }

        public static implicit operator libmp4v2.MP4ItmfData_s(IntPtr value)
        {
            return new libmp4v2.MP4ItmfData_s(value);
        }

        public libmp4v2.MP4ItmfData_s this[int index]
        {
            get
            {
                return (libmp4v2.MP4ItmfData_s) base.GetAtIndex(index);
            }
        }

        public UInt32 locale
        {
            get
            {
                return base.ReadStructFromField<UInt32>(8L);
            }
            set
            {
                base.WriteStructToField<UInt32>(8L, value);
            }
        }

        public MP4ItmfBasicType typeCode
        {
            get
            {
                return base.ReadStructFromField<MP4ItmfBasicType>(4L);
            }
            set
            {
                base.WriteStructToField<MP4ItmfBasicType>(4L, value);
            }
        }

        public Byte typeSetIdentifier
        {
            get
            {
                return base.ReadStructFromField<Byte>(0L);
            }
            set
            {
                base.WriteStructToField<Byte>(0L, value);
            }
        }

        public ByteArrayPtr value
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

        public UInt32 valueSize
        {
            get
            {
                return base.ReadStructFromField<UInt32>(0x10L);
            }
            set
            {
                base.WriteStructToField<UInt32>(0x10L, value);
            }
        }
    }
}

