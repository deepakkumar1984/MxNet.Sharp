using System;
using System.Collections;
using System.Linq;

namespace MxNet.Gluon.Data.Vision
{
    public class DataLoaderV1 : IEnumerable
    {
        private readonly BatchSampler _batch_sampler;
        private readonly Func<NDArrayList, NDArrayList> _batchify_fn;
        private readonly Dataset<NDArray> _dataset;
        private readonly int _num_workers;
        private readonly int _pin_device_id;
        private readonly bool _pin_memory;

        public DataLoaderV1(Dataset<NDArray> dataset, int? batch_size = null, bool shuffle = false,
            Sampler sampler = null,
            string last_batch = null, BatchSampler batch_sampler = null,
            Func<NDArrayList, NDArrayList> batchify_fn = null,
            int num_workers = 0, bool pin_memory = false, int pin_device_id = 0)
        {
            _dataset = dataset;
            _pin_memory = pin_memory;
            _pin_device_id = pin_device_id;
            if (batch_sampler == null)
            {
                if (!batch_size.HasValue)
                    throw new Exception("batch_size must be specified unless " +
                                        "batch_sampler is specified");

                if (sampler == null)
                {
                    if (shuffle)
                        sampler = new RandomSampler(_dataset.Length);
                    else
                        sampler = new SequentialSampler(_dataset.Length);
                }
                else
                {
                    throw new Exception("shuffle must not be specified if sampler is specified");
                }

                batch_sampler = new BatchSampler(sampler, batch_size.Value,
                    !string.IsNullOrWhiteSpace(last_batch) ? last_batch : "keep");
            }
            else if (batch_size.HasValue || shuffle || sampler != null || !string.IsNullOrWhiteSpace(last_batch))
            {
                throw new Exception("batch_size, shuffle, sampler and last_batch must " +
                                    "not be specified if batch_sampler is specified.");
            }

            _batch_sampler = batch_sampler;
            _num_workers = num_workers >= 0 ? num_workers : num_workers;
            if (batchify_fn == null)
            {
                if (num_workers > 0)
                    _batchify_fn = DataLoader.DefaultMPBatchifyFn;
                else
                    _batchify_fn = DataLoader.DefaultBatchifyFn;
            }
            else
            {
                _batchify_fn = batchify_fn;
            }
        }

        public int Length => _batch_sampler.Length;

        public IEnumerator GetEnumerator()
        {
            if (_num_workers == 0)
                foreach (var batch in _batch_sampler)
                {
                    var ret = _batchify_fn(batch.Select(x => _dataset[x]).ToArray());
                    if (_pin_memory)
                        ret = DataLoader.AsInContext(ret, Context.CpuPinned(_pin_device_id));

                    yield return ret;
                }

            yield return new _MultiWorkerIterV1(_num_workers, _dataset, _batchify_fn, _batch_sampler, _pin_memory,
                _pin_device_id).Next();
        }
    }
}