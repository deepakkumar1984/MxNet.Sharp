using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Layers.AdvancedActivations
{
    public class ThresholdedReLU : Layer
    {
        public float theta;

        public ThresholdedReLU(float theta = 0.3f) : base()
        {
            this.supports_masking = true;
            this.theta = theta;
        }

        public override KerasSymbol[] Call(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            List<KerasSymbol> result = new List<KerasSymbol>();
            foreach (var input in inputs)
            {
                result.Add(input * K.Cast(K.Greater(inputs[0], this.theta), K.FloatX()));
            }

            return result.ToArray();
        }

        public override ConfigDict GetConfig()
        {
            var config = new ConfigDict {
                    {
                        "theta",
                        this.theta}};
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
