using MxNet.Gluon.NN;
using MxNet.Image;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Contrib.Data.Vision
{
    public class DataLoader
    {
        public static HybridSequential CreateImageAugment(Shape data_shape, int resize= 0, bool rand_crop= false, bool rand_resize= false, 
            bool rand_mirror= false, NDArray mean= null, NDArray std= null, float brightness= 0, float contrast= 0, float saturation= 0, float hue= 0,
                         float pca_noise= 0, float rand_gray= 0, int inter_method= 2, DType dtype= null)
        {
            throw new NotImplementedRelease1Exception();
        }

        public static Sequential CreateBboxAugment(Shape data_shape, float rand_crop= 0, float rand_pad= 0, float rand_gray= 0,
                        bool rand_mirror= false, NDArray mean= null, NDArray std= null, float brightness= 0, float contrast= 0,
                        float saturation= 0, float pca_noise= 0, float hue= 0, int inter_method= 2,
                        float max_aspect_ratio= 2, (float, float)? area_range= null,
                        int max_attempts= 50, (int, int, int)? pad_val= null, DType dtype = null)
        {
            throw new NotImplementedRelease1Exception();
        }
    }
}
