using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.NN
{
    public class Concatenate : Sequential
    {
        public int Axis { get; set; }
        public Concatenate(int axis = -1)
        {
            Axis = axis;
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
