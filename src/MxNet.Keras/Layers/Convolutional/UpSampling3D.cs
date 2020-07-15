using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class UpSampling3D : _UpSampling
    {
        public UpSampling3D((int, int, int)? size = null, string data_format = "") : base(size.HasValue ? new int[] { size.Value.Item1, size.Value.Item2, size.Value.Item3 } : new int[] { 2, 2, 2 }, data_format)
        {
            throw new NotImplementedException();
        }

        public override KerasSymbol[] Invoke(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            throw new NotImplementedException();
        }

        public override ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }
    }
}
