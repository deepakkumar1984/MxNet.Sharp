using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class MXNetModelCheckpoint : ModelCheckpoint
    {
        public float best;

        public int epochs_since_last_save;

        public string prefix;

        public MXNetModelCheckpoint(string prefix, string monitor = "val_loss", int verbose = 0, bool save_best_only = false, string mode = "auto", int period = 1) : base("", monitor, verbose, save_best_only, false, mode, period)
        {
            this.prefix = prefix;
        }

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            logs = logs != null ? logs : new Dictionary<string, float>();

            this.epochs_since_last_save += 1;
            if (this.epochs_since_last_save >= this.period)
            {
                this.epochs_since_last_save = 0;
                if (this.save_best_only)
                {
                    // We use epoch=0 for saving the best model. This will replace previous best model.
                    float? current = null;
                    if (logs.ContainsKey(monitor))
                        current = logs[this.monitor];

                    if (current == null)
                    {
                        Logger.Warning($"Can save best model only with {monitor} available, skipping.");
                    }
                    else if (this.monitor_op(current.Value, this.best))
                    {
                        if (this.verbose > 0)
                        {
                            Console.WriteLine(String.Format("\nEpoch %05d: %s improved from %0.5f to %0.5f, saving the MXNet model.", epoch + 1, this.monitor, this.best, current));
                        }
                        this.best = current.Value;
                        Saving.SaveMxnetModel(this.model, prefix: this.prefix);
                    }
                    else if (this.verbose > 0)
                    {
                        Console.WriteLine(String.Format("\nEpoch %05d: %s did not improve from %0.5f", epoch + 1, this.monitor, this.best));
                    }
                }
                else
                {
                    // User want to save model after each epoch. Hence, using the `epoch`.
                    if (this.verbose > 0)
                    {
                        Console.WriteLine(String.Format("\nEpoch %05d: saving the MXNet model.", epoch + 1));
                    }

                    Saving.SaveMxnetModel(this.model, prefix: this.prefix, epoch: epoch);
                }
            }
        }
    }
}
