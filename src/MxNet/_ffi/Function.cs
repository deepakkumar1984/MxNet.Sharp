using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet._ffi
{
    public class Function
    {
        public IntPtr ObjectHandle;

        public static (MXNetValue[], TypeCode[], int[]) MakeMxnetArgs(List<object> args, List<object> temp_args)
        {
            throw new NotImplementedException();
        }
    }

    public class FunctionBase : IDisposable
    {
        public FunctionBase(IntPtr handle, bool is_global)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
