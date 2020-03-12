using System;

namespace MxNet.Gluon
{
    public class LogisticLoss : Loss
    {
        public LogisticLoss(float? weight = null, int? batch_axis = 0, string label_format = "signed",
            string prefix = null, ParameterDict @params = null) : base(weight, batch_axis, prefix, @params)
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