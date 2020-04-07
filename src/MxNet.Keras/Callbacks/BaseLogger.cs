using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class BaseLogger : Callback
    {
        public BaseLogger(string[] stateful_metrics = null)
        {
            throw new NotImplementedException();
        }

        public override void OnEpochBegin(int epoch, Dictionary<string, float> logs = null)
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
