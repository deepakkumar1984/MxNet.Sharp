using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN.BBox
{
    public class BBoxArea : HybridBlock
    {
        private HybridBlock _pre;
        public BBoxArea(int axis = -1, string fmt = "corner", string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            if (fmt.ToLower() == "corner")
            {
                this._pre = new BBoxCornerToCenter(split: true);
            }
            else if (fmt.ToLower() == "center")
            {
                this._pre = new BBoxSplit(axis: axis);
            }
            else
            {
                throw new Exception($"Unsupported format: {fmt}. Use 'corner' or 'center'.");
            }
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            var _tup_1 = this._pre.Call(x);
            var width = _tup_1[2];
            var height = _tup_1[3];
            if (x.IsNDArray)
            {
                width = nd.Where(width > 0, width, nd.ZerosLike(width));
                height = nd.Where(height > 0, height, nd.ZerosLike(height));
            }
            else
            {
                width = sym.Where(width > 0, width, sym.ZerosLike(width));
                height = sym.Where(height > 0, height, sym.ZerosLike(height));
            }

            return width * height;
        }
    }
}
