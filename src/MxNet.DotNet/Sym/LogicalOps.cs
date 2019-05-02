using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet
{
    public partial class SymbolOps
    {
        public Symbol BroadcastLogicalAnd(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_logical_and").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol BroadcastLogicalOr(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_logical_or").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol BroadcastLogicalXor(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_logical_xor").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol LogicalNot(Symbol data, string name = "")
        {
            return new Operator("logical_not").Set(data).CreateSymbol(name);
        }
    }
}
