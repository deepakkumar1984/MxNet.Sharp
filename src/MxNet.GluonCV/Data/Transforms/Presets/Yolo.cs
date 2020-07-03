using MxNet.Image;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class Yolo
    {
        public static (NDArrayList, NDArrayList) TransformTest(NDArrayList imgs, int @short = 416, int max_size = 1024, int stride = 1, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            if (!mean.HasValue)
                mean = (0.485f, 0.456f, 0.406f);

            if (!std.HasValue)
                std = (0.229f, 0.224f, 0.225f);

            var tensors = new List<NDArray>();
            var origs = new List<NDArray>();
            foreach (var img_ in imgs)
            {
                var img = Image.ResizeShortWithin(img_, @short, max_size, mult_base: stride);
                var orig_img = img.AsType(DType.UInt8);
                img = nd.Image.ToTensor(img);
                img = nd.Image.Normalize(img, mean: mean.Value, std: std.Value);
                tensors.Add(img.ExpandDims(0));
                origs.Add(orig_img);
            }
           
            return (tensors, origs);
        }

        public static (NDArrayList, NDArrayList) LoadTest(string[] filenames, int @short = 416, int max_size = 1024, int stride = 1, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            if (!mean.HasValue)
                mean = (0.485f, 0.456f, 0.406f);

            if (!std.HasValue)
                std = (0.229f, 0.224f, 0.225f);

            var imgs = (from f in filenames
                        select Img.ImRead(f)).ToList();
            return TransformTest(imgs, @short, max_size, stride, mean, std);
        }

        public static (NDArray, NDArray) LoadTest(string filenames, int @short = 416, int max_size = 1024, int stride = 1, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            var (x, img) = LoadTest(new string[] { filenames }, @short, max_size, stride, mean, std);
            return (x[0], img[0]);
        }
    }
}
