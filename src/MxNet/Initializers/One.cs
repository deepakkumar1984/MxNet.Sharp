using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Initializers
{
    public class One : Initializer
    {
        public override void InitWeight(string name, ref NDArray arr)
        {
            arr.Constant(1);
        }
    }
}
