using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms
{
    public class VideoMultiScaleCrop : Block
    {
        public VideoMultiScaleCrop((int, int) size, float[] scale_ratios, bool fix_crop= true, bool more_fix_crop= true, int max_distort= 1) : base(null, null)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
