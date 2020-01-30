using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class Img
    {
        public static NDArray ImRead(string filename, int flag = 1, bool to_rgb = true)
        {
            return nd.Cvimread(filename, flag, to_rgb);
        }

        public static NDArray ImResize(NDArray src, int w, int h, InterpolationFlags interp = InterpolationFlags.INTER_LINEAR) => throw new NotImplementedException();

        public static NDArray ImDecode(byte[] buf, int flag = 1, bool to_rgb = true) => throw new NotImplementedException();

        public static (int, int) ScaleDown((int, int) src_size, (int, int) size) => throw new NotImplementedException();

        public static NDArray CopyMakeBorder(NDArray src, int top, int bot, int left, int right, BorderTypes type = BorderTypes.BORDER_CONSTANT) => throw new NotImplementedException();

        private static InterpolationFlags GetInterpMethod(InterpolationFlags interep) => throw new NotImplementedException();

        public static NDArray ResizeShort(NDArray src, int size, InterpolationFlags interp= InterpolationFlags.INTER_CUBIC) => throw new NotImplementedException();

        public static NDArray FixedCrop(NDArray src, int x0, int y0, int w, int h, 
                                        int? size = null, InterpolationFlags interp = InterpolationFlags.INTER_CUBIC) => throw new NotImplementedException();

        public static NDArray RandomCrop(NDArray src, int size, InterpolationFlags interp = InterpolationFlags.INTER_CUBIC) => throw new NotImplementedException();

        public static NDArray CenterCrop(NDArray src, int size, InterpolationFlags interp = InterpolationFlags.INTER_CUBIC) => throw new NotImplementedException();

        public static NDArray ColorNormalize(NDArray src, NDArray mean, NDArray std) => throw new NotImplementedException();

        public static NDArray RandomSizeCrop(NDArray src, (int, int) size, (float, float) area, (float, float) ratio, InterpolationFlags interp = InterpolationFlags.INTER_CUBIC) => throw new NotImplementedException();

        public static Augmenter CreateAugmenter(Shape data_shape, int resize= 0, bool rand_crop= false, bool rand_resize= false, bool rand_mirror= false,
                                                NDArray mean= null, NDArray std= null, float brightness= 0, float contrast= 0, float saturation= 0, float hue= 0,
                                                float pca_noise= 0, float rand_gray= 0, InterpolationFlags inter_method= InterpolationFlags.INTER_CUBIC)
        {
            throw new NotImplementedException();
        }
    }
}
