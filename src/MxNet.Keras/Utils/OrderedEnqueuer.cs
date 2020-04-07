using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Utils
{
    public class OrderedEnqueuer : SequenceEnqueuer
    {
        public OrderedEnqueuer(Sequence sequence, bool use_multiprocessing = false, bool shuffle = false) : base(sequence, use_multiprocessing)
        {
            throw new NotImplementedException();
        }

        public override List<(NDArray, NDArray)> Get()
        {
            throw new NotImplementedException();
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }

        private void WaitQueue()
        {
            throw new NotImplementedException();
        }
    }
}
