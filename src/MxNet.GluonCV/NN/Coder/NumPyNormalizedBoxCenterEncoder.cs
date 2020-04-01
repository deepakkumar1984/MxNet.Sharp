using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class NumPyNormalizedBoxCenterEncoder
    {
        public NumPyNormalizedBoxCenterEncoder(float[] stds = null, float[] means = null)
        {
            if (stds == null)
                stds = new float[] { 0.1f, 0.1f, 0.2f, 0.2f };

            if (means == null)
                means = new float[] { 0, 0, 0, 0 };

            Stds = stds;
            Means = means;
            corner_to_center = new NumPyBBoxCornerToCenter(split: true);
        }

        public float[] Stds { get; }
        public float[] Means { get; }
        private NumPyBBoxCornerToCenter corner_to_center;

        public (NDArray, NDArray) Call(NDArray samples, NDArray matches, NDArray anchors, NDArray refs)
        {
            var ref_boxes = np.repeat(refs.Reshape(refs.Shape[0], 1, -1, 4), axis: 1, repeats: matches.Shape[1]);
            // refs [B, N, M, 4] -> [B, N, 4]
            ref_boxes = (ndarray)ref_boxes[":", Enumerable.Range(0, matches.Shape[1]), matches, ":"];
            ref_boxes = ref_boxes.reshape(matches.Shape[0], -1, 4);

            // g [B, N, 4], a [B, N, 4] -> codecs [B, N, 4]
            var g = this.corner_to_center.Call(nd.Array(ref_boxes));
            var a = this.corner_to_center.Call(anchors);
            var t0 = ((g[0] - a[0]) / a[2] - this.Means[0]) / this.Stds[0];
            var t1 = ((g[1] - a[1]) / a[3] - this.Means[1]) / this.Stds[1];
            var t2 = (nd.Log(g[2] / a[2]) - this.Means[2]) / this.Stds[2];
            var t3 = (nd.Log(g[3] / a[3]) - this.Means[3]) / this.Stds[3];

            var codecs = nd.Concat(new NDArrayList(t0, t1, t2, t3), dim: 2);
            // samples [B, N] -> [B, N, 1] -> [B, N, 4] -> boolean
            var temp = nd.Tile(samples.Reshape(samples.Shape[0], -1, 1), reps: new Shape(1, 1, 4)) > 0.5f;
            // fill targets and masks [B, N, 4]
            var targets = nd.Where(temp, codecs, nd.ZerosLike(temp));
            var masks = nd.Where(temp, nd.OnesLike(temp), nd.ZerosLike(temp));
            return (targets, masks);
        }
    }
}
