using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Rpn
{
    public class RPNTargetGenerator : Block
    {
        public RPNTargetGenerator(int num_sample= 256, float pos_iou_thresh= 0.7f, float neg_iou_thresh= 0.3f, float pos_ratio= 0.5f, float[] stds= null, int allowed_border= 0) : base(null, null)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
