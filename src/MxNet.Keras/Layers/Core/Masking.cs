using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Layers
{
    public class Masking : Layer
    {
        public float mask_value;

        public Masking(float mask_value = 0)
        {
            this.supports_masking = true;
            this.mask_value = mask_value;
        }

        public override KerasSymbol[] Call(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            List<KerasSymbol> result = new List<KerasSymbol>();

            foreach (var input in inputs)
            {
                var maskValue = K.Constant(mask_value, input.DType, input.Shape);
                var boolean_mask = K.Any(K.NotEqual(input, maskValue), axis: -1, keepdims: true);
                result.Add(input * K.Cast(boolean_mask, K.DataType(input)));
            }

            return result.ToArray();
        }

        public override KerasSymbol[] ComputeMask(KerasSymbol[] inputs, KerasSymbol[] mask = null)
        {
            List<KerasSymbol> result = new List<KerasSymbol>();
            
            foreach (var input in inputs)
            {
                var maskValue = K.Constant(mask_value, input.DType, input.Shape);
                var output_mask = K.Any(K.NotEqual(input, maskValue), axis: -1);
                result.Add(output_mask);
            }
            
            return result.ToArray();
        }

        public override ConfigDict GetConfig()
        {
            var config = new ConfigDict {
                    {
                        "mask_value",
                        this.mask_value}};
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
