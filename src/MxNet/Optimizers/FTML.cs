using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class FTML : Optimizer
    {
        public FTML(float beta1 = 0.6f, float beta2= 0.999f, float epsilon= 1e-8f)
        {
            throw new NotImplementedException();
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
