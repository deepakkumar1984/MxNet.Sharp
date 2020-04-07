using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras
{
    internal class Models
    {
        public static Model CloneFunctionalModel(Model model, KerasSymbol[] input_tensors = null)
        {
            throw new NotImplementedException();
        }

        public static Sequential CloneSequentialModel(Sequential model, KerasSymbol[] input_tensors = null)
        {
            throw new NotImplementedException();
        }

        public static T CloneModel<T>(T model, KerasSymbol[] input_tensors = null)
        {
            throw new NotImplementedException();
        }
    }
}
