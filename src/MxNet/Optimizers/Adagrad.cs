using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class Adagrad : Optimizer
    {
        public float Epsilon { get; set; }

        public Adagrad(float epsilon = 1e-07f)
        {
            Epsilon = epsilon;
        }

        public override Dictionary<string, NDArray> CreateState(int index, NDArray weight)
        {
            throw new NotImplementedException();
        }

        public override void Update(int index, NDArray weight, NDArray grad, Dictionary<string, NDArray> state)
        {
            throw new NotImplementedException();
        }
    }
}
