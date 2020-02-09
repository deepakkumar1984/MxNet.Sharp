using System;

// ReSharper disable once CheckNamespace
namespace MxNet
{

    internal static class InteropHelper
    {

        #region Methods

        public static IntPtr[] ToPointerArray(IntPtr ptr, uint count)
        {
            unsafe
            {
                var array = new IntPtr[count];
                var p = (void**)ptr;
                for (var i = 0; i < count; i++)
                    array[i] = (IntPtr)p[i];

                return array;
            }
        }

        public static float[] ToFloatArray(IntPtr ptr, uint count)
        {
            unsafe
            {
                var array = new float[count];
                var p = (float*)ptr;
                for (var i = 0; i < count; i++)
                    array[i] = p[i];

                return array;
            }
        }

        public static int[] ToInt32Array(IntPtr ptr, int count)
        {
            unsafe
            {
                var array = new int[count];
                var p = (int*)ptr;
                for (var i = 0; i < count; i++)
                    array[i] = p[i];

                return array;
            }
        }

        public static ulong[] ToUInt64Array(IntPtr ptr, uint count)
        {
            unsafe
            {
                var array = new ulong[count];
                var p = (ulong*)ptr;
                for (var i = 0; i < count; i++)
                    array[i] = p[i];

                return array;
            }
        }

        #endregion

    }

}
