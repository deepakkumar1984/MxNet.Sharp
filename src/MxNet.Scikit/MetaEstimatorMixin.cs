using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit
{
    public class MetaEstimatorMixin : BaseEstimator
    {
        public string[] _required_parameters = new string[] { "estimator" };
    }
}
