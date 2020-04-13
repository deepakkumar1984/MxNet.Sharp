using MxNet.Gluon;
using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class OHEMSampler : Block
    {
        public int _min_samples;

        public float _ratio;

        public float _thresh;

        public OHEMSampler(float ratio, int min_samples= 0, float thresh= 0.5f, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            Debug.Assert(ratio > 0, $"OHEMSampler ratio must > 0, {ratio} given");
            this._ratio = ratio;
            this._min_samples = min_samples;
            this._thresh = thresh;
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            NDArray logits = args[0];
            NDArray ious = args[0];

            var num_positive = nd.Sum(x > -1, axis: 1);
            var num_negative = this._ratio * num_positive;
            var num_total = x.NdX.Shape[1];
            num_negative = nd.Minimum(nd.MaximumScalar(num_negative, this._min_samples), num_total - num_positive);
            var positive = logits.SliceAxis(axis: 2, begin: 1, end: null);
            var background = logits.SliceAxis(axis: 2, begin: 0, end: 1).Reshape(0, -1);
            var maxval = positive.Max(axis: 2);
            var esum = nd.Exp(logits - maxval.Reshape(0, 0, 1)).Sum(axis: 2);
            var score = nd.Negative(nd.Log(nd.Exp(background - maxval) / esum));
            var mask = nd.OnesLike(score) * -1;
            score = nd.Where(x < 0, score, mask);
            if (ious.Shape.Dimension == 3)
            {
                ious = nd.Max(ious, axis: new Shape(2));
            }
            score = nd.Where(ious < this._thresh, score, mask);
            var argmaxs = nd.Argsort(score, axis: 1, is_ascend: false);
            // neg number is different in each batch, using dynamic numpy operations.
            var y = np.zeros(new shape(x.NdX.Shape.Data));
            y[np.where(x.NdX.AsNumpy() >= 0)] = 1;
            var np_argmaxs = argmaxs.AsNumpy();
            var nunum_negative_list = num_negative.AsNumpy().astype(np.Int32).AsInt32Array();
            for(int i = 0;i< nunum_negative_list.Length;i++)
            {
                var num_neg = nunum_negative_list[i];
                var indices = (ndarray)np_argmaxs[i, $":{num_neg}"];
                y[i, indices.astype(np.Int32)] = -1;
            }
            
            return nd.Array(y, ctx: x.NdX.Context);
        }
    }
}
