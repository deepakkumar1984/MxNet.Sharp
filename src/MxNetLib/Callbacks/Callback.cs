using MxNetLib.Metrics;
using MxNetLib.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Callbacks
{
    public class ModuleCheckpoint : IIterEndCallback
    {
        public ModuleCheckpoint(BaseModule mod, string prefix, int period = 1, bool save_optimizer_states = false)
        {
            throw new NotImplementedException();
        }

        public void Invoke(int epoch, Symbol symbol, Dictionary<string, NDArray> arg_params, Dictionary<string, NDArray> aux_params)
        {
            throw new NotImplementedException();
        }
    }


    public class DoCheckPoint : IEpochEndCallback
    {
        public DoCheckPoint(string prefix, int period = 1)
        {
            throw new NotImplementedException();
        }

        public void Invoke(int epoch, Symbol symbol, Dictionary<string, NDArray> arg_params, Dictionary<string, NDArray> aux_params)
        {
            throw new NotImplementedException();
        }
    }

    public class LogTrainMetric : IIterEpochCallback
    {
        public LogTrainMetric(int period, bool auto_reset = false)
        {
            throw new NotImplementedException();
        }

        public void Invoke(int epoch, int nbatch, EvalMetric eval_metric, FuncArgs locals = null)
        {
            throw new NotImplementedException();
        }
    }
}
