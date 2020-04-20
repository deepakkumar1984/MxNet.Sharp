using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class ModelCheckpoint : Callback
    {
        public float best;

        public int epochs_since_last_save;

        public string filepath;

        public string monitor;

        public Func<float, float, bool> monitor_op;

        public int period;

        public bool save_best_only;

        public bool save_weights_only;

        public int verbose;

        public ModelCheckpoint(string filepath, string monitor= "val_loss", int verbose= 0, bool save_best_only= false, bool save_weights_only= false, string mode= "auto", int period= 1)
        {
            this.monitor = monitor;
            this.verbose = verbose;
            this.filepath = filepath;
            this.save_best_only = save_best_only;
            this.save_weights_only = save_weights_only;
            this.period = period;
            this.epochs_since_last_save = 0;
            if (!new List<string> {
                "auto",
                "min",
                "max"
            }.Contains(mode))
            {
                Logger.Warning($"ModelCheckpoint mode {mode} is unknown, fallback to auto mode.");
                mode = "auto";
            }

            if (mode == "min")
            {
                this.monitor_op = Lesser;
                this.best = float.PositiveInfinity;
            }
            else if (mode == "max")
            {
                this.monitor_op = Greater;
                this.best = float.NegativeInfinity;
            }
            else if (this.monitor.Contains("acc") || this.monitor.StartsWith("fmeasure"))
            {
                this.monitor_op = Greater;
                this.best = float.NegativeInfinity;
            }
            else
            {
                this.monitor_op = Lesser;
                this.best = float.NegativeInfinity;
            }
        }

        private bool Lesser(float l, float r) => l < r;

        private bool Greater(float l, float r) => l > r;

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            logs = logs != null ? logs : new Dictionary<string, float>();
            this.epochs_since_last_save += 1;
            if (this.epochs_since_last_save >= this.period)
            {
                this.epochs_since_last_save = 0;
                var filepath = string.Format(this.filepath, epoch);
                if (this.save_best_only)
                {
                    float? current = null;
                    if (logs.ContainsKey(monitor))
                        current = logs[this.monitor];

                    if (current == null)
                    {
                        Logger.Warning($"Unable to calculate the metric for determining the best model. Can save best model only with {monitor} available, skipping.");
                    }
                    else if (this.monitor_op(current.Value, this.best))
                    {
                        if (this.verbose > 0)
                        {
                            Console.WriteLine($"\nEpoch {epoch + 1}: {monitor} improved from {best} to {current}, saving model to {filepath}");
                        }

                        this.best = current.Value;
                        if (this.save_weights_only)
                        {
                            this.model.SaveWeights(filepath, overwrite: true);
                        }
                        else
                        {
                            this.model.Save(filepath, overwrite: true);
                        }
                    }
                    else if (this.verbose > 0)
                    {
                        Console.WriteLine($"\nEpoch {epoch + 1}: {monitor} did not improve from {best}");
                    }
                }
                else
                {
                    if (this.verbose > 0)
                    {
                        Console.WriteLine($"\nEpoch {epoch + 1}: saving model to {filepath}");
                    }
                    if (this.save_weights_only)
                    {
                        this.model.SaveWeights(filepath, overwrite: true);
                    }
                    else
                    {
                        this.model.Save(filepath, overwrite: true);
                    }
                }
            }
        }
    }
}
