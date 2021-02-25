using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet._ffi
{
    public class MXNetValue
    {
        public Dictionary<string, Type> _fields_ = new Dictionary<string, Type>() {
            { "v_int64", typeof(long)},
            { "v_float64", typeof(double) },
            { "v_handle", typeof(IntPtr)},
            { "v_str", typeof(string) }
        };

        public static Dictionary<TypeCode, Type> RETURN_SWITCH = new Dictionary<TypeCode, Type>()
        {
            { TypeCode.INT, typeof(long) },
            { TypeCode.FLOAT, typeof(double) },
            { TypeCode.NULL, typeof(Nullable) },
            { TypeCode.NDARRAYHANDLE, typeof(IntPtr) }
        };
    }
}
