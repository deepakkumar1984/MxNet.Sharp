namespace MxNet.Gluon.NN
{
    public class SELU : HybridBlock
    {
        public SELU(string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.LeakyReLU(x.NdX, act_type: ReluActType.Selu);

            return sym.LeakyReLU(x.SymX, act_type: ReluActType.Selu, symbol_name: "fwd");
        }
    }
}