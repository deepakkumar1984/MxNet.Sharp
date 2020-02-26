using MxNet.IO;
using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Modules
{
    public class DataParallelExecutorGroup
    {
        internal int _total_exec_bytes;
        internal NDArrayDict _arg_params;
        internal NDArrayDict _aux_params;

        public List<NDArrayList> ParamArrays { get; set; }
        public List<NDArrayList> GradArrays { get; set; }
        public List<NDArrayList> AuxArrays { get; set; }
        public int BatchSize { get; set; }
        public string[] ParamNames { get; set; }

        public DataParallelExecutorManager[] Execs { get; set; }



        public DataParallelExecutorGroup(Symbol symbol, Context[] contexts, int[] workload, DataDesc[] data_shapes, DataDesc[] label_shapes,
                                        string[] param_names, bool for_training, bool inputs_need_grad, DataParallelExecutorGroup shared_group = null,
                                        string[] fixed_param_names = null, OpGradReq grad_req = OpGradReq.Write, string[] state_names = null,
                                        Dictionary<string, Context> group2ctxs = null)
        {
            throw new NotImplementedException();
        }

        public void DecideSlices(Shape[] data_shapes) => throw new NotImplementedException();

        public NDArrayList CollectArrays() => throw new NotImplementedException();

        public void BindExec(Shape[] data_shapes, Shape[] label_shapes, DataParallelExecutorGroup shared_group = null, bool reshape= false) => throw new NotImplementedException();

        public void Reshape(DataDesc[] data_shapes, DataDesc[] label_shapes) => throw new NotImplementedException();

        public void SetParams(NDArrayDict arg_params, NDArrayDict aux_params, bool allow_extra= false) => throw new NotImplementedException();

        public void GetParams(ref NDArrayDict arg_params, ref NDArrayDict aux_params) => throw new NotImplementedException();

        public void Forward(DataBatch data_batch, bool? is_train = null) => throw new NotImplementedException();

        public DataDesc[] GetOutputShapes() => throw new NotImplementedException();

        public List<NDArrayList> GetOutputs(bool merge_multi_context= true, int begin= 0, int? end= null) => throw new NotImplementedException();

        public List<NDArrayList> GetStates(bool merge_multi_context = true) => throw new NotImplementedException();

        public void SetStates(List<NDArrayList> states = null, int? value = null) => throw new NotImplementedException();

        public List<NDArrayList> GetInputGrads(bool merge_multi_context = true) => throw new NotImplementedException();

        public void Backward(NDArrayList grads) => throw new NotImplementedException();

        public void UpdateMetric(EvalMetric eval_metric, NDArrayList labels, bool pre_sliced = false)
        {
            throw new NotImplementedException();
        }

        private Executor _BindiThExec(int i, Shape[] data_shapes, Shape[] label_shapes, DataParallelExecutorGroup shared_group) => throw new NotImplementedException();

        private Shape[] SlicedShape(Shape[] shapes, int i, int major_axis) => throw new NotImplementedException();

        public void InstallMonitor(Monitor mon)
        {
            throw new NotImplementedException();
        }
    }
}
