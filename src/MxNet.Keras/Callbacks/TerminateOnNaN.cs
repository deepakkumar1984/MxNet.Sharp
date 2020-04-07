using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class TerminateOnNaN : Callback
    {
        public override void OnBatchEnd(int batch, Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }
    }
}
