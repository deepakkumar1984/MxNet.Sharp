using MxNet.Callbacks;
using MxNet.EventArgs;
using MxNet.Initializers;
using MxNet.IO;
using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Modules
{
    public abstract class BaseModule
    {
        private Symbol symbol;

        public abstract string[] DataNames
        {
            get;
        }

        public abstract string[] OutputNames
        {
            get;
        }

        public abstract string[] LabelNames
        {
            get;
        }

        public abstract Shape[] DataShapes
        {
            get;
        }

        public abstract Shape[] LabelShapes
        {
            get;
        }

        public abstract Shape[] OutputShapes
        {
            get;
        }

        public virtual Symbol Symbol
        {
            get
            {
                return symbol;
            }
        }

        public BaseModule(Logger logging)
        {
            throw new NotImplementedException();
        }

        public void ForwardBackward(DataBatch data_batch)
        {

        }

        public void Score(DataIter eval_data, EvalMetric eval_metric, int? num_batch= null, IBatchEndCallback[] batch_end_callback  = null,
              IScoreEndCallback[] score_end_callback = null, bool reset= true, int epoch= 0, Func<DataBatch, NDArrayDict> sparse_row_id_fn= null)
        {
            throw new NotImplementedException();
        }

        public void IterPredict(DataIter eval_data, int? num_batch = null, bool reset = true, int epoch = 0, Func<DataBatch, NDArrayDict> sparse_row_id_fn = null)
        {
            throw new NotImplementedException();
        }

        public void Predict(DataIter eval_data, int? num_batch = null, bool merge_batches = true, bool reset = true, bool always_output_list = true, Func<DataBatch, NDArrayDict> sparse_row_id_fn = null)
        {
            throw new NotImplementedException();
        }

        public void Fit(DataIter train_data, DataIter eval_data= null, string eval_metric= "acc",
            IEpochEndCallback[] epoch_end_callback= null, IBatchEndCallback[] batch_end_callback= null, string kvstore = "local",
            string optimizer= "sgd", Dictionary<string, object> optimizer_params= null, IBatchEndCallback[] eval_end_callback= null,
            IBatchEndCallback[] eval_batch_end_callback= null, Initializer initializer= null, NDArrayDict arg_params= null,
            NDArrayDict aux_params = null, bool allow_missing= false, bool force_rebind= false, 
            bool force_init= false, int begin_epoch= 0, int? num_epoch= null, EvalMetric validation_metric= null,
            Monitor monitor= null, Func<DataBatch, NDArrayDict>  sparse_row_id_fn = null)
        {
            throw new NotImplementedException();
        }

        public abstract (NDArrayDict, NDArrayDict) GetParams();

        public abstract void InitParams(Initializer initializer = null, NDArrayDict arg_params = null, NDArrayDict aux_params = null,
                    bool allow_missing = false, bool force_init = false, bool allow_extra = false);

        public virtual void SetParams(NDArrayDict arg_params = null, NDArrayDict aux_params = null,
                    bool allow_missing = false, bool force_init = false, bool allow_extra = false)
        {
            InitParams(null, arg_params, aux_params, allow_missing, force_init, allow_extra);
        }

        public virtual void SaveParams(string fname) => throw new NotImplementedException();

        public virtual void LoadParams(string fname) => throw new NotImplementedException();

        public virtual List<NDArray[]> GetStates(bool merge_multi_context = false) => throw new NotImplementedException();

        public virtual void SetStates(List<NDArray[]> states, int value) => throw new NotImplementedException();

        public abstract void InstallMonitor(Monitor mon);

        public virtual void Prepare(DataBatch data_batch, Func<DataBatch, NDArrayDict> sparse_row_id_fn = null) => throw new NotImplementedException();

        public abstract void Forward(DataBatch data_batch, bool is_train = true);

        public abstract void Backward(NDArray[] out_grads = null);

        public abstract List<NDArray[]> GetOutputs(bool merge_multi_context = true);

        public abstract List<NDArray[]> GetInputGrads(bool merge_multi_context = true);

        public abstract void Update();

        public abstract void UpdateMetric(EvalMetric eval_metric, NDArray[] labels, bool pre_sliced = false);

        public abstract void Bind(Shape[] data_shapes, Shape[] label_shapes = null, bool for_training = true,
                                    bool inputs_need_grad = false, bool force_rebind = false, Module shared_module = null, string grad_req = "write");

        public abstract void InitOptimizer(string kvstore = "local", string optimizer = "sgd", Dictionary<string, object> optimizer_params = null, bool force_init = false);

        internal static void CheckInputNames(Symbol symbol, string[] names, string typename, bool @throw)
        {
            throw new NotImplementedException();
        }

        internal static void CheckNamesMatch(string[] data_names, Shape[] data_shapes, string name, bool @throw)
        {
            throw new NotImplementedException();
        }

        internal static (Shape[], Shape[]) ParseDataDesc(string[] data_names, string[] label_names, Shape[] data_shapes, Shape[] label_shapes)
        {
            throw new NotImplementedException();
        }


    }
}
