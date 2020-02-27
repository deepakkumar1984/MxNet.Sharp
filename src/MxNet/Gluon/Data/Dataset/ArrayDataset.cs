using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data
{
    public class ArrayDataset<T> : Dataset<T[]>
    {
        private int _length;
        private List<T[]> _data;
        public ArrayDataset(List<T[]> args)
        {
            if (args.Count == 0)
                throw new ArgumentException("Need atleast 1 array");
            _data = new List<T[]>();
            _length = args.Count;

            if (typeof(T).Name == "Array" || typeof(T).Name == "NDArray")
            {
                for (int i = 0; i < args.Count; i++)
                {
                    _data.Add(args[i]);
                }
            }
            else
            {
                throw new Exception("Array or NDArray type supported");
            }
        }

        public override T[] this[int idx]
        {
            get
            {
                if (_data.Count == 1)
                    return new T[] { _data[0][idx] };

                List<T> ret = new List<T>();
                foreach (var item in _data)
                {
                    ret.Add(item[idx]);
                }

                return ret.ToArray();
            }
        }

        public override int Length => _length;
    }
}
