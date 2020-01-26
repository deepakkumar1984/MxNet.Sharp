using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Initializers
{
    public class Constant : Initializer
    {
        public Constant(float value)
        {
            throw new NotImplementedException();
        }

        public override void InitWeight(string name, NDArray arr)
        {
            throw new NotImplementedException();
        }
    }
}
