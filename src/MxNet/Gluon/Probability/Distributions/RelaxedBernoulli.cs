using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Probability.Distributions
{
    public class RelaxedBernoulli : TransformedDistribution
    {
        public TransformedDistribution T
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public NDArrayOrSymbol Prob
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public NDArrayOrSymbol Logit
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public RelaxedBernoulli(NDArrayOrSymbol prob = null, NDArrayOrSymbol logit = null, bool? validate_args = null)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol BroadcastTo(Shape batch_shape)
        {
            throw new NotImplementedException();
        }
    }
}
