using System;

namespace MxNet.Image
{
    public class RandomGrayAug : Augmenter
    {
        private readonly NDArray mat;

        public RandomGrayAug(float p)
        {
            Probability = p;
            mat = new NDArray(new[] {0.21f, 0.21f, 0.21f, 0.72f, 0.72f, 0.72f, 0.07f, 0.07f, 0.07f}).Reshape(3, 3);
        }

        public float Probability { get; set; }

        public override NDArray Call(NDArray src)
        {
            if (new Random().NextDouble() < Probability)
                src = nd.Dot(src, mat);

            return src;
        }
    }
}