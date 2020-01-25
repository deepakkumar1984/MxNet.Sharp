using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Callbacks
{
    public interface IEvalEndCallback
    {
        void Invoke(int epoch, EvalMetric eval_metric);
    }
}
