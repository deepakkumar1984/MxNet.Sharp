using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib
{
    public class ExecuterManager
    {
        internal static Slice[] SplitInputSlice(int batch_size, int[] work_load_list) => throw new NotImplementedException();

        internal static void CheckArguments(Symbol symbol) => throw new NotImplementedException();

        internal static void LoadGeneral(NDArray[] data, NDArray[] targets) => throw new NotImplementedException();

        internal static void LoadData(DataBatch batch, NDArray[] targets) => throw new NotImplementedException();

        internal static void LoadLabel(DataBatch batch, NDArray[] targets) => throw new NotImplementedException();

        internal static void BindExec(Symbol sym, Context ctx, Shape[] input_shapes, string[] param_names, bool need_grad = false,
               Executor base_exec = null, NDArray[] shared_data_arrays = null, DType[] input_types = null, Logger logger = null) => throw new NotImplementedException();
    }
}
