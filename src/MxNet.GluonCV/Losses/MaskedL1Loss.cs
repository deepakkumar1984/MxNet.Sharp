using System;
using System.Collections.Generic;
using System.Text;
using MxNet;
using MxNet.Gluon;
using MxNet.Gluon.Losses;

namespace MxNet.GluonCV.Losses
{
    public class MaskedL1Loss : Loss
    {
        public MaskedL1Loss(float? weight = null, int? batch_axis = null, string prefix = null, ParameterDict @params = null) : base(weight, batch_axis, prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol pred, NDArrayOrSymbol label, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            NDArrayOrSymbol mask = args[0] as NDArrayOrSymbol;
            if (pred.IsNDArray)
                return F(pred.NdX, label, mask, sample_weight);

            return F(pred.SymX, label, mask, sample_weight);
        }

        private NDArrayOrSymbol F(NDArray pred, NDArray label, NDArray mask, NDArray sample_weight = null)
        {
            label = nd.ReshapeLike(label, pred);
            var loss = nd.Abs(label * mask - pred * mask);
            loss = ApplyWeighting(loss, this.Weight, sample_weight);
            var norm = nd.Sum(mask).Clip(1, 1e+30f);
            return nd.Sum(loss) / norm;
        }

        private NDArrayOrSymbol F(Symbol pred, Symbol label, Symbol mask, Symbol sample_weight = null)
        {
            label = sym.ReshapeLike(label, pred);
            var loss = sym.Abs(label * mask - pred * mask);
            loss = ApplyWeighting(loss, this.Weight, sample_weight);
            var norm = sym.Clip(sym.Sum(mask), 1, 1e+30f);
            return sym.Sum(loss) / norm;
        }
    }
}
