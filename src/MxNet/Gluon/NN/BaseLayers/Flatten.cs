namespace MxNet.Gluon.NN
{
    public class Flatten : HybridBlock
    {
        public Flatten(string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.Flatten(x.NdX);

            return sym.Flatten(x.SymX, "fwd");
        }
    }
}