using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class DCASGD : Optimizer
    {
        public DCASGD(float momentum= 0, float lamda= 0.04f)
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
