using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Probability.Distributions
{
    public class DistributionsUtils
    {
        public static Func<NDArray, string, NDArray> ConstraintCheck()
        {
            throw new NotImplementedException();
        }

        public static Func<NDArray, NDArray> DiGamma()
        {
            throw new NotImplementedException();
        }

        public static Func<NDArray, NDArray> GammaLn()
        {
            throw new NotImplementedException();
        }

        public static Func<NDArray, NDArray> Erf()
        {
            throw new NotImplementedException();
        }

        public static Func<NDArray, NDArray> ErfInv()
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

        public static NDArray SumRightMost(NDArray x, int ndim)
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
