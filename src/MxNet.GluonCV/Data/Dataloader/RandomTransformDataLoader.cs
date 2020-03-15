using MxNet.Gluon.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Dataloader
{
    public class RandomTransformDataLoader : Gluon.Data.DataLoader
    {
        public RandomTransformDataLoader(Func<NDArray, NDArray>[] transform_fns, Dataset<(NDArray, NDArray)> dataset, int interval = 1, int? batch_size = null, bool shuffle = false, Sampler sampler = null, string last_batch = null, BatchSampler batch_sampler = null, Func<(NDArray, NDArray)[], (NDArray, NDArray)> batchify_fn = null, int num_workers = 0, bool pin_memory = false, int pin_device_id = 0, int? prefetch = null, bool thread_pool = false) : base(dataset, batch_size, shuffle, sampler, last_batch, batch_sampler, batchify_fn, num_workers, pin_memory, pin_device_id, prefetch, thread_pool)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator<(NDArray, NDArray)> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
