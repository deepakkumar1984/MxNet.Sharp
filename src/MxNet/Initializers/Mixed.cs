using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MxNet.Initializers
{
    public class Mixed
    {
        private readonly List<KeyValuePair<Regex, Initializer>> map = new List<KeyValuePair<Regex, Initializer>>();

        public Mixed(string[] patterns, Initializer[] initializers)
        {
            if (patterns.Length != initializers.Length)
                throw new ArgumentException("patterns and initializers not of same length");

            for (var i = 0; i < patterns.Length; i++)
                map.Add(new KeyValuePair<Regex, Initializer>(new Regex(patterns[i]), initializers[i]));
        }

        public void Call(string name, NDArray arr)
        {
            foreach (var item in map)
                if (item.Key.IsMatch(name))
                    item.Value.InitWeight(name, ref arr);
        }
    }
}