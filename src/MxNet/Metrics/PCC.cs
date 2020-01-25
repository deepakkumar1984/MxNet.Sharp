using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Metrics
{
    public class PCC : EvalMetric
    {
        public float SumMetric
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public float GlobalSumMetric
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public PCC(string output_name = null, string label_name = null) 
            : base("pcc", output_name, label_name, true)
        {
        }

        private void Grow(int inc)
        {
            throw new NotImplementedException();
        }

        private NDArray CalcMcc(NDArray cmat) => throw new NotImplementedException();

        public override void Update(NDArray labels, NDArray preds)
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public override void ResetLocal()
        {
            throw new NotImplementedException();
        }
    }
}
