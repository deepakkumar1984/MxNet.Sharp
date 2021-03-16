using MxNet.Gluon.Probability.Distributions.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Contrib.Data.Vision.Transforms.BBox
{
    public class ImageBboxRandomCropWithConstraints : Block
    {
        public ImageBboxRandomCropWithConstraints(float p= 0.5f, float min_scale= 0.3f, float max_scale= 1,
                 float max_aspect_ratio= 2, Constraint[] constraints= null, int max_trial= 50)
        {
            throw new NotImplementedRelease1Exception();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedRelease1Exception();
        }
    }
}
