using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class TerminateOnNaN : Callback
    {
        public override void OnBatchEnd(int batch, Dictionary<string, float> logs = null)
        {
            if (logs == null)
                logs = new Dictionary<string, float>();

            if (logs.ContainsKey("loss"))
            {
                float loss = logs["loss"];
                if (float.IsNaN(loss) || float.IsInfinity(loss))
                {
                    Console.WriteLine($"Batch {batch}: Invalid loss, terminating training");
                    this.model.stop_training = true;
                }
            }
        }
    }
}
