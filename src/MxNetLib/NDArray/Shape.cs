using System;
using System.Collections.Generic;
using System.Linq;
using mx_uint = System.UInt32;
using size_t = System.UInt64;

// ReSharper disable once CheckNamespace
namespace MxNetLib
{

    public sealed class Shape
    {

        #region Fields

        private const int StackCache = 4;

        #endregion

        #region Constructors

        public Shape()
        {
            this._Dimension = 0;
            this._Data = new List<mx_uint>(StackCache);
        }

        public Shape(IList<mx_uint> v)
            : this(v.ToArray())
        {
        }

        public Shape(params mx_uint[] v)
        {
            if (v == null)
                throw new ArgumentNullException(nameof(v));

            this._Dimension = (uint)v.Length;

            uint[] data = new mx_uint[this._Dimension < StackCache ? StackCache : this._Dimension];
            Array.Copy(v, data, v.Length);
            _Data = data.ToList();
        }

        public Shape(mx_uint s1)
            : this(new[] { s1 })
        {
        }

        public Shape(mx_uint s1, mx_uint s2)
            : this(new[] { s1, s2 })
        {
        }

        public Shape(mx_uint s1, mx_uint s2, mx_uint s3)
            : this(new[] { s1, s2, s3 })
        {
        }

        public Shape(mx_uint s1, mx_uint s2, mx_uint s3, mx_uint s4)
            : this(new[] { s1, s2, s3, s4 })
        {
        }

        public Shape(mx_uint s1, mx_uint s2, mx_uint s3, mx_uint s4, mx_uint s5)
            : this(new[] { s1, s2, s3, s4, s5 })
        {
        }

        public Shape(Shape shape)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            this._Dimension = shape._Dimension;

            uint[] data = new mx_uint[this._Dimension < StackCache ? StackCache : this._Dimension];
            Array.Copy(shape.Data, data, this._Dimension);
            _Data = data.ToList();
        }

        #endregion

        #region Properties

        private readonly List<mx_uint> _Data = new List<mx_uint>();

        public mx_uint[] Data => this._Data.ToArray();

        private readonly mx_uint _Dimension;

        public mx_uint Dimension => this._Dimension;

        public size_t Size
        {
            get
            {
                size_t size = 1;
                var data = this._Data;

                for (var index = 0; index < this._Dimension; index++)
                    size *= data[index];

                return size;
            }
        }

        public mx_uint this[mx_uint index] => this.Data[index];

        #endregion

        #region Methods

        public Shape Clone()
        {
            var array = new mx_uint[this._Dimension < StackCache ? StackCache : this._Dimension];
            Array.Copy(this.Data, array, Math.Min(array.Length, this._Data.Count));
            return new Shape(array);
        }

        public void Add(mx_uint i)
        {
            _Data.Add(i);
        }
        #region Overrides

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Shape && Equals((Shape)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((this._Data != null ? this._Data.Select(u => (int)u).Sum().GetHashCode() : 0) * 397) ^ (int)this._Dimension;
            }
        }

        public override string ToString()
        {
            return $"({string.Join(",", Enumerable.Range(0, (int)this.Dimension).Select(i => this._Data[i].ToString()))})";
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

            if (lhs._Dimension != rhs._Dimension)
                return false;

            for (var i = 0; i < lhs._Dimension; ++i)
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

            if (lhs._Dimension != rhs._Dimension)
                return true;

            for (var i = 0; i < lhs._Dimension; ++i)
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

        #endregion

        #endregion

        #endregion

    }

}

