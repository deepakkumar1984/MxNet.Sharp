using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Initializers
{
    public class Uniform : Initializer
    {
        public float Scale { get; set; }

        public Uniform(float scale = 0.07f)
        {
            Scale = scale;
        }

        public override void InitWeight(string name, ref NDArray arr)
        {
            arr = nd.Random.Uniform(-Scale, Scale, arr.Shape);
        }
    }
}
