using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class ModelCheckpoint : Callback
    {
        public ModelCheckpoint(string filepath, string monitor= "val_loss", int verbose= 0, bool save_best_only= false, bool save_weights_only= false, string mode= "auto", int period= 1)
        {
            throw new NotImplementedException();
        }


        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }
    }
}
