using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class SGLD : Optimizer
    {

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
