using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Probability.Transformations
{
    public class _InverseTransformation : Transformation
    {
        public override NDArrayOrSymbol Sign => throw new NotImplementedException();

        public override NDArrayOrSymbol Inv => throw new NotImplementedException();

        public _InverseTransformation(Transformation forward_transformation)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol ForwardCompute(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol InverseCompute(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol LogDetJacobian(NDArrayOrSymbol x, NDArrayOrSymbol y)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Call(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }
    }
}
