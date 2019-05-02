using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet
{
    public partial class SymbolOps
    {
        public Symbol Sort(Symbol data, Shape axis = null, bool isAscend = true, string name = "")
        {
            if (axis == null)
                axis = new Shape();
            return new Operator("sort").Set(data, axis, isAscend).CreateSymbol(name);
        }

        public Symbol ArgSort(Symbol data, Shape axis = null, bool isAscend = true, DType dtype = null, string name = "")
        {
            if (axis == null)
                axis = new Shape();

            if (dtype == null)
                dtype = DType.Float32;

            return new Operator("argsort").Set(data, axis, isAscend, dtype).CreateSymbol(name);
        }

        public Symbol ArgMax(Symbol data, Shape axis = null, bool keepDims = false, string name = "")
        {
            if (axis == null)
                axis = new Shape();
            return new Operator("argmax").Set(data, axis, keepDims).CreateSymbol(name);
        }

        public Symbol ArgMaxChannel(Symbol data, string name = "")
        {
            return new Operator("argmax").Set(data).CreateSymbol(name);
        }

        public Symbol ArgMin(Symbol data, Shape axis = null, bool keepDims = false, string name = "")
        {
            if (axis == null)
                axis = new Shape();
            return new Operator("argmin").Set(data, axis, keepDims).CreateSymbol(name);
        }

        public Symbol TopK(Symbol data, Shape axis = null, int k = 1, string name = "")
        {
            if (axis == null)
                axis = new Shape();
            return new Operator("topk").Set(data, axis, k).CreateSymbol(name);
        }
    }
}
