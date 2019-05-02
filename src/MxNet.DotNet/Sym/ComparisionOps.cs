using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet
{
    public partial class SymbolOps
    {
        public Symbol BroadcastEqual(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_equal").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol BroadcastNotEqual(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_not_equal").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol BroadcastGreater(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_greater").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol BroadcastGreaterEqual(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_greater_equal").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol BroadcastLesser(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_lesser").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol BroadcastLesserEqual(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_lesser_equal").Set(lhs, rhs).CreateSymbol(name);
        }
    }
}
