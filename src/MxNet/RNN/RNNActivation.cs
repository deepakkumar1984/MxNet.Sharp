using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class RNNActivation
    {
        private string _name;
        private FuncArgs _kwargs;
        public RNNActivation(string name)
        {
            _name = name;
        }

        public Symbol Invoke(Symbol x)
        {
            Symbol ret = null;

            switch (_name)
            {
                case "leaky":
                    ret = sym.LeakyReLU(x);
                    break;
                case "relu":
                    ret = sym.Relu(x);
                    break;
                default:
                    break;
            }

            return ret;
        }
    }
}
