using MxNet.Keras.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class ProgbarLogger : Callback
    {
        public int epochs;

        public Dictionary<string, float> log_values;

        public Progbar progbar;

        public int seen;

        public string[] stateful_metrics;

        public int target;

        public bool use_steps;

        public int verbose;

        public ProgbarLogger(string count_mode = "samples", string[] stateful_metrics = null)
        {
            if (count_mode == "samples")
            {
                this.use_steps = false;
            }
            else if (count_mode == "steps")
            {
                this.use_steps = true;
            }
            else
            {
                throw new Exception("Unknown `count_mode`: " + count_mode.ToString());
            }

            if (stateful_metrics != null)
            {
                this.stateful_metrics = stateful_metrics;
            }
            else
            {
                this.stateful_metrics = new string[0];
            }
        }

        public override void OnTrainBegin(Dictionary<string, float> logs = null)
        {
            this.verbose = (int)this.@params["verbose"];
            this.epochs = (int)this.@params["epochs"];
        }

        public override void OnEpochBegin(int epoch, Dictionary<string, float> logs = null)
        {
            if (this.verbose > 0)
            {
                Console.WriteLine(String.Format("Epoch %d/%d", epoch + 1, this.epochs));
                if (this.use_steps)
                {
                    target = (int)this.@params["steps"];
                } 
                else {
                    target = (int)this.@params["samples"];
                }
                this.progbar = new Progbar(target: this.target, verbose: this.verbose, stateful_metrics: this.stateful_metrics);
            }

            this.seen = 0;
        }

        public override void OnBatchBegin(int batch, Dictionary<string, float> logs = null)
        {
            if (this.seen < this.target)
            {
                this.log_values = new Dictionary<string, float>();
            }
        }

        public override void OnBatchEnd(int batch, Dictionary<string, float> logs = null)
        {
            logs = logs != null ? logs : new Dictionary<string, float>();

            var batch_size = logs.ContainsKey("size") ? (int)logs["size"] : 0;
            if (this.use_steps)
            {
                this.seen += 1;
            }
            else
            {
                this.seen += batch_size;
            }

            string[] metrics = (string[])this.@params["metrics"];
            foreach (var k in metrics)
            {
                if (logs.ContainsKey(k))
                {
                    this.log_values.Add(k, logs[k]);
                }
            }

            // Skip progbar update for the last batch;
            // will be handled by on_epoch_end.
            if (this.verbose > 0 && this.seen < this.target) {
                this.progbar.Update(this.seen, this.log_values);
}
}

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            logs = logs != null ? logs : new Dictionary<string, float>();
            string[] metrics = (string[])this.@params["metrics"];
            foreach (var k in metrics)
            {
                if (logs.ContainsKey(k))
                {
                    this.log_values.Add(k, logs[k]);
                }
            }
            if (this.verbose > 0)
            {
                this.progbar.Update(this.seen, this.log_values);
            }
        }
    }
}

