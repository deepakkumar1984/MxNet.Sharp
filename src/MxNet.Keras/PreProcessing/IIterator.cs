using MxNet.Keras.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.PreProcessing
{
    public abstract class Iterator : Sequence<(NDArray, NDArray, NDArray)>
    {
        public Iterator(int n, int batch_size, bool shuffle, int? seed)
        {
            throw new NotImplementedException();
        }

        private void SetIndexArray()
        {
            throw new NotImplementedException();
        }

        public override (NDArray, NDArray, NDArray) this[int index] => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();

        public override void OnEpochEnd()
        {
            throw new NotImplementedException();
        }

        public virtual void Reset()
        {
            throw new NotImplementedException();
        }

        private List<NDArray> FlowIndex()
        {
            throw new NotImplementedException();
        }

        public override IEnumerator<(NDArray, NDArray, NDArray)> GetEnumerator()
        {
            return Next();
        }

        public IEnumerator<(NDArray, NDArray, NDArray)> Next()
        {
            throw new NotImplementedException();
        }

        public abstract (NDArray, NDArray, NDArray)  GetBatchesOfTransformedSamples(NDArray index_array);
    }
}
