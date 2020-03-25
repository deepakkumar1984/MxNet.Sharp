using System;
using System.Collections.Generic;
using System.Text;
using MxNet;
using MxNet.Gluon;
using MxNet.Gluon.Losses;

namespace MxNet.GluonCV.Losses
{
    public class FocalLoss : Loss
    {
        private float _alpha;

        private int _axis;

        private float _eps;

        private bool _from_logits;

        private float _gamma;

        private int? _num_class;

        private bool _size_average;

        private bool _sparse_label;

        public FocalLoss(int axis= -1, float alpha= 0.25f, float gamma= 2, bool sparse_label= true, bool from_logits= false, float? weight = null, int? num_class = null, float eps = 1e-12f, bool size_average = true, int? batch_axis = null, string prefix = null, ParameterDict @params = null) : base(weight, batch_axis, prefix, @params)
        {
            this._axis = axis;
            this._alpha = alpha;
            this._gamma = gamma;
            this._sparse_label = sparse_label;
            if (sparse_label && (!(num_class is int) || num_class < 1))
            {
                throw new ArgumentException("Number of class > 0 must be provided if sparse label is used.");
            }
            this._num_class = num_class;
            this._from_logits = from_logits;
            this._eps = eps;
            this._size_average = size_average;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol pred, NDArrayOrSymbol label, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            if (pred.IsNDArray)
                return F(pred.NdX, label, sample_weight);

            return F(pred.SymX, label, sample_weight);
        }

        private NDArrayOrSymbol F(NDArray pred, NDArray label, NDArray sample_weight = null)
        {
            NDArray one_hot;
            if (!this._from_logits)
            {
                pred = nd.Sigmoid(pred);
            }
            if (this._sparse_label)
            {
                one_hot = nd.OneHot(label, this._num_class.Value);
            }
            else
            {
                one_hot = label > 0;
            }

            var pt = nd.Where(one_hot, pred, 1 - pred);
            var t = nd.OnesLike(one_hot);
            var alpha = nd.Where(one_hot, this._alpha * t, (1 - this._alpha) * t);
            var loss = nd.Negative(alpha) * nd.PowerScalar(1f - pt, this._gamma) * nd.Log(nd.MinimumScalar(pt + this._eps, 1));
            loss = base.ApplyWeighting(loss, this.Weight, sample_weight);
            if (this._size_average)
            {
                return nd.Mean(loss, axis: this.BatchAxis.Value, exclude: true);
            }
            else
            {
                return nd.Sum(loss, axis: this.BatchAxis.Value, exclude: true);
            }
        }

        private NDArrayOrSymbol F(Symbol pred, Symbol label, Symbol sample_weight = null)
        {
            Symbol one_hot;
            if (!this._from_logits)
            {
                pred = sym.Sigmoid(pred);
            }
            if (this._sparse_label)
            {
                one_hot = sym.OneHot(label, this._num_class.Value);
            }
            else
            {
                one_hot = sym.GreaterScalar(label, 0);
            }

            var pt = sym.Where(one_hot, pred, 1 - pred);
            var t = sym.OnesLike(one_hot);
            var alpha = sym.Where(one_hot, this._alpha * t, (1 - this._alpha) * t);
            var loss = sym.Negative(alpha) * sym.PowerScalar(1f - pt, this._gamma) * sym.Log(sym.MinimumScalar(pt + this._eps, 1));
            loss = base.ApplyWeighting(loss, this.Weight, sample_weight);
            if (this._size_average)
            {
                return sym.Mean(loss, axis: this.BatchAxis.Value, exclude: true);
            }
            else
            {
                return sym.Sum(loss, axis: this.BatchAxis.Value, exclude: true);
            }
        }
    }
}
