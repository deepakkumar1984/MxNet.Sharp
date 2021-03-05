using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Libs
{
    public class ContextVar
    {
        private object defaultVal;
        private string name;

        public ContextVar(string name, object @default)
        {
            this.name = name;
            defaultVal = @default;
        }

        public object Get()
        {
            return defaultVal;
        }
    }
}
