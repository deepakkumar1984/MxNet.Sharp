using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MxNet
{
    public class NDArrayList : IEnumerable<NDArray>
    {
        public List<NDArray> data = null;

        public NDArrayList()
        {
            data = new List<NDArray>();
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
        }

        public int Length => data.Count;
    }
}
