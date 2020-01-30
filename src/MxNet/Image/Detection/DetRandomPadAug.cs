using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class DetRandomPadAug : DetAugmenter
    {
        public DetRandomPadAug((float, float)? aspect_ratio_range = null, (float, float)? area_range = null, int max_attempts = 50)
        {
            throw new NotImplementedException();
        }

        public override void Call(NDArray src, NDArray label)
        {
            throw new NotImplementedException();
        }

        private NDArray UpdateLabels(NDArray label, float[] pad_box, int height, int width) => throw new NotImplementedException();

        private (float, float, float, float, NDArray) RandomCropProposal(NDArray label, int height, int width) => throw new NotImplementedException();
    }
}
