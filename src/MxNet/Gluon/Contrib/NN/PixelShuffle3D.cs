using System;

namespace MxNet.Gluon.Contrib.NN
{
    public class PixelShuffle3D : HybridBlock
    {
        public PixelShuffle3D((int, int, int) factor)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}