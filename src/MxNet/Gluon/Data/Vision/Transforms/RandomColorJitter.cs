using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class RandomColorJitter : HybridBlock
    {
        private float _brightness;
        private float _contrast;
        private float _saturation;
        private float _hue;

        public RandomColorJitter(float brightness= 0, float contrast = 0, float saturation = 0, float hue = 0)
        {
            _brightness = brightness;
            _contrast = contrast;
            _saturation = saturation;
            _hue = hue;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.Image.RandomColorJitter(x, _brightness, _contrast, _saturation, _hue);

            return sym.Image.RandomColorJitter(x, _brightness, _contrast, _saturation, _hue);
        }
    }
}
