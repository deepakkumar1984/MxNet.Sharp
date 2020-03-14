using System;
using System.Collections.Generic;

namespace MxNet.Gluon.Data
{
    public class ArrayDataset : Dataset<NDArray>
    {
        private readonly NDArrayList _data;

        public ArrayDataset(params NDArray[] args)
        {
            if (args.Length == 0)
                throw new ArgumentException("Need atleast 1 array");
            _data = new NDArrayList();
            Length = args[0].Shape[0];

            for (var i = 0; i < args.Length; i++)
                _data.Add(args[i]);
        }

        public override NDArray this[int idx]
        {
            get
            {
                return _data[idx];

                //if (_data.Count == 1)
                    

                //var ret = new List<T>();
                //foreach (var item in _data) ret.Add(item[idx]);

                //return ret.ToArray();
            }
        }


        public override int Length { get; }
    }
}