using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras
{
    public class CustomObjects : Dictionary<string, Type>
    {
        public CustomObjects Copy()
        {
            return (CustomObjects)this.MemberwiseClone();
        }
    }
}
