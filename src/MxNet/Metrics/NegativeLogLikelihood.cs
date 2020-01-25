using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Metrics
{
    public class NegativeLogLikelihood : EvalMetric
    {
        public NegativeLogLikelihood(float eps = 1e-12f, string output_name = null, string label_name = null) 
            : base("nll-loss", output_name, label_name, true)
        {
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            throw new NotImplementedException();
        }
    }
}
