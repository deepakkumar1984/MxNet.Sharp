using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Probability.Transformations
{
    public class ComposeTransform : Transformation
    {
        public override NDArrayOrSymbol F { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override NDArrayOrSymbol Sign => throw new NotImplementedException();

        public override NDArrayOrSymbol Inv => throw new NotImplementedException();

        public int EventDim
        {
            get
            {
                throw new NotImplementedException();
            }
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
    }
}
