namespace MxNet.Gluon.NN
{
    public class Dropout : HybridBlock
    {
        public Dropout(float rate, Shape axes = null, string prefix = null, ParameterDict @params = null) : base(prefix,
            @params)
        {
            Rate = rate;
            Axes = axes;
        }

        public float Rate { get; set; }

        public Shape Axes { get; set; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (Rate > 0)
            {
                if (x.IsNDArray)
                    return nd.Dropout(x.NdX, Rate, axes: Axes);

                if (x.IsSymbol)
                    return sym.Dropout(x.SymX, Rate, axes: Axes, cudnn_off: false, symbol_name: "fwd");
            }

            return x;
        }
    }
}