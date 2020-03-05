using System;

namespace MxNet.Image
{
    public class DetHorizontalFlipAug : DetAugmenter
    {
        public DetHorizontalFlipAug(float p)
        {
            Probability = p;
        }

        public float Probability { get; set; }

        public override (NDArray, NDArray) Call(NDArray src, NDArray label)
        {
            if (new Random().NextDouble() < Probability)
            {
                src = nd.Flip(src, 1);
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