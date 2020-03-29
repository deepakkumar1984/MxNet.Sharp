using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Ssd
{
    public class SSDAnchorGenerator : HybridBlock
    {
        public int NumDepth => throw new NotImplementedException();

        public SSDAnchorGenerator(int index, (int, int) im_size, float[] sizes, float[] ratios, int step, (int, int)? alloc_size= null, (float, float)? offsets= null, bool clip= false, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private NDArray GenerateAnchors((int, int) sizes, float[] ratios, int step, (int, int) alloc_size, (float, float) offsets)
        {
            throw new NotImplementedException();
        }
    }
}
