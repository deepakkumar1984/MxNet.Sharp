using System.Collections.Generic;
using System.Linq;

namespace MxNet
{
    public static class ListExtensions
    {
        public static Symbol[] ToSymbols(this List<NDArrayOrSymbol> source)
        {
            return source.Select(x => x.SymX).ToArray();
        }

        public static NDArrayList ToNDArrays(this List<NDArrayOrSymbol> source)
        {
            return source.Select(x => x.NdX).ToArray();
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
            NDArrayOrSymbol result = null;
            if (source.Length > 0)
            {
                if (source[0].IsNDArray)
                    foreach (var item in source)
                    {
                        if (result == null)
                        {
                            result = item;
                            continue;
                        }

                        result = result.NdX + item.NdX;
                    }
                else if (source[0].IsSymbol)
                    foreach (var item in source)
                    {
                        if (result == null)
                        {
                            result = item;
                            continue;
                        }

                        result = result.SymX + item.SymX;
                    }
            }

            return result;
        }

        public static NDArrayOrSymbol Sum(this List<NDArrayOrSymbol> source)
        {
            NDArrayOrSymbol result = null;
            if (source.Count > 0)
            {
                if (source[0].IsNDArray)
                    foreach (var item in source)
                    {
                        if (result == null)
                        {
                            result = item;
                            continue;
                        }

                        result = result.NdX + item.NdX;
                    }
                else if (source[0].IsSymbol)
                    foreach (var item in source)
                    {
                        if (result == null)
                        {
                            result = item;
                            continue;
                        }

                        result = result.SymX + item.SymX;
                    }
            }

            return result;
        }

        public static string ToValueString(this List<float> source)
        {
            string line = string.Join(",", source);
            return $"({line})";
        }

        public static string ToValueString(this float[] source)
        {
            string line = string.Join(",", source);
            return $"({line})";
        }
    }
}