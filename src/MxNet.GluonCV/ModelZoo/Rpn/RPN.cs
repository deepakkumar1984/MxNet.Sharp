using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Rpn
{
    public class RPN : HybridBlock
    {
        public RPN(int channels, int strides, int base_size, float[] scales, float ratios, (int, int) alloc_size, float clip, float nms_thresh, int train_pre_nms, int train_post_nms,
                 int test_pre_nms, int test_post_nms, int min_size, bool multi_level= false, bool per_level_nms= false, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public int GetTestPostNms() => throw new NotImplementedException();
    }
}
