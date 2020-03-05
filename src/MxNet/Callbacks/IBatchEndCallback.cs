using MxNet.Metrics;

namespace MxNet.Callbacks
{
    public interface IBatchEndCallback
    {
        void Invoke(int epoch, int nbatch, EvalMetric eval_metric, FuncArgs locals = null);
    }
}