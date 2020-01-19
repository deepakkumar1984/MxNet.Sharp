using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Metrics
{
    public class Loss : EvalMetric
    {
        public Loss(string name = "loss", string output_name = null, string label_name = null) : base(name, output_name, label_name, true)
        {
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            throw new NotImplementedException();
        }
    }
}
