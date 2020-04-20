using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public abstract class Callback
    {
        public Model model;

        public Dictionary<string, object> @params;
        
        public NDArrayList validation_data;

        public Callback()
        {
            this.validation_data = null;
            this.model = null;
        }

        public virtual void SetParams(Dictionary<string, object> @params)
        {
            this.@params = @params;
        }

        public virtual void SetModel(Model model)
        {
            this.model = model;
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
