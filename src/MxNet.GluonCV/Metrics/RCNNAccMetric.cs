using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Metrics
{
    public class RCNNAccMetric : EvalMetric
    {
        public RCNNAccMetric() : base("RCNNAcc", "")
        {

        }

        public override void Update(NDArray labels, NDArray preds)
        {
            throw new NotImplementedException();
        }
    }
}
