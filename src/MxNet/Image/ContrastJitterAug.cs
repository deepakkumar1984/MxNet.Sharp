using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class ContrastJitterAug : Augmenter
    {
        public float Contrast { get; set; }

        private NDArray coef;

        public ContrastJitterAug(float contrast)
        {
            Contrast = contrast;
            coef = new NDArray(new float[] { 0.299f, 0.587f, 0.114f }).Reshape(1, 3);
        }

        public override NDArray Call(NDArray src)
        {
            var alpha = 1f + NumSharp.np.random.uniform(-Contrast, Contrast);
            var gray = src * coef;
            gray = (3.0 * (1.0 - alpha) / gray.Size) * nd.Sum(gray);
            src *= alpha;
            src += gray;
            return src;
        }
    }
}
