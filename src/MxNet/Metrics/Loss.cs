using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Metrics
{
    public class Loss : EvalMetric
    {
        public Loss(string name = "loss", string output_name = null, string label_name = null) : base(name, output_name, label_name, true)
        {
        }

        public override void Update(NDArray _, NDArray preds)
        {
            var loss = nd.Sum(preds).AsScalar<float>();
            sum_metric += loss;
            global_sum_metric += loss;
            num_inst += (int)preds.Shape.Size;
            global_num_inst += (int)preds.Shape.Size;
        }
    }
}
