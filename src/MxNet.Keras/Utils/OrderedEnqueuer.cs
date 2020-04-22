using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MxNet.Keras.Utils
{
    public class OrderedEnqueuer : SequenceEnqueuer
    {
        public bool shuffle;

        public OrderedEnqueuer(Sequence<NDArrayList> sequence, bool use_multiprocessing = false, bool shuffle = false) : base(sequence, use_multiprocessing)
        {
            this.shuffle = shuffle;
        }

        public virtual void WaitQueue()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (this.queue.Count == 0 || this.stop_signal.IsSet)
                {
                    return;
                }
            }
        }

        public override IEnumerable<NDArrayList> Get()
        {
            while (this.IsRunning())
            {
                var inputs = ((Task<NDArrayList>)this.queue.Dequeue()).Result;
                if (inputs != null)
                {
                    yield return inputs;
                }
            }
        }

        public override void Run()
        {
            var sequence = Enumerable.Range(0, this.sequence.Length).ToList();
            this.SendSequence();
            while (true)
            {
                if (this.shuffle)
                {
                    sequence.Shuffle();
                }

                foreach (var i in sequence)
                {
                    if (this.stop_signal.IsSet)
                    {
                        return;
                    }

                    queue.Enqueue(Task.Run(() => DataUtils.GetIndex(this.uid, i)));
                    ThreadPool.QueueUserWorkItem((t) =>
                    {
                        DataUtils.GetIndex(this.uid, i);
                    });
                }

                // Done with the current epoch, waiting for the final batches
                this.WaitQueue();
                if (this.stop_signal.IsSet)
                {
                    // We're done
                    return;
                }
                // Call the internal on epoch end.
                this.sequence.OnEpochEnd();
                this.SendSequence();
            }
        }

    }
}
