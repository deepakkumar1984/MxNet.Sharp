using System;
using MxNet.Metrics;

namespace MxNet.Callbacks
{
    public class ProgressBar : IBatchEndCallback
    {
        private readonly int length;
        private readonly int total;

        public ProgressBar(int total, int length = 80)
        {
            this.total = total;
            this.length = length;
        }

        public void Invoke(int epoch, int nbatch, EvalMetric eval_metric, FuncArgs locals = null)
        {
            var count = nbatch;
            var filled_len = Convert.ToInt32(length * count / (float) total);
            var percents = Math.Ceiling(100 * count / (float) total);
            var prog_bar = "";
            for (var i = 0; i < filled_len; i++) prog_bar += "=";

            for (var i = 0; i < length - filled_len; i++) prog_bar += "-";

            Logger.Log(string.Format("[{0}] {1}%", prog_bar, Math.Round(percents)));
        }
    }
}