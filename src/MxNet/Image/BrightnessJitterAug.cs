using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class BrightnessJitterAug : Augmenter
    {
        public float Brightness { get; set; }

        public BrightnessJitterAug(float brightness)
        {
            Brightness = brightness;
        }

        public override NDArray Call(NDArray src)
        {
            var alpha = 1f + NumSharp.np.random.uniform(-Brightness, Brightness);
            src *= alpha;
            return src;
        }
    }
}
