using System.Collections.Generic;
using Newtonsoft.Json;

namespace MxNet.Image
{
    public abstract class Augmenter
    {
        public Augmenter()
        {
            Parameters = new Dictionary<string, object>();
        }

        public Dictionary<string, object> Parameters { get; set; }

        public virtual string Dumps()
        {
            return JsonConvert.SerializeObject(this);
        }

        public abstract NDArray Call(NDArray src);
    }
}