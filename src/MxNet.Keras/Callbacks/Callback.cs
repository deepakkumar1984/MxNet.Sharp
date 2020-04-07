using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public abstract class Callback
    {
        public Callback()
        {
            throw new NotImplementedException();
        }

        public virtual void SetParams(Dictionary<string, object> @params)
        {
            throw new NotImplementedException();
        }

        public virtual void SetModel(Model model)
        {
            throw new NotImplementedException();
        }

        public virtual void OnEpochBegin(int epoch, Dictionary<string, float> logs = null)
        {
            return;
        }

        public virtual void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            return;
        }

        public virtual void OnBatchBegin(int batch, Dictionary<string, float> logs = null)
        {
            return;
        }

        public virtual void OnBatchEnd(int batch, Dictionary<string, float> logs = null)
        {
            return;
        }

        public virtual void OnTrainBegin(Dictionary<string, float> logs = null)
        {
            return;
        }

        public virtual void OnTrainEnd(Dictionary<string, float> logs = null)
        {
            return;
        }
    }
}
