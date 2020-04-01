using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class MultiClassEncoder : HybridBlock
    {
        public MultiClassEncoder(int ignore_label = -1, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            IgnoreLabel = ignore_label;
        }

        public int IgnoreLabel { get; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX, args[0], args[1]);

            return F(x.SymX, args[0], args[1]);
        }

        private NDArrayOrSymbol F(NDArray samples, NDArray matches, NDArray refs)
        {
            // samples (B, N) (+1, -1, 0: ignore), matches (B, N) [0, M), refs (B, M)
            // reshape refs (B, M) -> (B, 1, M) -> (B, N, M)
            refs = nd.BroadcastLike(refs.Reshape(0, 1, -1), matches, lhs_axes: new Shape(1), rhs_axes: new Shape(1));
            // ids (B, N, M) -> (B, N), value [0, M + 1), 0 reserved for background class
            var target_ids = nd.Pick(refs, matches, axis: 2) + 1;
            // samples 0: set ignore samples to ignore_label
            var targets = nd.Where(samples > 0.5f, target_ids, nd.OnesLike(target_ids) * this.IgnoreLabel);
            // samples -1: set negative samples to 0
            targets = nd.Where(samples < -0.5f, nd.ZerosLike(targets), targets);
            return targets;
        }

        private NDArrayOrSymbol F(Symbol samples, Symbol matches, Symbol refs)
        {
            // samples (B, N) (+1, -1, 0: ignore), matches (B, N) [0, M), refs (B, M)
            // reshape refs (B, M) -> (B, 1, M) -> (B, N, M)
            refs = sym.BroadcastLike(refs.Reshape(0, 1, -1), matches, lhs_axes: new Shape(1), rhs_axes: new Shape(1));
            // ids (B, N, M) -> (B, N), value [0, M + 1), 0 reserved for background class
            var target_ids = sym.Pick(refs, matches, axis: 2) + 1;
            // samples 0: set ignore samples to ignore_label
            var targets = sym.Where(samples > 0.5f, target_ids, sym.OnesLike(target_ids) * this.IgnoreLabel);
            // samples -1: set negative samples to 0
            targets = sym.Where(samples < -0.5f, sym.ZerosLike(targets), targets);
            return targets;
        }
    }
}
