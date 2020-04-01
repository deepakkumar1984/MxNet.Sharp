using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class NormalizedBoxCenterEncoder : HybridBlock
    {
        public NormalizedBoxCenterEncoder(float[] stds = null, float[] means = null)
        {
            if (stds == null)
                stds = new float[] { 0.1f, 0.1f, 0.2f, 0.2f };

            if (means == null)
                means = new float[] { 0, 0, 0, 0 };

            Debug.Assert(stds.Length == 4, "Box Encoder requires 4 std values.");
            Debug.Assert(means.Length == 4, "Box Encoder requires 4 std values.");
            this.Means = means;
            this.Stds = stds;
            this.corner_to_center = new BBoxCornerToCenter(split: true);
        }

        public float[] Stds { get; }
        public float[] Means { get; }
        private BBoxCornerToCenter corner_to_center;

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX, args[0], args[1], args[2]);

            return F(x.SymX, args[0], args[1], args[2]);
        }

        private NDArrayOrSymbol F(NDArray samples, NDArray matches, NDArray anchors, NDArray refs)
        {
            // TODO(zhreshold): batch_pick, take multiple elements?
            // refs [B, M, 4], anchors [B, N, 4], samples [B, N], matches [B, N]
            // refs [B, M, 4] -> reshape [B, 1, M, 4] -> repeat [B, N, M, 4]
            NDArrayList ref_boxes = nd.BroadcastLike(refs.Reshape(0, 1, -1, 4), matches, lhs_axes: new Shape(1), rhs_axes: new Shape(1));
            // refs [B, N, M, 4] -> 4 * [B, N, M]
            ref_boxes = nd.Split(ref_boxes, axis: -1, num_outputs: 4, squeeze_axis: true);
            // refs 4 * [B, N, M] -> pick from matches [B, N, 1] -> concat to [B, N, 4]
            ref_boxes = nd.Concat((from i in Enumerable.Range(0, 4)
                                          select nd.Pick(ref_boxes[i], matches, axis: 2).Reshape(0, -1, 1)).ToList(), 2);
            // transform based on x, y, w, h
            // g [B, N, 4], a [B, N, 4] -> codecs [B, N, 4]
            var g = this.corner_to_center.Call(ref_boxes[0]);
            var a = this.corner_to_center.Call(anchors);
            var t0 = ((g[0] - a[0]) / a[2] - this.Means[0]) / this.Stds[0];
            var t1 = ((g[1] - a[1]) / a[3] - this.Means[1]) / this.Stds[1];
            var t2 = (nd.Log(g[2] / a[2]) - this.Means[2]) / this.Stds[2];
            var t3 = (nd.Log(g[3] / a[3]) - this.Means[3]) / this.Stds[3];
            var codecs = nd.Concat(new NDArrayList(t0, t1, t2, t3), dim: 2);
            // samples [B, N] -> [B, N, 1] -> [B, N, 4] -> boolean
            var temp = nd.Tile(samples.Reshape(0, -1, 1), reps: new Shape(1, 1, 4)) > 0.5f;
            // fill targets and masks [B, N, 4]
            var targets = nd.Where(temp, codecs, nd.ZerosLike(codecs));
            var masks = nd.Where(temp, nd.OnesLike(temp), nd.ZerosLike(temp));
            return new NDArrayOrSymbol(targets, masks);
        }

        private NDArrayOrSymbol F(Symbol samples, Symbol matches, Symbol anchors, Symbol refs)
        {
            // TODO(zhreshold): batch_pick, take multiple elements?
            // refs [B, M, 4], anchors [B, N, 4], samples [B, N], matches [B, N]
            // refs [B, M, 4] -> reshape [B, 1, M, 4] -> repeat [B, N, M, 4]
            var ref_boxes = sym.BroadcastLike(refs.Reshape(0, 1, -1, 4), matches, lhs_axes: new Shape(1), rhs_axes: new Shape(1));
            // refs [B, N, M, 4] -> 4 * [B, N, M]
            ref_boxes = sym.Split(ref_boxes, axis: -1, num_outputs: 4, squeeze_axis: true);
            // refs 4 * [B, N, M] -> pick from matches [B, N, 1] -> concat to [B, N, 4]
            ref_boxes = sym.Concat((from i in Enumerable.Range(0, 4)
                                   select sym.Pick(ref_boxes[i], matches, axis: 2).Reshape(0, -1, 1)).ToList(), 2);
            // transform based on x, y, w, h
            // g [B, N, 4], a [B, N, 4] -> codecs [B, N, 4]
            var g = this.corner_to_center.Call(ref_boxes[0]);
            var a = this.corner_to_center.Call(anchors);
            var t0 = ((g[0] - a[0]) / a[2] - this.Means[0]) / this.Stds[0];
            var t1 = ((g[1] - a[1]) / a[3] - this.Means[1]) / this.Stds[1];
            var t2 = (sym.Log(g[2] / a[2]) - this.Means[2]) / this.Stds[2];
            var t3 = (sym.Log(g[3] / a[3]) - this.Means[3]) / this.Stds[3];
            var codecs = sym.Concat(new SymbolList(t0, t1, t2, t3), dim: 2);
            // samples [B, N] -> [B, N, 1] -> [B, N, 4] -> boolean
            var temp = sym.GreaterScalar(sym.Tile(samples.Reshape(0, -1, 1), reps: new Shape(1, 1, 4)), 0.5f);
            // fill targets and masks [B, N, 4]
            var targets = sym.Where(temp, codecs, sym.ZerosLike(codecs));
            var masks = sym.Where(temp, sym.OnesLike(temp), sym.ZerosLike(temp));
            return new NDArrayOrSymbol(targets, masks);
        }
    }
}
