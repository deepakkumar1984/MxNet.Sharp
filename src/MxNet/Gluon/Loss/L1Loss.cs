using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class L1Loss : Loss
    {
        public L1Loss(float? weight = null, int? batch_axis = 0, string prefix = null, ParameterDict @params = null) : base(weight, batch_axis, prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol pred, NDArrayOrSymbol label, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            if (pred.IsNDArray)
                return F(pred.NdX, label, sample_weight);

            return F(pred.SymX, label, sample_weight);
        }

        private NDArray F(NDArray pred, NDArray label, NDArray sample_weight = null)
        {
            label = nd.ReshapeLike(label, pred);
            var loss = nd.Abs(label - pred);
            loss = ApplyWeighting(loss, Weight, sample_weight);
            return nd.Mean(loss, axis: BatchAxis.Value, exclude: true);
        }

        private Symbol F(Symbol pred, Symbol label, Symbol sample_weight = null)
        {
            label = sym.ReshapeLike(label, pred);
            var loss = sym.Abs(label - pred);
            loss = ApplyWeighting(loss, Weight, sample_weight);
            return sym.Mean(loss, axis: BatchAxis.Value, exclude: true);
        }
    }
}
