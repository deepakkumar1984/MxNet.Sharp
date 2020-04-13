using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.GluonCV.NN
{
    public class CompositeMatcher : HybridBlock
    {
        private HybridSequential _matchers;

        public CompositeMatcher(HybridBlock[] matchers, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            this._matchers = new HybridSequential();
            foreach (var m in matchers)
            {
                this._matchers.Add(m);
            }
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            var matches = _matchers.Call(x);
            return this.ComposeMatches(matches.NdX);
        }

        private NDArray ComposeMatches(NDArrayOrSymbol matches)
        {
            var result = matches[0];
            var match = matches[1];
            if(matches.IsNDArray)
                result = nd.Where(result > -0.5f, result, match);
            else
                result = sym.Where(result > -0.5f, result, match);
            return result;
        }
    }
}
