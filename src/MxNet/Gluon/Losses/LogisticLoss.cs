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
using System;

namespace MxNet.Gluon.Losses
{
    public class LogisticLoss : Loss
    {
        public LogisticLoss(float? weight = null, int? batch_axis = 0, string label_format = "signed",
            string prefix = "", ParameterDict @params = null) : base(weight, batch_axis, prefix, @params)
        {
            if (label_format != "signed" && label_format != "binary")
                throw new ArgumentException($"Label_format can only be signed or binary, recieved {label_format}");

            LabelFormat = label_format;
        }

        public string LabelFormat { get; set; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol pred, NDArrayOrSymbol label,
            NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            if (pred.IsNDArray)
                return F(pred.NdX, label, sample_weight);

            return F(pred.SymX, label, sample_weight);
        }

        private NDArray F(NDArray pred, NDArray label, NDArray sample_weight = null)
        {
            label = nd.ReshapeLike(label, pred);
            if (LabelFormat == "signed")
                label = (label + 1) / 2;

            var loss = nd.Relu(pred) - pred * label +
                       nd.Activation(nd.Negative(nd.Abs(pred)), ActivationType.Softrelu);
            loss = ApplyWeighting(loss, Weight, sample_weight);
            return nd.Mean(loss, BatchAxis.Value, exclude: true);
        }

        private Symbol F(Symbol pred, Symbol label, Symbol sample_weight = null)
        {
            label = sym.ReshapeLike(label, pred);
            if (LabelFormat == "signed")
                label = (label + 1) / 2;

            var loss = sym.Relu(pred) - pred * label +
                       sym.Activation(sym.Negative(sym.Abs(pred)), ActivationType.Softrelu);
            loss = ApplyWeighting(loss, Weight, sample_weight);
            return sym.Mean(loss, BatchAxis.Value, exclude: true);
        }
    }
}