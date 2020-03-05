using System;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class RandomContrast : HybridBlock
    {
        private readonly float _contrast;

        public RandomContrast(float contrast)
        {
            _contrast = contrast;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            var min_factor = Math.Max(0, 1 - _contrast);
            var max_factor = 1 + _contrast;

            if (x.IsNDArray)
                return nd.Image.RandomContrast(x, min_factor, max_factor);

            return sym.Image.RandomContrast(x, min_factor, max_factor);
        }
    }
}