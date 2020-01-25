using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Metrics
{
    public class PearsonCorrelation : EvalMetric
    {
        public PearsonCorrelation(string output_name = null, string label_name = null, string average = "macro") 
            : base("pearsonr", output_name, label_name, true)
        {
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            throw new NotImplementedException();
        }

        private void ResetMicro()
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            base.Reset();
            throw new NotImplementedException();
        }

        private (float, float, float) UpdateVariance(NDArray new_values, float[] aggregate)
        {
            throw new NotImplementedException();
        }

        private void UpdateCov(NDArray label, NDArray pred)
        {
            throw new NotImplementedException();
        }

        public override (string, float) Get()
        {
            throw new NotImplementedException();
        }
    }
}
