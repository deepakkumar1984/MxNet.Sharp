using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class ZeroPadding2D : _ZeroPadding
    {
        public ZeroPadding2D((int, int)? padding = null, string data_format = "") 
            : base(padding.HasValue ? new int[] { padding.Value.Item1, padding.Value.Item2 } : new int[] {1, 1 }, data_format)
        {
            throw new NotImplementedException();
        }

        public override KerasSymbol[] Invoke(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            throw new NotImplementedException();
        }
    }
}
