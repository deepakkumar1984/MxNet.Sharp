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
using MxNet.Numpy;

namespace MxNet.Gluon.Losses
{
    public class KLDivLoss : Loss
    {
        public KLDivLoss(bool from_logits = true, int axis = -1, float? weight = null, int? batch_axis = 0,
            string prefix = "", ParameterDict @params = null) : base(weight, batch_axis)
        {
            FromLogit = from_logits;
            Axis = axis;
        }

        public bool FromLogit { get; set; }

        public int Axis { get; set; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol pred, NDArrayOrSymbol label,
            NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            if (pred.IsNDArray)
                return F(pred.NdX, label, sample_weight);

            return F(pred.SymX, label, sample_weight);
        }

        private ndarray F(ndarray pred, ndarray label, ndarray sample_weight = null)
        {
            if (!FromLogit)
                pred = nd.LogSoftmax(pred, Axis);

            var loss = label * (np.log(label + 1e-12f) - pred);
            loss = ApplyWeighting(loss, Weight, sample_weight);
            return nd.Mean(loss, BatchAxis.Value, exclude: true);
        }

        private Symbol F(Symbol pred, Symbol label, Symbol sample_weight = null)
        {
            if (!FromLogit)
                pred = sym.LogSoftmax(pred, Axis);

            var loss = label * (sym.Log(label + 1e-12f) - pred);
            loss = ApplyWeighting(loss, Weight, sample_weight);
            return sym.Mean(loss, BatchAxis.Value, exclude: true);
        }
    }
}