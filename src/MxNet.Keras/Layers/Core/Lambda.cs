using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class Lambda : Layer
    {
        public Lambda(Func<KerasSymbol, KerasSymbol> function, Shape output_shape = null, KerasSymbol mask = null, FuncArgs arguments = null)
        {
            throw new NotImplementedException();
        }

        public override void Call(KerasSymbol[] inputs, FuncArgs kwargs)
        {
            throw new NotImplementedException();
        }

        public override Shape ComputeOutputShape(Shape input_shape)
        {
            return base.ComputeOutputShape(input_shape);
        }

        public override ConfigDict GetConfig()
        {
            return base.GetConfig();
        }

        public static new Layer FromConfig(string cls, ConfigDict config, CustomObjects custom_objects = null)
        {
            throw new NotImplementedException();
        }
    }
}
