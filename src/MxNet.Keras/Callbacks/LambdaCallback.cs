using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class LambdaCallback : Callback
    {
        public LambdaCallback(Action<int, Dictionary<string, float>> on_epoch_begin = null,
                            Action<int, Dictionary<string, float>> on_epoch_end = null,
                            Action<int, Dictionary<string, float>> on_batch_begin = null,
                            Action<int, Dictionary<string, float>> on_batch_end = null,
                            Action<Dictionary<string, float>> on_train_begin = null,
                            Action<Dictionary<string, float>> on_train_end = null)
        {
            throw new NotImplementedException();
        }

        public override void OnBatchBegin(int batch, Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }

        public override void OnBatchEnd(int batch, Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }

        public override void OnEpochBegin(int epoch, Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }

        public override void OnTrainBegin(Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }

        public override void OnTrainEnd(Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }
    }
}
