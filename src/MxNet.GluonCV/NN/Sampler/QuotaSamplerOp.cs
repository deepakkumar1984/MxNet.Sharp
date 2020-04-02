using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class QuotaSamplerOp : CustomOp
    {
        private bool _fill_negative;

        private float _neg_ratio;

        private float _neg_thresh_high;

        private float _neg_thresh_low;

        private int _num_sample;

        private float _pos_ratio;

        private float _pos_thresh;

        public QuotaSamplerOp(int num_sample, float pos_thresh, float neg_thresh_high= 0.5f, float neg_thresh_low= float.NegativeInfinity,
                 float pos_ratio= 0.5f, float? neg_ratio= null, bool fill_negative= true)
        {
            this._num_sample = num_sample;
            this._fill_negative = fill_negative;
            if (neg_ratio == null)
            {
                this._neg_ratio = 1 - pos_ratio;
            }
            this._pos_ratio = pos_ratio;
            Debug.Assert(this._neg_ratio + this._pos_ratio <= 1.0, $"Positive and negative ratio {(this._neg_ratio + this._pos_ratio)} exceed 1");
            this._pos_thresh = (float)Math.Min(1.0, Math.Max(0.0, pos_thresh));
            this._neg_thresh_high = (float)Math.Min(1.0, Math.Max(0.0, neg_thresh_high));
            this._neg_thresh_low = neg_thresh_low;
        }

        public override void Backward(OpGradReq[] req, NDArrayList out_grad, NDArrayList in_data, NDArrayList out_data, NDArrayList in_grad, NDArrayList aux)
        {
            this.Assign(in_grad[0], req[0], nd.ZerosLike(in_grad[0]));
            this.Assign(in_grad[1], req[1], nd.ZerosLike(in_grad[1]));
        }

        public override void Forward(bool is_train, OpGradReq[] req, NDArrayList in_data, NDArrayList out_data, NDArrayList aux)
        {
            ndarray disable_indices;
            var matches = in_data[0];
            var ious = in_data[1];
            var max_pos = Convert.ToInt32(Math.Round(this._pos_ratio * this._num_sample));
            var max_neg = Convert.ToInt32(this._neg_ratio * this._num_sample);
            foreach (var i in Enumerable.Range(0, matches.Shape[0]))
            {
                // init with 0s, which are ignored
                var result = nd.ZerosLike(matches[i]);
                // negative samples with label -1
                var ious_max = ious.Max(axis: -1)[i];
                var neg_mask = ious_max < this._neg_thresh_high;
                neg_mask = neg_mask * (ious_max >= this._neg_thresh_low);
                result = nd.Where(neg_mask, nd.OnesLike(result) * -1, result);
                // positive samples
                result = nd.Where(matches[i] >= 0, nd.OnesLike(result), result);
                result = nd.Where(ious_max >= this._pos_thresh, nd.OnesLike(result), result);
                // re-balance if number of positive or negative exceed limits
                var np_result = result.AsNumpy();
                var num_pos = Convert.ToInt32((result > 0).Sum());
                if (num_pos > max_pos)
                {
                    disable_indices = new np.random().choice(np.where(np_result > 0), size: num_pos - max_pos, replace: false);
                    np_result[disable_indices] = 0;
                }
                var num_neg = Convert.ToInt32((result < 0).Sum());
                if (this._fill_negative)
                {
                    // if pos_sample is less than quota, we can have negative samples filling the gap
                    max_neg = Math.Max(this._num_sample - Math.Min(num_pos, max_pos), max_neg);
                }
                if (num_neg > max_neg)
                {
                    disable_indices = new np.random().choice(np.where(np_result < 0), size: num_neg - max_neg, replace: false);
                    np_result[disable_indices] = 0;
                }

                this.Assign(out_data[0][i], req[0], nd.Array(np_result));
            }
        }
    }
}
