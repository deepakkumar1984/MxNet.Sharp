namespace MxNet.Metrics
{
    public class BinaryAccuracy : EvalMetric
    {
        public BinaryAccuracy(float threshold = 0.5f, string output_name = null, string label_name = null) : base("accuracy",
            output_name, label_name, true)
        {
            Threshold = threshold;
        }

        public float Threshold { get; }

        public override void Update(NDArray labels, NDArray preds)
        {
            CheckLabelShapes(labels, preds, true);

            preds = preds.Clip(0, 1);
            var label = labels.Ravel();
            preds = preds.Ravel() > Threshold;

            var num_correct = nd.Equal(preds, label).AsType(DType.Float32).Sum();

            sum_metric += num_correct;
            global_sum_metric += num_correct;
            num_inst += preds.Shape.Size;
            global_num_inst += preds.Shape.Size;
        }
    }
}