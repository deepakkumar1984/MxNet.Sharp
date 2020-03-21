namespace MxNet.Metrics
{
    public class Accuracy : EvalMetric
    {
        public Accuracy(int axis = 1, string output_name = null, string label_name = null) : base("accuracy",
            output_name, label_name, true)
        {
            Axis = axis;
        }

        public int Axis { get; set; }

        public override void Update(NDArray labels, NDArray preds)
        {
            CheckLabelShapes(labels, preds, true);

            NDArray pred_label = null;
            if (preds.Shape != labels.Shape)
                pred_label = preds.Argmax(Axis);
            else
                pred_label = preds;

            var label = labels.Ravel().AsType(DType.Int32);
            pred_label = pred_label.Ravel().AsType(DType.Int32);

            var num_correct = nd.Equal(pred_label, label).AsType(DType.Float32).Sum();

            sum_metric += num_correct;
            global_sum_metric += num_correct;
            num_inst += pred_label.Shape.Size;
            global_num_inst += pred_label.Shape.Size;
        }
    }
}