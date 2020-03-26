using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class SimplePoseDefaultTrainTransform
    {
        public SimplePoseDefaultTrainTransform(int num_joints, List<(int, int)> joint_pairs, (int, int)? image_size= null, (int, int)? heatmap_size = null, float sigma= 2, (float, float, float)? mean= null, (float, float, float)? std = null, bool random_flip= true, float scale_factor= 0.25f, int rotation_factor= 30)
        {
            throw new NotImplementedException();
        }

        public (NDArray, NDArray, NDArray, NDArray) Call(NDArray src, NDArray label, string img_path)
        {
            throw new NotImplementedException();
        }
    }
}
