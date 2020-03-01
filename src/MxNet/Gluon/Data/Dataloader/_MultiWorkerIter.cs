using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision
{
    public class _MultiWorkerIter
    {
        private WorkerPool _worker_pool;
        private Func<NDArrayList, NDArrayList> _batchify_fn;
        private BatchSampler _batch_sampler;
        private bool _pin_memory;
        private int _pin_device_id;
        private WorkerFn _worker_fn;
        private Dataset<NDArray> _dataset;
        private DataLoader _data_loader;
        private int _rcvd_idx;
        private int _sent_idx;
        private Dictionary<int, NDArrayList> _data_buffer;
        private IEnumerator<int[]> _iter;

        public delegate NDArrayList WorkerFn(int[] r, Func<NDArrayList, NDArrayList> _batchify_fn, Dataset<NDArray> dataset);

        public _MultiWorkerIter(WorkerPool worker_pool, Func<NDArrayList, NDArrayList> batchify_fn, BatchSampler batch_sampler,
                                bool pin_memory = false, int pin_device_id = 0, WorkerFn worker_fn = null,
                                int prefetch= 0, Dataset<NDArray> dataset= null, DataLoader data_loader= null)
        {
            _worker_pool = worker_pool;
            _batchify_fn = batchify_fn;
            _batch_sampler = batch_sampler;
            _data_buffer = new Dictionary<int, NDArrayList>();
            _rcvd_idx = 0;
            _sent_idx = 0;
            _iter = _batch_sampler.GetEnumerator();
            _worker_fn = worker_fn;
            _pin_memory = pin_memory;
            _pin_device_id = pin_device_id;
            _dataset = dataset;
            _data_loader = data_loader;
            foreach (var item in Enumerable.Range(0, prefetch))
            {
                PushNext();
            }
        }

        public int Length => _batch_sampler.Length;

        public NDArrayList Next()
        {
            PushNext();
            if (_rcvd_idx == _sent_idx)
            {
                if (_data_buffer != null)
                    throw new Exception("Data buffer should be empty at this moment");

                throw new Exception("Stop Iteration");
            }

            if (_rcvd_idx >= _sent_idx)
                throw new Exception("rcvd_idx must be smaller than sent_idx");

            if (!_data_buffer.ContainsKey(_rcvd_idx))
                throw new Exception("fatal error with _push_next, rcvd_idx missing");

            var batch = _data_buffer[_rcvd_idx];
            if (_pin_memory)
                batch = DataLoader.AsInContext(batch, Context.CpuPinned(_pin_device_id));

            _rcvd_idx += 1;
            return batch;
        }

        private void PushNext()
        {
            if (!_iter.MoveNext())
                return;

            var r = _iter.Current;

            ThreadPool.QueueUserWorkItem(new WaitCallback((obj) => 
            {
                _data_buffer[_sent_idx] = _worker_fn(r, _batchify_fn, _dataset);
                _sent_idx++;
            }));
        }
    }
}
