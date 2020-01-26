using NumSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Metrics
{
    public class CrossEntropy : EvalMetric
    {
        private float eps;

        public CrossEntropy(float eps = 1e-12f, string output_name = null, string label_name = null) : base("cross-entropy", output_name, label_name, true)
        {
            this.eps = eps;
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            var l = labels.AsNumpy();
            if (preds.Shape[0] != labels.Shape[0])
                throw new ArgumentException("preds.Shape[0] != labels.Shape[0]");

            l = l.ravel();
            var p = preds.AsNumpy();
            var prob = p[np.arange(l.shape[0]), l.astype(NPTypeCode.Int64)];
            var cross_entropy = np.sum(-np.log(prob + eps)).Data<float>()[0];
            sum_metric += sum_metric;
            global_sum_metric += sum_metric;
            num_inst += l.shape[0];
            global_num_inst += l.shape[0];
        }
    }
}
