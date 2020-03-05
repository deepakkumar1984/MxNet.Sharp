using System;
namespace MxNet.Schedulers
{
    public class PolyScheduler : LRScheduler
    {
        public int MaxUpdate { get; }
        public int Power { get; }
        public float FinalLr { get; }
        public float BaseLrOrig { get; }
        public int MaxSteps { get; }

        public PolyScheduler(int max_update, float base_lr = 0.01F, int pwr = 2, float final_lr = 0, int warmup_steps = 0,
                                float warmup_begin_lr = 0, string warmup_mode = "linear")
            : base(base_lr, warmup_steps, warmup_begin_lr, warmup_mode)
        {
            if (max_update < 1)
                throw new ArgumentException("maximum number of updates must be strictly positive");
            MaxUpdate = max_update;
            Power = pwr;
            FinalLr = final_lr;
            BaseLrOrig = base_lr;
            MaxSteps = max_update - warmup_steps;
        }

        public override float Call(uint num_update)
        {
            if (num_update < WarmupSteps)
                return GetWarmupLR(num_update);
    
            if(num_update <= MaxUpdate)
            {
                BaseLearningRate = FinalLr + (BaseLrOrig - FinalLr) * (float)Math.Pow(1 - (num_update - WarmupSteps) / MaxSteps, Power);
            }

            return BaseLearningRate;
        }
    }
}
