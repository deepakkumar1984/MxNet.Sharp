using System;
using System.Collections.Generic;
using System.Linq;

namespace MxNet.Gluon.Data
{
    public abstract class Dataset<T>
    {
        public Dataset(params T[] data)
        {
            Data = data.ToList();
        }

        public List<T> Data { get; set; }

        public abstract int Length { get; }

        public abstract T this[int idx] { get; }

        public Dataset<T> Transform(Func<T, T> fn, bool lazy = true)
        {
            var trans = new _LazyTransformDataset<T>(this, fn);
            if (lazy)
                return trans;

            return new SimpleDataset<T>(trans.Data.ToArray());
        }

        public Dataset<T> TransformFirst(Func<T, T> fn, bool lazy = true)
        {
            throw new NotImplementedException();
        }
    }
}