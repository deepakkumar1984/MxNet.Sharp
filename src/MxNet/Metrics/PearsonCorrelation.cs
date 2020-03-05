namespace MxNet.Metrics
{
    public class PearsonCorrelation : EvalMetric
    {
        public PearsonCorrelation(string output_name = null, string label_name = null)
            : base("pearsonr", output_name, label_name, true)
        {
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            CheckLabelShapes(labels, preds, true);

            var pearson_corr = nd.Correlation(labels.Ravel(), preds.Ravel()).AsNumpy()[0, 1].Data<float>()[0];
            sum_metric += pearson_corr;
            global_sum_metric += pearson_corr;
            num_inst += 1;
            global_num_inst += 1;
        }
    }
}