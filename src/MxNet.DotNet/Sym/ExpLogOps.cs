using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet
{
    public partial class SymbolOps
    {
        public Symbol Exp(Symbol data, string name = "")
        {
            return new Operator("exp").Set(data).CreateSymbol(name);
        }

        public Symbol Expm1(Symbol data, string name = "")
        {
            return new Operator("expm1").Set(data).CreateSymbol(name);
        }

        public Symbol Log(Symbol data, string name = "")
        {
            return new Operator("log").Set(data).CreateSymbol(name);
        }

        public Symbol Log10(Symbol data, string name = "")
        {
            return new Operator("log10").Set(data).CreateSymbol(name);
        }

        public Symbol Log2(Symbol data, string name = "")
        {
            return new Operator("log2").Set(data).CreateSymbol(name);
        }

        public Symbol Log1p(Symbol data, string name = "")
        {
            return new Operator("log1p").Set(data).CreateSymbol(name);
        }
    }
}
