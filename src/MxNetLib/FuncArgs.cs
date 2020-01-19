using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNetLib
{
    public class FuncArgs
    {
        private Dictionary<string, object> args = new Dictionary<string, object>();

        public void Add(string name, object value)
        {
            args.Add(name, value);
        }

        public void Remove(string name)
        {
            args.Remove(name);
        }

        public object this[string name]
        {
            get
            {
                if (!args.ContainsKey(name))
                    return null;

                return args[name];
            }
            set
            {
                args[name] = value;
            }
        }

        public object[] Values
        {
            get
            {
                return args.Values.ToArray();
            }
        }

        public T Get<T>(string name)
        {
            if (!args.ContainsKey(name))
                return default(T);

            return (T)args[name];
        }
    }
}
