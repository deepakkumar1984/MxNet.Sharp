using System;

namespace MxNet.Gluon
{
    public class PoissonNLLLoss : Loss
    {
        public PoissonNLLLoss(bool from_logits = false, bool compute_full = false, float? weight = null,
            int? batch_axis = 0, string prefix = null, ParameterDict @params = null) : base(weight, batch_axis, prefix,
            @params)
        {
            FromLogit = from_logits;
            ComputeFull = compute_full;
        }

        public bool FromLogit { get; set; }

        public bool ComputeFull { get; set; }

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
            NDArray loss = null;
            if (FromLogit)
                loss = nd.Exp(pred) - label * pred;
            else
                loss = pred - label * nd.Log(pred + 1e-08f);

            if (ComputeFull)
            {
                var stirling_factor = label * nd.Log(label) - label + 0.5f * nd.Log(2 * label * (float) Math.PI);
                var target_gt_1 = label > 1;
                stirling_factor *= target_gt_1;
                loss += stirling_factor;
            }

            loss = ApplyWeighting(loss, Weight, sample_weight);
            return nd.Mean(loss);
        }

        private Symbol F(Symbol pred, Symbol label, Symbol sample_weight = null)
        {
            label = sym.ReshapeLike(label, pred);
            Symbol loss = null;
            if (FromLogit)
                loss = sym.Exp(pred) - label * pred;
            else
                loss = pred - label * sym.Log(pred + 1e-08f);

            if (ComputeFull)
            {
                var stirling_factor = label * sym.Log(label) - label + 0.5f * sym.Log(2 * label * (float) Math.PI);
                var target_gt_1 = sym.GreaterScalar(label, 1);
                stirling_factor *= target_gt_1;
                loss += stirling_factor;
            }

            loss = ApplyWeighting(loss, Weight, sample_weight);
            return sym.Mean(loss);
        }
    }
}