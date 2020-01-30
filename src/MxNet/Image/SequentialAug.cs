using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class SequentialAug : Augmenter
    {
        public SequentialAug(Augmenter[] ts)
        {
            throw new NotImplementedException();
        }

        public override string Dumps()
        {
            throw new NotImplementedException(); 
        }

        public override void Call(NDArray src, NDArray label)
        {
            throw new NotImplementedException();
        }
    }
}
