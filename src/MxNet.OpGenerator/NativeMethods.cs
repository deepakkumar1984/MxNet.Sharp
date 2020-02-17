using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.OpGenerator
{
    static class NativeMethods
    {        /// Return Type: int
             ///out_size: mx_uint*
             ///out_array: AtomicSymbolCreator**
        [DllImport("libmxnet", EntryPoint = "MXSymbolListAtomicSymbolCreators",CallingConvention = CallingConvention.Cdecl)]
        public static extern int MXSymbolListAtomicSymbolCreators(out uint outSize,
            out IntPtr outArrayPtr);

        /// Return Type: int
        ///creator: AtomicSymbolCreator->void*
        ///name: char**
        ///description: char**
        ///num_args: mx_uint*
        ///arg_names: char***
        ///arg_type_infos: char***
        ///arg_descriptions: char***
        ///key_var_num_args: char**
        ///return_type: char**
        [DllImport("libmxnet", EntryPoint = "MXSymbolGetAtomicSymbolInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MXSymbolGetAtomicSymbolInfo(IntPtr creator,
          [Out]out IntPtr name,
          [Out]out IntPtr description,
          [Out]out uint numArgs,
          [Out]out IntPtr argNames,
          [Out]out IntPtr argTypeInfos,
          [Out]out IntPtr argDescriptions,
          [Out]out IntPtr keyVarNumArgs,
          [Out]out IntPtr returnType);
    }
}
