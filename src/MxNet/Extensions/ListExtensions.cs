using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet
{
    public static class ListExtensions
    {
        public static Symbol[] ToSymbols(this List<NDArrayOrSymbol> source)
        {
            return source.Select(x => (x.SymX)).ToArray();
        }

        public static NDArray[] ToNDArrays(this List<NDArrayOrSymbol> source)
        {
            return source.Select(x => (x.NdX)).ToArray();
        }

        public static NDArrayOrSymbol[] ToNDArrayOrSymbols(this List<Symbol> source)
        {
            return source.Select(x => new NDArrayOrSymbol(x)).ToArray();
        }

        public static NDArrayOrSymbol[] ToNDArrayOrSymbols(this List<NDArray> source)
        {
            return source.Select(x => new NDArrayOrSymbol(x)).ToArray();
        }
    }
}
