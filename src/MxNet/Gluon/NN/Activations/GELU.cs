namespace MxNet.Gluon.NN
{
    public class GELU : HybridBlock
    {
        public GELU(string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.LeakyReLU(x.NdX, act_type: ReluActType.Gelu);

            return sym.LeakyReLU(x.SymX, act_type: ReluActType.Gelu, symbol_name: "fwd");
        }
    }
}