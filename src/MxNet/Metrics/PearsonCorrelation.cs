using NumSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Metrics
{
    public class PearsonCorrelation : EvalMetric
    {
        public PearsonCorrelation(string output_name = null, string label_name = null) 
            : base("pearsonr", output_name, label_name, true)
        {
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            CheckLabelShapes(labels, preds, true);

            var pearson_corr = nd.Correlation(labels.Ravel(), preds.Ravel()).AsNumpy()[0, 1].Data<float>()[0];
            this.sum_metric += pearson_corr;
            this.global_sum_metric += pearson_corr;
            this.num_inst += 1;
            this.global_num_inst += 1;

        }
    }
}
