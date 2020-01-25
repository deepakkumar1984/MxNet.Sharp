using mx_float = System.Single;

// ReSharper disable once CheckNamespace
namespace MxNet
{
    public static class OperatorSupply
    {
        public static Symbol Plus(Symbol lhs, Symbol rhs)
        {
            return new Operator("_Plus").Set(lhs, rhs).CreateSymbol();
        }

        public static Symbol Sum(this Symbol lhs)
        {
            return new Operator("_Plus").Set(lhs).CreateSymbol();
        }

        public static Symbol Mul(Symbol lhs, Symbol rhs)
        {
            return new Operator("_Mul").Set(lhs, rhs).CreateSymbol();
        }

        public static Symbol Minus(Symbol lhs, Symbol rhs)
        {
            return new Operator("_Minus").Set(lhs, rhs).CreateSymbol();
        }

        public static Symbol Div(Symbol lhs, Symbol rhs)
        {
            return new Operator("_Div").Set(lhs, rhs).CreateSymbol();
        }

        public static Symbol Mod(Symbol lhs, Symbol rhs)
        {
            return new Operator("_Mod").Set(lhs, rhs).CreateSymbol();
        }

        public static Symbol Power(Symbol lhs, Symbol rhs)
        {
            return new Operator("_Power").Set(lhs, rhs).CreateSymbol();
        }

        public static Symbol Maximum(Symbol lhs, Symbol rhs)
        {
            return new Operator("_Maximum").Set(lhs, rhs).CreateSymbol();
        }

        public static Symbol Minimum(Symbol lhs, Symbol rhs)
        {
            return new Operator("_Minimum").Set(lhs, rhs).CreateSymbol();
        }

        public static Symbol Log(Symbol data)
        {
            return new Operator("log").SetInput("data", data).CreateSymbol();
        }

        public static Symbol PlusScalar(Symbol lhs, mx_float scalar)
        {
            return new Operator("_PlusScalar").Set(lhs)
                     .SetParam("scalar", scalar)
                     .CreateSymbol();
        }

        public static Symbol MinusScalar(Symbol lhs, mx_float scalar)
        {
            return new Operator("_MinusScalar").Set(lhs)
                     .SetParam("scalar", scalar)
                     .CreateSymbol();
        }

        public static Symbol RMinusScalar(mx_float scalar, Symbol rhs)
        {
            return new Operator("_RMinusScalar").Set(rhs)
                     .SetParam("scalar", scalar)
                     .CreateSymbol();
        }

        public static Symbol MulScalar(Symbol lhs, mx_float scalar)
        {
            return new Operator("_MulScalar").Set(lhs)
                     .SetParam("scalar", scalar)
                     .CreateSymbol();
        }

        public static Symbol DivScalar(Symbol lhs, mx_float scalar)
        {
            return new Operator("_DivScalar").Set(lhs)
                     .SetParam("scalar", scalar)
                     .CreateSymbol();
        }

        public static Symbol RDivScalar(mx_float scalar, Symbol rhs)
        {
            return new Operator("_RDivScalar").Set(rhs)
                     .SetParam("scalar", scalar)
                     .CreateSymbol();
        }

        public static Symbol ModScalar(Symbol lhs, mx_float scalar)
        {
            return new Operator("_ModScalar").Set(lhs)
                     .SetParam("scalar", scalar)
                     .CreateSymbol();
        }

        public static Symbol RModScalar(mx_float scalar, Symbol rhs)
        {
            return new Operator("_RModScalar").Set(rhs)
                     .SetParam("scalar", scalar)
                     .CreateSymbol();
        }
    }
}
