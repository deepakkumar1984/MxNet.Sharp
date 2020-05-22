/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
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

        public void Deconstruct(out NDArray x0, out NDArray x1)
        {
            x0 = this[0];
            x1 = this[1];
        }

        public void Deconstruct(out NDArray x0, out NDArray x1, out NDArray x2)
        {
            x0 = this[0];
            x1 = this[1];
            x2 = this[2];
        }

        public void Deconstruct(out NDArray x0, out NDArray x1, out NDArray x2, out NDArray x3)
        {
            x0 = this[0];
            x1 = this[1];
            x2 = this[2];
            x3 = this[3];
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