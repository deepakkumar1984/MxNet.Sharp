using MxNetLib.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Callbacks
{
    public interface IEvalEndCallback
    {
        void Invoke(EvalMetric eval_metric);
    }
}
