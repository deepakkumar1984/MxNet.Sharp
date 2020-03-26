using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class AlphaPoseDefaultValTransform
    {
        public AlphaPoseDefaultValTransform(int num_joints, List<(int, int)> joint_pairs, (int, int)? image_size = null, float sigma = 1)
        {
            throw new NotImplementedException();
        }

        public void Call(NDArray src, AlphaPoseLabel label, string img_path) => throw new NotImplementedException();
    }
}
