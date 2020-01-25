using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Callbacks
{
    public class LogValidationMetricsCallback : IEvalEndCallback
    {
        private Logger logging;

        public LogValidationMetricsCallback(Logger logger = null)
        {
            logging = logger != null ? logger : Logger.GetLogger();
        }

        public void Invoke(int epoch, EvalMetric eval_metric)
        {
            if(eval_metric ==null)
            {
                return;
            }

            var name_value = eval_metric.GetNameValue();
            foreach (var item in name_value)
            {
                logging.Log(string.Format("Epoch[{0}] Validation-{1}={2}", epoch, item.Item1, Math.Round(item.Item2, 2)));
            }
        }
    }
}
