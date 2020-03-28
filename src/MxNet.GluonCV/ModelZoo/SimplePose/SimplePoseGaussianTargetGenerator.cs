using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.SimplePose
{
    public class SimplePoseGaussianTargetGenerator
    {
        public SimplePoseGaussianTargetGenerator(int num_joints, (int, int) image_size, (int, int) heatmap_size, float sigma= 2)
        {
            throw new NotImplementedException();
        }

        public (NDArray, NDArray) Call(NDArray joints_3d)
        {
            throw new NotImplementedException();
        }
    }
}
