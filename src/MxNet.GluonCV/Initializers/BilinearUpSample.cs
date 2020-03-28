using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Initializers
{
    public class BilinearUpSample : Initializer
    {
        public BilinearUpSample()
        {
        }

        public override void InitWeight(string name, ref NDArray arr)
        {
            throw new NotImplementedException();
        }
    }
}
