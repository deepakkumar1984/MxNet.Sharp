using System;
using System.Collections.Generic;

namespace MxNet
{
    public abstract class LRScheduler
    {
        #region Constructors

        protected LRScheduler(float base_lr = 0.01f, int warmup_steps = 0, float warmup_begin_lr = 0,
            string warmup_mode = "linear")
        {
            BaseLearningRate = base_lr;
            WarmupFinalLr = base_lr;
            WarmupSteps = warmup_steps;
            WarmupBeginLr = warmup_begin_lr;
            WarmupMode = warmup_mode;

            if (warmup_begin_lr > WarmupFinalLr)
                throw new Exception("Base lr has to be higher than warmup_begin_lr");

            if (WarmupSteps < 0)
                throw new Exception("Warmup steps has to be positive or 0");

            if (!new List<string> {"linear", "constant"}.Contains(warmup_mode))
                throw new Exception("Supports only linear and constant modes of warmup");
        }

        #endregion

        #region Properties

        internal float BaseLearningRate { get; set; }

        public int WarmupSteps { get; }
        public float WarmupBeginLr { get; }
        public float WarmupFinalLr { get; }
        public string WarmupMode { get; }

        #endregion

        #region Methods

        public float GetWarmupLR(uint num_update)
        {
            if (num_update >= WarmupSteps)
                throw new Exception("num_update should be less than WarmupSteps");

            if (WarmupMode == "linear")
            {
                var increase = (WarmupFinalLr - WarmupBeginLr) * num_update / WarmupSteps;
                return WarmupBeginLr + increase;
            }

            if (WarmupMode == "constant")
                return WarmupBeginLr;
            throw new Exception("Invalid warmup mode");
        }

        public abstract float Call(uint num_update);

        #endregion
    }
}