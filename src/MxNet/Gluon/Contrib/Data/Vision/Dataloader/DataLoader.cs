using MxNet.Gluon.Data.Vision.Transforms;
using MxNet.Gluon.NN;
using MxNet.Image;
using MxNet.Numpy;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MxNet.Gluon.Contrib.Data.Vision
{
    public class DataLoader
    {
        public static HybridSequential CreateImageAugment(Shape data_shape, int resize= 0, bool rand_crop= false, bool rand_resize= false, 
            bool rand_mirror= false, Tuple<float> mean= null, Tuple<float> std = null, float brightness= 0, float contrast= 0, float saturation= 0, float hue= 0,
                         float pca_noise= 0, float rand_gray= 0, int inter_method= 2, DType dtype = null)
        {
            HybridSequential augmenter = Construct(
                data_shape,
                resize,
                rand_crop,
                rand_resize,
                rand_mirror,
                brightness,
                contrast,
                saturation,
                hue,
                pca_noise,
                rand_gray,
                ref inter_method);

            augmenter.Add(new ToTensor());
            if (mean != null || std != null)
            {
                augmenter.Add(new Normalize(mean, std));
            }

            augmenter.Add(new Cast(dtype));
            return augmenter;
        }

        private static HybridSequential Construct(Shape data_shape,
                                                  int resize,
                                                  bool rand_crop,
                                                  bool rand_resize,
                                                  bool rand_mirror,
                                                  float brightness,
                                                  float contrast,
                                                  float saturation,
                                                  float hue,
                                                  float pca_noise,
                                                  float rand_gray,
                                                  ref int inter_method)
        {
            if (inter_method == 10)
            {
                inter_method = new System.Random().Next(0, 5);
            }

            var augmenter = new HybridSequential();
            if (resize > 0)
            {
                augmenter.Add(new Resize((resize, resize), interpolation: (ImgInterp)inter_method));
            }
            var crop_size = (data_shape[2], data_shape[1]);
            if (rand_resize)
            {
                Debug.Assert(rand_crop);
                augmenter.Add(new RandomResizedCrop(crop_size, interpolation: (InterpolationFlags)inter_method));
            }
            else if (rand_crop)
            {
                augmenter.Add(new RandomCrop(crop_size, pad: null, interpolation: (InterpolationFlags)inter_method));
            }
            else
            {
                augmenter.Add(new CenterCrop(crop_size, interpolation: (InterpolationFlags)inter_method));
            }
            if (rand_mirror)
            {
                augmenter.Add(new RandomFlipLeftRight(0.5f));
            }
            augmenter.Add(new Cast());

            if (brightness > 0 || contrast > 0 || saturation > 0 || hue > 0)
            {
                augmenter.Add(new RandomColorJitter(brightness, contrast, saturation, hue));
            }
            if (pca_noise > 0)
            {
                augmenter.Add(new RandomLighting(pca_noise));
            }
            if (rand_gray > 0)
            {
                augmenter.Add(new RandomGray(rand_gray));
            }

            return augmenter;
        }

        public static HybridSequential CreateImageAugment(Shape data_shape, int resize = 0, bool rand_crop = false, bool rand_resize = false,
            bool rand_mirror = false, bool mean = false, bool std = false, float brightness = 0, float contrast = 0, float saturation = 0, float hue = 0,
                         float pca_noise = 0, float rand_gray = 0, int inter_method = 2, DType dtype = null)
        {
            HybridSequential augmenter = Construct(
                data_shape,
                resize,
                rand_crop,
                rand_resize,
                rand_mirror,
                brightness,
                contrast,
                saturation,
                hue,
                pca_noise,
                rand_gray,
                ref inter_method);

            Tuple<float> meanTuple = null;
            if (mean)
            {
                meanTuple = new Tuple<float>(
                    123.68f,
                    116.28f,
                    103.53f
                );
            }

            Tuple<float> stdTuple = null;
            if (std)
            {
                stdTuple = new Tuple<float> (
                    58.395f,
                    57.12f,
                    57.375f
                );
            }

            augmenter.Add(new ToTensor());
            if (mean != null || std != null)
            {
                augmenter.Add(new Normalize(meanTuple, stdTuple));
            }

            augmenter.Add(new Cast(dtype));
            return augmenter;
        }

        public static Sequential CreateBboxAugment(Shape data_shape, float rand_crop= 0, float rand_pad= 0, float rand_gray= 0,
                        bool rand_mirror= false, ndarray mean= null, ndarray std= null, float brightness= 0, float contrast= 0,
                        float saturation= 0, float pca_noise= 0, float hue= 0, int inter_method= 2,
                        float max_aspect_ratio= 2, (float, float)? area_range= null,
                        int max_attempts= 50, (int, int, int)? pad_val= null, DType dtype = null)
        {
            throw new NotImplementedRelease1Exception();
        }
    }
}
