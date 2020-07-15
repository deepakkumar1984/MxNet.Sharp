using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Layers
{
    public class Lambda : Layer
    {
        private Shape _output_shape;

        public FuncArgs arguments;

        public Func<KerasSymbol, FuncArgs, KerasSymbol> function;

        public KerasSymbol mask;

        public Lambda(Func<KerasSymbol, FuncArgs, KerasSymbol> function, Shape output_shape = null, KerasSymbol mask = null, FuncArgs arguments = null)
        {
            this.function = function;
            this.arguments = arguments != null ? arguments : new FuncArgs();
            if (mask != null)
            {
                this.supports_masking = true;
            }

            this.mask = mask;
            this._output_shape = output_shape;
        }

        public override KerasSymbol[] Invoke(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            List<KerasSymbol> result = new List<KerasSymbol>();

            if (function.Method.GetParameters().Select(c => (c.Name)).Contains("mask"))
            {
                arguments["mask"] = mask;
            }
            foreach (var input in inputs)
            {
                result.Add(this.function(input, arguments));
            }

            return result.ToArray();
        }

        public override Shape[] ComputeOutputShape(Shape[] input_shapes)
        {
            List<Shape> result = new List<Shape>();
            foreach (var item in input_shapes)
            {
                result.Add(ComputeOutputShape(item));
            }

            return result.ToArray(); ;
        }

        public Shape ComputeOutputShape(Shape input_shape)
        {
            int num_samples;
            if (this._output_shape == null)
            {
                var x = K.Placeholder(shape: input_shape);
                x = this.Invoke(new KerasSymbol[] { x }, null)[0];
                return x.Shape;
            }
            else
            {
                num_samples = input_shape[0];
                var shape = _output_shape;
                shape.Insert(0, num_samples);
                return shape;
            }
        }

        public override ConfigDict GetConfig()
        {
            object function_type;
            string str_function;
            str_function = Encoding.UTF8.GetString(this.function.Method.GetMethodBody().GetILAsByteArray());
            function_type = "lambda";

            var config = new ConfigDict() { 
                    {
                        "function",
                        str_function},
                    {
                        "function_type",
                        function_type},
                    {
                        "output_shape",
                        _output_shape},
                    {
                        "output_shape_type",
                        "raw"},
                    {
                        "arguments",
                        this.arguments}};
            var base_config = base.GetConfig();
            base_config.Update(config);
            return base_config;
        }

        public static new Layer FromConfig(string cls, ConfigDict config, CustomObjects custom_objects = null)
        {
            throw new NotImplementedException();
        }
    }
}
