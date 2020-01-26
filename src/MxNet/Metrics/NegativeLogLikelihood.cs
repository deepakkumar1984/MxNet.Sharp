using NumSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Metrics
{
    public class NegativeLogLikelihood : EvalMetric
    {
        private float eps;

        public NegativeLogLikelihood(float eps = 1e-12f, string output_name = null, string label_name = null) 
            : base("nll-loss", output_name, label_name, true)
        {
            this.eps = eps;
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            CheckLabelShapes(labels, preds);
            if (preds.Shape[0] != labels.Shape[0])
                throw new ArgumentException("preds.Shape[0] != labels.Shape[0]");

            var l = labels.AsNumpy();
            l = l.ravel();
            var p = preds.AsNumpy();
            int num_examples = p.shape[0];
            var prob = p[np.arange(num_examples).astype(NPTypeCode.Int64), l.astype(NPTypeCode.UInt64)];
            var nll = (-np.log(prob + eps)).sum().Data<float>()[0];
            this.sum_metric += nll;
            this.global_sum_metric += nll;
            this.num_inst += num_examples;
            this.global_num_inst += num_examples;
        }
    }
}
