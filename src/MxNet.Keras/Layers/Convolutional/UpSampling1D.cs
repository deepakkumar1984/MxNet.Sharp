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
