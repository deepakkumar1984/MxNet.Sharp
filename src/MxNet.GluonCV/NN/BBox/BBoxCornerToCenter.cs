using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN.BBox
{
    public class BBoxCornerToCenter : HybridBlock
    {
        public BBoxCornerToCenter(int axis = -1, bool split = false) : base(null, null)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
