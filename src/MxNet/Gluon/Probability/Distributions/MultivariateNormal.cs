using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Probability.Distributions
{
    public class MultivariateNormal : Distribution
    {
        public NDArrayOrSymbol ScaleTril
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public NDArrayOrSymbol Cov
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public NDArrayOrSymbol Precision
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public MultivariateNormal(NDArrayOrSymbol loc, NDArrayOrSymbol cov = null, NDArrayOrSymbol precision = null, NDArrayOrSymbol scale_tril = null, bool? validate_args = null)
        {
            throw new NotImplementedException();
        }

        private NDArrayOrSymbol _precision_to_scale_tril(NDArrayOrSymbol P)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol LogProb(NDArrayOrSymbol value)
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
    }
}
