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

        public static NDArrayList ToNDArrays(this List<NDArrayOrSymbol> source)
        {
            return source.Select(x => (x.NdX)).ToArray();
        }

        public static NDArrayOrSymbol[] ToNDArrayOrSymbols(this List<Symbol> source)
        {
            return source.Select(x => new NDArrayOrSymbol(x)).ToArray();
        }

        public static NDArrayOrSymbol[] ToNDArrayOrSymbols(this NDArrayList source)
        {
            return source.Select(x => new NDArrayOrSymbol(x)).ToArray();
        }

        public static NDArrayOrSymbol Sum(this NDArrayOrSymbol[] source)
        {

        }
    }
}
