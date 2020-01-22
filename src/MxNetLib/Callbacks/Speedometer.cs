using MxNetLib.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Callbacks
{
    public class Speedometer : IBatchEndCallback
    {
        public Speedometer(int batch_size, int frequent= 50, bool auto_reset= true)
        {
            throw new NotImplementedException();
        }

        public void Invoke(int epoch, int nbatch, EvalMetric eval_metric, FuncArgs locals = null)
        {
            throw new NotImplementedException();
        }
    }
}
