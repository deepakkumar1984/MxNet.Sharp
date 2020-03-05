namespace MxNet.Metrics
{
    public class MSE : EvalMetric
    {
        public MSE(string output_name = null, string label_name = null) : base("mse", output_name, label_name, true)
        {
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            if (labels.Shape.Dimension == 1)
                labels = labels.Reshape(labels.Shape[0], 1);
            if (preds.Shape.Dimension == 1)
                preds = preds.Reshape(preds.Shape[0], 1);

            var mse = nd.Square(labels - preds).Mean();

            sum_metric += mse;
            global_sum_metric += mse;
            num_inst += 1;
            global_num_inst += 1;
        }
    }
}