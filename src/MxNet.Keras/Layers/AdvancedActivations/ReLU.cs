using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Layers.AdvancedActivations
{
    public class ReLU : Layer
    {
        public float? max_value;

        public float negative_slope;

        public float threshold;

        public ReLU(float? max_value = null, float negative_slope = 0, float threshold = 0) : base()
        {
            if (max_value != null && max_value < 0.0)
            {
                throw new Exception(String.Format("max_value of ReLU layer cannot be negative value: " + max_value.ToString()));
            }

            if (negative_slope < 0.0)
            {
                throw new Exception(String.Format("negative_slope of ReLU layer cannot be negative value: " + negative_slope.ToString()));
            }
            this.supports_masking = true;
            if (max_value != null)
            {
                max_value = max_value.Value;
            }

            this.max_value = max_value;
            this.negative_slope = negative_slope;
            this.threshold = threshold;
        }

        public override KerasSymbol[] Invoke(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            List<KerasSymbol> result = new List<KerasSymbol>();
            foreach (var input in inputs)
            {
                result.Add(
                    K.Relu(input, alpha: this.negative_slope, max_value: this.max_value, threshold: this.threshold)
                    );
            }

            return result.ToArray();
        }

        public override ConfigDict GetConfig()
        {
            var config = new ConfigDict {
                   {
                        "max_value",
                        this.max_value},
                    {
                        "negative_slope",
                        this.negative_slope},
                    {
                        "threshold",
                        this.threshold}};
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
