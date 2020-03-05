using System.Collections.Generic;

namespace MxNet
{
    public class ConfigData
    {
        private readonly Dictionary<string, object> configValues = new Dictionary<string, object>();

        public object this[string name]
        {
            get
            {
                if (!configValues.ContainsKey(name))
                    return null;

                return configValues[name];
            }
            set => configValues[name] = value;
        }

        public void Add(string name, object value)
        {
            configValues.Add(name, value);
        }

        public void Remove(string name)
        {
            configValues.Remove(name);
        }

        public T Get<T>(string name)
        {
            if (!configValues.ContainsKey(name))
                return default;

            return (T) configValues[name];
        }
    }
}