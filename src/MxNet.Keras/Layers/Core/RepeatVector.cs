using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Layers
{
    public class RepeatVector : Layer
    {
        public int n;

        public RepeatVector(int n)
        {
            this.n = n;
            this.input_spec = new InputSpec[] { new InputSpec(ndim: 2) };
        }

        public override KerasSymbol[] Invoke(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            List<KerasSymbol> result = new List<KerasSymbol>();

            foreach (var input in inputs)
            {
                result.Add(K.Repeat(input, this.n));
            }

            return result.ToArray();
        }

        public override ConfigDict GetConfig()
        {
            var config = new ConfigDict {
                     {
                        "n",
                        this.n}};
            var base_config = base.GetConfig();
            base_config.Update(config);
            return base_config;
        }

        public override Shape[] ComputeOutputShape(Shape[] input_shape)
        {
            List<Shape> result = new List<Shape>();
            foreach (var item in input_shape)
            {
                var d = item.Data.ToList();
                d.Insert(1, n);
                result.Add(new Shape(d));
            }

            return result.ToArray();
        }
    }
}
