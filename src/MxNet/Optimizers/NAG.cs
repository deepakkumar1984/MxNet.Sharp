using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class NAG : Optimizer
    {
        public NAG(float momentum = 0)
        {
            throw new NotImplementedException();
        }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            throw new NotImplementedException();
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            throw new NotImplementedException();
        }
    }
}
