using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class SaturationJitterAug : Augmenter
    {
        public float Saturation { get; set; }

        private NDArray coef;

        public SaturationJitterAug(float saturation)
        {
            Saturation = saturation;
            coef = new NDArray(new float[] { 0.299f, 0.587f, 0.114f }).Reshape(1, 3);
        }

        public override NDArray Call(NDArray src)
        {
            var alpha = 1f + NumSharp.np.random.uniform(-Saturation, Saturation);
            var gray = src * coef;
            gray = nd.Sum(gray, axis: 2, keepdims: true);
            gray *= (1 - alpha);
            src *= gray;
            src += gray;
            return src;
        }
    }
}
