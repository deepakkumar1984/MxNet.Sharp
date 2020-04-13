using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Rpn
{
    public class RPNAnchorGenerator : HybridBlock
    {
        public int NumDepth
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public RPNAnchorGenerator(int stride, (int, int) base_size, float[] ratios, float[] scales, (int, int) alloc_size, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private NDArrayList GenerateAnchors(int stride, (int, int) base_size, float[] ratios, float[] scales, (int, int) alloc_size)
        {
            throw new NotImplementedException();
        }

        public static NDArray GenerateBaseAnchors(int stride= 16, int[] sizes= null, float[] aspect_ratios= null)
        {
            throw new NotImplementedException();
        }

        private static NDArray _generate_base_anchors(int base_size, NDArray scales, NDArray aspect_ratios)
        {
            throw new NotImplementedException();
        }

        private static (NDArray, NDArray, NDArray, NDArray) Whctrs(NDArray anchor)
        {
            throw new NotImplementedException();
        }

        private static NDArray MKAnchors(NDArray ws, NDArray hs, NDArray x_ctr, NDArray y_ctr)
        {
            throw new NotImplementedException();
        }

        private static NDArray RatioEnum(NDArray achor, NDArray ratios)
        {
            throw new NotImplementedException();
        }

        private static NDArray ScaleEnum(NDArray achor, NDArray scales)
        {
            throw new NotImplementedException();
        }
    }
}
