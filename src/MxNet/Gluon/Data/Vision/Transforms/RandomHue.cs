using System;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class RandomHue : HybridBlock
    {
        private readonly float _hue;

        public RandomHue(float hue)
        {
            _hue = hue;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            var min_factor = Math.Max(0, 1 - _hue);
            var max_factor = 1 + _hue;

            if (x.IsNDArray)
                return nd.Image.RandomHue(x, min_factor, max_factor);

            return sym.Image.RandomHue(x, min_factor, max_factor);
        }
    }
}