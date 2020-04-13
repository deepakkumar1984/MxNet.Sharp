using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class MultiClassDecoder : HybridBlock
    {
        public MultiClassDecoder(int axis= -1, float thresh= 0.01f, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            Axis = axis;
            Thresh = thresh;
        }

        public int Axis { get; }
        public float Thresh { get; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX);

            return F(x.SymX);
        }

        private NDArrayOrSymbol F(NDArray x)
        {
            var pos_x = x.SliceAxis(axis: this.Axis, begin: 1, end: null);
            var cls_id = nd.Argmax(pos_x, this.Axis);
            var scores = nd.Pick(pos_x, cls_id, axis: -1);
            var mask = scores > this.Thresh;
            cls_id = nd.Where(mask, cls_id, nd.OnesLike(cls_id) * -1);
            scores = nd.Where(mask, scores, nd.ZerosLike(scores));
            return new NDArrayOrSymbol(cls_id, scores);
        }

        private NDArrayOrSymbol F(Symbol x)
        {
            var pos_x = x.SliceAxis(axis: this.Axis, begin: 1, end: null);
            var cls_id = sym.Argmax(pos_x, this.Axis);
            var scores = sym.Pick(pos_x, cls_id, axis: -1);
            var mask = scores > this.Thresh;
            cls_id = sym.Where(mask, cls_id, sym.OnesLike(cls_id) * -1);
            scores = sym.Where(mask, scores, sym.ZerosLike(scores));
            return new NDArrayOrSymbol(cls_id, scores);
        }
    }
}
