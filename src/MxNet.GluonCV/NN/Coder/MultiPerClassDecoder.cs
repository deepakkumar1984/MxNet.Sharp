using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class MultiPerClassDecoder : HybridBlock
    {
        public MultiPerClassDecoder(int num_class, int axis = -1, float thresh = 0.01f, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            _fg_class = num_class;
            _axis = axis;
            _thresh = thresh;
        }

        private int _fg_class { get; }
        private int _axis { get; }
        private float _thresh { get; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX);

            return F(x.SymX);
        }

        private NDArrayOrSymbol F(NDArray x)
        {
            var scores = x.SliceAxis(axis: this._axis, begin: 1, end: null);
            var template = nd.ZerosLike(x.SliceAxis(axis: -1, begin: 0, end: 1));
            var cls_id = nd.BroadcastAdd(template, nd.Reshape(nd.Arange(this._fg_class), shape: new Shape(1, 1, this._fg_class)));
            var mask = scores > this._thresh;
            cls_id = nd.Where(mask, cls_id, nd.OnesLike(cls_id) * -1);
            scores = nd.Where(mask, scores, nd.ZerosLike(scores));
            return new NDArrayOrSymbol(cls_id, scores);
        }

        private NDArrayOrSymbol F(Symbol x)
        {
            var scores = x.SliceAxis(axis: this._axis, begin: 1, end: null);
            var template = sym.ZerosLike(x.SliceAxis(axis: -1, begin: 0, end: 1));
            var cls_id = sym.BroadcastAdd(template, sym.Reshape(sym.Arange(this._fg_class), shape: new Shape(1, 1, this._fg_class)));
            var mask = scores > this._thresh;
            cls_id = sym.Where(mask, cls_id, sym.OnesLike(cls_id) * -1);
            scores = sym.Where(mask, scores, sym.ZerosLike(scores));
            return new NDArrayOrSymbol(cls_id, scores);
        }
    }
}
