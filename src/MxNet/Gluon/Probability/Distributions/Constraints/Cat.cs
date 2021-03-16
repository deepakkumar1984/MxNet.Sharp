using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Probability.Distributions.Constraints
{
    public class Cat : Constraint
    {
        public Cat(NDArrayOrSymbol constraint_seq, int axis = 0, int? lengths = null)
        {
            throw new NotImplementedException();
        }

        public override bool Check(NDArrayOrSymbol value)
        {
            throw new NotImplementedException();
        }
    }
}
