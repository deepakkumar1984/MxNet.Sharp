using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Optimizers
{
    public class SGD : MxNet.Optimizers.SGD, IOptimizer
    {
        public float Lr { get; set; }
        public float Decay { get; set; }

        private int aggregate_num = 1;

        public SGD(float lr = 0.01f, float momentum = 0, float decay = 0, bool nesterov = false, float? clipnorm = null) : base(lr, momentum)
        {
            Lr = lr;
            Decay = decay;
            ClipGradient = clipnorm;
        }

        public override float GetLr(int index)
        {
            return base.GetLr(index);
        }

        public override float[] GetLrs(int[] indices)
        {
            return base.GetLrs(indices);
        }

        public ConfigDict GetConfig()
        {
            var config = new ConfigDict {
                    {
                        "lr",
                        this.Lr},
                    {
                        "momentum",
                        this.momentum},
                    {
                        "decay",
                        this.Decay
                }
            };

            return config;
        }
    }
}
