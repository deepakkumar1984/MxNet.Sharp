namespace MxNet.Metrics
{
    public class MCC : EvalMetric
    {
        private readonly BinaryClassificationMetrics metrics;

        public MCC(string output_name = null, string label_name = null, string average = "macro") : base("mcc",
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
                sum_metric += metrics.MatthewsCC();
                global_sum_metric += metrics.MatthewsCC(true);
                num_inst += 1;
                global_num_inst += 1;
                metrics.ResetStats();
            }
            else
            {
                sum_metric = metrics.MatthewsCC() * metrics.TotalExamples;
                global_sum_metric = metrics.MatthewsCC(true) * metrics.GlobalTotalExamples;
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