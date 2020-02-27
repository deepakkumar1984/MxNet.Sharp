using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data
{
    public class _LazyTransformDataset<T> : Dataset<T>
    {
        private Dataset<T> _data;
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
