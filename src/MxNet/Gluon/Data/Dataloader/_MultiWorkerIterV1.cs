using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision
{
    public class _MultiWorkerIterV1 : IDisposable
    {
        public delegate void WorkerFn(Dataset<NDArray> dataset, Queue key_queue, Queue data_queue, Func<NDArrayList, bool> batchify_fn);

        public _MultiWorkerIterV1(int num_workers, Dataset<NDArray> dataset, Func<NDArrayList, bool>  batchify_fn, BatchSampler batch_sampler,
                                bool pin_memory= false, int pin_device_id= 0, WorkerFn worker_fn= null)
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
