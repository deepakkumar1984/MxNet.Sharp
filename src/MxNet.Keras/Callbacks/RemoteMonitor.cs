using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using Flurl.Http;
using Flurl.Http.Content;

namespace MxNet.Keras.Callbacks
{
    public class RemoteMonitor : Callback
    {
        public string field;

        public Dictionary<string, string> headers;

        public string path;

        public string root;

        public bool send_as_json;

        public RemoteMonitor(string root= "http://localhost:9000", string path= "/publish/epoch/end/", string field= "data", Dictionary<string, string> headers= null, bool send_as_json= true)
        {
            this.root = root;
            this.path = path;
            this.field = field;
            this.headers = headers == null ? new Dictionary<string, string>() : headers;
            this.send_as_json = send_as_json;
        }

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            logs = logs != null ? logs : new Dictionary<string, float>();
            var send = new Dictionary<string, float>();

            send["epoch"] = epoch;
            foreach (var log in logs)
            {
                var k = log.Key;
                var v = log.Value;
                send[k] = v;
            }

            try
            {
                var req = new FlurlRequest(new Flurl.Url(this.root + this.path));
                foreach (var item in headers)
                {
                    req.Headers.Add(item.Key, item.Value);
                }
                
                if (this.send_as_json)
                {
                    req.PostJsonAsync(send).Wait();
                }
                else
                {
                    throw new NotSupportedException("Only json format supported");
                }
            }
            catch
            {
                Logger.Warning("Warning: could not reach RemoteMonitor root server at " + this.root.ToString());
            }
        }
    }
}
