using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Metrics
{
    public class VOC07MApMetric : VOCMApMetric
    {
        internal override NDArray AveragePrecision(NDArray rec, NDArray prec)
        {
            throw new NotImplementedException();
        }
    }
}
