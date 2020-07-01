using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers.AdvancedActivations
{
    public class Softmax : Layer
    {
        public int axis;

        public Softmax(int axis = -1) : base()
        {
            this.supports_masking = true;
            this.axis = axis;
        }

        public override KerasSymbol[] Call(KerasSymbol[] inputs, FuncArgs kwargs)
        {
            List<KerasSymbol> result = new List<KerasSymbol>();
            foreach (var input in inputs)
            {
                result.Add(Activations.Softmax(input, axis));
            }

            return result.ToArray();
        }

        public override ConfigDict GetConfig()
        {
            var config = new ConfigDict {
                    {
                        "axis",
                        this.axis}};
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
