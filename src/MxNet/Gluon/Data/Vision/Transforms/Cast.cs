namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class Cast : HybridBlock
    {
        private readonly DType _dtype;

        public Cast(DType dtype = null)
        {
            _dtype = dtype;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.Cast(x, _dtype);

            return sym.Cast(x, _dtype);
        }
    }
}