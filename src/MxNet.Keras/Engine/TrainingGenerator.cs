using MxNet.Keras.Callbacks;
using MxNet.Keras.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Engine
{
    public class TrainingGenerator
    {
        public void FitGenerator(Model model, Sequence<(NDArray, NDArray, NDArray)> generator, int? steps_per_epoch= null, int epochs= 1, int verbose= 1, Callback[] callbacks= null,
                                (NDArray, NDArray)? validation_data= null, int? validation_steps= null, Dictionary<int, float> class_weight= null, int max_queue_size= 10,
                                int workers= 1, bool use_multiprocessing= false, bool shuffle= true, int initial_epoch= 0)
        {
            throw new NotImplementedException();
        }

        public void EvaluateGenerator(Model model, Sequence<(NDArray, NDArray, NDArray)> generator, int? steps = null, int max_queue_size = 10, int workers = 1, bool use_multiprocessing = false, int verbose = 0)
        {
            throw new NotImplementedException();
        }

        public void PredictGenerator(Model model, Sequence<(NDArray, NDArray, NDArray)> generator, int? steps = null, int max_queue_size = 10, int workers = 1, bool use_multiprocessing = false, int verbose = 0)
        {
            throw new NotImplementedException();
        }
    }
}
