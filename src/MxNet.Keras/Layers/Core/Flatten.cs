using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Layers
{
    public class Flatten : Layer
    {
        public string data_format;

        public Flatten(string data_format = "")
        {
            this.input_spec = new InputSpec[] { new InputSpec(min_ndim: 3) };
            this.data_format = K.NormalizeDataFormat(data_format);
        }

        public override KerasSymbol[] Call(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            List<KerasSymbol> result = new List<KerasSymbol>();
            foreach (var input in inputs)
            {
                if (this.data_format == "channels_first")
                {
                    // Ensure works for any dim
                    var permutation = new List<int> {
                        0
                    };
                    permutation.AddRange((from i in Enumerable.Range(2, K.NDim(input) - 2)
                                        select i).ToList());
                    permutation.Add(1);
                    result.Add(K.PermuteDimensions(input, new Shape(permutation)));
                }
                else
                {
                    result.Add(K.BatchFlatten(input));
                }
            }

            return result.ToArray();
        }

        public override ConfigDict GetConfig()
        {
            var config = new ConfigDict {
                     {
                        "data_format",
                        this.data_format}};
            var base_config = base.GetConfig();
            base_config.Update(config);
            return base_config;
        }

        public override Shape[] ComputeOutputShape(Shape[] input_shapes)
        {
            List<Shape> result = new List<Shape>();
            foreach (var input_shape in input_shapes)
            {
                if (!input_shape.Data.Skip(1).All(x => x > 0))
                {
                    throw new Exception("The shape of the input to \"Flatten\" is not fully defined (got " + input_shape + ". Make sure to pass a complete \"input_shape\" or \"batch_input_shape\" argument to the first layer in your model.");
                }

                result.Add((input_shape[0], input_shape.Data.Skip(1).Aggregate((a, b) => a * b)));
            }

            return result.ToArray();
        }
    }
}
