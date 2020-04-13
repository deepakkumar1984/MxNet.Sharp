using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class CenterNetDecoder : HybridBlock
    {
        private float _scale;

        private int _topk;

        public CenterNetDecoder(int topk= 100, float scale= 4, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            this._topk = topk;
            this._scale = scale;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX, args[0], args[1]);

            return F(x.SymX, args[0], args[1]);
        }

        public NDArrayOrSymbol F(NDArray x, NDArray wh, NDArray reg)
        {
            var _tup_1 = nd.ShapeArray(x).Split(num_outputs: 4, axis: 0);
            var out_h = _tup_1[2];
            var out_w = _tup_1[3];
            var _tup_2 = x.Reshape(0, -1).Topk(k: this._topk, ret_typ:  TopkRetTyp.Both);
            var scores = _tup_2[0];
            var indices = _tup_2[1];
            indices = nd.Cast(indices, DType.Int64);
            var topk_classes = nd.Cast(nd.BroadcastDiv(indices, out_h * out_w), DType.Float32);
            var topk_indices = nd.BroadcastMod(indices, out_h * out_w);
            var topk_ys = nd.BroadcastDiv(topk_indices, out_w);
            var topk_xs = nd.BroadcastMod(topk_indices, out_w);
            var center = reg.Transpose(new Shape(0, 2, 3, 1)).Reshape(0, -1, 2);
            wh = wh.Transpose(new Shape(0, 2, 3, 1)).Reshape(0, -1, 2);
            var batch_indices = nd.Cast(nd.SliceLike(nd.Arange(256), center, axes: new Shape(0)).ExpandDims(-1).Tile(reps: new Shape(1, this._topk)), DType.Int64);
            var reg_xs_indices = nd.ZerosLike(batch_indices).AsType(DType.Int64);
            var reg_ys_indices = nd.OnesLike(batch_indices).AsType(DType.Int64);
            var reg_xs = nd.Concat(new NDArrayList(batch_indices, topk_indices, reg_xs_indices), dim: 0).Reshape(3, -1);
            var reg_ys = nd.Concat(new NDArrayList(batch_indices, topk_indices, reg_ys_indices), dim: 0).Reshape(3, -1);
            var xs = nd.Cast(nd.GatherNd(center, reg_xs).Reshape(-1, this._topk), DType.Float32);
            var ys = nd.Cast(nd.GatherNd(center, reg_ys).Reshape(-1, this._topk), DType.Float32);
            topk_xs = nd.Cast(topk_xs, "float32") + xs;
            topk_ys = nd.Cast(topk_ys, "float32") + ys;
            var w = nd.Cast(nd.GatherNd(wh, reg_xs).Reshape(-1, this._topk), DType.Float32);
            var h = nd.Cast(nd.GatherNd(wh, reg_ys).Reshape(-1, this._topk), DType.Float32);
            var half_w = w / 2;
            var half_h = h / 2;
            var results = new List<NDArray> {
                    topk_xs - half_w,
                    topk_ys - half_h,
                    topk_xs + half_w,
                    topk_ys + half_h
                };

            var ret = nd.Concat((from tmp in results
                                         select tmp.ExpandDims(-1)).ToList(), dim: -1);
            return new NDArrayOrSymbol(topk_classes, scores, ret * this._scale);
        }

        public NDArrayOrSymbol F(Symbol x, Symbol wh, Symbol reg)
        {
            var _tup_1 = sym.Split(sym.ShapeArray(x), num_outputs: 4, axis: 0);
            var out_h = _tup_1[2];
            var out_w = _tup_1[3];
            var _tup_2 = sym.Topk(x.Reshape(0, -1), k: this._topk, ret_typ: TopkRetTyp.Both);
            var scores = _tup_2[0];
            var indices = _tup_2[1];
            indices = sym.Cast(indices, DType.Int64);
            var topk_classes = sym.Cast(sym.BroadcastDiv(indices, out_h * out_w), DType.Float32);
            var topk_indices = sym.BroadcastMod(indices, out_h * out_w);
            var topk_ys = sym.BroadcastDiv(topk_indices, out_w);
            var topk_xs = sym.BroadcastMod(topk_indices, out_w);
            var center = reg.Transpose(new Shape(0, 2, 3, 1)).Reshape(0, -1, 2);
            wh = wh.Transpose(new Shape(0, 2, 3, 1)).Reshape(0, -1, 2);
            var batch_indices = sym.Cast(sym.SliceLike(sym.Arange(256), center, axes: new Shape(0)).ExpandDims(-1).Tile(reps: new Shape(1, this._topk)), DType.Int64);
            var reg_xs_indices = sym.ZerosLike(batch_indices).AsType(DType.Int64);
            var reg_ys_indices = sym.OnesLike(batch_indices).AsType(DType.Int64);
            var reg_xs = sym.Concat(new SymbolList(batch_indices, topk_indices, reg_xs_indices), dim: 0).Reshape(3, -1);
            var reg_ys = sym.Concat(new SymbolList(batch_indices, topk_indices, reg_ys_indices), dim: 0).Reshape(3, -1);
            var xs = sym.Cast(sym.GatherNd(center, reg_xs).Reshape(-1, this._topk), DType.Float32);
            var ys = sym.Cast(sym.GatherNd(center, reg_ys).Reshape(-1, this._topk), DType.Float32);
            topk_xs = sym.Cast(topk_xs, "float32") + xs;
            topk_ys = sym.Cast(topk_ys, "float32") + ys;
            var w = sym.Cast(sym.GatherNd(wh, reg_xs).Reshape(-1, this._topk), DType.Float32);
            var h = sym.Cast(sym.GatherNd(wh, reg_ys).Reshape(-1, this._topk), DType.Float32);
            var half_w = w / 2;
            var half_h = h / 2;
            var results = new List<Symbol> {
                    topk_xs - half_w,
                    topk_ys - half_h,
                    topk_xs + half_w,
                    topk_ys + half_h
                };

            var ret = sym.Concat((from tmp in results
                                 select tmp.ExpandDims(-1)).ToList(), dim: -1);
            return new NDArrayOrSymbol(topk_classes, scores, ret * this._scale);
        }
    }
}
