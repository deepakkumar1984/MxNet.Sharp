using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class History : Callback
    {
        public override void OnTrainBegin(Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }
    }
}
