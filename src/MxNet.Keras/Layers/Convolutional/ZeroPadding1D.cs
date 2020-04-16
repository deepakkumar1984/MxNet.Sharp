using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class ZeroPadding1D : _ZeroPadding
    {
        public ZeroPadding1D(int padding = 1, string data_format = "") : base(new int[] { padding }, data_format)
        {
            throw new NotImplementedException();
        }

        public override ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }

        public override void Call(KerasSymbol[] inputs, FuncArgs kwargs)
        {
            throw new NotImplementedException();
        }
    }
}
