using System;       
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV
{
    public class LRScheduler : MxNet.LRScheduler
    {
        public LRScheduler(string mode, float base_lr= 0.1f, float target_lr= 0, int niters= 0, int nepochs= 0, int iters_per_epoch= 0,int  offset= 0,
                            int power= 2, int[] step_iter= null, int[] step_epoch= null, float step_factor= 0.1f, float? baselr= null, float? targetlr= null)
        {
            throw new NotImplementedException();
        }

        public override float Call(uint num_update)
        {
            throw new NotImplementedException();
        }

        public void Update(uint num_update)
        {
            throw new NotImplementedException();
        }
    }
}
