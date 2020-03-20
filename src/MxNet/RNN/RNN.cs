using MxNet.Callbacks;
using MxNet.RecurrentLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RNN
{
    public class RNN
    {
        public static void SaveRNNCheckPoint(RNNCell[] cells, string prefix, int epoch, Symbol symbol, NDArrayDict arg_params, NDArrayDict aux_params )
        {
            throw new NotImplementedException();
        }

        public static (Symbol, NDArrayDict, NDArrayDict) LoadRNNCheckPoint(RNNCell[] cells, string prefix, int epoch)
        {
            throw new NotImplementedException();
        }
    }

    public class RNNCheckPointCallback : IEpochEndCallback
    {
        public void Invoke(int epoch, Symbol symbol, NDArrayDict arg_params, NDArrayDict aux_params)
        {
            throw new NotImplementedException();
        }
    }
}
