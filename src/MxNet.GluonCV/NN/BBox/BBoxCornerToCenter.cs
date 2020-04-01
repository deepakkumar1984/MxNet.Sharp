using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class BBoxCornerToCenter : HybridBlock
    {
        public BBoxCornerToCenter(int axis = -1, bool split = false) : base(null, null)
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
            var xmin = splitArray[0];
            var ymin = splitArray[1];
            var xmax = splitArray[2];
            var ymax = splitArray[3];
            // note that we do not have +1 here since our nms and box iou does not.
            // this is different that detectron.
            var width = xmax - xmin;
            var height = ymax - ymin;
            x = xmin + width * 0.5f;
            var y = ymin + height * 0.5f;
            if (!this.Split)
            {
                return new NDArrayOrSymbol(nd.Concat(new NDArrayList(x, y, width, height), dim: this.Axis));
            }
            else
            {
                return new NDArrayOrSymbol(x, y, width, height);
            }
        }

        private NDArrayOrSymbol F(Symbol x)
        {
            var splitArray = sym.Split(x, axis: this.Axis, num_outputs: 4);
            var xmin = splitArray[0];
            var ymin = splitArray[1];
            var xmax = splitArray[2];
            var ymax = splitArray[3];
            // note that we do not have +1 here since our nms and box iou does not.
            // this is different that detectron.
            var width = xmax - xmin;
            var height = ymax - ymin;
            x = xmin + width * 0.5f;
            var y = ymin + height * 0.5f;
            if (!this.Split)
            {
                return new NDArrayOrSymbol(sym.Concat(new SymbolList(x, y, width, height), dim: this.Axis));
            }
            else
            {
                return new NDArrayOrSymbol(x, y, width, height);
            }
        }
    }
}
