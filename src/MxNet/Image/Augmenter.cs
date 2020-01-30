using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public abstract class Augmenter
    {
        public Dictionary<string, object> Parameters { get; set; }

        public Augmenter()
        {
            Parameters = new Dictionary<string, object>();
        }

        public virtual string Dumps()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public abstract NDArray Call(NDArray src);
    }
}
