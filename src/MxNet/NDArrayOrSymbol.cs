using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet
{
    public class NDArrayOrSymbol
    {
        private object X;

        public bool IsSymbol { get; set; }

        public bool IsNDArray { get; set; }

        public NDArray NdX
        {
            get
            {
                if(IsNDArray)
                    return (NDArray)X;

                return null;
            }
        }

        public Symbol SymX
        {
            get
            {
                if (IsSymbol)
                    return (Symbol)X;

                return null;
            }
        }

        public NDArrayOrSymbol(NDArray x)
        {
            IsNDArray = true;
            IsSymbol = false;
            X = x;
        }

        public NDArrayOrSymbol(Symbol x)
        {
            IsNDArray = false;
            IsSymbol = true;
            X = x;
        }

        public static implicit operator NDArrayOrSymbol(NDArray x) => new NDArrayOrSymbol(x);

        public static implicit operator NDArrayOrSymbol(Symbol x) => new NDArrayOrSymbol(x);
    }
}
