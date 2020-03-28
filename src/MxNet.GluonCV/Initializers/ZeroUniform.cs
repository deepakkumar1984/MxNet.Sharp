using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Initializers
{
    public class ZeroUniform : Initializer
    {
        public ZeroUniform(float scale = 1)
        {
            throw new NotImplementedException();
        }

        public override void InitWeight(string name, ref NDArray arr)
        {
            throw new NotImplementedException();
        }
    }
}
