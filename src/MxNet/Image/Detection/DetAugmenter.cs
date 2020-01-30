using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image.Detection
{
    public abstract class DetAugmenter
    {
        public virtual string Dumps() => throw new NotImplementedException();

        public abstract void Call(NDArray src, NDArray label);
    }
}
