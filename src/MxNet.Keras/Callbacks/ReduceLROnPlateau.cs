using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class ReduceLROnPlateau : Callback
    {
        public ReduceLROnPlateau(string monitor= "val_loss", float factor= 0.1f, int patience= 10, int verbose= 0, string mode= "auto", float min_delta= 1e-4f, int cooldown= 0, float min_lr= 0)
        {
            throw new NotImplementedException();
        }

        internal void Reset()
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

        public bool IsCoolDown()
        {
            throw new NotImplementedException();
        }
    }
}
