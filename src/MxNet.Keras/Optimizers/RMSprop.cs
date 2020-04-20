using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Optimizers
{
    public class RMSprop : MxNet.Optimizers.RMSProp, IOptimizer
    {
        public RMSprop(float lr = 0.001f,
                float rho = 0.9f,
                float epsilon = 1E-08f,
                float decay = 0,
                float? clipnorm = null)
                : base(learning_rate: lr, gamma1: rho, epsilon: epsilon, clip_weights: clipnorm)
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
                        "rho",
                        this.Gamma1},
                    {
                        "decay",
                        this.Decay},
                    {
                        "epsilon",
                        this.Epsilon
                }
            };
        }
    }
}
