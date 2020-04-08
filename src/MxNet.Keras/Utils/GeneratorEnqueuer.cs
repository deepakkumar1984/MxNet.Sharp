using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Utils
{
    public class GeneratorEnqueuer : SequenceEnqueuer
    {
        public GeneratorEnqueuer(Sequence<(NDArray, NDArray)> sequence, bool use_multiprocessing = false, int? wait_time = null, int? random_seed = null) : base(sequence, use_multiprocessing)
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
    }
}
