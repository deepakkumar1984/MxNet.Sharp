using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class MXNetModelCheckpoint : ModelCheckpoint
    {
        public MXNetModelCheckpoint(string prefix, string monitor = "val_loss", int verbose = 0, bool save_best_only = false, string mode = "auto", int period = 1) : base("", monitor, verbose, save_best_only, false, mode, period)
        {
            throw new NotImplementedException();
        }

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }
    }
}
