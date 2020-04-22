using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MxNet.Keras.Utils
{
    public abstract class SequenceEnqueuer
    {
        public Queue<Task<NDArrayList>> queue;

        public Thread run_thread;

        public Sequence<NDArrayList> sequence;

        public ManualResetEventSlim stop_signal;

        public int uid;

        public bool use_multiprocessing;

        public int workers;

        internal int? random_seed;

        public SequenceEnqueuer(Sequence<NDArrayList> sequence, bool use_multiprocessing= false)
        {
            this.sequence = sequence;
            this.use_multiprocessing = use_multiprocessing;
            if (DataUtils._SEQUENCE_COUNTER == null)
            {
                DataUtils._SEQUENCE_COUNTER = 0;
            }

            this.uid = DataUtils._SEQUENCE_COUNTER.Value;
            DataUtils._SEQUENCE_COUNTER += 1;
            this.workers = 0;
            this.queue = null;
            this.run_thread = null;
            this.stop_signal = null;
        }

        public bool IsRunning()
        {
            return this.stop_signal != null && !this.stop_signal.IsSet;
        }

        public void Start(int workers = 1, int max_queue_size = 10)
        {
            ThreadPool.SetMaxThreads(workers, workers);

            this.workers = workers;
            this.queue = new Queue<Task<NDArrayList>>(max_queue_size);
            this.stop_signal = new ManualResetEventSlim(false);
            this.run_thread = new Thread(Run);
            this.run_thread.IsBackground = true;
            this.run_thread.Start();
        }

        public void SendSequence()
        {
            DataUtils._SHARED_SEQUENCES[this.uid] = this.sequence;
        }

        public void Stop(int timeout = 0)
        {
            this.stop_signal.Set();
            queue.Clear();
            queue.Dequeue();
            this.run_thread.Join(timeout);
            DataUtils._SHARED_SEQUENCES[this.uid] = null;
        }

        public abstract void Run();

        public abstract IEnumerable<NDArrayList> Get();
    }
}
