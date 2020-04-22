using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Keras.Utils
{
    public class GeneratorEnqueuer : SequenceEnqueuer
    {
        public GeneratorEnqueuer(Sequence<NDArrayList> sequence, bool use_multiprocessing = false, int? wait_time = null, int? random_seed = null) : base(sequence, use_multiprocessing)
        {
            this.random_seed = random_seed;
            if (wait_time != null)
            {
                Logger.Warning("`wait_time` is not used anymore.");
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
            this.SendSequence();
            while (true)
            {
                if (this.stop_signal.IsSet)
                {
                    return;
                }

                queue.Enqueue(Task.Run(() => DataUtils.NextSample(this.uid)));
            }
        }
    }
}
