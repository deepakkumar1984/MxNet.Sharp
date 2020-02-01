using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.NN
{
    public class PReLU : HybridBlock
    {
        public Initializer AlphaInitializer { get; set; }

        private NDArray alpha;

        public PReLU(Initializer alpha_initializer = null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            AlphaInitializer = alpha_initializer ?? new Initializers.Constant(0.25f);
            
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.LeakyReLU(x.NdX, gamma: alpha, act_type:LeakyreluActType.Prelu);

            return sym.LeakyReLU(x.SymX, gamma: alpha, act_type: LeakyreluActType.Prelu, symbol_name: "fwd");
        }
    }
}
