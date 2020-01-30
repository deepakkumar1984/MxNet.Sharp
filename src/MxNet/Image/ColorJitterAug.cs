using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class ColorJitterAug : RandomOrderAug
    {
        public ColorJitterAug(float brightness, float contrast, float saturation) : base(new Augmenter[] { })
        {
            throw new NotImplementedException();
        }
    }
}
