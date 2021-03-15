using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Probability.Distributions
{
    public class HalfNormal : TransformedDistribution
    {
        public NDArrayOrSymbol Loc
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override NDArrayOrSymbol Mean
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override NDArrayOrSymbol Variance
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public HalfNormal(NDArrayOrSymbol scale = null, bool? validate_args = null)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol LogProb(NDArrayOrSymbol value)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Cdf(NDArrayOrSymbol value)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Icdf(NDArrayOrSymbol value)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Entropy()
        {
            throw new NotImplementedException();
        }

    }
}
