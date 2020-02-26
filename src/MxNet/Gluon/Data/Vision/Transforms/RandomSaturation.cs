using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class RandomSaturation : HybridBlock
    {
        private float _saturation;

        public RandomSaturation(float saturation)
        {
            _saturation = saturation;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            float min_factor = Math.Max(0, 1 - _saturation);
            float max_factor = 1 + _saturation;

            if (x.IsNDArray)
                return nd.Image.RandomSaturation(x, min_factor, max_factor);

            return sym.Image.RandomSaturation(x, min_factor, max_factor);
        }
    }
}
