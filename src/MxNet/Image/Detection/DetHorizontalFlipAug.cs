using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class DetHorizontalFlipAug : DetAugmenter
    {
        public float Probability { get; set; }

        public DetHorizontalFlipAug(float p)
        {
            Probability = p;
        }

        public override (NDArray, NDArray) Call(NDArray src, NDArray label)
        {
            if (new Random().NextDouble() < Probability)
            {
                src = nd.Flip(src, axis: 1);
                FlipLabel(label);
            }

            return (src, label);
        }

        private void FlipLabel(NDArray label)
        {
            var tmp = 1 - label[":,1"];
            label[":,1"] = 1 - label[":,3"];
            label[":,3"] = tmp;
        }
    }
}
