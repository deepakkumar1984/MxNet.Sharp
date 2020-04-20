using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Optimizers
{
    public class Adamax : MxNet.Optimizers.Adamax, IOptimizer
    {
        public Adamax(float lr = 0, float beta1 = 0.9F, float beta2 = 0.999F, float decay = 0, float? clipnorm = null) : base(lr, beta1, beta2)
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
                        "decay",
                        this.Decay
                }
            };
        }
    }
}
