using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class CSVLogger : Callback
    {
        public CSVLogger(string filename, string separator= ",", bool append= false)
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
    }
}
