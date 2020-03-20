using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class RNNParams
    {
        public RNNParams(string prefix = "")
        {
            throw new NotImplementedException();
        }

        public Symbol Get(string name, Dictionary<string, string> attr = null, Shape shape = null,
            float? lr_mult = null, float? wd_mult = null,
            DType dtype = null, Initializer init = null, StorageStype? stype = null)
        {
            throw new NotImplementedException();
        }
    }
}
