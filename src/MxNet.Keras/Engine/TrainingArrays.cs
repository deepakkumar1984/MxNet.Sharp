using MxNet.Keras.Callbacks;
using System;   
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Engine
{
    public class TrainingArrays
    {
        public static History FitLoop(Model model, Func<NDArrayList> fit_function, NDArrayList fit_inputs, string[] out_labels= null, int? batch_size= null, int epochs= 100,
                                int verbose= 1, Callback[] callbacks= null, Func<NDArrayList> val_function= null, NDArrayList val_inputs= null, bool shuffle= true,
                                string[] callback_metrics= null, int initial_epoch= 0, int? steps_per_epoch= null, int? validation_steps= null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayList PredictLoop(Model model, Func<NDArrayList>  f, NDArrayList ins, int batch_size= 32, int verbose= 0, int? steps= null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayList TestLoop(Model model, Func<NDArrayList> f, NDArrayList ins, int batch_size = 32, int verbose = 0, int? steps = null)
        {
            throw new NotImplementedException();
        }
    }
}
