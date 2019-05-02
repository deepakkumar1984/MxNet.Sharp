using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet
{
    public partial class SymbolOps
    {
        public Symbol Add(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("_Plus").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol Mul(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("_Mul").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol Sub(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("_Minus").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol Div(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("_Div").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol Mod(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("_Mod").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol Power(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("_Power").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol BroadcastAdd(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_add").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol BroadcastSub(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_sub").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol BroadcastMul(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_mul").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol BroadcastDiv(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_div").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol BroadcastMod(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_mod").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol Negative(Symbol data, string name = "")
        {
            return new Operator("negative").Set(data).CreateSymbol(name);
        }

        public Symbol Dot(Symbol lhs, Symbol rhs, bool transpose_a = false, bool transpose_b = false, string name = "")
        {
            return new Operator("dot").Set(lhs, rhs, transpose_a, transpose_b).CreateSymbol(name);
        }

        public Symbol BatchDot(Symbol lhs, Symbol rhs, bool transpose_a = false, bool transpose_b = false, string name = "")
        {
            return new Operator("batch_dot").Set(lhs, rhs, transpose_a, transpose_b).CreateSymbol(name);
        }

        public Symbol AddN(Symbol[] data, string name = "")
        {
            return new Operator("add_n").Set(data).CreateSymbol(name);
        }
    }
}
