using MxNet.Initializers;

namespace MxNet.Gluon.NN
{
    public class Dense : HybridBlock
    {
        public Dense(int units, ActivationActType? activation = null, bool use_bias = true, bool flatten = true,
            DType dtype = null, Initializer weight_initializer = null, string bias_initializer = "zeros",
            int in_units = 0, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Units = units;
            Act = activation != null ? new Activation(activation.Value) : null;
            UseBias = use_bias;
            Flatten_ = flatten;
            DataType = dtype;
            this["weight"] = Params.Get("weight", OpGradReq.Write, new Shape(units, in_units), dtype,
                init: weight_initializer, allow_deferred_init: true);

            if (UseBias)
                this["bias"] = Params.Get("bias", OpGradReq.Write, new Shape(units), dtype,
                    init: Initializer.Get(bias_initializer), allow_deferred_init: true);
        }

        public int Units { get; set; }

        public Activation Act { get; set; }

        public bool UseBias { get; set; }

        public bool Flatten_ { get; set; }

        public DType DataType { get; set; }

        public int InUnits { get; set; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            NDArrayOrSymbol output = null;
            var weight = args[0];
            var bias = args.Length > 1 ? args[1] : null;
            if (x.IsNDArray)
                output = nd.FullyConnected(x.NdX, weight, bias, Units, !UseBias, Flatten_);

            if (x.IsSymbol)
                output = sym.FullyConnected(x.SymX, weight, bias, Units, !UseBias, Flatten_);

            if (Act != null)
                output = Act.HybridForward(output);

            return output;
        }
    }
}