using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Probability.Distributions
{
    public class ExponentialFamily : Distribution
    {
        public virtual object[] NaturalParams
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public virtual NDArrayOrSymbol LogNormalizer(params object[] natural_params)
        {
            throw new NotSupportedException();
        }

        public virtual NDArrayOrSymbol MeanCarrierMeasure(NDArrayOrSymbol x)
        {
            throw new NotSupportedException();
        }
    }
}
