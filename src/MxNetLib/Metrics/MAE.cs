using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Metrics
{
    public class MAE : EvalMetric
    {
        public MAE(string output_name = null, string label_name = null) : base("mae", output_name, label_name, true)
        {
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            if (labels.Shape.Dimension == 1)
                labels = labels.Reshape(labels.Shape[0], 1);
            if (preds.Shape.Dimension == 1)
                preds = preds.Reshape(preds.Shape[0], 1);

            var mae = nd.Abs(labels = preds).Mean();

            this.sum_metric += mae;
            this.global_sum_metric += mae;
            this.num_inst += 1;
            this.global_num_inst += 1;
        }
    }
}
