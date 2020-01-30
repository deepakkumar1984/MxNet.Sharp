using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision
{
    public class _MultiWorkerIter : IDisposable
    {
        public delegate void WorkerFn(Dataset<NDArray> dataset, Queue key_queue, Queue data_queue, Func<NDArray[], bool> batchify_fn);

        public _MultiWorkerIter(int worker_pool, Func<NDArray[], bool> batchify_fn, BatchSampler batch_sampler,
                                bool pin_memory = false, int pin_device_id = 0, WorkerFn worker_fn = null,
                                int prefetch= 0, Dataset<NDArray> dataset= null, DataLoader data_loader= null)
        {
            throw new NotImplementedException();
        }

        public int Len() => throw new NotImplementedException();

        public byte[] Next() => throw new NotImplementedException();

        private void PushNext() => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
