using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class NormalizedPerClassBoxCenterEncoder : HybridBlock
    {
        private int _batch_size;

        private int _max_pos;

        private int _num_class;

        private NormalizedBoxCenterEncoder class_agnostic_encoder;

        public float[] Means { get; }

        public float[] Stds { get; }

        public NormalizedPerClassBoxCenterEncoder(int num_class, int max_pos= 128, int per_device_batch_size= 1, float[] stds = null, float[] means = null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            if (stds == null)
                stds = new float[] { 0.1f, 0.1f, 0.2f, 0.2f };

            if (means == null)
                means = new float[] { 0, 0, 0, 0 };

            Debug.Assert(stds.Length == 4, "Box Encoder requires 4 std values.");
            Debug.Assert(num_class > 0, "Number of classes must be positive");
            this._num_class = num_class;
            this._max_pos = max_pos;
            this._batch_size = per_device_batch_size;
            this.class_agnostic_encoder = new NormalizedBoxCenterEncoder(stds: stds, means: means);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX, args[0], args[1], args[2], args[3]);

            return F(x.SymX, args[0], args[1], args[2], args[3]);
        }

        private NDArrayOrSymbol F(NDArray samples, NDArray matches, NDArray anchors, NDArray labels, NDArray refs)
        {
            var _tup_2 = this.class_agnostic_encoder.Call(samples, matches, anchors, refs);
            NDArray targets = _tup_2[0];
            NDArray masks = _tup_2[1];

            var ref_labels = nd.BroadcastLike(labels.Reshape(0, 1, -1), matches, lhs_axes: new Shape(1), rhs_axes: new Shape(1));
            // labels [B, N, M] -> pick from matches [B, N] -> [B, N, 1]
            ref_labels = nd.Pick(ref_labels, matches, axis: 2).Reshape(0, -1).ExpandDims(2);
            // boolean array [B, N, C]
            var same_cids = nd.BroadcastEqual(ref_labels, nd.Reshape(nd.Arange(this._num_class), shape: new Shape(1, 1, -1)));
            // reduce box targets to positive samples only
            var indices = nd.SliceAxis(nd.Reshape(nd.Argsort(nd.SliceAxis(masks, axis: -1, begin: 0, end: 1), axis: 1, is_ascend: false), new Shape(this._batch_size, -1)), axis: 1, begin: 0, end: this._max_pos);
            var targets_tmp = new List<NDArray>();
            var masks_tmp = new List<NDArray>();
            var same_cids_tmp = new List<NDArray>();
            foreach (var i in Enumerable.Range(0, this._batch_size))
            {
                var ind = nd.SliceAxis(indices, axis: 0, begin: i, end: i + 1).Squeeze(axis: 0);
                var target = nd.SliceAxis(targets, axis: 0, begin: i, end: i + 1).Squeeze(axis: 0);
                var mask = nd.SliceAxis(masks, axis: 0, begin: i, end: i + 1).Squeeze(axis: 0);
                var same_cid = nd.SliceAxis(same_cids, axis: 0, begin: i, end: i + 1).Squeeze(axis: 0);
                targets_tmp.Add(nd.Take(target, ind).ExpandDims(axis: 0));
                masks_tmp.Add(nd.Take(mask, ind).ExpandDims(axis: 0));
                same_cids_tmp.Add(nd.Take(same_cid, ind).ExpandDims(axis: 0));
            }

            targets = nd.Concat(targets_tmp, dim: 0);
            masks = nd.Concat(masks_tmp, dim: 0);
            same_cids = nd.Concat(same_cids_tmp, dim: 0).ExpandDims(3);
            // targets, masks [B, N_pos, C, 4]
            var all_targets = nd.BroadcastAxis(targets.ExpandDims(2), axis: new Shape(2), size: new Shape(this._num_class));
            var all_masks = nd.BroadcastMul(masks.ExpandDims(2), nd.BroadcastAxis(same_cids, axis: new Shape(3), size: new Shape(4)));
            return new NDArrayOrSymbol(all_targets, all_masks, indices);
        }

        private NDArrayOrSymbol F(Symbol samples, Symbol matches, Symbol anchors, Symbol labels, Symbol refs)
        {
            var _tup_2 = this.class_agnostic_encoder.Call(samples, matches, anchors, refs);
            Symbol targets = _tup_2[0];
            Symbol masks = _tup_2[1];

            var ref_labels = sym.BroadcastLike(labels.Reshape(0, 1, -1), matches, lhs_axes: new Shape(1), rhs_axes: new Shape(1));
            // labels [B, N, M] -> pick from matches [B, N] -> [B, N, 1]
            ref_labels = sym.Pick(ref_labels, matches, axis: 2).Reshape(0, -1).ExpandDims(2);
            // boolean array [B, N, C]
            var same_cids = sym.BroadcastEqual(ref_labels, sym.Reshape(sym.Arange(this._num_class), shape: new Shape(1, 1, -1)));
            // reduce box targets to positive samples only
            var indices = sym.SliceAxis(sym.Reshape(sym.Argsort(sym.SliceAxis(masks, axis: -1, begin: 0, end: 1), axis: 1, is_ascend: false), new Shape(this._batch_size, -1)), axis: 1, begin: 0, end: this._max_pos);
            var targets_tmp = new List<Symbol>();
            var masks_tmp = new List<Symbol>();
            var same_cids_tmp = new List<Symbol>();
            foreach (var i in Enumerable.Range(0, this._batch_size))
            {
                var ind = sym.SliceAxis(indices, axis: 0, begin: i, end: i + 1).Squeeze(axis: 0);
                var target = sym.SliceAxis(targets, axis: 0, begin: i, end: i + 1).Squeeze(axis: 0);
                var mask = sym.SliceAxis(masks, axis: 0, begin: i, end: i + 1).Squeeze(axis: 0);
                var same_cid = sym.SliceAxis(same_cids, axis: 0, begin: i, end: i + 1).Squeeze(axis: 0);
                targets_tmp.Add(sym.Take(target, ind).ExpandDims(axis: 0));
                masks_tmp.Add(sym.Take(mask, ind).ExpandDims(axis: 0));
                same_cids_tmp.Add(sym.Take(same_cid, ind).ExpandDims(axis: 0));
            }

            targets = sym.Concat(targets_tmp, dim: 0);
            masks = sym.Concat(masks_tmp, dim: 0);
            same_cids = sym.Concat(same_cids_tmp, dim: 0).ExpandDims(3);
            // targets, masks [B, N_pos, C, 4]
            var all_targets = sym.BroadcastAxis(targets.ExpandDims(2), axis: new Shape(2), size: new Shape(this._num_class));
            var all_masks = sym.BroadcastMul(masks.ExpandDims(2), sym.BroadcastAxis(same_cids, axis: new Shape(3), size: new Shape(4)));
            return new NDArrayOrSymbol(all_targets, all_masks, indices);
        }
    }
}
