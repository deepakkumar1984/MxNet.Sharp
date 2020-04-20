using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class ReduceLROnPlateau : Callback
    {
        public float best;

        public int cooldown;

        public int cooldown_counter;

        public float factor;

        public float min_delta;

        public float min_lr;

        public string mode;

        public string monitor;

        public Func<float, float, bool> monitor_op;

        public int patience;

        public int verbose;

        public int wait;

        public ReduceLROnPlateau(string monitor= "val_loss", float factor= 0.1f, int patience= 10, int verbose= 0, string mode= "auto", float min_delta= 1e-4f, int cooldown= 0, float min_lr= 0)
        {
            this.monitor = monitor;
            if (factor >= 1.0)
            {
                throw new Exception("ReduceLROnPlateau does not support a factor >= 1.0.");
            }
            
            this.factor = factor;
            this.min_lr = min_lr;
            this.min_delta = min_delta;
            this.patience = patience;
            this.verbose = verbose;
            this.cooldown = cooldown;
            this.cooldown_counter = 0;
            this.wait = 0;
            this.best = 0;
            this.mode = mode;
            this.monitor_op = null;
            this.Reset();
        }

        internal void Reset()
        {
            if (!new List<string> {
                "auto",
                "min",
                "max"
            }.Contains(this.mode))
            {
                Logger.Warning($"Learning Rate Plateau Reducing mode {mode} is unknown, fallback to auto mode.");
                this.mode = "auto";
            }
            if (this.mode == "min" || this.mode == "auto" && !this.monitor.Contains("acc"))
            {
                this.monitor_op = (a, b) => (a < b - this.min_delta);
                this.best = float.PositiveInfinity;
            }
            else
            {
                this.monitor_op = (a, b) => (a > b + this.min_delta);
                this.best = float.NegativeInfinity;
            }

            this.cooldown_counter = 0;
            this.wait = 0;
        }

        public override void OnTrainBegin(Dictionary<string, float> logs = null)
        {
            Reset();
        }

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            logs = logs != null ? logs : new Dictionary<string, float>();
            logs["lr"] = this.model.optimizer.LearningRate;
            float? current = null;
            if (logs.ContainsKey(monitor))
                current = logs[monitor];

            if (current == null)
            {
                Logger.Warning($"Reduce LR on plateau conditioned on metric `{monitor}` which is not available. Available metrics are: {string.Join(",", logs.Keys)}");
            }
            else
            {
                if (this.InCoolDown())
                {
                    this.cooldown_counter -= 1;
                    this.wait = 0;
                }
                if (this.monitor_op(current.Value, this.best))
                {
                    this.best = current.Value;
                    this.wait = 0;
                }
                else if (!this.InCoolDown())
                {
                    this.wait += 1;
                    if (this.wait >= this.patience)
                    {
                        var old_lr = this.model.optimizer.LearningRate;
                        if (old_lr > this.min_lr)
                        {
                            var new_lr = old_lr * this.factor;
                            new_lr = Math.Max(new_lr, this.min_lr);
                            this.model.optimizer.LearningRate = new_lr;
                            if (this.verbose > 0)
                            {
                                Console.WriteLine($"\nEpoch {epoch + 1}: ReduceLROnPlateau reducing learning rate to {new_lr}.");
                            }

                            this.cooldown_counter = this.cooldown;
                            this.wait = 0;
                        }
                    }
                }
            }
        }

        public bool InCoolDown()
        {
            return this.cooldown_counter > 0;
        }
    }
}
