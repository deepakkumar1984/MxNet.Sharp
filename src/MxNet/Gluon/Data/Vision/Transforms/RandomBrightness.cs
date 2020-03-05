using System;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class RandomBrightness : HybridBlock
    {
        private readonly float _brightness;

        public RandomBrightness(float brightness)
        {
            _brightness = brightness;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            var min_factor = Math.Max(0, 1 - _brightness);
            var max_factor = 1 + _brightness;

            if (x.IsNDArray)
                return nd.Image.RandomBrightness(x, min_factor, max_factor);

            return sym.Image.RandomBrightness(x, min_factor, max_factor);
        }
    }
}