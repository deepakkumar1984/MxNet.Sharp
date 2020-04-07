using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class RemoteMonitor : Callback
    {
        public RemoteMonitor(string root= "http://localhost:9000", string path= "/publish/epoch/end/", string field= "data", Dictionary<string, string> headers= null, bool send_as_json= false)
        {
            throw new NotImplementedException();
        }

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }
    }
}
