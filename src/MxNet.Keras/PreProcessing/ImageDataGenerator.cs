using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.PreProcessing
{
    public class ImageDataGenerator
    {
        public ImageDataGenerator(bool featurewise_center= false,
                                 bool samplewise_center= false,
                                 bool featurewise_std_normalization= false,
                                 bool samplewise_std_normalization= false,
                                 bool zca_whitening= false,
                                 float zca_epsilon= 1e-6f,
                                 int rotation_range= 0,
                                 float width_shift_range= 0,
                                 float height_shift_range= 0,
                                 (float, float)? brightness_range= null,
                                 float shear_range= 0,
                                 float zoom_range= 0,
                                 float channel_shift_range= 0,
                                 string fill_mode= "nearest",
                                 float cval= 0,
                                 bool horizontal_flip= false,
                                 bool vertical_flip= false,
                                 float? rescale= null,
                                 Func<NDArray, NDArray> preprocessing_function= null,
                                 string data_format= "channels_last",
                                 float validation_split= 0,
                                 int interpolation_order= 1,
                                 DType dtype= null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<(NDArray, NDArray)> Flow(NDArray x,
                                                     NDArray y = null,
                                                     int batch_size = 32,
                                                     bool shuffle = true,
                                                     NDArray sample_weight = null,
                                                     int? seed = null,
                                                     string save_to_dir = null,
                                                     string save_prefix = "",
                                                     string save_format = "png",
                                                     string subset = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerator<(NDArray, NDArray)> flow_from_directory(string directory,
                                                                    (int, int)? target_size = null,
                                                                    string color_mode = "rgb",
                                                                    string[] classes = null,
                                                                    string class_mode = "categorical",
                                                                    int batch_size = 32,
                                                                    bool shuffle = true,
                                                                    int? seed = null,
                                                                    string save_to_dir = null,
                                                                    string save_prefix = "",
                                                                    string save_format = "png",
                                                                    bool follow_links = false,
                                                                    string gsubset = null,
                                                                    string interpolation = "nearest")
        {
            throw new NotImplementedException();
        }

        public NDArray Standardize(NDArray x)
        {
            throw new NotImplementedException();
        }

        public FuncArgs GetRandomTransform(NDArray img_shape, int? seed= null)
        {
            throw new NotImplementedException();
        }

        public NDArray ApplyTransform(NDArray x, FuncArgs transform_parameters)
        {
            throw new NotImplementedException();
        }

        public NDArray RandomTransform(NDArray img_shape, int? seed = null)
        {
            throw new NotImplementedException();
        }

        public void Fit(NDArray x, bool augment= false, int rounds= 1, int? seed= null)
        {
            throw new NotImplementedException();
        }
    }
}
