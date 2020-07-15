using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class UpSampling1D : _UpSampling
    {
        public UpSampling1D(int size = 2) : base(new int[] { size }, "channels_last")
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
