using MxNet.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Modules
{
    public class ExecutiorGroup
    {
        internal static void LoadGeneral(NDArrayList data, NDArrayList targets, int major_axis) => throw new NotImplementedException();

        internal static void LoadData(DataBatch batch, NDArrayList targets, int major_axis) => throw new NotImplementedException();

        internal static void LoadLabel(DataBatch batch, NDArrayList targets, int major_axis) => throw new NotImplementedException();

        internal static void MergeMultiContext(NDArrayList outputs, int major_axis) => throw new NotImplementedException();

        internal static Dictionary<string, Context> PrepareGroup2Ctxs(Dictionary<string, Context> group2ctxs, int ctx_len) => throw new NotImplementedException();

    }
}
