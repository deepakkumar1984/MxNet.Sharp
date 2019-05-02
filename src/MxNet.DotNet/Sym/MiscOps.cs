using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet
{
    public partial class SymbolOps
    {
        public Symbol Maximum(Symbol left, Symbol right, string name = "")
        {
            return new Operator("maximum").Set(left, right).CreateSymbol(name);
        }

        public Symbol Minimum(Symbol left, Symbol right, string name = "")
        {
            return new Operator("minimum").Set(left, right).CreateSymbol(name);
        }

        public Symbol Maximum(Symbol left, float right, string name = "")
        {
            return new Operator("_MaximumScalar").Set(left)
                     .SetParam("scalar", right)
                     .CreateSymbol();
        }

        public Symbol Minimum(Symbol left, float right, string name = "")
        {
            return new Operator("_MinimumScalar").Set(left)
                     .SetParam("scalar", right)
                     .CreateSymbol();
        }

        public Symbol BroadcastMaximum(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_maximum").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol BroadcastMinimum(Symbol lhs, Symbol rhs, string name = "")
        {
            return new Operator("broadcast_minimum").Set(lhs, rhs).CreateSymbol(name);
        }

        public Symbol Clip(Symbol data, float min, float max, string name = "")
        {
            return new Operator("clip").Set(data, min, max).CreateSymbol(name);
        }

        public Symbol Abs(Symbol data, string name = "")
        {
            return new Operator("abs").Set(data).CreateSymbol(name);
        }

        public Symbol Sign(Symbol data, string name = "")
        {
            return new Operator("sign").Set(data).CreateSymbol(name);
        }

        public Symbol Gamma(Symbol data, string name = "")
        {
            return new Operator("gamma").Set(data).CreateSymbol(name);
        }

        public Symbol Gammaln(Symbol data, string name = "")
        {
            return new Operator("gammaln").Set(data).CreateSymbol(name);
        }

        public Symbol SwapAxis(Symbol data,
                                     uint dim1 = 0,
                                     uint dim2 = 0,
                                     string name = "")
        {
            return new Operator("SwapAxis").SetParam("dim1", dim1)
                                           .SetParam("dim2", dim2)
                                           .SetInput("data", data)
                                           .CreateSymbol(name);
        }

        public Symbol Transpose(Symbol data, Shape axes = null, string name = "")
        {
            if (axes == null)
                axes = new Shape();
            return new Operator("transpose").SetParam("axes", axes)
                                            .SetInput("data", data)
                                            .CreateSymbol(name);
        }
    }
}
