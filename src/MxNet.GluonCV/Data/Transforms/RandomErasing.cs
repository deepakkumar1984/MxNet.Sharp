using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms
{
    public class RandomErasing : Block
    {
        public RandomErasing(float probability= 0.5f, float s_min= 0.02f, float s_max= 0.4f, float ratio= 0.3f, (float, float, float)? mean= null) : base(null, null)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
