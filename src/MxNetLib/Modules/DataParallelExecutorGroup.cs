using MxNetLib.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Modules
{
    public class DataParallelExecutorGroup
    {
        public DataParallelExecutorGroup(Symbol symbol, Context[] contexts, int[] workload, Shape[] data_shapes, Shape[] label_shapes,
                                        string[] param_names, bool for_training, bool inputs_need_grad, DataParallelExecutorGroup shared_group = null,
                                        Logger logger = null, string[] fixed_param_names = null, string grad_req = "write", string[] state_names = null,
                                        Dictionary<string, Context> group2ctxs = null)
        {
            throw new NotImplementedException();
        }

        public void DecideSlices(Shape[] data_shapes) => throw new NotImplementedException();

        public NDArray[] CollectArrays() => throw new NotImplementedException();

        public void BindExec(Shape[] data_shapes, Shape[] label_shapes, DataParallelExecutorGroup shared_group = null, bool reshape= false) => throw new NotImplementedException();

        public void Reshape(Shape[] data_shapes, Shape[] label_shapes) => throw new NotImplementedException();

        public void SetParams(Dictionary<string, NDArray> arg_params, Dictionary<string, NDArray> aux_params, bool allow_extra= false) => throw new NotImplementedException();

        public void GetParams(Dictionary<string, NDArray> arg_params, Dictionary<string, NDArray> aux_params) => throw new NotImplementedException();

        public void Forward(DataBatch data_batch, bool? is_train = null) => throw new NotImplementedException();

        public Shape[] GetOutputShapes() => throw new NotImplementedException();

        public List<NDArray[]> GetOutputs(bool merge_multi_context= true, int begin= 0, int? end= null) => throw new NotImplementedException();

        public List<NDArray[]> GetStates(bool merge_multi_context = true) => throw new NotImplementedException();

        public void SetStates(List<NDArray[]> states = null, int? value = null) => throw new NotImplementedException();

        public List<NDArray[]> GetInputGrads(bool merge_multi_context = true) => throw new NotImplementedException();

        public void Backward(NDArray[] grads) => throw new NotImplementedException();

        public void UpdateMetric(EvalMetric eval_metric, NDArray[] labels, bool pre_sliced = false)
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
