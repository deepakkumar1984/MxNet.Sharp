using System;

namespace MxNet.Gluon.NN
{
    public class Activation : HybridBlock
    {
        public Activation(ActivationType activation, string prefix = null, ParameterDict @params = null) : base(
            prefix, @params)
        {
            ActType = activation;
        }

        public ActivationType ActType { get; set; }

        public override string Alias()
        {
            return Enum.GetName(typeof(ActivationType), ActType);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.Activation(x.NdX, ActType);

            return sym.Activation(x.SymX, ActType, "fwd");
        }

        public override string ToString()
        {
            return Prefix + Alias();
        }
    }
}