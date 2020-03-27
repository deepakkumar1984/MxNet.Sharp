using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Metrics
{
    public class HeatmapAccuracy : EvalMetric
    {
        public HeatmapAccuracy(int axis = 1, string name = "heatmap_accuracy", string hm_type = "gaussian", float threshold = 0.5f, string[] output_names = null, string[] label_names = null) : base(name, output_names, label_names)
        {
            throw new NotImplementedException();
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            throw new NotImplementedException();
        }

        private NDArray CalcDists(NDArray preds, NDArray target, NDArray normalize)
        {
            throw new NotImplementedException();
        }

        private NDArray DistAcc(NDArray dists)
        {
            throw new NotImplementedException();
        }
    }
}
