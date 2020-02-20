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

        public virtual NDArrayOrSymbol HybridForward(NDArrayOrSymbol pred, NDArrayOrSymbol label, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            return pred;
        }

        internal NDArrayOrSymbol ApplyWeighting(NDArrayOrSymbol loss, float? weight = null, NDArrayOrSymbol sample_weight = null)
        {
            if(sample_weight != null)
            {
                if (loss.IsNDArray)
                    loss = nd.BroadcastMul(loss, sample_weight);
                else
                    loss = sym.BroadcastMul(loss, sample_weight);
            }

            if(weight.HasValue)
            {
                if (loss.IsNDArray)
                    loss = loss.NdX * weight.Value;
                else
                    loss = loss.SymX * weight.Value;
            }

            return loss;
        }

    }
}
