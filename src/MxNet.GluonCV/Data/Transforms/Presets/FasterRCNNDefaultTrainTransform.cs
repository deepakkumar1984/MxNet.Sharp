using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class FasterRCNNDefaultTrainTransform
    {
        public FasterRCNNDefaultTrainTransform(int @short= 600, int max_size= 1000, HybridBlock net= null, (float, float, float)? mean = null, (float, float, float)? std = null, (float, float, float)? box_norm = null, int num_sample= 256, float pos_iou_thresh= 0.7f, float neg_iou_thresh= 0.3f, float pos_ratio= 0.5f, float flip_p= 0.5f, int ashape= 128, bool multi_stage= false)
        {
            throw new NotImplementedException();
        }

        public (NDArray, NDArray, NDArray, NDArray, NDArray) Call(NDArray src, NDArray label)
        {
            throw new NotImplementedException();
        }
    }
}
