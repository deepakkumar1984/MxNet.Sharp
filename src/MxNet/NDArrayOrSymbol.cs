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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MxNet
{
    public class NDArrayOrSymbol
    {
        private readonly NDArrayList ndx;

        private readonly SymbolList symx;

        public NDArrayOrSymbol(params NDArray[] x)
        {
            IsNDArray = true;
            IsSymbol = false;
            ndx = x;
        }

        public NDArrayOrSymbol(params Symbol[] x)
        {
            IsNDArray = false;
            IsSymbol = true;
            symx = x;
        }

        public bool IsSymbol { get; set; }

        public bool IsNDArray { get; set; }

        public NDArray NdX
        {
            get
            {
                if (IsNDArray)
                    return ndx;

                return null;
            }
        }

        public NDArrayList NdXList
        {
            get
            {
                if (IsNDArray)
                    return ndx;

                return null;
            }
        }

        public Symbol SymX
        {
            get
            {
                if (IsSymbol)
                    return symx;

                return null;
            }
        }

        public SymbolList SymXList
        {
            get
            {
                if (IsSymbol)
                    return symx;

                return null;
            }
        }

        public NDArrayOrSymbol this[int index]
        {
            get
            {
                if (IsNDArray)
                    return ndx[index];

                return symx[index];
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

        #region Operators

        public static NDArrayOrSymbol operator +(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if(lhs.IsNDArray)
                return nd.BroadcastAdd(lhs, rhs);

            return sym.BroadcastAdd(lhs, rhs);
        }

        public static NDArrayOrSymbol operator +(NDArrayOrSymbol lhs, float scalar)
        {
            if (lhs.IsNDArray)
                return nd.PlusScalar(lhs, scalar);

            return sym.PlusScalar(lhs, scalar);
        }

        public static NDArrayOrSymbol operator +(float scalar, NDArrayOrSymbol rhs)
        {
            if (rhs.IsNDArray)
                return nd.PlusScalar(rhs, scalar);

            return sym.PlusScalar(rhs, scalar);
        }

        public static NDArrayOrSymbol operator -(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
                return nd.BroadcastSub(lhs, rhs);

            return sym.BroadcastSub(lhs, rhs);
        }

        public static NDArrayOrSymbol operator -(NDArrayOrSymbol lhs, float scalar)
        {
            if (lhs.IsNDArray)
                return nd.MinusScalar(lhs, scalar);

            return sym.MinusScalar(lhs, scalar);
        }

        public static NDArrayOrSymbol operator -(float scalar, NDArrayOrSymbol rhs)
        {
            if (rhs.IsNDArray)
                return nd.RminusScalar(rhs, scalar);

            return sym.RminusScalar(rhs, scalar);
        }

        public static NDArrayOrSymbol operator *(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
                return nd.BroadcastMul(lhs, rhs);

            return sym.BroadcastMul(lhs, rhs);
        }

        public static NDArrayOrSymbol operator *(NDArrayOrSymbol lhs, float scalar)
        {
            if (lhs.IsNDArray)
                return nd.MulScalar(lhs, scalar);

            return sym.MulScalar(lhs, scalar);
        }

        public static NDArrayOrSymbol operator *(float scalar, NDArrayOrSymbol rhs)
        {
            if (rhs.IsNDArray)
                return nd.MulScalar(rhs, scalar);

            return sym.MulScalar(rhs, scalar);
        }

        public static NDArrayOrSymbol operator /(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            return nd.BroadcastDiv(lhs, rhs);
        }

        public static NDArrayOrSymbol operator /(NDArrayOrSymbol lhs, float scalar)
        {
            if (lhs.IsNDArray)
                return nd.DivScalar(lhs, scalar);

            return sym.DivScalar(lhs, scalar);
        }

        public static NDArrayOrSymbol operator /(float scalar, NDArrayOrSymbol rhs)
        {
            if (rhs.IsNDArray)
                return nd.RdivScalar(rhs, scalar);

            return sym.RdivScalar(rhs, scalar);
        }

        public static NDArrayOrSymbol operator >(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
                return nd.BroadcastGreater(lhs, rhs);

            return sym.BroadcastGreater(lhs, rhs);
        }

        public static NDArrayOrSymbol operator >=(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
                return nd.BroadcastGreaterEqual(lhs, rhs);

            return sym.BroadcastGreaterEqual(lhs, rhs);
        }

        public static NDArrayOrSymbol operator >(NDArrayOrSymbol lhs, float rhs)
        {
            if (lhs.IsNDArray)
                return nd.GreaterScalar(lhs, rhs);

            return sym.GreaterScalar(lhs, rhs);
        }

        public static NDArrayOrSymbol operator >=(NDArrayOrSymbol lhs, float rhs)
        {
            if (lhs.IsNDArray)
                return nd.GreaterEqualScalar(lhs, rhs);

            return nd.GreaterEqualScalar(lhs, rhs);
        }

        public static NDArrayOrSymbol operator >(float lhs, NDArrayOrSymbol rhs)
        {
            if (rhs.IsNDArray)
                return nd.GreaterScalar(rhs, lhs);

            return nd.GreaterScalar(rhs, lhs);
        }

        public static NDArrayOrSymbol operator >=(float lhs, NDArrayOrSymbol rhs)
        {
            if (rhs.IsNDArray)
                return nd.GreaterEqualScalar(rhs, lhs);

            return nd.GreaterEqualScalar(rhs, lhs);
        }

        public static NDArrayOrSymbol operator <(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
                return nd.BroadcastLesser(lhs, rhs);

            return nd.BroadcastLesser(lhs, rhs);
        }

        public static NDArrayOrSymbol operator <=(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
                return nd.BroadcastLesserEqual(lhs, rhs);

            return nd.BroadcastLesserEqual(lhs, rhs);
        }

        public static NDArrayOrSymbol operator <(NDArrayOrSymbol lhs, float rhs)
        {
            if (lhs.IsNDArray)
                return nd.LesserScalar(lhs, rhs);

            return nd.LesserScalar(lhs, rhs);
        }

        public static NDArrayOrSymbol operator <=(NDArrayOrSymbol lhs, float rhs)
        {
            if (lhs.IsNDArray)
                return nd.LesserEqualScalar(lhs, rhs);

            return nd.LesserEqualScalar(lhs, rhs);
        }

        public static NDArrayOrSymbol operator <(float lhs, NDArrayOrSymbol rhs)
        {
            if (rhs.IsNDArray)
                return nd.LesserScalar(rhs, lhs);

            return nd.LesserScalar(rhs, lhs);
        }

        public static NDArrayOrSymbol operator <=(float lhs, NDArrayOrSymbol rhs)
        {
            if (rhs.IsNDArray)
                return nd.LesserEqualScalar(rhs, lhs);

            return nd.LesserEqualScalar(rhs, lhs);
        }

        #endregion
    }

    public class NDArrayOrSymbolList : IEnumerable<NDArrayOrSymbol>
    {
        public List<NDArrayOrSymbol> data;

        public NDArrayOrSymbolList()
        {
            data = new List<NDArrayOrSymbol>();
        }

        public NDArrayOrSymbolList(params NDArrayOrSymbol[] args)
        {
            data = args.ToList();
        }

        public NDArrayOrSymbolList((NDArrayOrSymbol, NDArrayOrSymbol) args)
        {
            data = new List<NDArrayOrSymbol> { args.Item1, args.Item2 };
        }

        public NDArrayOrSymbolList((NDArrayOrSymbol, NDArrayOrSymbol, NDArrayOrSymbol) args)
        {
            data = new List<NDArrayOrSymbol> { args.Item1, args.Item2, args.Item3 };
        }

        public NDArrayOrSymbol[] Data => data.ToArray();
        
        public NDArrayOrSymbol this[int i]
        {
            get => data[i];
            set => data[i] = value;
        }

        public int Length => data.Count;

        public IEnumerator<NDArrayOrSymbol> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public void Add(params NDArrayOrSymbol[] x)
        {
            if (x == null)
                return;

            data.AddRange(x);
        }

        public static implicit operator NDArrayOrSymbolList(NDArrayOrSymbol[] x)
        {
            return new NDArrayOrSymbolList(x);
        }

        public static implicit operator NDArrayOrSymbolList(NDArrayOrSymbol x)
        {
            return new NDArrayOrSymbolList(x);
        }

        public static implicit operator NDArrayOrSymbolList(List<NDArrayOrSymbol> x)
        {
            return new NDArrayOrSymbolList(x.ToArray());
        }
    }
}