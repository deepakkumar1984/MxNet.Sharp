using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Layers
{
    public class Reshape : Layer
    {
        public Shape target_shape;

        public Reshape(Shape target_shape)
        {
            this.target_shape = target_shape;
        }

        private Shape FixUnknownDimension(Shape input_shape, Shape output_shape)
        {
            var msg = "total size of new array must be unchanged";
            var known = 1;
            int unknown = -1;
            for(int index = 0; index < output_shape.Dimension; index++)
            {
                var dim = output_shape[index];
                if (dim < 0)
                {
                    if (unknown == -1)
                    {
                        unknown = index;
                    }
                    else
                    {
                        throw new Exception("Can only specify one unknown dimension.");
                    }
                }
                else
                {
                    known *= dim;
                }
            }

            var original = input_shape.Size;
            if (unknown != -1)
            {
                if (known == 0 || original % known != 0)
                {
                    throw new Exception(msg);
                }

                output_shape[unknown] = original / known;
            }
            else if (original != known)
            {
                throw new Exception(msg);
            }

            return output_shape;
        }

        public override KerasSymbol[] Call(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            List<KerasSymbol> result = new List<KerasSymbol>();
            foreach (var input in inputs)
            {
                List<int> data = new List<int>();
                data.Add(K.Shape(input)[0]);
                data.AddRange(target_shape.Data);
                result.Add(K.Reshape(input, new Shape(data)));
            }

            return result.ToArray();
        }

        public override ConfigDict GetConfig()
        {
            var config = new ConfigDict {
                    {
                        "target_shape",
                        this.target_shape}};
            var base_config = base.GetConfig();
            base_config.Update(config);
            return base_config;
        }

        public override Shape[] ComputeOutputShape(Shape[] input_shapes)
        {
            Shape[] result = input_shapes;
            int i = 0;
            foreach (var input_shape in input_shapes)
            {
                if (input_shape.Data.Skip(1).Contains(-1))
                {
                    List<int> data = new List<int>();
                    data.Add(input_shape[0]);
                    data.AddRange(from s in this.target_shape.Data
                                  select s != -1 ? s : 0);
                    result[i] = new Shape(data);
                }
                else
                {
                    // input shape known? then we can compute the output shape
                    List<int> data = new List<int>();
                    data.Add(input_shape[0]);
                    data.AddRange(FixUnknownDimension(new Shape(input_shape.Data.Skip(1).ToList()), target_shape).Data);
                    result[i] = new Shape(data);
                }
            }

            return result;
        }
    }
}
