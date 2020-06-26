using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras
{
    public class ConfigDict : Dictionary<string, object>
    {
        public void Update(ConfigDict dict)
        {
            foreach (var item in dict)
            {
                this[item.Key] = item.Value;
            }
        }
    }
}
