using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using MxNet.Interop;
using CachedOpHandle = System.IntPtr;
using mx_uint = System.UInt32;
using mx_float = System.Single;
using size_t = System.UInt64;

namespace MxNet
{
    public class CachedOp : IDisposable
    {
        private CachedOpHandle handle;

        public CachedOp(Symbol sym, NDArrayDict flags)
        {
            handle = IntPtr.Zero;
            NativeMethods.MXCreateCachedOpEx(sym.GetHandle(), flags.Count, flags.Keys.ToArray(), MxUtil.GetNDArrayHandles(flags.Values.ToArray()), out handle);
        }

        public void Dispose()
        {
            if(handle != null)
                NativeMethods.MXFreeCachedOp(handle);
        }

        public NDArrayList Call(NDArrayList args)
        {
            NativeMethods.MXInvokeCachedOpEx(handle, args.Length, MxUtil.GetNDArrayHandles(args), out var num_outputs, out var outputs, out var out_stypes);
            NDArrayList result = new NDArrayList();
            for (int i = 0; i < num_outputs; i++)
            {
                result.Add(new NDArray(outputs[i]).ToSType((StorageStype)out_stypes[i]));
            }

            return result.ToArray();
        }
    }
}
