using System;

namespace MxNet.Image
{
    public class DetRandomSelectAug : DetAugmenter
    {
        public DetRandomSelectAug(DetAugmenter[] aug_list, float skip_prob)
        {
            AugList = aug_list;
            SkipProb = skip_prob;
        }

        public DetAugmenter[] AugList { get; set; }

        public float SkipProb { get; set; }

        public override (NDArray, NDArray) Call(NDArray src, NDArray label)
        {
            if (new Random().NextDouble() < SkipProb)
                return (src, label);

            AugList.Shuffle();
            return AugList[0].Call(src, label);
        }
    }
}