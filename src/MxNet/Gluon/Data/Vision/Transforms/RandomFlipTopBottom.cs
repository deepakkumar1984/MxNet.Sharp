namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class RandomFlipTopBottom : HybridBlock
    {
        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.Image.RandomFlipTopBottom(x);

            return sym.Image.RandomFlipTopBottom(x);
        }
    }
}