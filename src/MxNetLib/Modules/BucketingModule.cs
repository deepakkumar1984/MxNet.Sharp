using MxNetLib.Initializers;
using MxNetLib.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Modules
{
    public class BucketingModule : BaseModule
    {
        public override string[] DataNames => throw new NotImplementedException();

        public override string[] OutputNames => throw new NotImplementedException();

        public override string[] LabelNames => throw new NotImplementedException();

        public override Shape[] DataShapes => throw new NotImplementedException();

        public override Shape[] LabelShapes => throw new NotImplementedException();

        public override Shape[] OutputShapes => throw new NotImplementedException();

        public override Symbol Symbol
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public BucketingModule(Func<string, (Symbol, string[], string[])> sym_gen, string default_bucket_key = null, Logger logging = null,
                            Context context= null, int[] work_load_list= null, string[] fixed_param_names= null, string[] state_names= null,
                            Dictionary<string, Context> group2ctxs= null, Dictionary<string, object> compression_params= null) : base(logging)
        {
            throw new NotImplementedException();
        }

        private void ResetBind() => throw new NotImplementedException();

        private (Symbol, string[], string[]) CallSymGen(string bucketKey) => throw new NotImplementedException();

        

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

        public override void SetParams(NDArrayDict arg_params = null, NDArrayDict aux_params = null, bool allow_missing = false, bool force_init = false, bool allow_extra = false)
        {
            base.SetParams(arg_params, aux_params, allow_missing, force_init, allow_extra);
        }

        public override void SaveParams(string fname)
        {
            throw new NotImplementedException();
        }

        public override void LoadParams(string fname)
        {
            throw new NotImplementedException();
        }

        public override List<NDArray[]> GetStates(bool merge_multi_context = false)
        {
            throw new NotImplementedException();
        }

        public override void SetStates(List<NDArray[]> states, int value)
        {
            throw new NotImplementedException();
        }

        public void SwitchBucket(string bucket_key, Shape[] data_shapes, Shape[] label_shapes= null) => throw new NotImplementedException();

        public override void Prepare(DataBatch data_batch, Func<DataBatch, NDArrayDict> sparse_row_id_fn = null)
        {
            base.Prepare(data_batch, sparse_row_id_fn);
        }

        public void SaveCheckpoint(string prefix, int epoch, bool remove_amp_cast= false) => throw new NotImplementedException();

        public static BucketingModule Load(string prefix, int epoch, Func<string, (Symbol, string[], string[])>  sym_gen = null, string default_bucket_key= null,
                            Logger logging = null, Context context = null, int[] work_load_list = null, string[] fixed_param_names = null, string[] state_names = null,
                            Dictionary<string, Context> group2ctxs = null, Dictionary<string, object> compression_params = null) => throw new NotImplementedException();

        public static BucketingModule LoadDict(Dictionary<string, Symbol> sym_dict, Func<string, (Symbol, string[], string[])> sym_gen = null, 
                            string default_bucket_key = null, NDArrayDict arg_params = null, NDArrayDict aux_params = null,
                            Logger logging = null, Context context = null, int[] work_load_list = null, string[] fixed_param_names = null, string[] state_names = null,
                            Dictionary<string, Context> group2ctxs = null, Dictionary<string, object> compression_params = null) => throw new NotImplementedException();
    }
}
