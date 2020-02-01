using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.NN
{
    public class ReflectionPad2D : HybridBlock
    {
        public int Padding { get; }
        public ReflectionPad2D(int padding = 0, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Padding = padding;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.Pad(x.NdX, PadMode.Reflect, new Shape(Padding));

            return sym.Pad(x.SymX, PadMode.Reflect, new Shape(Padding));
        }
    }
}
