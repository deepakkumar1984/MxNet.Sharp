using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public abstract class Augmenter
    {
        public virtual string Dumps() => throw new NotImplementedException();

        public abstract void Call(NDArray src, NDArray label);
    }
}
