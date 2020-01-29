using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Contrib.NN
{
    public class PixelShuffle2D : HybridBlock
    {
        public PixelShuffle2D((int, int) factor) : base(null, null)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
