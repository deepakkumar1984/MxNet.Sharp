using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib
{
    public class ConfigData
    {
        private Dictionary<string, object> configValues = new Dictionary<string, object>();

        public void Add(string name, object value)
        {
            configValues.Add(name, value);
        }

        public void Remove(string name)
        {
            configValues.Remove(name);
        }

        public object this[string name]
        {
            get
            {
                if (!configValues.ContainsKey(name))
                    return null;

                return configValues[name];
            }
            set
            {
                configValues[name] = value;
            }
        }

        public T Get<T>(string name)
        {
            if (!configValues.ContainsKey(name))
                return default(T);

            return (T)configValues[name];
        }
    }
}
