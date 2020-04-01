using System;       
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV
{
    public class LRScheduler : MxNet.LRScheduler
    {
        public float LearningRate { get; private set; }

        public string Mode { get; }

        public int NIters { get; }

        public int Offset { get; set; }

        public int Power { get; }

        public int[] Step { get; }

        public float StepFactor { get; }

        public float TargetLr { get; }

        public LRScheduler(string mode, float base_lr= 0.1f, float target_lr= 0, int niters= 0, int nepochs= 0, int iters_per_epoch= 0,int  offset= 0,
                            int power= 2, int[] step_iter= null, int[] step_epoch= null, float step_factor= 0.1f, float? baselr= null, float? targetlr= null)
        {
            Debug.Assert(new List<string> {
                    "constant",
                    "step",
                    "linear",
                    "poly",
                    "cosine"
                }.Contains(mode));
            this.Mode = mode;
            if (mode == "step")
            {
                Debug.Assert(step_iter != null || step_epoch != null);
            }

            if (baselr != null)
            {
                Logger.Warning("baselr is deprecated. Please use base_lr.");
                if (base_lr == 0.1)
                {
                    base_lr = baselr.Value;
                }
            }

            this.BaseLearningRate = base_lr;
            if (targetlr != null)
            {
                Logger.Warning("targetlr is deprecated. Please use target_lr.");
                if (target_lr == 0)
                {
                    target_lr = targetlr.Value;
                }
            }

            this.TargetLr = target_lr;
            if (this.Mode == "constant")
            {
                this.TargetLr = this.BaseLearningRate;
            }
            this.NIters = niters;
            this.Step = step_iter;
            var epoch_iters = nepochs * iters_per_epoch;
            if (epoch_iters > 0)
            {
                this.NIters = epoch_iters;
                if (step_epoch != null)
                {
                    this.Step = (from s in step_epoch
                                 select (s * iters_per_epoch)).ToArray();
                }
            }
            this.Offset = offset;
            this.Power = power;
            this.StepFactor = step_factor;
        }

        public override float Call(uint num_update)
        {
            this.Update(num_update);
            return this.LearningRate;
        }

        public void Update(uint num_update)
        {
            float factor;
            var N = this.NIters - 1;
            var T = num_update - this.Offset;
            T = Math.Min(Math.Max(0, T), N);
            if (this.Mode == "constant")
            {
                factor = 0;
            }
            else if (this.Mode == "linear")
            {
                factor = 1 - T / N;
            }
            else if (this.Mode == "poly")
            {
                factor = (float)Math.Pow(1 - T / N, this.Power);
            }
            else if (this.Mode == "cosine")
            {
                factor = (float)(1 + Math.Cos(Math.PI * T / N)) / 2;
            }
            else if (this.Mode == "step")
            {
                if (this.Step != null)
                {
                    var count = (from s in this.Step
                                 where s <= T
                                 select 1).ToList().Sum();
                    factor = (float)Math.Pow(this.StepFactor, count);
                }
                else
                {
                    factor = 1;
                }
            }
            else
            {
                throw new NotImplementedException();
            }
            if (this.Mode == "step")
            {
                this.LearningRate = this.BaseLearningRate * factor;
            }
            else
            {
                this.LearningRate = this.TargetLr + (this.BaseLearningRate - this.TargetLr) * factor;
            }
        }
    }
}
