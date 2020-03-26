using MxNet.Gluon;
using MxNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Losses
{
    public class MixSoftmaxCrossEntropyLoss : SoftmaxCrossEntropyLoss
    {
        private bool Aux { get; set; }

        public float AuxWeight { get; set; }

        public bool Mixup { get; set; }

        public MixSoftmaxCrossEntropyLoss(bool aux= true, bool mixup = false, float aux_weight= 0.2f, int axis = -1, bool sparse_label = true, bool from_logits = false, float? weight = null, int? batch_axis = 0, string prefix = null, ParameterDict @params = null) : base(axis, sparse_label, from_logits, weight, batch_axis, prefix, @params)
        {
            this.Aux = aux;
            this.Mixup = mixup;
            this.AuxWeight = aux_weight;
        }

        private NDArrayOrSymbol AuxForward(NDArrayOrSymbol pred1, NDArrayOrSymbol pred2, NDArrayOrSymbol label, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            var loss1 = base.HybridForward(pred1, label, sample_weight);
            var loss2 = base.HybridForward(pred2, label, sample_weight);
            if(loss1.IsNDArray)
                return loss1.NdX + this.AuxWeight * loss2.NdX;

            return loss1.SymX + this.AuxWeight * loss2.SymX;
        }

        private NDArrayOrSymbol AuxMixupForward(NDArrayOrSymbol pred1, NDArrayOrSymbol pred2, NDArrayOrSymbol label1, NDArrayOrSymbol label2, NDArrayOrSymbol lam, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            var loss1 = this.MixupForward(pred1, label1, label2, lam);
            var loss2 = this.MixupForward(pred2, label1, label2, lam);
            if (loss1.IsNDArray)
                return loss1.NdX + this.AuxWeight * loss2.NdX;

            return loss1.SymX + this.AuxWeight * loss2.SymX;
        }

        private NDArrayOrSymbol MixupForward(NDArrayOrSymbol pred, NDArrayOrSymbol label1, NDArrayOrSymbol label2, NDArrayOrSymbol lam, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            NDArrayOrSymbol loss;
            NDArrayOrSymbol loss2;
            NDArrayOrSymbol loss1;
            if (!this._from_logits)
            {
                pred = nd.LogSoftmax(pred, this._axis);
            }
            if (this._sparse_label)
            {
                loss1 = nd.Negative(nd.Pick(pred, label1, axis: this._axis, keepdims: true));
                loss2 = nd.Negative(nd.Pick(pred, label2, axis: this._axis, keepdims: true));
                if(loss1.IsNDArray)
                    loss = lam.NdX * loss1.NdX + (1 - lam.NdX) * loss2.NdX;
                else
                    loss = lam.SymX * loss1.SymX + (1 - lam.SymX) * loss2.SymX;
            }
            else
            {
                if (pred.IsNDArray)
                {
                    label1 = nd.ReshapeLike(label1, pred);
                    label2 = nd.ReshapeLike(label2, pred);
                    loss1 = nd.Negative(nd.Sum(pred.NdX * label1.NdX, axis: this._axis, keepdims: true));
                    loss2 = nd.Negative(nd.Sum(pred.NdX * label2.NdX, axis: this._axis, keepdims: true));
                    loss = lam.NdX * loss1.NdX + (1 - lam.NdX) * loss2.NdX;
                }
                else
                {
                    label1 = sym.ReshapeLike(label1, pred);
                    label2 = sym.ReshapeLike(label2, pred);
                    loss1 = sym.Negative(sym.Sum(pred.SymX * label1.SymX, axis: this._axis, keepdims: true));
                    loss2 = sym.Negative(sym.Sum(pred.SymX * label2.SymX, axis: this._axis, keepdims: true));
                    loss = lam.SymX * loss1.SymX + (1 - lam.SymX) * loss2.SymX;
                }
            }

            loss = ApplyWeighting(loss, this.Weight, sample_weight);
            if(loss.IsNDArray)
                nd.Mean(loss, BatchAxis.Value, exclude: true);

            return sym.Mean(loss, BatchAxis.Value, exclude: true);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (this.Aux)
            {
                if (this.Mixup)
                {
                    return this.AuxMixupForward(x, args[0], args[1], args[2], args[3], args.Length == 5 ? args[4] : null);
                }
                else
                {
                    return this.AuxForward(x, args[0], args[1], args.Length == 3 ? args[2] : null);
                }
            }
            else if (this.Mixup)
            {
                return this.MixupForward(x, args[0], args[1], args[2], args.Length == 4 ? args[3] : null);
            }
            else
            {
                return base.HybridForward(x, args[0], args.Length == 2 ? args[1] : null);
            }
        }
    }
}
