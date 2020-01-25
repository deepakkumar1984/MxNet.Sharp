using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Metrics
{
    public class F1 : EvalMetric
    {
        public string Average { get; private set; }

        private _BinaryClassificationMetrics metrics;

        public F1(string output_name = null, string label_name = null, string average = "macro") : base("f1", output_name, label_name, true)
        {
            Average = average;
            metrics = new _BinaryClassificationMetrics();
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            CheckLabelShapes(labels, preds);

            metrics.UpdateBinaryStats(labels, preds);

            if(Average == "macro")
            {
                sum_metric += metrics.FScore;
                global_sum_metric += metrics.GlobalFScore;
                num_inst += 1;
                global_num_inst += 1;
                metrics.ResetStats();
            }
            else
            {
                this.sum_metric = this.metrics.FScore * this.metrics.TotalExamples;
                this.global_sum_metric = this.metrics.GlobalFScore * this.metrics.GlobalTotalExamples;
                this.num_inst = this.metrics.TotalExamples;
                this.global_num_inst = this.metrics.GlobalTotalExamples;
            }
        }

        public override void Reset()
        {
            base.Reset();
            metrics.ResetStats();
        }

        public override void ResetLocal()
        {
            base.ResetLocal();
            metrics.LocalResetStats();
        }
    }
}
