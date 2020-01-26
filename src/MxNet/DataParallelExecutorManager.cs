using MxNet.IO;
using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet
{
    public class DataParallelExecutorManager
    {
        private Logger logging;
        private int num_device;
        private string[] arg_names;
        private string[] param_names;
        private string[] aux_names;
        private Slice[] slices;
        private Context[] contexts;
        private Symbol symbol;
        private Func<int, Symbol> sym_gen;
        private DataParallelExecutorGroup execgrp;
        private Dictionary<int, DataParallelExecutorGroup> execgrp_bucket = new Dictionary<int, DataParallelExecutorGroup>();
        private DataParallelExecutorGroup curr_execgrp;

        public NDArray[] ParamArrays
        {
            get
            {
                return execgrp.param_arrays.ToArray();
            }
        }

        public NDArray[] GradArrays
        {
            get
            {
                return execgrp.grad_arrays.ToArray();
            }
        }

        public NDArray[] AuxArrays
        {
            get
            {
                return execgrp.aux_arrays.ToArray();
            }
        }

        public DataParallelExecutorManager(Symbol symbol, Context[] ctx, DataIter train_data, string[] arg_names, string[] param_names,
                                        string[] aux_names, int[] work_load_list = null, Logger logger = null, Func<int, Symbol> sym_gen = null)
        {
            num_device = ctx.Length;
            Logger.Info(string.Format("Start training with {0}", num_device));

            if (work_load_list == null)
            {
                work_load_list = new int[num_device];
                for (int i = 0; i < num_device; i++)
                    work_load_list[i] = 1;
            }
            else if (work_load_list.Length != num_device)
                throw new MXNetException("Invalid setting for work load");

            slices = ExecuterManager.SplitInputSlice((int)train_data.BatchSize, work_load_list);

            this.arg_names = arg_names;
            this.param_names = param_names;
            this.aux_names = aux_names;
            this.contexts = ctx;
            this.execgrp = new DataParallelExecutorGroup(symbol, arg_names, param_names, ctx, slices, train_data);
            this.symbol = symbol;
            this.sym_gen = sym_gen;
            if (sym_gen != null)
                execgrp_bucket.Add(train_data.DefaultBucketKey, execgrp);
        }

        public void InstallMonitor(Monitor monitor)
        {
            if (sym_gen != null)
                throw new MXNetException("Monitoring is not implemented for bucketing");

            foreach (var texec in execgrp.train_execs)
            {
                monitor.Install(texec);
            }
        }

        public void SetParams(NDArrayDict arg_params, NDArrayDict aux_params)
        {
            foreach (var texec in execgrp.train_execs)
            {
                texec.CopyFromParams(arg_params, aux_params);
            }
        }

        public void CopyTo(NDArrayDict arg_params, NDArrayDict aux_params)
        {
            //ToDo: Revisit code
            Enumerable.Zip(param_names, ParamArrays, (name, block) =>
            {
                NDArray w = new NDArray(new float[] { block.Sum() }, Context.Cpu(0));
                w.AsType(arg_params[name].DataType).CopyTo(arg_params[name]);
                return true;
            });

            Enumerable.Zip(aux_names, AuxArrays, (name, block) =>
            {
                NDArray w = new NDArray(new float[] { block.Sum() }, Context.Cpu(0));
                w.AsType(aux_params[name].DataType).CopyTo(aux_params[name]);
                return true;
            });
        }

        public void LoadDataBatch(DataBatch data_batch)
        {
            if(sym_gen != null)
            {
                int key = data_batch.BucketKey.Value;
                if(execgrp_bucket.ContainsKey(key))
                {
                    symbol = sym_gen(key);
                    execgrp = new DataParallelExecutorGroup(symbol, arg_names, param_names, contexts, slices, NDArrayIter.FromBatch(data_batch), shared_group: execgrp);
                    execgrp_bucket[key] = execgrp;
                }

                curr_execgrp = execgrp_bucket[key];
            }
            else
            {
                curr_execgrp = execgrp;
            }

            curr_execgrp.LoadDataBatch(data_batch);
        }

        public void Forward(bool is_train = false)
        {
            curr_execgrp.Forward(is_train);
        }

        public void Backward(NDArray[] grads)
        {
            curr_execgrp.Backward();
        }

        public void UpdateMetric(EvalMetric eval_metric, NDArray[] labels, bool pre_sliced = false)
        {
            curr_execgrp.UpdateMetric(eval_metric, labels, pre_sliced);
        }

    }
}
