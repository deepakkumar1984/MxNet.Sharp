using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.AMP
{
    public class Amp
    {
        public static NDArrayOrSymbol CastSymbolNDArray(NDArrayOrSymbol s, DType dtype, bool is_numpy_module = false)
        {
            throw new NotImplementedException();
        }

        public static (string, Type[]) GetNdFuncToWrap(string name, Type module, Dictionary<string, object> submodule_dict)
        {
            throw new NotImplementedException();
        }

        public static (string, Type[]) GetNpFuncToWrap(string name, Type module, Dictionary<string, object> submodule_dict)
        {
            throw new NotImplementedException();
        }
    }
}
