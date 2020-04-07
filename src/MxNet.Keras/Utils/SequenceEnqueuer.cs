using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Utils
{
    public abstract class SequenceEnqueuer
    {
        public SequenceEnqueuer(Sequence sequence, bool use_multiprocessing= false)
        {
            throw new NotImplementedException();
        }

        public bool IsRunning()
        {
            throw new NotImplementedException();
        }

        public void Start(int workers = 1, int max_queue_size = 10)
        {
            throw new NotImplementedException();
        }

        public void SendSequence()
        {
            throw new NotImplementedException();
        }

        public void Stop(int? timeout = null)
        {
            throw new NotImplementedException();
        }

        public abstract void Run();

        public abstract List<(NDArray, NDArray)> Get();
    }
}
