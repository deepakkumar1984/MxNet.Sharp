using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Callbacks
{
    public class LearningRateScheduler : Callback
    {
        public Func<int, float, float> schedule;

        public int verbose;

        public LearningRateScheduler(Func<int, float, float> schedule, int verbose = 0)
        {
            this.schedule = schedule;
            this.verbose = verbose;
        }

        public override void OnEpochBegin(int epoch, Dictionary<string, float> logs = null)
        {
            var lr = this.model.optimizer.LearningRate;
            try
            {
                lr = this.schedule(epoch, lr);
            }
            catch (Exception)
            {
                // old API for backward compatibility
                lr = this.schedule(epoch, 0);
            }

            this.model.optimizer.LearningRate = lr;

            if (this.verbose > 0)
            {
                Console.WriteLine($"\nEpoch {epoch + 1}: LearningRateScheduler setting learning rate to {lr}.");
            }
        }

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            logs = logs != null ? logs : new Dictionary<string, float>();
            logs["lr"] = this.model.optimizer.LearningRate;
        }
    }
}
