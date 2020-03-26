using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class SSDDefaultValTransform
    {
        public SSDDefaultValTransform(int width, int height, (float, float, float)? mean = null, (float, float, float)? std = null, float iou_thresh = 0.5f)
        {
            throw new NotImplementedException();
        }

        public (NDArray, NDArray) Call(NDArray arc, NDArray label)
        {
            throw new NotImplementedException();
        }
    }
}
