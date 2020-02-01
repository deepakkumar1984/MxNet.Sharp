using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.NN
{
    public class Dense : HybridBlock
    {
        public int Units { get; set; }

        public Activation Act { get; set; }

        public bool UseBias { get; set; }

        public bool Flatten_ { get; set; }

        public DType DataType { get; set; }

        public NDArray Weight { get; set; }

        public NDArray Bias { get; set; }

        public int InUnits { get; set; }

        public Dense(int units, ActivationActType? activation = null, bool use_bias = true, bool flatten = true,
                    DType dtype = null, string weight_initializer = null, string bias_initializer = "zeros",
                    int in_units = 0, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Units = units;
            Act = activation != null ? new Activation(activation.Value) : null;
            UseBias = use_bias;
            Flatten_ = flatten;
            DataType = dtype;
            Weight = Params.Get("weight", new Shape((uint)units, (uint)in_units), Initializer.Get(weight_initializer), dtype, true);

            if(UseBias)
                Bias = Params.Get("bias", new Shape((uint)units), Initializer.Get(bias_initializer), dtype, true);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            NDArrayOrSymbol output = null;
            NDArrayOrSymbol weight = args[0];
            NDArrayOrSymbol bias = args[1];
            if (x.IsNDArray)
                output = nd.FullyConnected(x.NdX, weight.NdX, bias.NdX, Units, !UseBias, Flatten_);

            if (x.IsSymbol)
                output = sym.FullyConnected(x.SymX, weight.SymX, bias.SymX, Units, !UseBias, Flatten_);

            if (Act != null)
                output = Act.HybridForward(output);

            return output;
        }
    }
}
