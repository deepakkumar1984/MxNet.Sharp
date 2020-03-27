using CocoTools.NET;
using MxNet;
using MxNet.GluonCV.Data;
using MxNet.IO;
using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Metrics
{
    public class COCOInstanceMetric : EvalMetric
    {
        public COCOInstanceMetric(COCOInstance dataset, string save_prefix, bool use_time = true, bool cleanup = false, bool use_ext = false, int starting_id = 0, float score_thresh = 0.05f) : base("COCOInstance", "")
        {
            throw new NotImplementedException();
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            throw new NotImplementedException();
        }

        public NDArrayList GetResultBuffer()
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public void DumpJson()
        {
            throw new NotImplementedException();
        }

        private NDArray GetAp(COCOEval coco_eval)
        {
            throw new NotImplementedException();
        }

        private (string[], string[]) Update(string annType = "bbox")
        {
            throw new NotImplementedException();
        }

        public new (string[], string[]) Get()
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, object> EncodeMask(COCOMask mask)
        {
            throw new NotImplementedException();
        }

        public void update(NDArray pred_bboxes, NDArray pred_labels, NDArray pred_scores, NDArray pred_masks)
        {
            throw new NotImplementedException();
        }
    }
}
