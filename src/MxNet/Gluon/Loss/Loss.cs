using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class Loss : HybridBlock
    {
        internal float? _weight;
        internal int? _batch_axis;

        public Loss(float? weight = null, int? batch_axis = null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            _weight = weight;
            _batch_axis = batch_axis;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            return x;
        }

        public virtual NDArrayOrSymbol HybridForward(NDArrayOrSymbol pred, NDArrayOrSymbol label, NDArrayOrSymbol sample_weight = null)
        {
            return pred;
        }

        internal NDArrayOrSymbol ApplyWeighting(NDArrayOrSymbol loss, float? weight = null, NDArrayOrSymbol sample_weight = null) => throw new NotImplementedException();

    }
}
