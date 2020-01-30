using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class RandomSizedCropAug : Augmenter
    {
        public RandomSizedCropAug(int size, (float, float) area, (float, float) ratio, InterpolationFlags interp = InterpolationFlags.INTER_CUBIC)
        {
            throw new NotImplementedException();
        }

        public override void Call(NDArray src, NDArray label)
        {
            throw new NotImplementedException();
        }
    }
}
