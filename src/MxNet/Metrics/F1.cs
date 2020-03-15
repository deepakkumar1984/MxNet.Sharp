namespace MxNet.Metrics
{
    public class F1 : EvalMetric
    {
        private readonly BinaryClassificationMetrics metrics;

        public F1(string output_name = null, string label_name = null, string average = "macro") : base("f1",
            output_name, label_name, true)
        {
            Average = average;
            metrics = new BinaryClassificationMetrics();
        }

        public string Average { get; }

        public override void Update(NDArray labels, NDArray preds)
        {
            CheckLabelShapes(labels, preds);

            metrics.UpdateBinaryStats(labels, preds);

            if (Average == "macro")
            {
                sum_metric += metrics.FScore;
                global_sum_metric += metrics.GlobalFScore;
                num_inst += 1;
                global_num_inst += 1;
                metrics.ResetStats();
            }
            else
            {
                sum_metric = metrics.FScore * metrics.TotalExamples;
                global_sum_metric = metrics.GlobalFScore * metrics.GlobalTotalExamples;
                num_inst = metrics.TotalExamples;
                global_num_inst = metrics.GlobalTotalExamples;
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