using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet
{
    public partial class SymbolOps
    {
        public Symbol BroadcastPower(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_power").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol Sqrt(Symbol data, string name = "")
        {
            return new Operator("sqrt").Set(data).CreateSymbol(name);
        }

        public Symbol RSqrt(Symbol data, string name = "")
        {
            return new Operator("rsqrt").Set(data).CreateSymbol(name);
        }

        public Symbol Cbrt(Symbol data, string name = "")
        {
            return new Operator("cbrt").Set(data).CreateSymbol(name);
        }

        public Symbol RCbrt(Symbol data, string name = "")
        {
            return new Operator("rcbrt").Set(data).CreateSymbol(name);
        }

        public Symbol Square(Symbol data, string name = "")
        {
            return new Operator("square").Set(data).CreateSymbol(name);
        }

        public Symbol Reciprocal(Symbol data, string name = "")
        {
            return new Operator("reciprocal").Set(data).CreateSymbol(name);
        }
    }
}
