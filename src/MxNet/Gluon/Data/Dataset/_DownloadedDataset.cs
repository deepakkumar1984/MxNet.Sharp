
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data
{
    public abstract class _DownloadedDataset : Dataset<NDArrayList>
    {
        internal Func<NDArray, NDArray, (NDArray, NDArray)> _transform;
        internal NDArrayList _data;
        internal NDArrayList _label;
        internal string _root;

        public _DownloadedDataset(string root, Func<NDArray, NDArray, (NDArray, NDArray)> transform)
        {
            _transform = transform;
            _data = null;
            _label = null;
            _root = root;
            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);

            GetData();
        }

        public override NDArrayList this[int idx]
        {
            get
            {
                if (_transform != null)
                    return new NDArrayList(_transform(_data[idx], _label[idx]));

                return new NDArrayList(_data[idx], _label[idx]);
            }
        }

        public override int Length => _label.Length;

        public abstract void GetData();
    }
}
