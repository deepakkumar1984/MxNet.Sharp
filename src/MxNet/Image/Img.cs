/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
using System;
using NumpyDotNet;
using OpenCvSharp;

namespace MxNet.Image
{
    public enum ImgInterp
    {
        Nearest_Neighbors = 0,
        Bilinear = 1,
        Area_Based = 2,
        Bicubic = 3,
        Lanczos = 4,
        Cubic_Area_Bilinear = 9,
        Random_Select = 10
    }

    public class Img
    {
        public static NDArray ImRead(string filename, int flag = 1, bool to_rgb = false)
        {
            Mat mat = Cv2.ImRead(filename, (ImreadModes)flag);
            if (to_rgb)
                Cv2.CvtColor(mat, mat, ColorConversionCodes.BGR2RGB);
            return mat;
            //return nd.Cvimread(filename, flag, to_rgb);
        }

        public static NDArray ImResize(NDArray src, int w, int h, InterpolationFlags interp = InterpolationFlags.Linear)
        {
            //Mat mat = new Mat();
            //Mat input = src;
            //Cv2.Resize(input, input, new Size(w, h), interpolation: interp);
            //return input;
            return nd.Cvimresize(src, w, h, (int) interp);
        }

        public static void ImShow(NDArray x, string winname = "", bool wait = true)
        {
            if (winname == "")
                winname = "test";

            bool transpose = true;

            if (x.Shape.Dimension == 4)
                x = x.Reshape(x.Shape[1], x.Shape[2], x.Shape[3]).AsType(DType.UInt8);
            else
                x = x.AsType(DType.UInt8);

            if (x.Shape[0] > 3)
                transpose = false;

            if (transpose)
                x = x.Transpose(new Shape(1, 2, 0));
            NDArray.WaitAll();
            Mat mat = x;
            
            Cv2.ImShow(winname, mat);
            NDArray.WaitAll();
            if (wait)
                Cv2.WaitKey();
        }

        public static NDArray ImDecode(byte[] buf, int flag = 1, bool to_rgb = true)
        {
            return nd.Cvimdecode(buf, flag, to_rgb);
        }

        public static (int, int) ScaleDown((int, int) src_size, (int, int) size)
        {
            var (w, h) = size;
            var (sw, sh) = src_size;
            if (sh < h)
                (w, h) = (w * sh / h, sh);
            if (sw < w)
                (w, h) = (sw, h * sw / w);

            return (w, h);
        }

        public static NDArray CopyMakeBorder(NDArray src, int top, int bot, int left, int right,
            BorderTypes type = BorderTypes.Constant)
        {
            return nd.CvcopyMakeBorder(src, top, bot, left, right, (int) type);
        }

        public static InterpolationFlags GetInterp(InterpolationFlags interp, (int, int, int, int)? sizes = null)
        {
            if (interp == InterpolationFlags.Cubic)
            {
                if (sizes.HasValue)
                {
                    var (oh, ow, nh, nw) = sizes.Value;

                    if (nh > oh && nw > ow)
                        return InterpolationFlags.Area;
                    if (nh < oh && nw < ow)
                        return InterpolationFlags.Cubic;
                    return InterpolationFlags.Linear;
                }

                return InterpolationFlags.Area;
            }

            return interp;
        }

        public static NDArray ResizeShort(NDArray src, int size, InterpolationFlags interp = InterpolationFlags.Linear)
        {
            var (h, w, _) = (src.Shape[0], src.Shape[1], src.Shape[2]);
            int new_h;
            int new_w;
            if (h > w)
                (new_h, new_w) = (size * (int)Math.Round((double)h / w), size);
            else
                (new_h, new_w) = (size, size * (int)Math.Round((double)w / h));

            return ImResize(src, new_w, new_h, GetInterp(interp, (h, w, new_h, new_w)));
        }

        public static NDArray FixedCrop(NDArray src, int x0, int y0, int w, int h,
            (int, int)? size = null, InterpolationFlags interp = InterpolationFlags.Area)
        {
            var output = nd.Slice(src, new Shape(y0, x0, 0), new Shape(y0 + h, x0 + w, src.Shape[2]));
            if (size.HasValue && size.Value.Item1 != w && size.Value.Item2 != h)
            {
                var sizes = (h, w, size.Value.Item2, size.Value.Item1);
                output = ImResize(output, size.Value.Item1, size.Value.Item2, GetInterp(interp, sizes));
            }

            return output;
        }

        public static (NDArray, (int, int, int, int)) RandomCrop(NDArray src, (int, int) size,
            InterpolationFlags interp = InterpolationFlags.Area)
        {
            var (h, w, _) = (src.Shape[0], src.Shape[1], src.Shape[2]);
            var (new_w, new_h) = ScaleDown((w, h), size);
            var x0 = new Random().Next(0, w - new_w);
            var y0 = new Random().Next(0, h - new_h);
            var output = FixedCrop(src, x0, y0, new_w, new_h, size, interp);
            return (output, (x0, y0, new_w, new_h));
        }

        public static (NDArray, (int, int, int, int)) CenterCrop(NDArray src, (int, int) size,
            InterpolationFlags interp = InterpolationFlags.Area)
        {
            var (h, w, _) = (src.Shape[0], src.Shape[1], src.Shape[2]);
            var (new_w, new_h) = ScaleDown((w, h), size);
            var x0 = (w - new_w) / 2;
            var y0 = (h - new_h) / 2;
            var output = FixedCrop(src, x0, y0, new_w, new_h, size, interp);
            return (output, (x0, y0, new_w, new_h));
        }

        public static NDArray ColorNormalize(NDArray src, NDArray mean, NDArray std = null)
        {
            if (mean != null)
                src = src - mean;

            if (std != null)
                src = src / std;

            return src;
        }

        public static (NDArray, (int, int, int, int)) RandomSizeCrop(NDArray src, (int, int) size, (float, float) area,
            (float, float) ratio, InterpolationFlags interp = InterpolationFlags.Area)
        {
            var (h, w, _) = (src.Shape[0], src.Shape[1], src.Shape[2]);
            var src_area = h * w;
            for (var i = 0; i < 10; i++)
            {
                float target_area = FloatRnd.Uniform(area.Item1, area.Item2) * src_area;
                var log_ratio = ((float) Math.Log(ratio.Item1), (float) Math.Log(ratio.Item2));
                var new_ratio = Math.Exp(FloatRnd.Uniform(log_ratio.Item1, log_ratio.Item2));
                var new_w = (int) Math.Round(Math.Pow(target_area * new_ratio, 2));
                var new_h = (int) Math.Round(Math.Pow(target_area / new_ratio, 2));
                if (new_w <= w && new_h <= h)
                {
                    var x0 = new Random().Next(0, w - new_w);
                    var y0 = new Random().Next(0, h - new_h);

                    var @out = FixedCrop(src, x0, y0, new_w, new_h, size, interp);
                    return (@out, (x0, y0, new_w, new_h));
                }
            }

            return CenterCrop(src, size, interp);
        }

        public static Augmenter CreateAugmenter(Shape data_shape, int resize = 0, bool rand_crop = false,
            bool rand_resize = false, bool rand_mirror = false, NDArray mean = null, NDArray std = null,
            float brightness = 0, float contrast = 0, float saturation = 0, float hue = 0, float pca_noise = 0,
            float rand_gray = 0, ImgInterp inter_method = ImgInterp.Area_Based)
        {
            throw new NotImplementedException();
        }
    }
}