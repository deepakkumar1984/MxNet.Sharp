using System;

namespace MxNet.Schedulers
{
    public class MultiFactorScheduler : LRScheduler
    {
        private int _MaxUpdate;
        private int _Power;
        private float _FinalLR;
        private float _BaseLrOriginal;
        private int _MaxSteps;

        public MultiFactorScheduler(int max_update, float base_lr = 0.01F, int pwr = 2, float final_lr = 0,
                    int warmup_steps = 0, float warmup_begin_lr = 0, string warmup_mode = "linear")
            : base(base_lr, warmup_steps, warmup_begin_lr, warmup_mode)
        {
            if (max_update < 1)
                throw new ArgumentException("maximum number of updates must be strictly positive");

            _MaxUpdate = max_update;
            _Power = pwr;
            _FinalLR = final_lr;
            _BaseLrOriginal = base_lr;
            _MaxSteps = max_update - warmup_steps;
        }

        public override float Call(uint num_update)
        {
            throw new NotImplementedException();
        }
    }
}
