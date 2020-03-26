using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms
{
    public class VideoGroupValTransform : Block
    {
        public VideoGroupValTransform((int, int) size, float mean, float std, float max_intensity= 255) : base(null, null)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
