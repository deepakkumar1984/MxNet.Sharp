using MxNetLib.Initializers;
using MxNetLib.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Modules
{
    public class SequentialModule : BaseModule
    {
        public SequentialModule(Logger logging = null) : base(logging)
        {
            throw new NotImplementedException();
        }

        public override string[] DataNames => throw new NotImplementedException();

        public override string[] OutputNames => throw new NotImplementedException();

        public override string[] LabelNames => throw new NotImplementedException();

        public override Shape[] DataShapes => throw new NotImplementedException();

        public override Shape[] LabelShapes => throw new NotImplementedException();

        public override Shape[] OutputShapes => throw new NotImplementedException();

        public void Add(Module module, bool? take_labels = null, bool? auto_wiring = null)
        {
            throw new NotImplementedException();
        }

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
    }
}
