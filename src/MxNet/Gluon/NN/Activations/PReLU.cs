using MxNet.Initializers;

namespace MxNet.Gluon.NN
{
    public class PReLU : HybridBlock
    {
        private NDArray alpha;

        public PReLU(Initializer alpha_initializer = null, string prefix = null, ParameterDict @params = null) : base(
            prefix, @params)
        {
            AlphaInitializer = alpha_initializer ?? new Initializers.Constant(0.25f);
        }

        public Initializer AlphaInitializer { get; set; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.LeakyReLU(x.NdX, alpha, LeakyreluActType.Prelu);

            return sym.LeakyReLU(x.SymX, alpha, LeakyreluActType.Prelu, symbol_name: "fwd");
        }
    }
}