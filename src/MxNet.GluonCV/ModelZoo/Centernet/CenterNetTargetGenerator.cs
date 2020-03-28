using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Centernet
{
    public class CenterNetTargetGenerator : Block
    {
        public CenterNetTargetGenerator(int num_class, int output_width, int output_height) : base(null, null)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        internal static float GaussianRadius((int, int) det_size, float min_overlap = 0.7f)
        {
            throw new NotImplementedException();
        }

        internal static float Gaussian2D(Shape shape, float sigma = 1)
        {
            throw new NotImplementedException();
        }

        internal static float DrawUmichGaussian(NDArray heatmap, (int, int) center, float radius, int k = 1)
        {
            throw new NotImplementedException();
        }
    }
}
