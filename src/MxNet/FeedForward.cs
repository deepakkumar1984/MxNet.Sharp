using System;
using System.Collections;
using System.Collections.Generic;
using MxNet.Callbacks;
using MxNet.Initializers;
using MxNet.IO;
using MxNet.Optimizers;

namespace MxNet
{
    public class FeedForward
    {
        private Hashtable __dict__ = new Hashtable();

        public FeedForward(Symbol symbol, Context ctx = null, int? num_epoch = null, int? epoch_size = null,
            Optimizer optimizer = null,
            Initializer initializer = null, int numpy_batch_size = 128, NDArrayDict arg_params = null,
            NDArrayDict aux_params = null,
            bool allow_extra_params = false, int begin_epoch = 0)
        {
            throw new NotImplementedException();
        }

        public Hashtable State
        {
            get
            {
                var state = new Hashtable();
                foreach (DictionaryEntry item in __dict__) state[item.Key] = item.Value;

                state["_pred_exec"] = null;

                return state;
            }
            set => __dict__ = value;
        }

        internal void CheckArgument()
        {
            throw new NotImplementedException();
        }

        internal static bool IsDataArg(string name)
        {
            throw new NotImplementedException();
        }

        internal void InitParams(NDArrayList inputs, bool overwrite = false)
        {
            throw new NotImplementedException();
        }

        internal void InitPredictor(Shape[] input_shapes, Dictionary<string, DType> type_dict = null)
        {
            throw new NotImplementedException();
        }

        internal NDArray InitIter(NDArray X, NDArray y, bool is_train)
        {
            throw new NotImplementedException();
        }

        internal DataIter InitEvalIter(NDArrayList eval_data)
        {
            throw new NotImplementedException();
        }

        public NDArray predict(NDArray X, int? num_batch = null, bool reset = true)
        {
            throw new NotImplementedException();
        }

        public float Score(NDArray X, string eval_metric = "acc", int? num_batch = null,
            IBatchEndCallback batch_end_callback = null, bool reset = true)
        {
            throw new NotImplementedException();
        }

        public void Fit(NDArray X, NDArray y = null, DataIter eval_data = null, string eval_metric = "acc",
            IEpochEndCallback epoch_end_callback = null,
            IBatchEndCallback batch_end_callback = null, string kvstore = "local", Logger logger = null,
            int[] work_load_list = null,
            Monitor monitor = null, IEvalEndCallback eval_end_callback = null,
            IEvalBatchEndCallback eval_batch_end_callback = null)
        {
            throw new NotImplementedException();
        }

        public void Save(string prefix, int? epoch = null, bool remove_amp_cast = true)
        {
            throw new NotImplementedException();
        }

        public static FeedForward Load(string prefix, int epoch, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static FeedForward create(Symbol symbol, NDArray X, NDArray y = null, Context ctx = null,
            int? num_epoch = null,
            int? epoch_size = null, Optimizer optimizer = null, Initializer initializer = null,
            DataIter eval_data = null, string eval_metric = "acc", IEpochEndCallback epoch_end_callback = null,
            IBatchEndCallback batch_end_callback = null, string kvstore = "local", Logger logger = null,
            int[] work_load_list = null, IEvalEndCallback eval_end_callback = null,
            IEvalBatchEndCallback eval_batch_end_callback = null)
        {
            throw new NotImplementedException();
        }
    }
}