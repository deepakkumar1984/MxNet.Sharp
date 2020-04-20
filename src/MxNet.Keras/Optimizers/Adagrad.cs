using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Optimizers
{
    public class Adagrad : MxNet.Optimizers.AdaGrad, IOptimizer
    {
        public Adagrad(float lr = 0.01f, float eps = 1e-08F, float decay = 0, float? clipnorm = null) : base(lr, epsilon: eps)
        {
            Lr = lr;
            Decay = decay;
            ClipGradient = clipnorm;
        }

        public float Lr { get; set; }
        public float Decay { get; set; }

        public ConfigDict GetConfig()
        {
            var config = new ConfigDict {
                    {
                        "lr",
                        this.Lr
                    },
                    {
                        "decay",
                        this.Decay},
                    {
                        "epsilon",
                        this.Epsilon
                }
            };

            return config;
        }
    }
}
