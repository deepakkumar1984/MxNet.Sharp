using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class SimplePoseDefaultValTransform
    {
        public SimplePoseDefaultValTransform(int num_joints, List<(int, int)> joint_pairs, (int, int)? image_size = null, (int, int)? heatmap_size = null, float sigma = 2, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            throw new NotImplementedException();
        }

        public (NDArray, NDArray, NDArray, NDArray, string) Call(NDArray src, NDArray label, string img_path)
        {
            throw new NotImplementedException();
        }
    }
}
