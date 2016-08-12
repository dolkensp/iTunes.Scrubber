namespace libmp4v2
{
    using PInvoker.Marshal;
    using System;
    using System.Runtime.InteropServices;

    public class va_list : ByteArrayPtr
    {
        public va_list()
        {
        }

        internal va_list(ByteArrayPtr ptr1) : base(ptr1)
        {
        }

        public va_list([In] byte[] array) : base(array)
        {
        }

        public va_list([In] int size) : base(size)
        {
        }

        public va_list([In] IntPtr pointer) : base(pointer)
        {
        }

        public va_list([In] string value) : base(value)
        {
        }

        public static implicit operator va_list(byte[] buffer1)
        {
            if (buffer1 == null)
            {
                return null;
            }
            return new va_list(buffer1);
        }

        public static implicit operator va_list(string text1)
        {
            if (text1 == null)
            {
                return null;
            }
            return new va_list(text1);
        }
    }
}

