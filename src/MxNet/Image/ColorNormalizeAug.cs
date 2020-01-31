using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class ColorNormalizeAug : Augmenter
    {
        public NDArray Mean { get; set; }

        public NDArray Std { get; set; }

        public ColorNormalizeAug(NDArray mean, NDArray std)
        {
            Mean = mean;
            Std = std;
        }

        public override NDArray Call(NDArray src)
        {
            return Img.ColorNormalize(src, Mean, Std);
        }
    }
}
