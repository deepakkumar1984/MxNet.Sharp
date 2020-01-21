using MxNetLib.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Callbacks
{
    public interface IBatchEndCallback
    {
        void Invoke(int epoch, int nbatch, EvalMetric eval_metric, FuncArgs locals);
    }
}
