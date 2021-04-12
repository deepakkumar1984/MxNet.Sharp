using MxNet.Numpy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Contrib.Data.Vision.Transforms.BBox
{
    public class ImageBboxRandomFlipLeftRight : Block
    {
        public ImageBboxRandomFlipLeftRight(float p = 0.5f)
        {
            throw new NotImplementedRelease1Exception();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedRelease1Exception();
        }

        private ndarray FlipImage(ndarray img)
        {
            throw new NotImplementedRelease1Exception();
        }

        private ndarray FlipBBox(ndarray img, ndarray bbox)
        {
            throw new NotImplementedRelease1Exception();
        }
    }
}
