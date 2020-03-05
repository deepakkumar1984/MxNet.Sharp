using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MxNet
{
    public class NDArrayDict : IEnumerable<KeyValuePair<string, NDArray>>
    {
        private readonly Dictionary<string, NDArray> dict = new Dictionary<string, NDArray>();

        public NDArrayDict(params string[] names)
        {
            foreach (var item in names) Add(item, null);
        }

        public int Count => dict.Count;

        public string[] Keys => dict.Keys.ToArray();

        public NDArrayList Values => dict.Values.ToArray();

        public NDArray this[string name]
        {
            get
            {
                if (!dict.ContainsKey(name))
                    return null;

                return dict[name];
            }
            set => dict[name] = value;
        }

        public IEnumerator<KeyValuePair<string, NDArray>> GetEnumerator()
        {
            return dict.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dict.GetEnumerator();
        }

        public void Add(string name, NDArray value)
        {
            dict.Add(name, value);
        }

        public void Add(NDArrayDict other)
        {
            foreach (var item in other) Add(item.Key, item.Value);
        }

        public bool Contains(string name)
        {
            return dict.ContainsKey(name);
        }

        public void Remove(string name)
        {
            dict.Remove(name);
        }
    }
}