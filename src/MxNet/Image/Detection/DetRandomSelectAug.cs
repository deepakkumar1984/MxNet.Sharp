using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.Image
{
    public class DetRandomSelectAug : DetAugmenter
    {
        public DetAugmenter[] AugList { get; set; }

        public float SkipProb { get; set; }

        public DetRandomSelectAug(DetAugmenter[] aug_list, float skip_prob)
        {
            AugList = aug_list;
            SkipProb = skip_prob;
        }

        public override (NDArray, NDArray) Call(NDArray src, NDArray label)
        {
            if (new Random().NextDouble() < SkipProb)
                return (src, label);

            AugList.Shuffle();
            return AugList[0].Call(src, label);
        }
    }
}
