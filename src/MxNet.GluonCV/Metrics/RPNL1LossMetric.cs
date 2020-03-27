using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Metrics
{
    public class RPNL1LossMetric : EvalMetric
    {
        public RPNL1LossMetric() : base("RPNL1Loss", "")
        {

        }

        public override void Update(NDArray labels, NDArray preds)
        {
            throw new NotImplementedException();
        }
    }
}
