using System.Collections.Generic;
using MxNet.Gluon.NN;

namespace MxNet.Gluon.Contrib.NN
{
    public class HybridConcurrent : HybridSequential
    {
        public HybridConcurrent(int axis = -1, string prefix = null, ParameterDict @params = null) : base(prefix,
            @params)
        {
            Axis = axis;
        }

        public int Axis { get; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            var output = new List<NDArrayOrSymbol>();

            foreach (var block in _childrens.Values) output.Add(block.Call(x));

            if (x.IsNDArray)
                return nd.Concat(output.ToNDArrays(), Axis);

            return sym.Concat(output.ToSymbols(), Axis);
        }
    }
}