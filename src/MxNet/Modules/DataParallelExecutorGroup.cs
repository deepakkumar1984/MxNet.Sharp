using System;
using System.Collections.Generic;
using MxNet.IO;
using MxNet.Metrics;
using System.Linq;

namespace MxNet.Modules
{
    public class DataParallelExecutorGroup
    {
        public NDArrayDict ArgParams { get; set; }
        public NDArrayDict AuxParams { get; set; }
        public Symbol Symbol { get; }
        public Context[] Contexts { get; }
        public int[] Workload { get; }
        
        public bool ForTraining { get; }
        public bool InputsNeedGrad { get; }
        public string[] ParamNames { get; set; }
        public string[] DataNames { get; set; }
        public string[] LabelNames { get; set; }
        public string[] FixedParamNames { get; }
        public string[] StateNames { get; }
        public string[] OutputNames { get; }
        public Dictionary<string, Context> Group2Ctxs { get; }
        public Dictionary<string, OpGradReq> GradReq { get; }
        public string[] ArgNames { get; set; }
        public string[] AuxNames { get; set; }
        public List<NDArrayList> DataArrays { get; set; }
        public List<NDArrayList> LabelArrays { get; set; }
        public List<NDArrayList> StateArrays { get; set; }
        public List<NDArrayList> ParamArrays { get; set; }
        public List<NDArrayList> GradArrays { get; set; }
        public List<NDArrayList> InputGradArrays { get; set; }
        public List<NDArrayList> AuxArrays { get; set; }
        public int BatchSize { get; set; }
        public DataParallelExecutorManager[] Execs { get; set; }
        public NDArrayList SharedDataArrays { get; set; }
        public int Slices { get; set; }

        public DataDesc[] DataShapes { get; set; }
        public DataDesc[] LabelShapes { get; set; }
        public int[] DataLayouts { get; set; }
        public int[] LabelLayouts { get; set; }
        public int[] OutputLayouts { get; set; }
        public int NumOutputs { get; set; }

        internal int _total_exec_bytes;
        internal DataParallelExecutorManager _default_execs;

        public DataParallelExecutorGroup(Symbol symbol, Context[] contexts, int[] workload, DataDesc[] data_shapes,
            DataDesc[] label_shapes,
            string[] param_names, bool for_training, bool inputs_need_grad,
            DataParallelExecutorGroup shared_group = null,
            string[] fixed_param_names = null, OpGradReq grad_req = OpGradReq.Write, string[] state_names = null,
            Dictionary<string, Context> group2ctxs = null)
        {
            Symbol = symbol;
            Contexts = contexts;
            Workload = workload;
            ParamNames = param_names;
            ForTraining = for_training;
            InputsNeedGrad = inputs_need_grad;
            FixedParamNames = fixed_param_names;
            StateNames = state_names;
            Group2Ctxs = ExecutorGroup.PrepareGroup2Ctxs(group2ctxs, contexts.Length);
            ArgNames = symbol.ListArguments().ToArray();
            AuxNames = symbol.ListAuxiliaryStates().ToArray();

            _total_exec_bytes = 0;

            if (FixedParamNames == null)
                FixedParamNames = new string[0];

            if (StateNames == null)
                StateNames = new string[0];

            if (!ForTraining)
                grad_req = OpGradReq.Null;

            var data_names = data_shapes.Select(x => x.Name).ToArray();
            GradReq = new Dictionary<string, OpGradReq>();
            foreach (var name in ArgNames)
            {
                GradReq.Add(name, grad_req);
            }

            if (shared_group != null)
                SharedDataArrays = shared_group.SharedDataArrays;
            else
            {
                SharedDataArrays = new NDArrayList();
            }

            OutputNames = symbol.ListOutputs().ToArray();
            OutputLayouts = OutputNames.Select(x=>(DataDesc.GetBatchAxis(symbol[x].Attr("__layout__")))).ToArray();
            NumOutputs = symbol.ListOutputs().Count;
            BindExec(data_shapes, label_shapes, shared_group);
        }

        public void DecideSlices(Shape[] data_shapes)
        {
            throw new NotImplementedException();
        }

        public NDArrayList CollectArrays()
        {
            throw new NotImplementedException();
        }

        public void BindExec(DataDesc[] data_shapes, DataDesc[] label_shapes, DataParallelExecutorGroup shared_group = null,
            bool reshape = false)
        {
            throw new NotImplementedException();
        }

        public void Reshape(DataDesc[] data_shapes, DataDesc[] label_shapes)
        {
            throw new NotImplementedException();
        }

        public void SetParams(NDArrayDict arg_params, NDArrayDict aux_params, bool allow_extra = false)
        {
            throw new NotImplementedException();
        }

        public void GetParams(ref NDArrayDict arg_params, ref NDArrayDict aux_params)
        {
            throw new NotImplementedException();
        }

        public void Forward(DataBatch data_batch, bool? is_train = null)
        {
            throw new NotImplementedException();
        }

        public DataDesc[] GetOutputShapes()
        {
            throw new NotImplementedException();
        }

        public List<NDArrayList> GetOutputs(bool merge_multi_context = true, int begin = 0, int? end = null)
        {
            throw new NotImplementedException();
        }

        public List<NDArrayList> GetStates(bool merge_multi_context = true)
        {
            throw new NotImplementedException();
        }

        public void SetStates(List<NDArrayList> states = null, int? value = null)
        {
            throw new NotImplementedException();
        }

        public List<NDArrayList> GetInputGrads(bool merge_multi_context = true)
        {
            throw new NotImplementedException();
        }

        public void Backward(NDArrayList grads)
        {
            throw new NotImplementedException();
        }

        public void UpdateMetric(EvalMetric eval_metric, NDArrayList labels, bool pre_sliced = false)
        {
            throw new NotImplementedException();
        }

        private Executor _BindiThExec(int i, Shape[] data_shapes, Shape[] label_shapes,
            DataParallelExecutorGroup shared_group)
        {
            throw new NotImplementedException();
        }

        private Shape[] SlicedShape(Shape[] shapes, int i, int major_axis)
        {
            throw new NotImplementedException();
        }

        public void InstallMonitor(Monitor mon)
        {
            throw new NotImplementedException();
        }
    }
}