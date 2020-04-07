using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class LearningRateScheduler : Callback
    {
        public LearningRateScheduler(Func<int, float, float> schedule, int verbose = 0)
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
    }
}
