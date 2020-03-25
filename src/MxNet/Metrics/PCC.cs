/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
using System.Linq;
using NumSharp;

namespace MxNet.Metrics
{
    public class PCC : EvalMetric
    {
        private NDArray gcm;

        private int k;
        private NDArray lcm;

        public PCC(string output_name = null, string label_name = null)
            : base("pcc", output_name, label_name, true)
        {
            k = 2;
        }

        public float SumMetric => CalcMcc(lcm) * num_inst;

        public float GlobalSumMetric => CalcMcc(gcm) * global_num_inst;

        private void Grow(int inc)
        {
            lcm = nd.Pad(lcm, PadMode.Constant, new Shape(0, inc, 0, inc));
            gcm = nd.Pad(gcm, PadMode.Constant, new Shape(0, inc, 0, inc));
            k += inc;
        }

        private float CalcMcc(NDArray cmatArr)
        {
            var cmat = cmatArr.AsNumpy();
            var n = cmat.sum();
            var x = cmat.sum(1);
            var y = cmat.sum(0);
            var cov_xx = np.sum(x * (n - x)).Data<float>()[0];
            var cov_yy = np.sum(y * (n - y)).Data<float>()[0];

            if (cov_xx == 0 || cov_yy == 0)
                return float.NaN;

            var i = cmatArr.Diag().AsNumpy();
            var cov_xy = np.sum(i * n - x * y);
            return np.power(cov_xy / (cov_xx * cov_yy), 0.5);
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            var label = labels.AsType(DType.Int32).AsNumpy();
            var pred = np.argmax(preds.AsNumpy(), 1).astype(NPTypeCode.Int32);
            var n = np.max(pred.max(), label.max()).Data<int>()[0];
            if (n >= k)
                Grow(n + 1 - k);

            var bcm = np.zeros(k, k);
            pred.Data<int>().Zip(label.Data<int>(), (i, j) =>
            {
                bcm[i, j] += 1;
                return true;
            });

            lcm += bcm;
            gcm += bcm;

            num_inst += 1;
            global_num_inst += 1;
        }

        public override void Reset()
        {
            global_num_inst = 0;
            gcm = nd.Zeros(new Shape(k, k));
            ResetLocal();
        }

        public override void ResetLocal()
        {
            num_inst = 0;
            lcm = nd.Zeros(new Shape(k, k));
        }
    }
}