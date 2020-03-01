using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Contrib.NN
{
    public class HybridConcurrent : HybridSequential
    {
        public int Axis { get; }

        public HybridConcurrent( int axis = -1, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Axis = axis;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            List<NDArrayOrSymbol> output = new List<NDArrayOrSymbol>();

            foreach (var block in _childrens.Values)
            {
                output.Add(block.Call(x));
            }

            if (x.IsNDArray)
                return nd.Concat(output.ToNDArrays(), Axis);

            return sym.Concat(output.ToSymbols(), Axis);
        }
    }
}
