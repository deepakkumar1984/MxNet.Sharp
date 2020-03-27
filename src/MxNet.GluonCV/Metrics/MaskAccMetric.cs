using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Metrics
{
    public class MaskAccMetric : EvalMetric
    {
        public MaskAccMetric() : base("MaskAcc", "")
        {

        }

        public override void Update(NDArray labels, NDArray preds)
        {
            throw new NotImplementedException();
        }
    }
}
