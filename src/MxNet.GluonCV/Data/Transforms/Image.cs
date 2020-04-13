using MxNet.Image;
using NumpyDotNet;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms
{
    public class Image
    {
        public static NDArray ImResize(NDArray src, int w, int h, InterpolationFlags interp = InterpolationFlags.Linear)
        {
            var (oh, ow) = src.Shape;
            return Img.ImResize(src, w, h, interp: Img.GetInterp(interp, (oh, ow, h, w)));
        }

        public static NDArray ResizeLong(NDArray src, int size, InterpolationFlags interp = InterpolationFlags.Area)
        {
            int new_w = 0;
            int new_h = 0;
            var (h, w) = src.Shape;
            if (h > w)
            {
                new_h = size;
                new_w = size * w / h;
            }
            else
            {
                new_h = size * h / w;
                new_w = size;
            }
            return ImResize(src, new_w, new_h, interp: Img.GetInterp(interp, (h, w, new_h, new_w)));
        }

        public static NDArray ResizeShortWithin(NDArray src, int @short, int max_size, int mult_base= 1, InterpolationFlags interp = InterpolationFlags.Area)
        {
            var (h, w) = src.Shape;
            var _tup_2 = w > h ? (h, w) : (w, h);
            var im_size_min = _tup_2.Item1;
            var im_size_max = _tup_2.Item2;
            float scale = (float)@short / im_size_min;
            if (Math.Round(scale * im_size_max / mult_base) * mult_base > max_size)
            {
                // fit in max_size
                scale = (float)(Math.Floor(Convert.ToDouble(max_size) / mult_base) * mult_base) / im_size_max;
            }
            var (new_w, new_h) = (Convert.ToInt32(Math.Round(w * scale / mult_base) * mult_base), Convert.ToInt32(Math.Round(h * scale / mult_base) * mult_base));
            return ImResize(src, new_w, new_h, interp: Img.GetInterp(interp, (h, w, new_h, new_w)));
        }

        public static NDArray RandomPCALighting(NDArray src, float alphastd, NDArray eigval= null, NDArray eigvec = null)
        {
            if (alphastd <= 0)
            {
                return src;
            }

            if (eigval == null)
            {
                eigval = nd.Array(new float[] {
                    55.46f,
                    4.794f,
                    1.148f
                });
            }

            if (eigvec == null)
            {
                eigvec = nd.Array(new float[] { -0.5675f, 0.7192f, 0.4009f, -0.5808f, -0.0045f, -0.814f, -0.5836f, -0.6948f, 0.4203f }).Reshape(3, 3);
            }
            var alpha = nd.Random.Normal(0, alphastd, shape: new Shape(3));
            var rgb = nd.Dot(eigvec * alpha, eigval);
            src += rgb.AsInContext(src.Context);
            return src;
        }

        public static (NDArray, (int, int, int, int)) RandomExpand(NDArray src, float max_ratio = 4, float fill = 0, bool keep_ratio = true)
        {
            ndarray dst;
            float ratio_y;
            if (max_ratio <= 1)
            {
                return (src, (0, 0, src.Shape[1], src.Shape[0]));
            }
            var (h, w, c) = src.Shape;
            var ratio_x = FloatRnd.Uniform(1, max_ratio);
            if (keep_ratio)
            {
                ratio_y = ratio_x;
            }
            else
            {
                ratio_y = FloatRnd.Uniform(1, max_ratio);
            }
            var oh = Convert.ToInt32(h * ratio_y);
            var ow = Convert.ToInt32(w * ratio_x);
            var off_y = IntRnd.Uniform(0, oh - h);
            var off_x = IntRnd.Uniform(0, ow - w);
            // make canvas
            dst = nd.Full(fill, shape: new Shape(oh, ow, c), dtype: src.DataType).AsNumpy();

            dst[$"{off_y}:{(off_y + h)}", $"{off_x}:{(off_x + w)}", ":"] = src;
            return (dst, (off_x, off_y, ow, oh));
        }

        public static (NDArray, (bool, bool)) RandomFlip(NDArray src, float px = 0, float py = 0, bool copy = true)
        {
            var flip_y = FloatRnd.Uniform(0, 1 - py);
            var flip_x = FloatRnd.Uniform(0, 1 - px);

            if (flip_y > 0.5f)
            {
                src = nd.Flip(src, axis: 0);
            }

            if (flip_x > 0.5f)
            {
                src = nd.Flip(src, axis: 1);
            }

            if (copy)
            {
                src = src.Copy();
            }

            return (src, (flip_x > 0.5f, flip_y > 0.5f));
        }

        public static (NDArray, (int, int, int, int)) RandomContain(NDArray src, (int, int) size, float fill = 0)
        {
            ndarray dst;
            var (h, w, c) = src.Shape;
            var _tup_2 = size;
            var ow = _tup_2.Item1;
            var oh = _tup_2.Item2;
            var scale_h = (float)oh / h;
            var scale_w = (float)ow / w;
            var scale = Math.Min(Math.Min(scale_h, scale_w), 1);
            var scaled_x = Convert.ToInt32(w * scale);
            var scaled_y = Convert.ToInt32(h * scale);
            if (scale < 1)
            {
                src = Img.ImResize(src, scaled_x, scaled_y);
            }
            var off_y = scaled_y < oh ? (oh - scaled_y) / 2 : 0;
            var off_x = scaled_x < ow ? (ow - scaled_x) / 2 : 0;

            dst = nd.Full(fill, shape: new Shape(oh, ow, c), dtype: src.DataType).AsNumpy();
            dst[$"{off_y}:{(off_y + scaled_y)}", $"{off_x}:{(off_x + scaled_x)}", ":"] = src;

            return (dst, (off_x, off_y, scaled_x, scaled_y));
        }

        public static NDArray TenCrop(NDArray x, (int, int) size)
        {
            var (h, w) = x.Shape;
            var _tup_2 = size;
            var ow = _tup_2.Item1;
            var oh = _tup_2.Item2;
            if (h < oh || w < ow)
            {
                throw new Exception($"Cannot crop area {size.ToString()} from image with size ({h}, {w})");
            }

            var src = x.AsNumpy();
            var center = (ndarray)src[$"{Math.Round(((double)h - oh) / 2)}:{Math.Round(((double)h + oh) / 2)}", $"{Math.Round(((double)w - ow) / 2)}:{Math.Round(((double)w + ow) / 2)}", ":"];
            var tl = (ndarray)src[$"0:{oh}", $"0:{ow}", ":"];
            var bl = (ndarray)src[$"{(h - oh)}:{h}", $"0:{ow}", ":"];
            var tr = (ndarray)src[$"0:{oh}", $"{(w - ow)}:{w}", ":"];
            var br = (ndarray)src[$"{(h - oh)}:{h}", $"{(w - ow)}:{w}", ":"];
            var crops = nd.Stack(new List<NDArray> {
                                    center,
                                    tl,
                                    bl,
                                    tr,
                                    br
                                }, 5);

            crops = nd.Concat(new List<NDArray> {
                        crops,
                        nd.Flip(crops, axis: 2)
                    }, dim: 0);
            return crops;
        }
    }
}
