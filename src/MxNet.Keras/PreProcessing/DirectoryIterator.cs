using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.PreProcessing
{
    public class DirectoryIterator : BatchFromFilesMixin
    {
        public DirectoryIterator(string directory,
                                 ImageDataGenerator image_data_generator,
                                 (int, int)? target_size= null,
                                 string color_mode= "rgb",
                                 string[] classes= null,
                                 string class_mode= "categorical",
                                 int batch_size= 32,
                                 bool shuffle= true,
                                 int? seed= null,
                                 string data_format= "channels_last",
                                 string save_to_dir= "",
                                 string save_prefix= "",
                                 string save_format= "png",
                                 bool follow_links= false,
                                 string subset= "",
                                 string interpolation= "nearest",
                                 DType dtype = null) : base(0, batch_size, shuffle, seed)
        {
            throw new NotImplementedException();
        }

        public override (NDArray, NDArray, NDArray) GetBatchesOfTransformedSamples(NDArray index_array)
        {
            throw new NotImplementedException();
        }

        public override string[] FilePaths => throw new NotImplementedException();

        public override NDArray Labels => throw new NotImplementedException();

        public override NDArray SampleWeights => throw new NotImplementedException();
    }
}
