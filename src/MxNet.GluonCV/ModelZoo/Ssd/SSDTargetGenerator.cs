using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Ssd
{
    public class SSDTargetGenerator : Block
    {
        public SSDTargetGenerator(float iou_thresh= 0.5f, float neg_thresh= 0.5f, float negative_mining_ratio= 3, float[] stds = null) : base(null, null)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
