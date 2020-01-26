using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Initializers
{
    public class InitDesc
    {
        public string Name;
        public Dictionary<string, Dictionary<string, string>> Attrs;
        public Initializer GlobalInit = null;

        public InitDesc(string name, Dictionary<string, Dictionary<string, string>> attrs=null, Initializer global_init = null)
        {
            Name = name;
            Attrs = attrs;
            GlobalInit = global_init;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
