using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV
{
    public class LRSequential : MxNet.LRScheduler
    {
        public int Count { get; set; }

        public float LearningRate { get; set; }

        public List<LRScheduler> Schedulers { get; set; }

        public List<int> UpdateStep { get; set; }

        public LRSequential(LRScheduler[] schedulers)
        {
            Debug.Assert(schedulers.Length > 0);
            this.UpdateStep = new List<int>();
            this.Count = 0;
            this.LearningRate = 0;
            this.Schedulers = schedulers.ToList();
        }

        public override float Call(uint num_update)
        {
            this.Update((int)num_update);
            return this.LearningRate;
        }

        public void Add(LRScheduler scheduler)
        {
            Debug.Assert(scheduler is LRScheduler);
            scheduler.Offset = this.Count;
            this.Count += scheduler.NIters;
            this.UpdateStep.Add(this.Count);
            this.Schedulers.Add(scheduler);
        }

        public void Update(int num_update)
        {
            num_update = Math.Min(num_update, this.Count - 1);
            var ind = this.Schedulers.Count - 1;
            foreach (var _tup_1 in this.UpdateStep.Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
            {
                var i = _tup_1.Item1;
                var sep = _tup_1.Item2;
                if (sep > num_update)
                {
                    ind = i;
                    break;
                }
            }
            var lr = this.Schedulers[ind];
            lr.Update((uint)num_update);
            this.LearningRate = lr.LearningRate;
        }
    }
}
