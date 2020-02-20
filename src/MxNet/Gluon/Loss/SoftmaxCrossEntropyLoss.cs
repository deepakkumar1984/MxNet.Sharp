using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class SoftmaxCrossEntropyLoss : Loss
    {
        private int _axis;
        private bool _sparse_label;
        private bool _from_logits;

        public SoftmaxCrossEntropyLoss(int axis = -1, bool sparse_label = true, bool from_logits = false, float? weight = null, int? batch_axis = 0, string prefix = null, ParameterDict @params = null) : base(weight, batch_axis, prefix, @params)
        {
            _axis = axis;
            _sparse_label = sparse_label;
            _from_logits = from_logits;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol pred, NDArrayOrSymbol label, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            if (pred.IsNDArray)
                return F(pred.NdX, label.NdX, sample_weight.NdX);

            return F(pred.SymX, label.SymX, sample_weight.SymX);
        }

        private NDArray F(NDArray pred, NDArray label, NDArray sample_weight = null)
        {
            NDArray loss = null;
            if (!_from_logits)
                pred = nd.LogSoftmax(pred, _axis);

            if (_sparse_label)
                loss = nd.Negative(nd.Pick(pred, label, axis: _axis, keepdims: true));
            else
            {
                label = nd.ReshapeLike(label, pred);
                loss = nd.Negative(nd.Sum(pred * label, axis: _axis, keepdims: true));
            }

            loss = ApplyWeighting(loss, _weight, sample_weight).NdX;
            return nd.Mean(loss, axis: _batch_axis.Value, exclude: true);
        }

        private Symbol F(Symbol pred, Symbol label, Symbol sample_weight = null)
        {
            Symbol loss = null;
            if (!_from_logits)
                pred = sym.LogSoftmax(pred, _axis);

            if (_sparse_label)
                loss = sym.Negative(sym.Pick(pred, label, axis: _axis, keepdims: true));
            else
            {
                label = sym.ReshapeLike(label, pred);
                loss = sym.Negative(sym.Sum(pred * label, axis: _axis, keepdims: true));
            }

            loss = ApplyWeighting(loss, _weight, sample_weight).SymX;
            return sym.Mean(loss, axis: _batch_axis.Value, exclude: true);
        }
    }
}
