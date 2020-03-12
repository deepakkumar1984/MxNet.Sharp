using System;
using System.Collections.Generic;
using MxNet.IO;

namespace MxNet.Modules
{
    public class ExecutorGroup
    {
        internal static void LoadGeneral(List<NDArrayList> data, List<NDArrayList> targets, int[] major_axis)
        {
            throw new NotImplementedException();
        }

        internal static void LoadData(DataBatch batch, List<List<(Slice, NDArray)>> targets, int[] major_axis)
        {
            throw new NotImplementedException();
        }

        internal static void LoadLabel(DataBatch batch, List<List<(Slice, NDArray)>> targets, int[] major_axis)
        {
            throw new NotImplementedException();
        }

        internal static NDArrayList MergeMultiContext(List<NDArrayList> outputs, int[] major_axis)
        {
            throw new NotImplementedException();
        }

        internal static Dictionary<string, Context>[] PrepareGroup2Ctxs(Dictionary<string, Context>[] group2ctxs,
            int ctx_len)
        {
            throw new NotImplementedException();
        }
    }
}