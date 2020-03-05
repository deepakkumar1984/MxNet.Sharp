namespace MxNet.Gluon.NN
{
    public class Swish : HybridBlock
    {
        public Swish(float beta = 1, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Beta = beta;
        }

        public float Beta { get; set; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.Sigmoid(x.NdX * Beta);

            return sym.Sigmoid(x.SymX * Beta, "fwd");
        }
    }
}