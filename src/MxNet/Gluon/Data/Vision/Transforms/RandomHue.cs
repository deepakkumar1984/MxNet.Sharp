using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class RandomHue : HybridBlock
    {
        private float _hue;

        public RandomHue(float hue)
        {
            _hue = hue;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            float min_factor = Math.Max(0, 1 - _hue);
            float max_factor = 1 + _hue;

            if (x.IsNDArray)
                return nd.Image.RandomHue(x, min_factor, max_factor);

            return sym.Image.RandomHue(x, min_factor, max_factor);
        }
    }
}
