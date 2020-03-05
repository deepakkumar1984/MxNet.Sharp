using System;

namespace MxNet.Image
{
    public class HorizontalFlipAug : Augmenter
    {
        public HorizontalFlipAug(float p)
        {
            Probability = p;
        }

        public float Probability { get; set; }

        public override NDArray Call(NDArray src)
        {
            if (new Random().NextDouble() < Probability)
                src = nd.Flip(src, 1);

            return src;
        }
    }
}