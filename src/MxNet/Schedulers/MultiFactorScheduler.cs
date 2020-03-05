using System;

namespace MxNet.Schedulers
{
    public class MultiFactorScheduler : LRScheduler
    {
        public MultiFactorScheduler(int[] step, int factor = 1, float base_lr = 0.01F, int warmup_steps = 0,
            float warmup_begin_lr = 0, string warmup_mode = "linear")
            : base(base_lr, warmup_steps, warmup_begin_lr, warmup_mode)
        {
            for (var i = 0; i < step.Length; i++)
            {
                var _step = step[i];
                if (i != 0 && step[i] < step[i - 1])
                    throw new Exception("Schedule step must be an increasing integer list");
                if (_step < 1)
                    throw new Exception("Schedule step must be greater or equal than 1 round");
            }

            if (factor > 1)
                throw new Exception("Factor must be no more than 1 to make lr reduce");

            Step = step;
            Factor = factor;
            CurrStepInd = 0;
            Count = 0;
        }

        public int[] Step { get; }
        public int Factor { get; }
        public int CurrStepInd { get; private set; }
        public int Count { get; private set; }

        public override float Call(uint num_update)
        {
            if (num_update < WarmupSteps)
                return GetWarmupLR(num_update);

            while (CurrStepInd <= Step.Length - 1)
                if (num_update > Step[CurrStepInd])
                {
                    Count = Step[CurrStepInd];
                    CurrStepInd++;
                    BaseLearningRate *= Factor;
                    Logger.Info($"Update[{num_update}]: Change learning rate to {BaseLearningRate}");
                }
                else
                {
                    return BaseLearningRate;
                }

            return BaseLearningRate;
        }
    }
}