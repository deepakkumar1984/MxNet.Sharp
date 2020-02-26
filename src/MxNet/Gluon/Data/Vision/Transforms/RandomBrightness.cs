using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class RandomBrightness : HybridBlock
    {
        private float _brightness;

        public RandomBrightness(float brightness)
        {
            _brightness = brightness;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            float min_factor = Math.Max(0, 1 - _brightness);
            float max_factor = 1 + _brightness;

            if (x.IsNDArray)
                return nd.Image.RandomBrightness(x, min_factor, max_factor);

            return sym.Image.RandomBrightness(x, min_factor, max_factor);
        }
    }
}
