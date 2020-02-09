using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.NN
{
    public class LayerNorm : HybridBlock
    {
        public int Axis { get; }
        public float Epsilon { get; }
        public bool Center { get; }
        public bool Scale { get; }
        public int In_Channels { get; }
        public Parameter Gamma { get; set; }
        public Parameter Beta { get; set; }

        public LayerNorm(int axis = 1, float epsilon = 1e-5f, bool center = true, bool scale = false,
                        string beta_initializer = "zeros", string gamma_initializer = "ones",
                        int in_channels = 0, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Axis = axis;
            Epsilon = epsilon;
            Center = center;
            Scale = scale;
            In_Channels = in_channels;
            Gamma = Params.Get("gamma", scale ? OpGradReq.Write : OpGradReq.Null, new Shape(in_channels), init: Initializer.Get(gamma_initializer), allow_deferred_init: true);
            Beta = Params.Get("beta", center ? OpGradReq.Write : OpGradReq.Null, new Shape(in_channels), init: Initializer.Get(beta_initializer), allow_deferred_init: true);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            NDArrayOrSymbol gamma = args[0];
            NDArrayOrSymbol beta = args[1];

            if (x.IsNDArray)
                return nd.InstanceNorm(x.NdX, gamma.NdX, beta.NdX, Epsilon);

            return sym.InstanceNorm(x.SymX, gamma.SymX, beta.SymX, Epsilon, symbol_name: "fwd");
        }
    }
}
