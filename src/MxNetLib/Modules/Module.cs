using MxNetLib.Initializers;
using MxNetLib.IO;
using MxNetLib.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Modules
{
    public class Module : BaseModule
    {
        public Module(Symbol symbol, string[] data_names = null, string[] label_names = null, Logger logging = null,
                            Context context = null, int[] work_load_list = null, string[] fixed_param_names = null, string[] state_names = null,
                            Dictionary<string, Context> group2ctxs = null, Dictionary<string, object> compression_params = null) : base(logging)
        {
        }

        public override string[] DataNames => throw new NotImplementedException();

        public override string[] OutputNames => throw new NotImplementedException();

        public override string[] LabelNames => throw new NotImplementedException();

        public override Shape[] DataShapes => throw new NotImplementedException();

        public override Shape[] LabelShapes => throw new NotImplementedException();

        public override Shape[] OutputShapes => throw new NotImplementedException();

        public void SaveCheckpoint(string prefix, int epoch, bool save_optimizer_states = false, bool remove_amp_cast = false) => throw new NotImplementedException();

        public static Module Load(string prefix, int epoch, bool load_optimizer_states = false, string[] data_names = null, string[] label_names = null, Logger logging = null,
                            Context context = null, int[] work_load_list = null, string[] fixed_param_names = null) => throw new NotImplementedException();

        private void ResetBind() => throw new NotImplementedException();

        public override void Backward(NDArray[] out_grads = null)
        {
            throw new NotImplementedException();
        }

        public override void Bind(Shape[] data_shapes, Shape[] label_shapes = null, bool for_training = true, bool inputs_need_grad = false, bool force_rebind = false, Module shared_module = null, string grad_req = "write")
        {
            throw new NotImplementedException();
        }

        public override void Forward(DataBatch data_batch, bool is_train = true)
        {
            throw new NotImplementedException();
        }

        public override List<NDArray[]> GetInputGrads(bool merge_multi_context = true)
        {
            throw new NotImplementedException();
        }

        public override List<NDArray[]> GetOutputs(bool merge_multi_context = true)
        {
            throw new NotImplementedException();
        }

        public override (NDArrayDict, NDArrayDict) GetParams()
        {
            throw new NotImplementedException();
        }

        public override void InitOptimizer(string kvstore = "local", string optimizer = "sgd", Dictionary<string, object> optimizer_params = null, bool force_init = false)
        {
            throw new NotImplementedException();
        }

        public override void InitParams(Initializer initializer = null, NDArrayDict arg_params = null, NDArrayDict aux_params = null, bool allow_missing = false, bool force_init = false, bool allow_extra = false)
        {
            throw new NotImplementedException();
        }

        public override void InstallMonitor(Monitor mon)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void UpdateMetric(EvalMetric eval_metric, NDArray[] labels, bool pre_sliced = false)
        {
            throw new NotImplementedException();
        }

        public void Reshape(Shape[] data_shapes, Shape[] label_shapes = null) => throw new NotImplementedException();

        public void BorrowOptimizer(Module shaped_module) => throw new NotImplementedException();

        private void SyncParamsFromDevices() => throw new NotImplementedException();

        public void SaveOptimizerStates(string fname) => throw new NotImplementedException();

        public void LoadOptimizerStates(string fname) => throw new NotImplementedException();
    }
}
