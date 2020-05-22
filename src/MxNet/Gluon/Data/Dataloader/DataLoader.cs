/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
using MxNet.Gluon.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MxNet.Gluon.Data
{
    public class WorkerPool
    {
        public delegate void WorkerInit(Dataset<(NDArray, NDArray)> dataset);

        public WorkerPool(int num_thread)
        {
            NumThreads = num_thread;
        }

        public WorkerPool(int num_thread, WorkerInit initializer, Dataset<(NDArray, NDArray)> arg)
        {
            NumThreads = num_thread;
            Initializer = initializer;
            Arg = arg;
        }

        public int NumThreads { get; }

        public WorkerInit Initializer { get; }

        public Dataset<(NDArray, NDArray)> Arg { get; }
    }

    public partial class DataLoader : IEnumerable<(NDArray, NDArray)>
    {
        private readonly BatchSampler _batch_sampler;
        private readonly Func<(NDArray, NDArray)[], (NDArray, NDArray)> _batchify_fn;
        private readonly Dataset<(NDArray, NDArray)> _dataset;
        private readonly int _num_workers;
        private readonly int _pin_device_id;
        private readonly bool _pin_memory;
        private readonly int _prefetch;
        private bool _thread_pool;
        private readonly WorkerPool _worker_pool;

        public DataLoader(Dataset<(NDArray, NDArray)> dataset, int? batch_size = null, bool shuffle = false,
            Sampler<int> sampler = null,
            string last_batch = null, BatchSampler batch_sampler = null,
            Func<(NDArray, NDArray)[], (NDArray, NDArray)> batchify_fn = null,
            int num_workers = 0, bool pin_memory = false, int pin_device_id = 0, int? prefetch = null,
            bool thread_pool = false)
        {
            _dataset = dataset;
            _pin_memory = pin_memory;
            _pin_device_id = pin_device_id;
            _thread_pool = thread_pool;

            if (batch_sampler == null)
            {
                if (!batch_size.HasValue)
                    throw new Exception("batch_size must be specified unless " +
                                        "batch_sampler is specified");

                if (sampler == null)
                {
                    if (shuffle)
                        sampler = new RandomSampler(dataset.Length);
                    else
                        sampler = new SequentialSampler(dataset.Length);
                }
                else if (shuffle)
                {
                    throw new Exception("shuffle must not be specified if sampler is specified");
                }

                batch_sampler = new BatchSampler(sampler, batch_size.Value,
                    !string.IsNullOrWhiteSpace(last_batch) ? last_batch : "keep");
            }

            _batch_sampler = batch_sampler;
            _num_workers = num_workers;
            _prefetch = Math.Max(0, prefetch.HasValue ? prefetch.Value : 2 * _num_workers);
            if (_num_workers > 0)
            {
                if (thread_pool)
                    _worker_pool = new WorkerPool(_num_workers);
                else
                    _worker_pool = new WorkerPool(_num_workers, WorkerInitializer, dataset);

                ThreadPool.SetMinThreads(_worker_pool.NumThreads, _worker_pool.NumThreads);
            }

            if (batchify_fn == null)
            {
                _batchify_fn = DefaultBatchifyFn;
            }
            else
            {
                _batchify_fn = batchify_fn;
            }
        }

        public int Length => _batch_sampler.Length;

        public virtual IEnumerator<(NDArray, NDArray)> GetEnumerator()
        {
            if (_num_workers == 0)
                foreach (var batch in _batch_sampler)
                {
                    var ret = _batchify_fn(batch.Select(x => _dataset[x]).ToArray());
                    if (_pin_memory)
                        ret = AsInContext(ret, Context.CpuPinned(_pin_device_id));

                    yield return ret;
                }
            else
                yield return new _MultiWorkerIter(_worker_pool, _batchify_fn, _batch_sampler, _pin_memory, _pin_device_id,
                    WorkerFn, _prefetch, _dataset, this).Next();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        #region Static Methods

        internal static Dataset<(NDArray, NDArray)> _worker_dataset;

        public static NDArray RebuildNDArray(int shared_pid, int shared_id, Shape shape, DType dtype)
        {
            return NDArray.NewFromSharedMem(shared_pid, shared_id, shape, dtype);
        }

        public static (Func<int, int, Shape, DType, NDArray>, (int, int, Shape, DType)) ReduceNDArray(NDArray data)
        {
            return (RebuildNDArray, data.ToSharedMem());
        }

        public static NDArrayList DefaultBatchifyFn(NDArrayList data)
        {
            var shape = data[0].Shape.Data.Where(i => i > 0).ToList();
            shape[0] = data.Length;
            var x = nd.Stack(data, data.Length);
            x = x.Reshape(shape.ToArray());
            return x;
        }

        public static NDArrayList DefaultBatchifyFn(NDArrayList[] data)
        {
            var ret = new NDArrayList();
            foreach (var item in data) ret.Add(DefaultBatchifyFn(item));

            return ret;
        }

        public static (NDArray, NDArray) DefaultBatchifyFn((NDArray, NDArray)[] data)
        {
            return (DefaultBatchifyFn(data.Select(x=>(x.Item1)).ToArray()), DefaultBatchifyFn(data.Select(x => (x.Item2)).ToArray()));
        }

        public static NDArrayList DefaultMPBatchifyFn(NDArrayList data)
        {
            var shape = data[0].Shape.Data.ToList();
            shape.Insert(0, data.Length);
            var @out = nd.Stack(data, data.Length);
            return @out.Reshape(shape.ToArray()).AsInContext(new Context(DeviceType.CPUShared));
        }

        public static NDArrayList DefaultMPBatchifyFn(NDArrayList[] data)
        {
            var ret = new NDArrayList();
            foreach (var item in data) ret.Add(DefaultMPBatchifyFn(item));

            return ret;
        }

        public static NDArrayList AsInContext(NDArrayList data, Context ctx)
        {
            return data.Select(x => x.AsInContext(ctx)).ToList();
        }

        public static (NDArray, NDArray) AsInContext((NDArray, NDArray) data, Context ctx)
        {
            return (data.Item1.AsInContext(ctx), data.Item2.AsInContext(ctx));
        }

        public static void WorkerLoopV1(Dataset<NDArray> dataset, Queue<int> key_queue, Queue<NDArray> data_queue,
            Func<NDArrayList, NDArrayList> batchify_fn)
        {
            data_queue = new Queue<NDArray>();
            var idx = 0;
            while (true)
            {
                var q = key_queue.Get();
                if (q == null)
                    break;
                var batch = batchify_fn(q.Samples.Select(x => dataset[x]).ToArray());
                data_queue.Enqueue(new QueueItem<NDArray>(idx, batch.ToArray()));
            }
        }

        public static void FetcherLoopV1(Queue<NDArray> data_queue, Dictionary<int, NDArrayList> data_buffer,
            bool pin_memory = false, int pin_device_id = 0, object data_buffer_lock = null)
        {
            while (true)
            {
                var batch = data_queue.Get();
                if (batch == null)
                    break;

                if (pin_memory)
                    batch.Samples = AsInContext(batch.Samples, Context.CpuPinned(pin_device_id));
                else
                    batch.Samples = AsInContext(batch.Samples, Context.Cpu());

                if (data_buffer_lock != null)
                    lock (data_buffer_lock)
                    {
                        data_buffer[batch.Idx] = batch.Samples;
                    }
                else
                    data_buffer[batch.Idx] = batch.Samples;
            }
        }

        public static void WorkerInitializer(Dataset<(NDArray, NDArray)> dataset)
        {
            _worker_dataset = dataset;
        }

        public static (NDArray, NDArray) WorkerFn(int[] samples, Func<(NDArray, NDArray)[], (NDArray, NDArray)> batchify_fn,
            Dataset<(NDArray, NDArray)> dataset)
        {
            _worker_dataset = dataset;
            var batch = batchify_fn(samples.Select(i => _worker_dataset[i]).ToArray());
            return batch;
        }

        public static NDArrayList ThreadWorkerFn(int[] samples, Func<NDArrayList, NDArrayList> batchify_fn,
            Dataset<NDArray> dataset)
        {
            return batchify_fn(samples.Select(i => dataset[i]).ToArray());
        }

        #endregion
    }
}