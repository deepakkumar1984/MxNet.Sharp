using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class Ftlr : Optimizer
    {
        public Ftlr(float lamda1 = 0.1f, float learning_rate = 0.1f, float beta = 1) : base(learning_rate: learning_rate)
        {
            throw new NotImplementedException();
        }

        public override object CreateState(int index, NDArray weight)
        {
            throw new NotImplementedException();
        }

        public override void Update(int iteration, int index, NDArray param, NDArray grad, object state)
        {
            throw new NotImplementedException();
        }
    }
}
