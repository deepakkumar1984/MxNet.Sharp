using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Layers.AdvancedActivations
{
    public class LeakyReLU : Layer
    {
        public float alpha;

        public LeakyReLU(float alpha = 0.3f) : base()
        {
            this.supports_masking = true;
            this.alpha = alpha;
        }

        public override KerasSymbol[] Call(KerasSymbol[] inputs, FuncArgs kwargs)
        {
            List<KerasSymbol> result = new List<KerasSymbol>();
            foreach (var input in inputs)
            {
                result.Add(K.Relu(input, alpha));
            }

            return result.ToArray();
        }

        public override ConfigDict GetConfig()
        {
            var config = new ConfigDict
            {
                {
                    "alpha",
                    this.alpha
                }
            };

            var base_config = base.GetConfig();
            base_config.Update(config);
            return base_config;
        }

        public override Shape[] ComputeOutputShape(Shape[] input_shape)
        {
            return input_shape;
        }
    }
}
