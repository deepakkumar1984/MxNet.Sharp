using System;

namespace MxNet.Gluon.Data
{
    public class _LazyTransformDataset<T> : Dataset<T>
    {
        private readonly Dataset<T> _data;
        private Func<T, T> _fn;

        public _LazyTransformDataset(Dataset<T> data, Func<T, T> fn)
        {
            _data = data;
            _fn = fn;
        }

        public override T this[int idx] => _data[idx];

        public override int Length => _data.Length;
    }
}