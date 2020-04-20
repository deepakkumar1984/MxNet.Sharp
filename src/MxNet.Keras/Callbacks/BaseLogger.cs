using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class BaseLogger : Callback
    {
        public int seen;

        public string[] stateful_metrics;

        public Dictionary<string, float> totals;

        public BaseLogger(string[] stateful_metrics = null)
        {
            this.stateful_metrics = stateful_metrics != null ? stateful_metrics : new string[0];
        }

        public override void OnEpochBegin(int epoch, Dictionary<string, float> logs = null)
        {
            seen = 0;
            totals = new Dictionary<string, float>();
        }

        public override void OnBatchEnd(int batch, Dictionary<string, float> logs = null)
        {
            if (logs == null)
                logs = new Dictionary<string, float>();

            var batch_size = logs.ContainsKey("size") ? (int)logs["size"] : 0;
            this.seen += batch_size;
            foreach (var log in logs)
            {
                var k = log.Key;
                var v = log.Value;
                if (this.stateful_metrics.Contains(k))
                {
                    this.totals[k] = v;
                }
                else if (this.totals.ContainsKey(k))
                {
                    this.totals[k] += v * batch_size;
                }
                else
                {
                    this.totals[k] = v * batch_size;
                }
            }
        }

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            if (logs != null)
            {
                string[] metrics = (string[])this.@params["metrics"];
                foreach (var k in metrics)
                {
                    if (this.totals.ContainsKey(k))
                    {
                        // Make value available to next callbacks.
                        if (this.stateful_metrics.Contains(k))
                        {
                            logs[k] = this.totals[k];
                        }
                        else
                        {
                            logs[k] = this.totals[k] / this.seen;
                        }
                    }
                }
            }
        }
    }
}
