using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Callbacks
{
    public interface IEpochEndCallback
    {
        void Invoke(int epoch, Symbol symbol, NDArrayDict arg_params, NDArrayDict aux_params);
    }
}
