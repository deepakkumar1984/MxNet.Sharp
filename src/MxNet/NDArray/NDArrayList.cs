using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MxNet
{
    public class NDArrayList : IEnumerable<NDArray>
    {
        public List<NDArray> data;

        public NDArrayList()
        {
            data = new List<NDArray>();
        }

        public NDArrayList(int length)
        {
            data = new List<NDArray>();
            for (int i = 0; i < length; i++)
                data.Add(new NDArray());
        }

        public NDArrayList(params NDArray[] args)
        {
            data = args.ToList();
        }

        public NDArrayList((NDArray, NDArray) args)
        {
            data = new List<NDArray> { args.Item1, args.Item2 };
        }

        public NDArrayList((NDArray, NDArray, NDArray) args)
        {
            data = new List<NDArray> { args.Item1, args.Item2, args.Item3 };
        }

        public NDArray[] Data => data.ToArray();

        public IntPtr[] Handles
        {
            get
            {
                List<IntPtr> ret = new List<IntPtr>();
                foreach (var item in Data)
                {
                    if (item == null)
                        continue;

                    ret.Add(item.NativePtr);
                }

                return ret.ToArray();
            }

        }

        public NDArrayOrSymbol[] NDArrayOrSymbols => data.Select(x => new NDArrayOrSymbol(x)).ToArray();

        public NDArray this[int i]
        {
            get => data[i];
            set => data[i] = value;
        }

        public int Length => data.Count;

        public IEnumerator<NDArray> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public void Add(params NDArray[] x)
        {
            if (x == null)
                return;

            data.AddRange(x);
        }

        public static implicit operator NDArrayList(NDArray[] x)
        {
            return new NDArrayList(x);
        }

        public static implicit operator NDArrayList(NDArray x)
        {
            return new NDArrayList(x);
        }

        public static implicit operator NDArrayList(List<NDArray> x)
        {
            return new NDArrayList(x.ToArray());
        }

        public static implicit operator NDArrayList(NDArrayOrSymbol[] x)
        {
            return new NDArrayList(x.Select(i => i.NdX).ToArray());
        }

        public static implicit operator NDArrayList(NDArrayOrSymbol x)
        {
            return new NDArrayList(x);
        }

        public static implicit operator NDArrayList(List<NDArrayOrSymbol> x)
        {
            return new NDArrayList(x.Select(i => i.NdX).ToArray());
        }

        public static implicit operator NDArray(NDArrayList x)
        {
            return x.data.Count > 0 ? x[0] : null;
        }

        public static implicit operator List<NDArray>(NDArrayList x)
        {
            return x.data.ToList();
        }

        public static implicit operator NDArray[](NDArrayList x)
        {
            if (x == null)
                return null;

            return x.data.ToArray();
        }
    }
}