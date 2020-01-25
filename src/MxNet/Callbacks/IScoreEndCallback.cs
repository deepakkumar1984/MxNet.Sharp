using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Callbacks
{
    public interface IScoreEndCallback
    {
        void Invoke(int epoch, int nbatch, EvalMetric eval_metric, FuncArgs locals);
    }
}
