using MxNet.Metrics;

namespace MxNet.Callbacks
{
    public interface IEvalEndCallback
    {
        void Invoke(int epoch, EvalMetric eval_metric);
    }
}