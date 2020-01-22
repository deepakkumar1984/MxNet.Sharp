using MxNetLib.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Callbacks
{
    public class ProgressBar : IBatchEndCallback
    {
        public ProgressBar(int total, int length= 80)
        {
            throw new NotImplementedException();
        }

        public void Invoke(int epoch, int nbatch, EvalMetric eval_metric, FuncArgs locals = null)
        {
            throw new NotImplementedException();
        }
    }
}
