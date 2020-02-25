using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet
{
    public class NDArrayDict : IEnumerable<KeyValuePair<string, NDArray>>
    {
        private Dictionary<string, NDArray> dict = new Dictionary<string, NDArray>();

        public int Count
        {
            get
            {
                return dict.Count;
            }
        }

        public string[] Keys
        {
            get
            {
                return dict.Keys.ToArray();
            }
        }

        public NDArrayList Values
        {
            get
            {
                return dict.Values.ToArray();
            }
        }

        public void Add(string name, NDArray value)
        {
            dict.Add(name, value);
        }

        public bool Contains(string name)
        {
            return dict.ContainsKey(name);
        }

        public void Remove(string name)
        {
            dict.Remove(name);
        }

        public IEnumerator<KeyValuePair<string, NDArray>> GetEnumerator()
        {
            return dict.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dict.GetEnumerator();
        }

        public NDArray this[string name]
        {
            get
            {
                if (!dict.ContainsKey(name))
                    return null;

                return dict[name];
            }
            set
            {
                dict[name] = value;
            }
        }
    }
}
