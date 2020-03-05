using System.Collections.Generic;

namespace MxNet.Initializers
{
    public class InitDesc
    {
        public Dictionary<string, string> Attrs;
        public Initializer GlobalInit;
        public string Name;

        public InitDesc(string name, Dictionary<string, string> attrs = null, Initializer global_init = null)
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