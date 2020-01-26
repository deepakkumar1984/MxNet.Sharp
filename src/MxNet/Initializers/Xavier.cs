using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Initializers
{
    public class Xavier : Initializer
    {
        public Xavier(string rnd_type= "uniform", string factor_type= "avg", float magnitude= 3)
        {
            throw new NotImplementedException();
        }

        public override void InitWeight(string name, NDArray arr)
        {
            throw new NotImplementedException();
        }
    }
}
