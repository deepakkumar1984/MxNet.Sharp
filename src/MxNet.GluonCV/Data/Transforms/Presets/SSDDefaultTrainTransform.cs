using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class SSDDefaultTrainTransform
    {
        public SSDDefaultTrainTransform(int width, int height, NDArray anchors= null, (float, float, float)? mean = null, (float, float, float)? std = null, float iou_thresh= 0.5f, (float, float, float, float)?  box_norm = null)
        {
            throw new NotImplementedException();
        }

        public (NDArray, NDArray, NDArray) Call(NDArray arc, NDArray label)
        {
            throw new NotImplementedException();
        }
    }
}
