using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class History : Callback
    {
        public List<int> epoch;

        public Dictionary<string, List<float>> history;

        public override void OnTrainBegin(Dictionary<string, float> logs = null)
        {
            epoch = new List<int>();
            history = new Dictionary<string, List<float>>();
        }

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            logs = logs != null ? logs : new Dictionary<string, float>();
            this.epoch.Add(epoch);
            foreach (var log in logs)
            {
                var k = log.Key;
                var v = log.Value;
                if(!history.ContainsKey(k))
                    this.history.Add(k, new List<float>());

                history[k].Add(v);
            }
        }
    }
}
