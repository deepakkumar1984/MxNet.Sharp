using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Metrics
{
    public class CrossEntropy : EvalMetric
    {
        public CrossEntropy(float eps = 1e-12f, string output_name = null, string label_name = null) : base("cross-entropy", output_name, label_name, true)
        {
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            labels = labels.Ravel();
            if (preds.Shape[0] != labels.Shape[0])
                throw new ArgumentException("preds.Shape[0] != labels.Shape[0]");

        }
    }
}
