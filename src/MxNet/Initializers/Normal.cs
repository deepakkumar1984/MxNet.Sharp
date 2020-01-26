using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Initializers
{
    public class Normal : Initializer
    {
        public float Sigma { get; set; }

        public Normal(float sigma = 0.01f)
        {
            Sigma = sigma;
        }

        public override void InitWeight(string name, NDArray arr)
        {
            arr = nd.Random.Normal(0, Sigma, arr.Shape);
        }
    }
}
