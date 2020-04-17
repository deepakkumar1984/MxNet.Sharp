using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class CallbackList
    {
        public CallbackList(Callback[] callbacks = null, int queue_length = 10)
        {
            throw new NotImplementedException();
        }

        public void Append(Callback callback)
        {
            throw new NotImplementedException();
        }

        public void SetParams(Dictionary<string, object> @params)
        {
            throw new NotImplementedException();
        }

        public void SetModel(Model model)
        {
            throw new NotImplementedException();
        }

        public void OnEpochBegin(int epoch, Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }

        public void OnBatchBegin(int batch, Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }

        public void OnBatchEnd(int batch, Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }

        public void OnTrainBegin(Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }

        public void OnTrainEnd(Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }
    }
}
