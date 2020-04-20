using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Optimizers
{
    public class Nadam : MxNet.Optimizers.Nadam, IOptimizer
    {
        public Nadam(float lr = 0.001F, float beta1 = 0.9F, float beta2 = 0.999F, float epsilon = 1E-08F, float decay = 0, float? clipnorm = null, float schedule_decay = 0.004F) : base(lr, beta1, beta2, epsilon, schedule_decay)
        {
            Lr = lr;
            Decay = decay;
            ClipGradient = clipnorm;
        }

        public float Lr { get; set; }
        public float Decay { get; set; }

        public ConfigDict GetConfig()
        {
            return new ConfigDict{
                    {
                        "lr",
                        this.Lr},
                    {
                        "beta_1",
                        this.Beta1},
                    {
                        "beta_2",
                        this.Beta2},
                    {
                        "epsilon",
                        this.Epsilon},
                    {
                        "schedule_decay",
                        this.ScheduleDecay
                }
            };
        }
    }
}
