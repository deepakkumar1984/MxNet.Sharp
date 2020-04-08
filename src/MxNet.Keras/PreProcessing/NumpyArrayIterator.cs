using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.PreProcessing
{
    public class NumpyArrayIterator : Iterator
    {
        public NumpyArrayIterator(ndarray x,
                                    ndarray y,
                                    ImageDataGenerator image_data_generator,
                                    int batch_size= 32,
                                    bool shuffle= false,
                                    ndarray sample_weight= null,
                                    int? seed= null,
                                    string data_format= "channels_last",
                                    string save_to_dir= "",
                                    string save_prefix= "",
                                    string save_format= "png",
                                    string subset= "",
                                    dtype dtype= null) : base((int)x.shape.iDims[0], batch_size, shuffle, seed)
        {
        }

        public override (NDArray, NDArray, NDArray) GetBatchesOfTransformedSamples(NDArray index_array)
        {
            throw new NotImplementedException();
        }
    }
}
