/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
namespace MxNet
{
    public class NDArrayOrSymbol
    {
        private readonly object X;

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

        public bool IsSymbol { get; set; }

        public bool IsNDArray { get; set; }

        public NDArray NdX
        {
            get
            {
                if (IsNDArray)
                    return (NDArray) X;

                return null;
            }
        }

        public Symbol SymX
        {
            get
            {
                if (IsSymbol)
                    return (Symbol) X;

                return null;
            }
        }

        public static implicit operator NDArrayOrSymbol(NDArray x)
        {
            if (x == null)
                return null;
            return new NDArrayOrSymbol(x);
        }

        public static implicit operator NDArrayOrSymbol(Symbol x)
        {
            if (x == null)
                return null;
            return new NDArrayOrSymbol(x);
        }

        public static implicit operator NDArray(NDArrayOrSymbol x)
        {
            if (x == null)
                return null;
            return x.NdX;
        }

        public static implicit operator Symbol(NDArrayOrSymbol x)
        {
            if (x == null)
                return null;
            return x.SymX;
        }
    }
}