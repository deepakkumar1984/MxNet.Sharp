using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class DetRandomCropAug : DetAugmenter
    {
        public DetRandomCropAug(float min_object_covered = 0.1f, float min_eject_coverage=0.3f, (float, float)? aspect_ratio_range = null,
            (float, float)? area_range = null, int max_attempts = 50)
        {
            throw new NotImplementedException();
        }

        public override void Call(NDArray src, NDArray label)
        {
            throw new NotImplementedException();
        }

        private NDArray CalculateAreas(NDArray label) => throw new NotImplementedException();

        private NDArray Intersect(NDArray label, float xmin, float ymin, float xmax, float ymax) => throw new NotImplementedException();

        private NDArray CheckSatisfyConstraints(NDArray label, float xmin, float ymin, float xmax, float ymax, float width, float height) => throw new NotImplementedException();

        private NDArray UpdateLabels(NDArray label, float[] crop_box, int height, int width) => throw new NotImplementedException();

        private (float, float, float, float, NDArray) RandomCropProposal(NDArray label, int height, int width) => throw new NotImplementedException();
    }
}
