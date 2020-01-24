using MxNetLib.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Callbacks
{
    public class ProgressBar : IBatchEndCallback
    {
        private int total;
        private int length;
        private Logger logging;

        public ProgressBar(int total, int length= 80, Logger logger = null)
        {
            this.total = total;
            this.length = length;
            logging = logger != null ? logger : Logger.GetLogger();
        }

        public void Invoke(int epoch, int nbatch, EvalMetric eval_metric, FuncArgs locals = null)
        {
            int count = nbatch;
            int filled_len = Convert.ToInt32(length * count / (float)total);
            double percents = Math.Ceiling(100 * count / (float)total);
            string prog_bar = "";
            for (int i = 0; i < filled_len; i++)
            {
                prog_bar += "=";
            }

            for (int i = 0; i < length - filled_len; i++)
            {
                prog_bar += "-";
            }

            logging.Log(string.Format("[{0}] {1}%", prog_bar, Math.Round(percents)));
        }
    }
}
