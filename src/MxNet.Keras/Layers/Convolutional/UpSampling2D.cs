using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class UpSampling2D : _UpSampling
    {
        public UpSampling2D((int, int)? size = null, string data_format = "", string interpolation = "nearest") : base(size.HasValue ? new int[] { size.Value.Item1, size.Value.Item2 } : new int[] { 2, 2 }, data_format)
        {
            throw new NotImplementedException();
        }

        public override void Call(KerasSymbol[] inputs, FuncArgs kwargs)
        {
            throw new NotImplementedException();
        }

        public override ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }
    }
}
