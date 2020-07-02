using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Layers
{
    public class Permute : Layer
    {
        public Shape dims;

        public Permute(Shape dims)
        {
            this.dims = dims;
            this.input_spec = new InputSpec[] { new InputSpec(ndim: this.dims.Dimension + 1) };
        }

        public override KerasSymbol[] Call(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            var shape = this.dims.Data.ToList();
            shape.Insert(0, 0);
            List<KerasSymbol> result = new List<KerasSymbol>();
            foreach (var input in inputs)
            {
                result.Add(K.PermuteDimensions(input, new Shape(shape)));
            }

            return result.ToArray();
        }

        public override ConfigDict GetConfig()
        {
            var config = new ConfigDict {
                     {
                        "dims",
                        this.dims}};
            var base_config = base.GetConfig();
            base_config.Update(config);
            return base_config;
        }

        public override Shape[] ComputeOutputShape(Shape[] input_shapes)
        {
            Shape[] result = input_shapes;
            foreach (var input_shape in input_shapes)
            {
                var output_shape = input_shape;
                for(int i = 0;i<dims.Dimension;i++)
                {
                    var dim = dims[i];
                    var target_dim = input_shape[dim];
                    output_shape[i + 1] = target_dim;
                    result[i] = output_shape;
                }
            }

            return result;
        }
    }
}
