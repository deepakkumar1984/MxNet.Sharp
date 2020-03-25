using MxNet;
using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.GluonCV.Losses
{
    public class SSDMultiBoxLoss : Block
    {
        private float _lambd;

        private float _min_hard_negatives;

        private float _negative_mining_ratio;

        private float _rho;

        public (NDArray, NDArray, NDArray) LossOutput { get; set; }

        public SSDMultiBoxLoss(float negative_mining_ratio= 3, float rho= 1, float lambd= 1,
                float min_hard_negatives= 0, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            this._negative_mining_ratio = Math.Max(0, negative_mining_ratio);
            this._rho = rho;
            this._lambd = lambd;
            this._min_hard_negatives = Math.Max(0, min_hard_negatives);
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol cls_pred, params NDArrayOrSymbol[] args)
        {
            NDArrayOrSymbol box_pred = args[0];
            NDArrayOrSymbol cls_target = args[0];
            NDArrayOrSymbol box_target = args[0];
            
            var num_pos = new List<float>();
            var pos_samples = cls_target.NdX > 0;
            num_pos.Add(pos_samples.Sum());
            var num_pos_all = num_pos.Sum();

            NDArray cls_losses = null;
            NDArray box_losses = null;
            NDArray sum_losses = null;
            if (num_pos_all < 1 && this._min_hard_negatives < 1)
            {
                // no positive samples and no hard negatives, return dummy losses
                cls_losses = nd.Sum(cls_pred.NdX * 0);
                box_losses = nd.Sum(box_pred.NdX * 0);
                sum_losses = cls_losses + box_losses;
                LossOutput = (sum_losses, cls_losses, box_losses);
                return sum_losses;
            }

            // compute element-wise cross entropy loss and sort, then perform negative mining
            var pred = nd.LogSoftmax(cls_pred.NdX, axis: -1);
            var pos = cls_target.NdX > 0;
            var cls_loss = nd.Negative(nd.Pick(pred, cls_target.NdX, axis: -1, keepdims: false));
            var rank = (cls_loss * (pos - 1)).Argsort(axis: 1).Argsort(axis: 1);
            var hard_negative = rank < nd.MaximumScalar(pos.Sum(axis: 1) * this._negative_mining_ratio, _min_hard_negatives).ExpandDims(-1);
            // mask out if not positive or negative
            cls_loss = nd.Where(pos + hard_negative > 0, cls_loss, nd.ZerosLike(cls_loss));
            cls_losses = nd.Sum(cls_loss, axis: 0, exclude: true) / (float)Math.Max(1.0, num_pos_all);
            var bp = nd.ReshapeLike(box_pred, box_target);
            var box_loss = nd.Abs(box_pred.NdX - box_target.NdX);
            box_loss = nd.Where(box_loss > this._rho, box_loss - 0.5f * this._rho, 0.5f / this._rho * nd.Square(box_loss));
            // box loss only apply to positive samples
            box_loss = box_loss * pos.ExpandDims(axis: -1);
            box_losses = nd.Sum(box_loss, axis: 0, exclude: true) / (float)Math.Max(1.0, num_pos_all);
            sum_losses = cls_losses + this._lambd * box_losses;

            LossOutput = (sum_losses, cls_losses, box_losses);
            return sum_losses;
        }
    }
}
