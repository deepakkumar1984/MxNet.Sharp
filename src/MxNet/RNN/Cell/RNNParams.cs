using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class RNNParams
    {
        private string _prefix;
        private SymbolDict _params;

        public RNNParams(string prefix = "")
        {
            _prefix = prefix;
            _params = new SymbolDict();
        }

        public Symbol Get(string name, Dictionary<string, string> attr = null, Shape shape = null,
                            float? lr_mult = null, float? wd_mult = null, DType dtype = null, 
                            Initializer init = null, StorageStype? stype = null)
        {
            name = _prefix + name;
            if(!_params.Contains(name))
            {
                _params[name] = Symbol.Var(name, attr, shape, lr_mult, wd_mult, dtype, init, stype);
            }

            return _params[name];
        }
    }
}
