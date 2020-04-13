using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class Consensus : HybridBlock
    {
        public Consensus(int nclass, int num_segments, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            NClass = nclass;
            NumSegments = num_segments;
        }

        public int NClass { get; }
        public int NumSegments { get; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX);

            return F(x.SymX);
        }

        private NDArrayOrSymbol F(NDArray x)
        {
            var reshape_out = x.Reshape(-1, this.NumSegments, this.NClass);
            var consensus_out = reshape_out.Mean(axis: 1);
            return consensus_out;
        }

        private NDArrayOrSymbol F(Symbol x)
        {
            var reshape_out = x.Reshape(-1, this.NumSegments, this.NClass);
            var consensus_out = reshape_out.Mean(axis: 1);
            return consensus_out;
        }
    }
}
