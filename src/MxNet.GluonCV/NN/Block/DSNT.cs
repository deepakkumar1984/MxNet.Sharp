using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class DSNT : HybridBlock
    {
        public DSNT((int, int) size, string norm = "sum", Shape axis = null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            this.Size = size;
            this.Axis = axis;
            this.Norm = norm;
            if (this.Norm == "softmax")
            {
                this.softmax = new SoftmaxHD(this.Axis);
            }
            else if (this.Norm != "sum")
            {
                throw new Exception("argument `norm` only accepts 'softmax' or 'sum'.");
            }

            this.WFirst = 1 / (2 * this.Size.Item1);
            this.WLast = 1 - 1 / (2 * this.Size.Item1);
            this.HFirst = 1 / (2 * this.Size.Item2);
            this.HLast = 1 - 1 / (2 * this.Size.Item2);
        }

        public (int, int) Size { get; }
        public string Norm { get; }
        public Shape Axis { get; }
        public float HFirst;
        public float HLast;
        public SoftmaxHD softmax;
        public float WFirst;
        public float WLast;

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX);

            return F(x.SymX);
        }

        public NDArrayOrSymbol F(NDArray M)
        {
            NDArrayOrSymbol Z = null;
            if (this.Norm == "softmax")
            {
                Z = this.softmax.Call(M);
            }
            else if (this.Norm == "sum")
            {
                var norm = nd.Sum(M, axis: this.Axis, keepdims: true);
                Z = nd.BroadcastDiv(M, norm);
            }
            else
            {
                Z = M;
            }
            var x = nd.Linspace(this.WFirst, this.WLast, this.Size.Item1).ExpandDims(0);
            var y = nd.Linspace(this.HFirst, this.HLast, this.Size.Item2).ExpandDims(0).Transpose();
            var output_x = nd.Sum(nd.BroadcastMul(Z, x), axis: this.Axis);
            var output_y = nd.Sum(nd.BroadcastMul(Z, y), axis: this.Axis);
            var res = nd.Stack(new NDArrayList(output_x, output_y), 2, axis: 2);
            return new NDArrayOrSymbol(res, Z);
        }

        public NDArrayOrSymbol F(Symbol M)
        {
            NDArrayOrSymbol Z = null;
            if (this.Norm == "softmax")
            {
                Z = this.softmax.Call(M);
            }
            else if (this.Norm == "sum")
            {
                var norm = sym.Sum(M, axis: this.Axis, keepdims: true);
                Z = sym.BroadcastDiv(M, norm);
            }
            else
            {
                Z = M;
            }
            var x = sym.Linspace(this.WFirst, this.WLast, this.Size.Item1).ExpandDims(0);
            var y = sym.Linspace(this.HFirst, this.HLast, this.Size.Item2).ExpandDims(0).Transpose();
            var output_x = sym.Sum(sym.BroadcastMul(Z, x), axis: this.Axis);
            var output_y = sym.Sum(sym.BroadcastMul(Z, y), axis: this.Axis);
            var res = sym.Stack(new SymbolList(output_x, output_y), 2, axis: 2);
            return new NDArrayOrSymbol(res, Z);
        }
    }
}
