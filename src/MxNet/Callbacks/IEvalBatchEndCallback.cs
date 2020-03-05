using MxNet.Metrics;

namespace MxNet.Callbacks
{
    public interface IEvalBatchEndCallback
    {
        void Invoke(int epoch, int nbatch, EvalMetric eval_metric);
    }
}