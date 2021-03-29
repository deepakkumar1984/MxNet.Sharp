using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Probability.Distributions
{
    public class DistributionsUtils
    {
        public static Func<NDArrayOrSymbol, string, NDArrayOrSymbol> ConstraintCheck()
        {
            throw new NotImplementedException();
        }

        public static Func<NDArrayOrSymbol, NDArrayOrSymbol> DiGamma()
        {
            throw new NotImplementedException();
        }

        public static Func<NDArrayOrSymbol, NDArrayOrSymbol> GammaLn()
        {
            throw new NotImplementedException();
        }

        public static Func<NDArrayOrSymbol, NDArrayOrSymbol> Erf()
        {
            throw new NotImplementedException();
        }

        public static Func<NDArrayOrSymbol, NDArrayOrSymbol> ErfInv()
        {
            throw new NotImplementedException();
        }

        public static Shape SampleNShapeConverter(Shape size)
        {
            throw new NotImplementedException();
        }

        public static object GetF(NDArrayOrSymbolList @params)
        {
            throw new NotImplementedException();
        }

        public static NDArray SumRightMost(NDArrayOrSymbol x, int ndim)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol ClipProb(NDArrayOrSymbol prob)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol ClipFloatEps(NDArrayOrSymbol value)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol Prob2Logit(NDArrayOrSymbol prob, bool binary = true)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol Logit2Prob(NDArrayOrSymbol logit, bool binary = true)
        {
            throw new NotImplementedException();
        }
    }
}
