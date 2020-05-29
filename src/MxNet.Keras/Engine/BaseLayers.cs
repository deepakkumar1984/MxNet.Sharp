using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Engine
{
    public class BaseLayers
    {
        public static KerasSymbol[] CollectPreviousMask(KerasSymbol[]  input_tensors)
        {
            throw new NotImplementedException();
        }

        public static string ToSnakeCase(string name)
        {
            throw new NotImplementedException();
        }

        public static Shape[] CollectInputShape(KerasSymbol[] input_tensors)
        {
            throw new NotImplementedException();
        }
    }
}
