using System;
using System.Collections.Generic;
using System.Text;
using MxNet;
using MxNet.Gluon;
using MxNet.Gluon.Losses;

namespace MxNet.GluonCV.Losses
{
    public class HeatmapFocalLoss : Loss
    {
        public bool _from_logits;

        public HeatmapFocalLoss(bool from_logits= false, float? weight = null, int? batch_axis = null, string prefix = null, ParameterDict @params = null) : base(weight, batch_axis, prefix, @params)
        {
            this._from_logits = from_logits;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol pred, NDArrayOrSymbol label, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            if (pred.IsNDArray)
                return F(pred.NdX, label);

            return F(pred.SymX, label);
        }

        private NDArrayOrSymbol F(NDArray pred, NDArray label)
        {
            if (!this._from_logits)
            {
                pred = nd.Sigmoid(pred);
            }
            var pos_inds = nd.EqualScalar(label, 1);
            var neg_inds = label < 1;
            var neg_weights = nd.PowerScalar(1 - label, 4);
            var pos_loss = nd.Log(pred) * nd.PowerScalar(1 - pred, 2) * pos_inds;
            var neg_loss = nd.Log(1 - pred) * nd.PowerScalar(pred, 2) * neg_weights * neg_inds;
            // normalize
            var num_pos = nd.Clip(nd.Sum(pos_inds), a_min: 1, a_max: 1e+30f);
            pos_loss = nd.Sum(pos_loss);
            neg_loss = nd.Sum(neg_loss);
            return nd.Negative(pos_loss) + neg_loss / num_pos;
        }

        private NDArrayOrSymbol F(Symbol pred, Symbol label)
        {
            if (!this._from_logits)
            {
                pred = sym.Sigmoid(pred);
            }
            var pos_inds = sym.EqualScalar(label, 1);
            var neg_inds = sym.LesserScalar(label, 1);
            var neg_weights = sym.PowerScalar(1 - label, 4);
            var pos_loss = sym.Log(pred) * sym.PowerScalar(1 - pred, 2) * pos_inds;
            var neg_loss = sym.Log(1 - pred) * sym.PowerScalar(pred, 2) * neg_weights * neg_inds;
            // normalize
            var num_pos = sym.Clip(sym.Sum(pos_inds), a_min: 1, a_max: 1e+30f);
            pos_loss = sym.Sum(pos_loss);
            neg_loss = sym.Sum(neg_loss);
            return sym.Negative(pos_loss) + neg_loss / num_pos;
        }
    }
}
