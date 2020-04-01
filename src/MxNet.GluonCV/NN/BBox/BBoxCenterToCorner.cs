using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class BBoxCenterToCorner : HybridBlock
    {
        public BBoxCenterToCorner(int axis = -1, bool split = false) : base(null, null)
        {
            Axis = axis;
            Split = split;
        }

        public int Axis { get; }
        public bool Split { get; }


        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX);

            return F(x.SymX);
        }

        private NDArrayOrSymbol F(NDArray x)
        {
            var splitArray = nd.Split(x, axis: this.Axis, num_outputs: 4);
            x = splitArray[0];
            var y = splitArray[1];
            var w = splitArray[2];
            var h = splitArray[3];
            var hw = w * 0.5f;
            var hh = h * 0.5f;
            var xmin = x - hw;
            var ymin = y - hh;
            var xmax = x + hw;
            var ymax = y + hh;
            if (!this.Split)
            {
                return new NDArrayOrSymbol(nd.Concat(new NDArrayList(xmin, ymin, xmax, ymax), dim: this.Axis));
            }
            else
            {
                return new NDArrayOrSymbol(xmin, ymin, xmax, ymax);
            }
        }

        private NDArrayOrSymbol F(Symbol x)
        {
            var splitArray = sym.Split(x, axis: this.Axis, num_outputs: 4);
            x = splitArray[0];
            var y = splitArray[1];
            var w = splitArray[2];
            var h = splitArray[3];
            var hw = w * 0.5f;
            var hh = h * 0.5f;
            var xmin = x - hw;
            var ymin = y - hh;
            var xmax = x + hw;
            var ymax = y + hh;
            if (!this.Split)
            {
                return new NDArrayOrSymbol(sym.Concat(new SymbolList(xmin, ymin, xmax, ymax), dim: this.Axis));
            }
            else
            {
                return new NDArrayOrSymbol(xmin, ymin, xmax, ymax);
            }
        }
    }
}
