using MxNet.Gluon.Probability.Distributions.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Probability.Distributions
{
    public class Independent : Distribution
    {
        public bool HasEnumerateSupport
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Constraint Support
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

        public Independent(Distribution base_distribution, int reinterpreted_batch_ndims, bool? validate_args = null)
        {
            throw new NotImplementedException();
        }

        public override Distribution BroadcastTo(Shape batch_shape)
        {
            throw new NotImplementedException(); 
        }

        public override NDArrayOrSymbol Sample(Shape size)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol SampleN(Shape size)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol LogProb(NDArrayOrSymbol value)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Entropy()
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol EnumerateSupport()
        {
            throw new NotImplementedException();
        }
    }
}
