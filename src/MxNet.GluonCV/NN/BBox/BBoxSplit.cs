using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class BBoxSplit : HybridBlock
    {
        public BBoxSplit(int axis= -1, bool squeeze_axis = false, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Axis = axis;
            SqueezeAxis = squeeze_axis;
        }

        public int Axis { get; }
        public bool SqueezeAxis { get; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new Exception("Use the other HybridForward");
        }

        public NDArrayOrSymbolList HybridForward(NDArrayOrSymbol x)
        {
            if (x.IsNDArray)
                return nd.Split(x, axis: this.Axis, num_outputs: 4, squeeze_axis: this.SqueezeAxis).NDArrayOrSymbols;

            return new NDArrayOrSymbolList(sym.Split(x, axis: this.Axis, num_outputs: 4, squeeze_axis: this.SqueezeAxis));
        }
    }
}
