using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class SequentialAug : Augmenter
    {
        public Augmenter[] Augmenters { get; set; }

        public SequentialAug(Augmenter[] ts)
        {
            Augmenters = ts;
        }

        public override NDArray Call(NDArray src)
        {
            foreach (var aug in Augmenters)
            {
                src = aug.Call(src);
            }

            return src;
        }
    }
}
