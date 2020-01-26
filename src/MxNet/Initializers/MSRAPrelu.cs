using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Initializers
{
    public class MSRAPrelu : Xavier
    {
        public MSRAPrelu(string factor_type= "avg", float slope= 0.25f) : base("gaussian", factor_type)
        {
            throw new NotImplementedException();
        }

        public override void InitWeight(string name, NDArray arr)
        {
            throw new NotImplementedException();
        }
    }
}
