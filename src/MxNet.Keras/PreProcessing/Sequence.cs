using MxNet.Keras.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.PreProcessing
{
    public class SequenceUtils
    {
        public static NDArray PadSequences<T>(Sequence<T> sequences, int? maxlen= null, DType dtype= null, string padding= "pre", string truncating= "pre", float value= 0)
        {
            throw new NotImplementedException();
        }

        public static NDArray MakeSamplingTable(int size, float sampling_factor= 1e-5f)
        {
            throw new NotImplementedException();
        }

        public static (List<int[]>, int[]) SkipGrams(Sequence<string> sequence, int vocabulary_size, int window_size = 4, float negative_samples = 1, bool shuffle= true, bool categorical= false, NDArray sampling_table= null, int? seed= null)
        {
            throw new NotImplementedException();
        }

        private static Sequence<T>[] RemoveLongSequence<T>(int maxlen, Sequence<T>[] seq, int[] label)
        {
            throw new NotImplementedException();
        }
    }
}
