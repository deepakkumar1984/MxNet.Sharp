using System;
using System.Linq;

namespace MxNet.Gluon
{
    public class CTCLoss : Loss
    {
        public CTCLoss(string layout = "NTC", string label_layout = "NT", float? weight = null, int? batch_axis = 0,
            string prefix = null, ParameterDict @params = null) : base(weight, batch_axis, prefix, @params)
        {
            if (layout != "NTC" && layout != "TNC")
                throw new ArgumentException($"Only 'NTC' and 'TNC' layouts for pred are supported. Got: {layout}");

            if (label_layout != "NT" && label_layout != "TN")
                throw new ArgumentException(
                    $"Only 'NTC' and 'TNC' layouts for label are supported. Got: {label_layout}");

            Layout = layout;
            LabelLayout = label_layout;
            BatchAxis = label_layout.ToCharArray().ToList().IndexOf('N');
        }

        public string Layout { get; set; }

        public string LabelLayout { get; set; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol pred, NDArrayOrSymbol label,
            NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            NDArrayOrSymbol pred_lengths = args.Length > 0 ? (NDArray) args[0] : null;
            NDArrayOrSymbol label_lengths = args.Length > 1 ? (NDArray) args[1] : null;
            if (pred.IsNDArray)
                return F(pred.NdX, label, pred_lengths, label_lengths, sample_weight);

            return F(pred.SymX, label, pred_lengths, label_lengths, sample_weight);
        }

        private NDArray F(NDArray pred, NDArray label, NDArray pred_lengths = null, NDArray label_lengths = null,
            NDArray sample_weight = null)
        {
            if (Layout == "NTC")
                pred = nd.SwapAxis(pred, 0, 1);

            if (BatchAxis == 1)
                label = nd.SwapAxis(label, 0, 1);

            var loss = nd.CTCLoss(pred, label, pred_lengths, label_lengths,
                pred_lengths != null, label_lengths != null,
                CtclossBlankLabel.Last);

            return ApplyWeighting(loss, Weight, sample_weight);
        }

        private Symbol F(Symbol pred, Symbol label, Symbol pred_lengths = null, Symbol label_lengths = null,
            Symbol sample_weight = null)
        {
            if (Layout == "NTC")
                pred = sym.SwapAxis(pred, 0, 1);

            if (BatchAxis == 1)
                label = sym.SwapAxis(label, 0, 1);

            var loss = sym.CTCLoss(pred, label, pred_lengths, label_lengths,
                pred_lengths != null, label_lengths != null,
                CtclossBlankLabel.Last);

            return ApplyWeighting(loss, Weight, sample_weight);
        }
    }
}