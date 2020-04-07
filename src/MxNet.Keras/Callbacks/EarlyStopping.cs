using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class EarlyStopping : Callback
    {
        public EarlyStopping(string monitor= "val_loss", float min_delta= 0, int patience= 0, int verbose= 0, string mode= "auto",
                 float? baseline= null, bool restore_best_weights= false)
        {
            throw new NotImplementedException();
        }

        public override void OnTrainBegin(Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }

        public override void OnTrainEnd(Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }

        public float GetMonitorValue(Dictionary<string, float> logs)
        {
            throw new NotImplementedException();
        }
    }
}
