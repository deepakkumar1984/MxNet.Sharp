using System;

namespace MxNet.Metrics
{
    public class CustomMetric : EvalMetric
    {
        private bool _allow_extra_outputs;
        private readonly Func<NDArray, NDArray, float> _feval;

        public CustomMetric(Func<NDArray, NDArray, float> feval, string name, string output_name = null,
            string label_name = null, bool has_global_stats = false)
            : base(string.Format("custom({0})", name), output_name, label_name, has_global_stats)
        {
            _feval = feval;
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            CheckLabelShapes(labels, preds);
            var reval = _feval(labels, preds);
            num_inst++;
            global_num_inst++;
            sum_metric += reval;
            global_sum_metric += reval;
        }

        public override ConfigData GetConfig()
        {
            throw new NotImplementedException("Custom metric cannot be serialized");
        }
    }
}