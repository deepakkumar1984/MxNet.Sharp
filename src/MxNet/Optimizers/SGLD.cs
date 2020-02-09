using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class SGLD : Optimizer
    {

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
