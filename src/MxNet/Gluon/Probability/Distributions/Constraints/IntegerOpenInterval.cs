using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Probability.Distributions.Constraints
{
    public class IntegerOpenInterval : Constraint
    {
        public IntegerOpenInterval(float lower_bound, float upper_bound)
        {
            throw new NotImplementedException();
        }

        public override bool Check(NDArrayOrSymbol value)
        {
            throw new NotImplementedException();
        }
    }
}
