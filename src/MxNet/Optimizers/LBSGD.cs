using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class LBSGD : Optimizer
    {
        public LBSGD(float momentum= 0, bool multi_precision= false, string warmup_strategy= "linear'",
                    int warmup_epochs= 5, int batch_scale= 1, int updates_per_epoch= 32, int begin_epoch= 0, int num_epochs= 60)
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
