using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet
{
    public partial class SymbolOps
    {
        public Symbol Sum(Symbol data, Shape axis = null, bool keepDims = false, bool exclude = false, string name = "")
        {
            if (axis == null)
                axis = new Shape();
            return new Operator("sum").Set(data, axis, keepDims, exclude).CreateSymbol(name);
        }

        public Symbol NanSum(Symbol data, Shape axis = null, bool keepDims = false, bool exclude = false, string name = "")
        {
            if (axis == null)
                axis = new Shape();
            return new Operator("nansum").Set(data, axis, keepDims, exclude).CreateSymbol(name);
        }

        public Symbol Prod(Symbol data, Shape axis = null, bool keepDims = false, bool exclude = false, string name = "")
        {
            if (axis == null)
                axis = new Shape();
            return new Operator("prod").Set(data, axis, keepDims, exclude).CreateSymbol(name);
        }

        public Symbol NanProd(Symbol data, Shape axis = null, bool keepDims = false, bool exclude = false, string name = "")
        {
            if (axis == null)
                axis = new Shape();
            return new Operator("nanprod").Set(data, axis, keepDims, exclude).CreateSymbol(name);
        }

        public Symbol Mean(Symbol data, Shape axis = null, bool keepDims = false, bool exclude = false, string name = "")
        {
            if (axis == null)
                axis = new Shape();
            return new Operator("mean").Set(data, axis, keepDims, exclude).CreateSymbol(name);
        }

        public Symbol Max(Symbol data, Shape axis = null, bool keepDims = false, bool exclude = false, string name = "")
        {
            if (axis == null)
                axis = new Shape();
            return new Operator("max").Set(data, axis, keepDims, exclude).CreateSymbol(name);
        }

        public Symbol Min(Symbol data, Shape axis = null, bool keepDims = false, bool exclude = false, string name = "")
        {
            if (axis == null)
                axis = new Shape();
            return new Operator("min").Set(data, axis, keepDims, exclude).CreateSymbol(name);
        }

        public Symbol Norm(Symbol data, int ord = 2, Shape axis = null, DType out_dtype = null, bool keepDims = false, string name = "")
        {
            if (axis == null)
                axis = new Shape();

            if (out_dtype == null)
                out_dtype = DType.Float32;

            return new Operator("norm").Set(data, ord, axis, out_dtype, keepDims).CreateSymbol(name);
        }
    }
}
