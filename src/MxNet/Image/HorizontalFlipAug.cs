using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class HorizontalFlipAug : Augmenter
    {
        public float Probability { get; set; }

        public HorizontalFlipAug(float p)
        {
            Probability = p;
        }

        public override NDArray Call(NDArray src)
        {
            if (new Random().NextDouble() < Probability)
                src = nd.Flip(src, axis: 1);

            return src;
        }
    }
}
