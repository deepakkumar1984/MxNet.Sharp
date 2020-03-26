using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class Imagenet
    {
        public static NDArrayList TransformEval(NDArrayList imgs, int resize_short= 256, int crop_size= 224, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            throw new NotImplementedException();
        }
    }
}
