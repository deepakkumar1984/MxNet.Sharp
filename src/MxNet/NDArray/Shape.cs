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
using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace MxNet
{
    public sealed class Shape
    {
        #region Fields

        private const int StackCache = 4;

        #endregion

        #region Constructors

        public Shape()
        {
            Dimension = 0;
            _Data = new List<int>(StackCache);
        }

        public Shape(IList<int> v)
            : this(v.ToArray())
        {
        }

        public Shape(params int[] v)
        {
            if (v == null)
                v = new int[0];

            Dimension = v.Length;

            var data = new int[Dimension < StackCache ? StackCache : Dimension];
            Array.Copy(v, data, v.Length);
            _Data = data.ToList();
        }

        public Shape(params long[] vl)
        {
            if (vl == null)
                vl = new long[0];

            var v = vl.Select(x => (int)x).ToArray();

            Dimension = v.Length;

            var data = new int[Dimension < StackCache ? StackCache : Dimension];
            Array.Copy(v, data, v.Length);
            _Data = data.ToList();
        }

        public Shape(int s1)
            : this(new[] {s1})
        {
        }

        public Shape(int s1, int s2)
            : this(new[] {s1, s2})
        {
        }

        public Shape(int s1, int s2, int s3)
            : this(new[] {s1, s2, s3})
        {
        }

        public Shape(int s1, int s2, int s3, int s4)
            : this(new[] {s1, s2, s3, s4})
        {
        }

        public Shape(int s1, int s2, int s3, int s4, int s5)
            : this(new[] {s1, s2, s3, s4, s5})
        {
        }

        public Shape(Shape shape)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            Dimension = shape.Dimension;

            var data = new int[Dimension < StackCache ? StackCache : Dimension];
            Array.Copy(shape.Data, data, Dimension);
            _Data = data.ToList();
        }

        #endregion

        #region Properties

        private readonly List<int> _Data = new List<int>();

        public int[] Data => _Data.ToArray();

        public int Dimension { get; private set; }

        public int Size
        {
            get
            {
                var size = 1;
                var data = _Data;

                for (var index = 0; index < Dimension; index++)
                    size *= data[index];

                return size;
            }
        }

        public int this[int index] => Data[index];

        #endregion

        #region Methods

        public Shape Clone()
        {
            var array = new int[Dimension < StackCache ? StackCache : Dimension];
            Array.Copy(Data, array, Math.Min(array.Length, _Data.Count));
            return new Shape(array);
        }

        public void Add(int i)
        {
            _Data.Add(i);
            Dimension = _Data.Count;
        }

        #region Overrides

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Shape && Equals((Shape) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_Data != null ? _Data.Select(u => u).Sum().GetHashCode() : 0) * 397) ^ Dimension;
            }
        }

        public override string ToString()
        {
            return $"({string.Join(",", Enumerable.Range(0, Dimension).Select(i => _Data[i].ToString()))})";
        }

        #region Operators

        public static bool operator ==(Shape lhs, Shape rhs)
        {
            if (ReferenceEquals(lhs, rhs))
                return true;

            var lnull = ReferenceEquals(lhs, null);
            var rnull = ReferenceEquals(rhs, null);
            if (!(!lnull && !rnull))
                return false;

            if (lhs.Dimension != rhs.Dimension)
                return false;

            for (var i = 0; i < lhs.Dimension; ++i)
                if (lhs.Data[i] != rhs.Data[i])
                    return false;

            return true;
        }

        public static bool operator !=(Shape lhs, Shape rhs)
        {
            if (ReferenceEquals(lhs, rhs))
                return false;

            var lnull = ReferenceEquals(lhs, null);
            var rnull = ReferenceEquals(rhs, null);
            if (!(!lnull && !rnull))
                return true;

            if (lhs.Dimension != rhs.Dimension)
                return true;

            for (var i = 0; i < lhs.Dimension; ++i)
                if (lhs.Data[i] != rhs.Data[i])
                    return true;

            return false;
        }

        #endregion

        #region Helpers

        private bool Equals(Shape other)
        {
            return this == other;
        }

        public void Deconstruct(out int s0, out int s1)
        {
            s0 = this[0];
            s1 = this[1];
        }

        public void Deconstruct(out int s0, out int s1, out int s2)
        {
            s0 = this[0];
            s1 = this[1];
            s2 = this[2];
        }

        public void Deconstruct(out int s0, out int s1, out int s2, out int s3)
        {
            s0 = this[0];
            s1 = this[1];
            s2 = this[2];
            s3 = this[3];
        }

        #endregion

        #endregion

        #endregion
    }
}