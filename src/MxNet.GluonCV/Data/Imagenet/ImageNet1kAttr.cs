using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Imagenet
{
    public class ImageNet1kAttr
    {
        public int NumClass = 1000;
        public string[] Synset;
        public string[] Classes;
        public string[] ClassesLong;

        public ImageNet1kAttr()
        {
            throw new NotImplementedException();
        }
    }
}
