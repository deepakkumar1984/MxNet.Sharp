using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public abstract class DetAugmenter
    {
        public virtual string Dumps()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public abstract (NDArray, NDArray) Call(NDArray src, NDArray label);
    }
}
