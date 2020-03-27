using CocoTools.NET;
using MxNet.GluonCV.Data;
using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Metrics
{
    public class COCOKeyPointsMetric : EvalMetric, IDisposable
    {
        public COCOKeyPointsMetric(COCODetection dataset, string save_prefix, bool use_time = true, bool cleanup = false, float score_thresh = 0.05f, Shape data_shape = null, string[] output_names = null) : base("COCOMeanAP", output_names)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Update(NDArray preds, NDArray maxvals, NDArray score, NDArray imgid)
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public override (string, float) Get()
        {
            throw new NotImplementedException();
        }

        private COCOEval _Update()
        {
            throw new NotImplementedException();
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            throw new Exception("Use Update(NDArray preds, NDArray maxvals, NDArray score, NDArray imgid) method");
        }
    }
}
