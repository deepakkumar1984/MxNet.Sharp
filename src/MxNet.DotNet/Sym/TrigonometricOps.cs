using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet
{
    public partial class SymbolOps
    {
        public Symbol Sin(Symbol data, string name = "")
        {
            return new Operator("sin").Set(data).CreateSymbol(name);
        }

        public Symbol Cos(Symbol data, string name = "")
        {
            return new Operator("cos").Set(data).CreateSymbol(name);
        }

        public Symbol Tan(Symbol data, string name = "")
        {
            return new Operator("tan").Set(data).CreateSymbol(name);
        }

        public Symbol ArcSin(Symbol data, string name = "")
        {
            return new Operator("arcsin").Set(data).CreateSymbol(name);
        }

        public Symbol ArcCos(Symbol data, string name = "")
        {
            return new Operator("arccos").Set(data).CreateSymbol(name);
        }

        public Symbol ArcTan(Symbol data, string name = "")
        {
            return new Operator("arctan").Set(data).CreateSymbol(name);
        }

        public Symbol Hypot(Symbol left, Symbol right, string name = "")
        {
            return new Operator("hypot").Set(left, right).CreateSymbol(name);
        }

        public Symbol Hypot(Symbol left, float right, string name = "")
        {
            return new Operator("hypot").Set(left, right).CreateSymbol(name);
        }

        public Symbol Hypot(float left, Symbol right, string name = "")
        {
            return new Operator("hypot").Set(left, right).CreateSymbol(name);
        }

        public Symbol BroadcastHypot(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_hypot").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol Degrees(Symbol data, string name = "")
        {
            return new Operator("degrees").Set(data).CreateSymbol(name);
        }

        public Symbol Radians(Symbol data, string name = "")
        {
            return new Operator("radians").Set(data).CreateSymbol(name);
        }
    }
}
