using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms
{
    public class VideoTenCrop : Block
    {
        public VideoTenCrop((int, int) size) : base(null, null)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
