using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class LambdaCallback : Callback
    {
        private Action<int, Dictionary<string, float>> on_epoch_begin = null;
        private Action<int, Dictionary<string, float>> on_epoch_end = null;
        private Action<int, Dictionary<string, float>> on_batch_begin = null;
        private Action<int, Dictionary<string, float>> on_batch_end = null;
        private Action<Dictionary<string, float>> on_train_begin = null;
        private Action<Dictionary<string, float>> on_train_end = null;

        public LambdaCallback(Action<int, Dictionary<string, float>> on_epoch_begin = null,
                            Action<int, Dictionary<string, float>> on_epoch_end = null,
                            Action<int, Dictionary<string, float>> on_batch_begin = null,
                            Action<int, Dictionary<string, float>> on_batch_end = null,
                            Action<Dictionary<string, float>> on_train_begin = null,
                            Action<Dictionary<string, float>> on_train_end = null)
        {
            if (on_epoch_begin != null)
            {
                this.on_epoch_begin = on_epoch_begin;
            }
            else
            {
                this.on_epoch_begin = (epoch, logs) => { };
            }

            if (on_epoch_end != null)
            {
                this.on_epoch_end = on_epoch_end;
            }
            else
            {
                this.on_epoch_end = (epoch, logs) => { };
            }

            if (on_batch_begin != null)
            {
                this.on_batch_begin = on_batch_begin;
            }
            else
            {
                this.on_batch_begin = (batch, logs) => { };
            }

            if (on_batch_end != null)
            {
                this.on_batch_end = on_batch_end;
            }
            else
            {
                this.on_batch_end = (batch, logs) => { };
            }

            if (on_train_begin != null)
            {
                this.on_train_begin = on_train_begin;
            }
            else
            {
                this.on_train_begin = logs => { };
            }

            if (on_train_end != null)
            {
                this.on_train_end = on_train_end;
            }
            else
            {
                this.on_train_end = logs => { };
            }
        }

        public override void OnBatchBegin(int batch, Dictionary<string, float> logs = null)
        {
            on_batch_begin(batch, logs);
        }

        public override void OnBatchEnd(int batch, Dictionary<string, float> logs = null)
        {
            on_batch_end(batch, logs);
        }

        public override void OnEpochBegin(int epoch, Dictionary<string, float> logs = null)
        {
            on_epoch_begin(epoch, logs);
        }

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            on_epoch_end(epoch, logs);
        }

        public override void OnTrainBegin(Dictionary<string, float> logs = null)
        {
            on_train_begin(logs);
        }

        public override void OnTrainEnd(Dictionary<string, float> logs = null)
        {
            on_train_end(logs);
        }
    }
}
