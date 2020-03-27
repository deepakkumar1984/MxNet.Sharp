using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV
{
    public class LRSequential : MxNet.LRScheduler
    {
        public LRSequential(LRScheduler[] schedulers)
        {
            throw new NotImplementedException();
        }

        public override float Call(uint num_update)
        {
            throw new NotImplementedException();
        }

        public void Add(LRScheduler scheduler)
        {
            throw new NotImplementedException();
        }

        public void Update(int num_update)
        {
            throw new NotImplementedException();
        }
    }
}
