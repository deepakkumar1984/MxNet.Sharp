using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class EarlyStopping : Callback
    {
        public float? baseline;

        public float best;

        public NDArrayList best_weights;

        public float min_delta;

        public string monitor;

        public Func<float, float, bool> monitor_op;

        public int patience;

        public bool restore_best_weights;

        public int stopped_epoch;

        public int verbose;

        public int wait;

        public EarlyStopping(string monitor= "val_loss", float min_delta= 0, int patience= 0, int verbose= 0, string mode= "auto",
                 float? baseline= null, bool restore_best_weights= false)
        {
            this.monitor = monitor;
            this.baseline = baseline;
            this.patience = patience;
            this.verbose = verbose;
            this.min_delta = min_delta;
            this.wait = 0;
            this.stopped_epoch = 0;
            this.restore_best_weights = restore_best_weights;
            this.best_weights = null;
            if (!new List<string> {
                "auto",
                "min",
                "max"
            }.Contains(mode))
            {
                Logger.Warning($"EarlyStopping mode {mode} is unknown, fallback to auto mode.");
                mode = "auto";
            }

            if (mode == "min")
            {
                this.monitor_op = Lesser;
            }
            else if (mode == "max")
            {
                this.monitor_op = Greater;
            }
            else if (this.monitor.Contains("acc"))
            {
                this.monitor_op = Greater;
            }
            else
            {
                this.monitor_op = Lesser;
            }

            if (this.monitor_op == Greater)
            {
                this.min_delta *= 1;
            }
            else
            {
                this.min_delta *= -1;
            }
        }

        private bool Lesser(float l, float r) => l < r;

        private bool Greater(float l, float r) => l > r;

        public override void OnTrainBegin(Dictionary<string, float> logs = null)
        {
            this.wait = 0;
            this.stopped_epoch = 0;
            if (this.baseline != null)
            {
                this.best = this.baseline.Value;
            }
            else
            {
                this.best = this.monitor_op == Lesser ? float.PositiveInfinity : float.NegativeInfinity;
            }
        }

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            var current = this.GetMonitorValue(logs);
            if (current == null)
            {
                return;
            }

            if (this.monitor_op(current.Value - this.min_delta, this.best))
            {
                this.best = current.Value;
                this.wait = 0;
                if (this.restore_best_weights)
                {
                    this.best_weights = this.model.GetWeights();
                }
            }
            else
            {
                this.wait += 1;
                if (this.wait >= this.patience)
                {
                    this.stopped_epoch = epoch;
                    this.model.stop_training = true;
                    if (this.restore_best_weights)
                    {
                        if (this.verbose > 0)
                        {
                            Console.WriteLine("Restoring model weights from the end of the best epoch");
                        }

                        this.model.SetWeights(this.best_weights);
                    }
                }
            }
        }

        public override void OnTrainEnd(Dictionary<string, float> logs = null)
        {
            if (this.stopped_epoch > 0 && this.verbose > 0)
            {
                Console.WriteLine($"Epoch {stopped_epoch + 1}: early stopping");
            }
        }

        public float? GetMonitorValue(Dictionary<string, float> logs)
        {
            float? monitor_value = null;
            if (logs.ContainsKey(monitor))
                monitor_value = logs[this.monitor];

            if (monitor_value == null)
            {
                Logger.Warning($"Early stopping conditioned on metric `{monitor}` which is not available. Available metrics are: {string.Join(",", logs.Keys)}");
            }

            return monitor_value;
        }
    }
}
