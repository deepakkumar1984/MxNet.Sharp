using MxNetLib.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib
{
    public class DataParallelExecutorGroup
    {
        public DataParallelExecutorGroup(Symbol sym, string[] arg_names, string[] param_names, Context ctx, Slice[] slices, DataIter train_data, DataParallelExecutorGroup shared_group= null)
        {
            throw new NotImplementedException();
        }

        public void LoadDataBatch(DataBatch data_batch) => throw new NotImplementedException();

        public void Forward(bool is_train = false) => throw new NotImplementedException();

        public void Backward() => throw new NotImplementedException();

        public void update_metric(EvalMetric metric, NDArray[] labels, bool pre_sliced = false) => throw new NotImplementedException();
    }
}
