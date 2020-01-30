using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision
{
    public class DataLoader : IEnumerable, IDisposable
    {
        public DataLoader(Dataset<NDArray> dataset, int? batch_size = null, bool shuffle = false, Sampler sampler = null,
                 string last_batch = null, BatchSampler batch_sampler = null, Func<NDArray[], NDArray> batchify_fn = null,
                 int num_workers = 0, bool pin_memory = false, int pin_device_id = 0, int prefetch = 0, bool thread_pool = false)
        {
            throw new NotImplementedException();
        }

        public static NDArray RebuildArray(int shared_pid, int shared_id, Shape shape, DType dtype) => throw new NotImplementedException();

        public static (NDArray, IntPtr) ReduceNDArray(NDArray data) => throw new NotImplementedException();

        public static NDArray DefaultBatchifyFn(NDArray data) => throw new NotImplementedException();

        public static NDArray DefaultMPBatchifyFn(NDArray data) => throw new NotImplementedException();

        public static NDArray[] AsInContext(NDArray[] data, Context ctx) => throw new NotImplementedException();

        public static void WorkerLoopV1(Dataset<NDArray> dataset, Queue key_queue, Queue data_queue, Func<NDArray[], bool> batchify_fn) => throw new NotImplementedException();

        public static void FetcherLoopV1(Queue data_queue, byte[] data_buffer, bool pin_memory= false, int pin_device_id= 0, object data_buffer_lock= null) => throw new NotImplementedException();

        public static void WorkerInitializer(Dataset<NDArray> dataset) => throw new NotImplementedException();

        public static void WorkerFn(int[] samples, Func<NDArray[], NDArray> batchify_fn, Dataset<NDArray> dataset) => throw new NotImplementedException();

        public static void ThreadWorkerFn(int[] samples, Func<NDArray[], NDArray> batchify_fn, Dataset<NDArray> dataset) => throw new NotImplementedException();

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Len() => throw new NotImplementedException();
    }
}
