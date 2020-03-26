using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms
{
    public class VideoGroupTrainTransform : Block
    {
        public VideoGroupTrainTransform((int, int) size, float[] scale_ratios, float mean, float std, bool fix_crop= true, bool more_fix_crop= true, int max_distort= 1, float prob= 0.5f, float max_intensity= 255) : base(null, null)
        {
            throw new NotImplementedException();
        }

        public int[] FillFixOffset(int datum_height, int datum_width)
        {
            throw new NotImplementedException();
        }

        public int[] FillCropSize(int input_height, int input_width)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
