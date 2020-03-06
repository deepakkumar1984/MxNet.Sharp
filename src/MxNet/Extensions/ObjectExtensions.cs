using System;
using System.Runtime.InteropServices;

namespace MxNet
{
    public static class ObjectExtensions
    {
        public static string ToValueString(this object source)
        {
            return source is bool b ? b ? "1" : "0" : source.ToString();
        }

        public static IntPtr GetMemPtr(this object src)
        {
            if (src.GetType().Name == "NDArray")
                return ((NDArray)src).NativePtr;

            if (src.GetType().Name == "Symbol")
                return ((Symbol)src).NativePtr;

            GCHandle handle = GCHandle.Alloc(src, GCHandleType.Pinned);
            IntPtr pointer = GCHandle.ToIntPtr(handle);
            handle.Free();
            return pointer;
        }
    }
}