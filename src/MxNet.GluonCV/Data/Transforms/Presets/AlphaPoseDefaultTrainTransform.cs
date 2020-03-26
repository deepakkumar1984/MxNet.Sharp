using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class AlphaPoseLabel
    {
        public int[] BBox { get; set; }

        public NDArray Joints3D { get; set; }
    }

    public class AlphaPoseDefaultTrainTransform
    {
        public AlphaPoseDefaultTrainTransform(int num_joints, List<(int, int)> joint_pairs, (int, int)? image_size= null, (int, int)? heatmap_size = null,
                 float sigma= 1, bool random_flip= true, bool random_sample= false, bool random_crop= false, (float, float)? scale_factor= null, int rotation_factor= 30)
        {
            throw new NotImplementedException();
        }

        public void Call(NDArray src, AlphaPoseLabel label, string img_path) => throw new NotImplementedException();
    }
}
