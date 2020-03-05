namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class RandomFlipLeftRight : HybridBlock
    {
        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.Image.RandomFlipLeftRight(x);

            return sym.Image.RandomFlipLeftRight(x);
        }
    }
}