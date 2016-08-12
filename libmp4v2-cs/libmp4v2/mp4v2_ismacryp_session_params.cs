namespace libmp4v2
{
    using libmp4v2.Internal;
    using PInvoker.Marshal;
    using System;
    using System.Reflection;

    public sealed class mp4v2_ismacryp_session_params : StructPtr<libmp4v2.Internal.mp4v2_ismacryp_session_params>
    {
        public mp4v2_ismacryp_session_params()
        {
        }

        public mp4v2_ismacryp_session_params(libmp4v2.Internal.mp4v2_ismacryp_session_params value) : base(value)
        {
        }

        internal mp4v2_ismacryp_session_params(StructPtr<libmp4v2.Internal.mp4v2_ismacryp_session_params> other) : base(other)
        {
        }

        public mp4v2_ismacryp_session_params(libmp4v2.Internal.mp4v2_ismacryp_session_params[] value) : base(value)
        {
        }

        public mp4v2_ismacryp_session_params(int arraySize) : base(arraySize)
        {
        }

        public mp4v2_ismacryp_session_params(IntPtr value) : base(value)
        {
        }

        protected override StructPtr<libmp4v2.Internal.mp4v2_ismacryp_session_params> CreateInstance(IntPtr pointer)
        {
            return new libmp4v2.mp4v2_ismacryp_session_params(pointer);
        }

        public static implicit operator libmp4v2.mp4v2_ismacryp_session_params(libmp4v2.Internal.mp4v2_ismacryp_session_params value)
        {
            return new libmp4v2.mp4v2_ismacryp_session_params(value);
        }

        public static implicit operator libmp4v2.mp4v2_ismacryp_session_params(IntPtr value)
        {
            return new libmp4v2.mp4v2_ismacryp_session_params(value);
        }

        public libmp4v2.mp4v2_ismacryp_session_params this[int index]
        {
            get
            {
                return (libmp4v2.mp4v2_ismacryp_session_params) base.GetAtIndex(index);
            }
        }

        public Byte iv_len
        {
            get
            {
                return base.ReadStructFromField<Byte>(7L);
            }
            set
            {
                base.WriteStructToField<Byte>(7L, value);
            }
        }

        public Byte key_ind_len
        {
            get
            {
                return base.ReadStructFromField<Byte>(6L);
            }
            set
            {
                base.WriteStructToField<Byte>(6L, value);
            }
        }

        public ByteArrayPtr kms_uri
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

        public UInt32 scheme_type
        {
            get
            {
                return base.ReadStructFromField<UInt32>(0L);
            }
            set
            {
                base.WriteStructToField<UInt32>(0L, value);
            }
        }

        public UInt16 scheme_version
        {
            get
            {
                return base.ReadStructFromField<UInt16>(4L);
            }
            set
            {
                base.WriteStructToField<UInt16>(4L, value);
            }
        }

        public Byte selective_enc
        {
            get
            {
                return base.ReadStructFromField<Byte>(8L);
            }
            set
            {
                base.WriteStructToField<Byte>(8L, value);
            }
        }
    }
}

