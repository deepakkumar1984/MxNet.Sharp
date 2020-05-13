using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Cluster
{
    public class AgglomerationTransform : TransformerMixin
    {
        public override NDArray Fit(NDArray X, NDArray y = null, FuncArgs fit_params = null)
        {
            throw new NotImplementedException();
        }

        public override NDArray Transform(NDArray X)
        {
            throw new NotImplementedException();
        }

        public NDArray InverseTransform(NDArray Xred)
        {
            throw new NotImplementedException();
        }
    }
}
