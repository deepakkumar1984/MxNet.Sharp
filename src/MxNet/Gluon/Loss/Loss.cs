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
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public virtual NDArrayOrSymbol HybridForward(NDArrayOrSymbol pred, NDArrayOrSymbol label, NDArrayOrSymbol sample_weight = null)
        {
            return HybridForward(pred, label, sample_weight);
        }

        internal NDArrayOrSymbol ApplyWeighting(NDArrayOrSymbol loss, float? weight = null, NDArrayOrSymbol sample_weight = null) => throw new NotImplementedException();

    }
}
