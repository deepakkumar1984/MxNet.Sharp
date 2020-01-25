using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Metrics
{
    public class MCC : EvalMetric
    {
        public string Average { get; private set; }
        private _BinaryClassificationMetrics metrics;

        public MCC(string output_name = null, string label_name = null, string average = "macro") : base("mcc", output_name, label_name, true)
        {
            Average = average;
            metrics = new _BinaryClassificationMetrics();
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            CheckLabelShapes(labels, preds);

            metrics.UpdateBinaryStats(labels, preds);

            if (Average == "macro")
            {
                sum_metric += metrics.MatthewsCC();
                global_sum_metric += metrics.MatthewsCC(true);
                num_inst += 1;
                global_num_inst += 1;
                metrics.ResetStats();
            }
            else
            {
                this.sum_metric = this.metrics.MatthewsCC() * this.metrics.TotalExamples;
                this.global_sum_metric = this.metrics.MatthewsCC(true) * this.metrics.GlobalTotalExamples;
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
