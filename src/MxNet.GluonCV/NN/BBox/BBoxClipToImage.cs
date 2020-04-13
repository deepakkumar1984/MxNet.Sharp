using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class BBoxClipToImage : HybridBlock
    {
        public BBoxClipToImage(string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX, args[0]);

            return F(x.SymX, args[0]);
        }

        private NDArrayOrSymbol F(NDArray x, NDArray img)
        {
            x = nd.MaximumScalar(x, 0);
            // window [B, 2] -> reverse hw -> tile [B, 4] -> [B, 1, 4], boxes [B, N, 4]
            var window = nd.ShapeArray(img).SliceAxis(axis: 0, begin: 2, end: null).ExpandDims(0);
            var m = nd.Tile(nd.Reverse(window, axis: new Shape(1)), reps: new Shape(2)).Reshape(new Shape(0, -4, 1, -1));
            return nd.BroadcastMinimum(x, nd.Cast(m, dtype: DType.Float32));
        }

        private NDArrayOrSymbol F(Symbol x, Symbol img)
        {
            x = sym.MaximumScalar(x, 0);
            // window [B, 2] -> reverse hw -> tile [B, 4] -> [B, 1, 4], boxes [B, N, 4]
            var window = sym.ExpandDims(sym.ShapeArray(img).SliceAxis(axis: 0, begin: 2, end: null), 0);
            var m = sym.Tile(sym.Reverse(window, axis: new Shape(1)), reps: new Shape(2)).Reshape(new Shape(0, -4, 1, -1));
            return sym.BroadcastMinimum(x, sym.Cast(m, dtype: DType.Float32));
        }
    }
}
