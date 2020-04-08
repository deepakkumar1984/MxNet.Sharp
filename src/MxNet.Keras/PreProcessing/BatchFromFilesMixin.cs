using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.PreProcessing
{
    public class BatchFromFilesMixin : Iterator
    {
        public BatchFromFilesMixin(int n, int batch_size, bool shuffle, int? seed) : base(n, batch_size, shuffle, seed)
        {
        }

        public virtual string[] FilePaths { get; set; }

        public virtual NDArray Labels { get; set; }

        public virtual NDArray SampleWeights { get; set; }

        public override (NDArray, NDArray, NDArray) GetBatchesOfTransformedSamples(NDArray index_array)
        {
            throw new NotImplementedException();
        }

        public void SetProcessingAttrs(ImageDataGenerator image_data_generator, (int, int) target_size, string color_mode,   string data_format, string save_to_dir, string save_prefix, string save_format, string subset, int interpolation)
        {
            throw new NotImplementedException();
        }
    }
}
