using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.NN
{
    public class ELU : HybridBlock
    {
        public float Alpha { get; set; }

        public ELU(float alpha = 1, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            if (alpha < 0)
                throw new ArgumentException("Slope coefficient for LeakyReLU must be no less than 0");

            Alpha = alpha;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.LeakyReLU(x.NdX, act_type: LeakyreluActType.Elu, slope: Alpha);

            return sym.LeakyReLU(x.SymX, act_type: LeakyreluActType.Elu, slope: Alpha, symbol_name: "fwd");
        }

    }
}
