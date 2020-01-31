using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class RandomGrayAug : Augmenter
    {
        public float Probability { get; set; }

        private NDArray mat;

        public RandomGrayAug(float p)
        {
            Probability = p;
            mat = new NDArray(new float[] { 0.21f, 0.21f, 0.21f, 0.72f, 0.72f, 0.72f, 0.07f, 0.07f, 0.07f }).Reshape(3, 3);
        }

        public override NDArray Call(NDArray src)
        {
            if (new Random().NextDouble() < Probability)
                src = nd.Dot(src, mat);

            return src;
        }
    }
}
