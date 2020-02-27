using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet
{
    public class NDArrayList : IEnumerable<NDArray>
    {
        public List<NDArray> data = null;

        public NDArray[] Data => data.ToArray();

        public IntPtr[] Handles => data.Select(x => (x.NativePtr)).ToArray();

        public NDArrayOrSymbol[] NDArrayOrSymbols => data.Select(x => (new NDArrayOrSymbol(x))).ToArray();

        public NDArrayList()
        {
            data = new List<NDArray>();
        }

        public NDArrayList(int length)
        {
            data = new List<NDArray>(length);
        }

        public NDArrayList(params NDArray[] args)
        {
            data = args.ToList();
        }

        public NDArrayList((NDArray, NDArray) args)
        {
            data = new List<NDArray>() { args.Item1, args.Item2 };
        }

        public NDArrayList((NDArray, NDArray, NDArray) args)
        {
            data = new List<NDArray>() { args.Item1, args.Item2, args.Item3 };
        }

        public void Add(params NDArray[] x)
        {
            data.AddRange(x);
        }

        public IEnumerator<NDArray> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public NDArray this[int i]
        {
            get
            {
                return data[i];
            }
            set
            {
                data[i] = value;
            }
        }

        public int Length => data.Count;

        public static implicit operator NDArrayList(NDArray[] x) => new NDArrayList(x);

        public static implicit operator NDArrayList(NDArray x) => new NDArrayList(x);

        public static implicit operator NDArrayList(List<NDArray> x) => new NDArrayList(x.ToArray());

        public static implicit operator NDArrayList(NDArrayOrSymbol[] x) => new NDArrayList(x.Select(i=>(i.NdX)).ToArray());

        public static implicit operator NDArrayList(NDArrayOrSymbol x) => new NDArrayList(x);

        public static implicit operator NDArrayList(List<NDArrayOrSymbol> x) => new NDArrayList(x.Select(i => (i.NdX)).ToArray());

        public static implicit operator NDArray(NDArrayList x) => x.data.Count > 0 ? x[0] : null;
    }
}
