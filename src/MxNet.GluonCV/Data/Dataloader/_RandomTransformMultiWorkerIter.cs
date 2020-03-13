using MxNet.Gluon.Data;
using MxNet.Gluon.Data.Vision;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class _RandomTransformMultiWorkerIter : _MultiWorkerIter
    {
        public _RandomTransformMultiWorkerIter(Func<NDArray, NDArray>[] transform_fns, int interval, WorkerPool worker_pool, Func<NDArrayList, NDArrayList> batchify_fn, BatchSampler batch_sampler, bool pin_memory = false, int pin_device_id = 0, WorkerFn worker_fn = null, int prefetch = 0) : base(worker_pool, batchify_fn, batch_sampler, pin_memory, pin_device_id, worker_fn, prefetch)
        {
            throw new NotImplementedException();
        }

        public override void PushNext()
        {
            throw new NotImplementedException();
        }
    }
}
