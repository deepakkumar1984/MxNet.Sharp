using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Optimizers
{
    public class Adadelta : MxNet.Optimizers.AdaDelta, IOptimizer
    {
        public Adadelta(float lr = 1, float rho = 0.95F, float epsilon = 1E-08F, float decay = 0, float? clipnorm = null) : base(lr, rho, decay, epsilon)
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
                        this.LearningRate},
                    {
                        "rho",
                        this.Rho},
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
