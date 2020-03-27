using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Metrics
{
    public class RPNAccMetric : EvalMetric
    {
        public RPNAccMetric() : base("RPNAcc", "")
        {

        }

        public override void Update(NDArray labels, NDArray preds)
        {
            throw new NotImplementedException();
        }
    }
}
