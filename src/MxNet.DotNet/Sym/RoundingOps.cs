using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet
{
    public partial class SymbolOps
    {
        public Symbol Round(Symbol data, string name = "")
        {
            return new Operator("round").Set(data).CreateSymbol(name);
        }

        public Symbol RInt(Symbol data, string name = "")
        {
            return new Operator("rint").Set(data).CreateSymbol(name);
        }

        public Symbol Fix(Symbol data, string name = "")
        {
            return new Operator("fix").Set(data).CreateSymbol(name);
        }

        public Symbol Floor(Symbol data, string name = "")
        {
            return new Operator("floor").Set(data).CreateSymbol(name);
        }

        public Symbol Ceil(Symbol data, string name = "")
        {
            return new Operator("ceil").Set(data).CreateSymbol(name);
        }

        public Symbol Trunc(Symbol data, string name = "")
        {
            return new Operator("trunc").Set(data).CreateSymbol(name);
        }
    }
}
