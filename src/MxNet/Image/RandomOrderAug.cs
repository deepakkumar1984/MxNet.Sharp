using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.Image
{
    public class RandomOrderAug : Augmenter
    {
        public Augmenter[] Augmenters { get; set; }

        public RandomOrderAug(Augmenter[] ts)
        {
            Augmenters = ts;
        }

        public override NDArray Call(NDArray src)
        {
            Augmenters.Shuffle();
            foreach (var aug in Augmenters)
            {
                src = aug.Call(src);
            }

            return src;
        }
    }
}
