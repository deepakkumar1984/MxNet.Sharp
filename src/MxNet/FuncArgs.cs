using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MxNet
{
    public class FuncArgs : IEnumerable<KeyValuePair<string, object>>
    {
        private readonly Dictionary<string, object> args = new Dictionary<string, object>();

        public object this[string name]
        {
            get
            {
                if (!args.ContainsKey(name))
                    return null;

                return args[name];
            }
            set => args[name] = value;
        }

        public object[] Values => args.Values.ToArray();

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return args.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(string name, object value)
        {
            args.Add(name, value);
        }

        public void Remove(string name)
        {
            args.Remove(name);
        }

        public T Get<T>(string name)
        {
            if (!args.ContainsKey(name))
                return default;

            return (T) args[name];
        }
    }
}