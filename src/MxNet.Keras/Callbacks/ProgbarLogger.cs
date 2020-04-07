using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class ProgbarLogger : Callback
    {
        public ProgbarLogger(string count_mode = "samples", string[] stateful_metrics = null)
        {
            throw new NotImplementedException();
        }

        public override void OnTrainBegin(Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }

        public override void OnEpochBegin(int epoch, Dictionary<string, float> logs = null)
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

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }
    }
}

