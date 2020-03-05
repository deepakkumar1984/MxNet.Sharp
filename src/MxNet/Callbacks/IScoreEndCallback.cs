using MxNet.Metrics;

namespace MxNet.Callbacks
{
    public interface IScoreEndCallback
    {
        void Invoke(int epoch, int nbatch, EvalMetric eval_metric, FuncArgs locals);
    }
}