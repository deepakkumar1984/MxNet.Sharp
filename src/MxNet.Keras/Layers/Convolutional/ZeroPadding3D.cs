using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class ZeroPadding3D : _ZeroPadding
    {
        public ZeroPadding3D((int, int, int)? padding = null, string data_format = "")
           : base(padding.HasValue ? new int[] { padding.Value.Item1, padding.Value.Item2, padding.Value.Item3 } : new int[] { 1, 1, 1 }, data_format)
        {
            throw new NotImplementedException();
        }

        public override KerasSymbol[] Call(KerasSymbol[] inputs, FuncArgs kwargs)
        {
            throw new NotImplementedException();
        }
    }
}
