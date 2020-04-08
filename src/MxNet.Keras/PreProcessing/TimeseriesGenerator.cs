using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.PreProcessing
{
    public class TimeseriesGenerator
    {
        public TimeseriesGenerator(NDArray data, NDArray targets, int length, int sampling_rate= 1, int stride= 1, int start_index= 0,
                                    int? end_index= null, bool shuffle= false, bool reverse= false, int batch_size= 128)
        {
            throw new NotImplementedException();
        }

        public int Length => throw new NotImplementedException();

        public (NDArray, NDArray) this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }

        public string ToJson()
        {
            throw new NotImplementedException();
        }

        public static TimeseriesGenerator TimeseriesGeneratorFromJson(string json_string)
        {
            throw new NotImplementedException();
        }
    }
}
