using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class YOLO3DefaultTrainTransform
    {
        public YOLO3DefaultTrainTransform(int width, int height, HybridBlock net = null, (float, float, float)? mean = null, (float, float, float)? std = null, float iou_thresh = 0.5f)
        {
            throw new NotImplementedException();
        }

        public (NDArray, NDArray, NDArray, NDArray, NDArray, NDArray, NDArray) Call(NDArray arc, NDArray label)
        {
            throw new NotImplementedException();
        }
    }
}
