using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class DetBorrowAug : DetAugmenter
    {
        public Augmenter Augmenter { get; set; }

        public DetBorrowAug(Augmenter augmenter)
        {
            Augmenter = augmenter;
        }

        public override (NDArray, NDArray) Call(NDArray src, NDArray label)
        {
            src = Augmenter.Call(src);
            return (src, label);
        }
    }
}
