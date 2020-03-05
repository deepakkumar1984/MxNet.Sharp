using System;
using SharpCV;

namespace MxNet.Image
{
    public class Detection
    {
        public static DetRandomSelectAug CreateMultiRandCropAugmenter(float min_object_covered = 0.1f,
            (float, float)? aspect_ratio_range = null,
            (float, float)? area_range = null, float min_eject_coverage = 0.3f,
            int max_attempts = 50, float skip_prob = 0)
        {
            throw new NotImplementedException();
        }

        public static DetAugmenter CreateDetAugmenter(Shape data_shape, int resize = 0, float rand_crop = 0,
            float rand_pad = 0, float rand_gray = 0,
            bool rand_mirror = false, NDArray mean = null, NDArray std = null, float brightness = 0,
            float contrast = 0, float saturation = 0, float pca_noise = 0, float hue = 0,
            InterpolationFlags inter_method = InterpolationFlags.INTER_CUBIC,
            float min_object_covered = 0.1f, (float, float)? aspect_ratio_range = null,
            (float, float)? area_range = null, float min_eject_coverage = 0.3f,
            int max_attempts = 50, float pad_val = 127)
        {
            throw new NotImplementedException();
        }
    }
}