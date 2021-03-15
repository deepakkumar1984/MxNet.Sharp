using MxNet.Gluon.Probability.Distributions.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Probability.Distributions
{
    public class Distribution
    {
        public virtual NDArrayOrSymbolList ArgConstraints
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public virtual NDArrayOrSymbol Mean
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public virtual NDArrayOrSymbol Variance
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual NDArrayOrSymbol StdDev
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public virtual Constraint Support
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public static void SetDefaultValidateArgs(bool value)
        {
            throw new NotImplementedException();
        }

        public Distribution(int? event_dim = null, bool? validate_args = null)
        {
            throw new NotImplementedException();
        }

        public virtual NDArrayOrSymbol LogProb(NDArrayOrSymbol value)
        {
            throw new NotSupportedException();
        }

        public virtual NDArrayOrSymbol Pdf(NDArrayOrSymbol value)
        {
            throw new NotImplementedException();
        }

        public virtual NDArrayOrSymbol Cdf(NDArrayOrSymbol value)
        {
            throw new NotSupportedException();
        }

        public virtual NDArrayOrSymbol Icdf(NDArrayOrSymbol value)
        {
            throw new NotSupportedException();
        }

        public virtual NDArrayOrSymbol Sample(Shape size)
        {
            throw new NotSupportedException();
        }

        public virtual NDArrayOrSymbol SampleN(Shape size)
        {
            throw new NotSupportedException();
        }

        public virtual NDArrayOrSymbol BroadcastTo(Shape batch_shape)
        {
            throw new NotSupportedException();
        }

        public virtual NDArrayOrSymbol EnumerateSupport()
        {
            throw new NotSupportedException();
        }

        public virtual NDArrayOrSymbol Entropy()
        {
            throw new NotSupportedException();
        }

        public virtual NDArrayOrSymbol Perplexity()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        private bool ValidateSamples(NDArray value)
        {
            throw new NotImplementedException();
        }
    }
}
