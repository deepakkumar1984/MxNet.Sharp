namespace MxNet.Metrics
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

            sum_metric += mae;
            global_sum_metric += mae;
            num_inst += 1;
            global_num_inst += 1;
        }
    }
}