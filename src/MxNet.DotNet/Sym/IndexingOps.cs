using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet
{
    public partial class SymbolOps
    {
        public Symbol Slice(Symbol data, Shape begin = null, Shape end = null, Shape step = null, string name = "")
        {
            if (begin == null)
                begin = new Shape();

            if (end == null)
                end = new Shape();

            if (step == null)
                step = new Shape();

            return new Operator("slice").Set(data, begin, end, step).CreateSymbol(name);
        }

        public Symbol SliceAxis(Symbol data, int axis, int begin, int end, Shape step = null, string name = "")
        {
            return new Operator("slice_axis").Set(data, begin, end, step).CreateSymbol(name);
        }

        public Symbol SliceLike(Symbol data, Symbol shapeLike, Shape axis = null, string name = "")
        {
            if (axis == null)
                axis = new Shape();

            return new Operator("slice_like").Set(data, shapeLike, axis).CreateSymbol(name);
        }

        public Symbol Take(Symbol a, Symbol indices, int axis = 0, string name = "")
        {
            return new Operator("take").Set(a, indices, axis).CreateSymbol(name);
        }

        public Symbol OneHot(Symbol indices, int depth, double on_value = 1, double off_value = 0, DType dtype = null, string name = "")
        {
            if (dtype == null)
                dtype = DType.Float32;

            return new Operator("one_hot").Set(indices, depth, on_value, off_value, dtype).CreateSymbol(name);
        }

        public Symbol Pick(Symbol data, Symbol index, int axis = -1, bool keepDims = false, string name = "")
        {
            return new Operator("pick").Set(data, index, axis, keepDims).CreateSymbol(name);
        }

        public Symbol RavelMultiIndex(Symbol data, Shape shape, string name = "")
        {
            return new Operator("ravel_multi_index").Set(data, shape).CreateSymbol(name);
        }

        public Symbol UnravelIndex(Symbol data, Shape shape, string name = "")
        {
            return new Operator("unravel_index").Set(data, shape).CreateSymbol(name);
        }
    }
}
