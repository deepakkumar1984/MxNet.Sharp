using System;
using System.Collections.Generic;

namespace MxNet.Gluon.Data
{
    public class ArrayDataset<T> : Dataset<T[]>
    {
        private readonly List<T[]> _data;

        public ArrayDataset(List<T[]> args)
        {
            if (args.Count == 0)
                throw new ArgumentException("Need atleast 1 array");
            _data = new List<T[]>();
            Length = args.Count;

            if (typeof(T).Name == "Array" || typeof(T).Name == "NDArray")
                for (var i = 0; i < args.Count; i++)
                    _data.Add(args[i]);
            else
                throw new Exception("Array or NDArray type supported");
        }

        public override T[] this[int idx]
        {
            get
            {
                if (_data.Count == 1)
                    return new[] {_data[0][idx]};

                var ret = new List<T>();
                foreach (var item in _data) ret.Add(item[idx]);

                return ret.ToArray();
            }
        }

        public override int Length { get; }
    }
}