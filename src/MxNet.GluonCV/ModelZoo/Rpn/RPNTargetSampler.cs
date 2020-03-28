using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Rpn
{
    public class RPNTargetSampler
    {
        public RPNTargetSampler(int num_sample, float pos_iou_thresh, float neg_iou_thresh, float pos_ratio)
        {
            throw new NotImplementedException();
        }

        public (NDArray, NDArray) Call((int, int) ious)
        {
            throw new NotImplementedException();
        }
    }
}
