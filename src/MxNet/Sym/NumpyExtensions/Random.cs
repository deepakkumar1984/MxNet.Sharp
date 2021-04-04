using MxNet.Numpy;
using System;
using System.Collections.Generic;
using System.Text;
using dtype = NumpyDotNet.dtype;

namespace MxNet.Sym.Numpy
{
    internal partial class Random
    {
        public ndarray bernoulli(float? prob = null, float? logit = null, Shape size = null, dtype dtype = null, Context ctx = null, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public ndarray uniform_n(float low = 0, float high = 1, Shape batch_shape = null, dtype dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public ndarray normal_n(float loc = 0, float scale = 1, Shape batch_shape = null, dtype dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }
    }
}
