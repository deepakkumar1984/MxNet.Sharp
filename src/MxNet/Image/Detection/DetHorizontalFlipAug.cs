using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class DetHorizontalFlipAug : DetAugmenter
    {
        public DetHorizontalFlipAug(float p)
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

        private void FlipLabel(NDArray label) => throw new NotImplementedException();
    }
}
