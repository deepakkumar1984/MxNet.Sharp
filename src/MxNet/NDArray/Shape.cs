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
            this._Dimension = 0;
            this._Data = new List<int>(StackCache);
        }

        public Shape(IList<int> v)
            : this(v.ToArray())
        {
        }

        public Shape(params int[] v)
        {
            if (v == null)
                v = new int[0];

            this._Dimension = v.Length;

            int[] data = new int[this._Dimension < StackCache ? StackCache : this._Dimension];
            Array.Copy(v, data, v.Length);
            _Data = data.ToList();
        }

        public Shape(int s1)
            : this(new[] { s1 })
        {
        }

        public Shape(int s1, int s2)
            : this(new[] { s1, s2 })
        {
        }

        public Shape(int s1, int s2, int s3)
            : this(new[] { s1, s2, s3 })
        {
        }

        public Shape(int s1, int s2, int s3, int s4)
            : this(new[] { s1, s2, s3, s4 })
        {
        }

        public Shape(int s1, int s2, int s3, int s4, int s5)
            : this(new[] { s1, s2, s3, s4, s5 })
        {
        }

        public Shape(Shape shape)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            this._Dimension = shape._Dimension;

            int[] data = new int[this._Dimension < StackCache ? StackCache : this._Dimension];
            Array.Copy(shape.Data, data, this._Dimension);
            _Data = data.ToList();
        }

        #endregion

        #region Properties

        private readonly List<int> _Data = new List<int>();

        public int[] Data => this._Data.ToArray();

        private int _Dimension;

        public int Dimension => this._Dimension;

        public int Size
        {
            get
            {
                int size = 1;
                var data = this._Data;

                for (var index = 0; index < this._Dimension; index++)
                    size *= data[index];

                return size;
            }
        }

        public int this[int index] => this.Data[index];

        #endregion

        #region Methods

        public Shape Clone()
        {
            var array = new int[this._Dimension < StackCache ? StackCache : this._Dimension];
            Array.Copy(this.Data, array, Math.Min(array.Length, this._Data.Count));
            return new Shape(array);
        }

        public void Add(int i)
        {
            _Data.Add(i);
            _Dimension = _Data.Count;
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

