using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Initializers
{
    public class Orthogonal : Initializer
    {
        public Orthogonal(float scale = 1.414f, string rand_type = "uniform")
        {
            throw new NotImplementedException();
        }

        public override void InitWeight(string name, NDArray arr)
        {
            throw new NotImplementedException();
        }
    }
}
