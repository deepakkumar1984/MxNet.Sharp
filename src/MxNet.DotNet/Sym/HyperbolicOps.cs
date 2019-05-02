using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet.Sym
{
    public partial class SymbolOps
    {
        public Symbol Sinh(Symbol data, string name = "")
        {
            return new Operator("sinh").Set(data).CreateSymbol(name);
        }

        public Symbol Cosh(Symbol data, string name = "")
        {
            return new Operator("cosh").Set(data).CreateSymbol(name);
        }

        public Symbol Tanh(Symbol data, string name = "")
        {
            return new Operator("tanh").Set(data).CreateSymbol(name);
        }

        public Symbol ArcSinh(Symbol data, string name = "")
        {
            return new Operator("arcsinh").Set(data).CreateSymbol(name);
        }

        public Symbol ArcCosh(Symbol data, string name = "")
        {
            return new Operator("arccosh").Set(data).CreateSymbol(name);
        }

        public Symbol ArcTanh(Symbol data, string name = "")
        {
            return new Operator("arctanh").Set(data).CreateSymbol(name);
        }
    }
}
