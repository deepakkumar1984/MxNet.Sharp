using System;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class RandomSaturation : HybridBlock
    {
        private readonly float _saturation;

        public RandomSaturation(float saturation)
        {
            _saturation = saturation;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            var min_factor = Math.Max(0, 1 - _saturation);
            var max_factor = 1 + _saturation;

            if (x.IsNDArray)
                return nd.Image.RandomSaturation(x, min_factor, max_factor);

            return sym.Image.RandomSaturation(x, min_factor, max_factor);
        }
    }
}