using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Metrics
{
    public class MaskFGAccMetric : EvalMetric
    {
        public MaskFGAccMetric() : base("MaskFGAcc", "")
        {

        }

        public override void Update(NDArray labels, NDArray preds)
        {
            throw new NotImplementedException();
        }
    }
}
