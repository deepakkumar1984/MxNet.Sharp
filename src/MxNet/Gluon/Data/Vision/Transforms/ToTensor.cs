namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class ToTensor : HybridBlock
    {
        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.Image.ToTensor(x);

            return sym.Image.ToTensor(x);
        }
    }
}