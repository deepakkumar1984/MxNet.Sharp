using System;
using System.Collections.Generic;
using System.Threading;

namespace MxNet.Gluon.Data.Vision
{
    public class _MultiWorkerIterV1 : IDisposable
    {
        public delegate void WorkerFn(Dataset<NDArray> _dataset, Queue<int> _key_queue, Queue<NDArray> _data_queue,
            Func<NDArrayList, NDArrayList> _batchify_fn);

        private readonly BatchSampler _batch_sampler;
        private readonly Func<NDArrayList, NDArrayList> _batchify_fn;
        private readonly Dictionary<int, NDArrayList> _data_buffer;
        private readonly object _data_buffer_lock;
        private Queue<NDArray> _data_queue;
        private readonly Dataset<NDArray> _dataset;
        private readonly Thread _fetcher;
        private readonly IEnumerator<int[]> _iter;
        private Queue<int> _key_queue;
        private readonly int _num_workers;
        private int _rcvd_idx;
        private int _sent_idx;
        private bool _shutdown;
        private readonly List<Thread> _workers;

        public _MultiWorkerIterV1(int num_workers, Dataset<NDArray> dataset, Func<NDArrayList, NDArrayList> batchify_fn,
            BatchSampler batch_sampler, bool pin_memory = false, int pin_device_id = 0, WorkerFn worker_fn = null)
        {
            if (num_workers == 0)
                throw new Exception($"_MultiWorkerIter is not for {num_workers} workers");

            _num_workers = num_workers;
            _dataset = dataset;
            _batchify_fn = batchify_fn;
            _batch_sampler = batch_sampler;
            _key_queue = new Queue<int>();
            _data_queue = new Queue<NDArray>();
            _data_buffer = new Dictionary<int, NDArrayList>();
            _data_buffer_lock = new object();
            _rcvd_idx = 0;
            _sent_idx = 0;
            _iter = _batch_sampler.GetEnumerator();
            _shutdown = false;

            _workers = new List<Thread>();
            for (var i = 0; i < _num_workers; i++)
            {
                var t = new Thread(obj => { worker_fn(_dataset, _key_queue, _data_queue, _batchify_fn); });

                t.IsBackground = true;
                t.Start();
                _workers.Add(t);
            }

            _fetcher = new Thread(obj =>
            {
                DataLoader.FetcherLoopV1(_data_queue, _data_buffer, pin_memory, pin_device_id, _data_buffer_lock);
            });

            _fetcher.IsBackground = true;
            _fetcher.Start();

            for (var i = 0; i < 2 * _num_workers; i++)
                PushNext();
        }

        public int Length => _batch_sampler.Length;

        public void Dispose()
        {
            if (!_shutdown)
            {
                _data_queue = null;
                _fetcher.Join();
                _key_queue = null;
                foreach (var w in _workers)
                    if (w.IsAlive)
                        w.Abort();

                _shutdown = true;
            }
        }

        public NDArrayList Next()
        {
            if (_shutdown)
                throw new Exception("call Next() after shutdown is forbidden");

            if (_rcvd_idx == _sent_idx)
            {
                if (_data_buffer != null)
                    throw new Exception("Data buffer should be empty at this moment");

                Dispose();
                throw new Exception("Stop Iteration");
            }

            while (true)
                if (_data_buffer.ContainsKey(_rcvd_idx))
                {
                    NDArrayList batch = null;

                    lock (_data_buffer_lock)
                    {
                        batch = _data_buffer[_rcvd_idx];
                    }

                    _rcvd_idx++;
                    PushNext();
                    return batch;
                }
        }

        private void PushNext()
        {
            if (!_iter.MoveNext())
                return;

            var r = _iter.Current;
            _key_queue.Enqueue(new QueueItem<int>(_sent_idx, r));
            _sent_idx++;
        }
    }
}