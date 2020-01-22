using MxNetLib.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib
{
    public class DataParallelExecutorManager
    {
        public NDArray[] ParamArrays
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public NDArray[] GradArrays
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public NDArray[] AuxArrays
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DataParallelExecutorManager(Symbol symbol, Context ctx, DataIter train_data, string[] arg_names, string[] param_names,
                                        string[] aux_names, int[] work_load_list = null, Logger logger = null, Func<string, Symbol> sym_gen = null)
        {
            throw new NotImplementedException();
        }

        public void InstallMonitor(Monitor mon) => throw new NotImplementedException();

        public void SetParams(NDArray[] arg_params, NDArray[] aux_params) => throw new NotImplementedException();

        public void CopyTo(NDArray[] arg_params, NDArray[] aux_params) => throw new NotImplementedException();

        public void LoadDataBatch(DataBatch data_batch) => throw new NotImplementedException();

        public void Forward(DataBatch data_batch, bool? is_train = null) => throw new NotImplementedException();

        public void Backward(NDArray[] grads) => throw new NotImplementedException();

        public void UpdateMetric(EvalMetric eval_metric, NDArray[] labels, bool pre_sliced = false)
        {
            throw new NotImplementedException();
        }

    }
}
