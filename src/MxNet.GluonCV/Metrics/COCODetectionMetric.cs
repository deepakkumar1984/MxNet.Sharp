using MxNet;
using MxNet.GluonCV.Data;
using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Metrics
{
    public class COCODetectionMetric : EvalMetric
    {
        public COCODetectionMetric(COCODetection dataset, string save_prefix, bool use_time = true, bool cleanup= false, float score_thresh= 0.05f, Shape data_shape= null, Func<int, int, int, int, int[]> post_affine= null, string output_name = null, string label_name = null, bool has_global_stats = false) : base("COCOMeanAP", output_name, label_name, has_global_stats)
        {
            throw new NotImplementedException();
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            throw new NotImplementedException();
        }
    }
}
