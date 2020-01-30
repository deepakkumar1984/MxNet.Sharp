using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class ForceResizeAug : Augmenter
    {
        public ForceResizeAug(int size, InterpolationFlags interp = InterpolationFlags.INTER_CUBIC)
        {
            throw new NotImplementedException();
        }

        public override void Call(NDArray src, NDArray label)
        {
            throw new NotImplementedException();
        }
    }
}
