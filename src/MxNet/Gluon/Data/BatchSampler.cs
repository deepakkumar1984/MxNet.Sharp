using System;
using System.Collections;
using System.Collections.Generic;

namespace MxNet.Gluon.Data
{
    public class BatchSampler : IEnumerable<int[]>
    {
        private readonly int _batch_size;
        private readonly string _last_batch;
        private List<int> _prev;
        private readonly Sampler _sampler;

        public BatchSampler(Sampler sampler, int batch_size, string last_batch = "keep")
        {
            _sampler = sampler;
            _batch_size = batch_size;
            _last_batch = last_batch;
            _prev = new List<int>();
        }

        public int Length
        {
            get
            {
                if (_last_batch == "keep")
                    return Convert.ToInt32((_sampler.Length + _batch_size - 1) / _batch_size);
                if (_last_batch == "discard")
                    return Convert.ToInt32(_sampler.Length / _batch_size);
                if (_last_batch == "rollover")
                    return Convert.ToInt32((_sampler.Length + _prev.Count) / _batch_size);
                throw new Exception("last_batch must be one of 'keep', 'discard', or 'rollover', " +
                                    $"but got {_last_batch}");
            }
        }

        public IEnumerator<int[]> GetEnumerator()
        {
            var batch = new List<int>();
            batch = _prev;
            _prev.Clear();

            foreach (var i in _sampler)
            {
                batch.Add(i);
                if (batch.Count == _batch_size)
                {
                    yield return batch.ToArray();
                    batch.Clear();
                }
            }

            if (batch.Count > 0)
            {
                if (_last_batch == "keep")
                    yield return batch.ToArray();
                else if (_last_batch == "discard")
                    yield return null;
                else if (_last_batch == "rollover")
                    _prev = batch;
                else
                    throw new Exception("last_batch must be one of 'keep', 'discard', or 'rollover', " +
                                        $"but got {_last_batch}");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}