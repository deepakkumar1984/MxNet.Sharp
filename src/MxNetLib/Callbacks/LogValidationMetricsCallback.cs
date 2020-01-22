using MxNetLib.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Callbacks
{
    public class LogValidationMetricsCallback : IBatchEndCallback
    {
        public void Invoke(int epoch, int nbatch, EvalMetric eval_metric, FuncArgs locals = null)
        {
            throw new NotImplementedException();
        }
    }
}
