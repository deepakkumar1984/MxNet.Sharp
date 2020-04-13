using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Rcnn
{
    public class RCNNTargetSampler : HybridBlock
    {
        public RCNNTargetSampler(int num_image, int num_proposal, int num_sample, float pos_iou_thresh, float pos_ratio, int max_num_gt, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
