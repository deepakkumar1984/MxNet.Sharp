namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class RandomLighting : HybridBlock
    {
        private readonly float _alpha;

        public RandomLighting(float alpha)
        {
            _alpha = alpha;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.Image.RandomLighting(x, _alpha);

            return sym.Image.RandomLighting(x, _alpha);
        }
    }
}