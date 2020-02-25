using MxNet.IO;
using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet
{
    public class DataParallelExecutorGroup
    {
        internal List<NDArrayDict> shared_data_arrays = new List<NDArrayDict>();
        internal List<string> data_names = new List<string>();
        internal List<string> label_names = new List<string>();
        internal List<string> aux_names = new List<string>();
        internal List<int> param_idx = new List<int>();
        internal List<string> param_names = new List<string>();

        internal List<Executor> train_execs = new List<Executor>();

        internal NDArrayList data_arrays = new NDArrayList();
        internal NDArrayList label_arrays = new NDArrayList();
        internal NDArrayList param_arrays = new NDArrayList();
        internal NDArrayList grad_arrays = new NDArrayList();
        internal NDArrayList aux_arrays = new NDArrayList();

        private Slice[] slices;

        public DataParallelExecutorGroup(Symbol sym, string[] arg_names, string[] param_names, Context[] ctxlist, Slice[] slices, DataIter train_data, DataParallelExecutorGroup shared_group = null)
        {
            ExecuterManager.CheckArguments(sym);

            if (shared_group == null)
            {
                foreach (var item in ctxlist)
                {
                    shared_data_arrays.Add(new NDArrayDict());
                }
            }
            else
                this.shared_data_arrays = shared_group.shared_data_arrays;

            foreach (var item in train_data.ProvideData)
                this.data_names.Add(item.Name);

            foreach (var item in train_data.ProvideLabel)
                this.label_names.Add(item.Name);

            aux_names = sym.ListAuxiliaryStates().ToList();
            for (int i = 0; i < arg_names.Length; i++)
            {
                if (param_names.Contains(arg_names[i]))
                {
                    this.param_idx.Add(i);
                    this.param_names.Add(arg_names[i]);
                }
            }

            for (int i = 0; i < ctxlist.Length; i++)
            {
                Dictionary<string, Shape> data_shapes = new Dictionary<string, Shape>();
                Dictionary<string, DType> data_types = new Dictionary<string, DType>();
                List<int> shapeData = new List<int>();
                foreach (var item in train_data.ProvideData)
                {
                    shapeData = item.Shape.Data.ToList();
                    shapeData.RemoveAt(0);
                    shapeData.Insert(0, (slices[i].End.Value - slices[i].Begin));
                    data_shapes[item.Name] = new Shape(shapeData);
                    data_types[item.Name] = item.DataType;
                }

                foreach (var item in train_data.ProvideLabel)
                {
                    shapeData = item.Shape.Data.ToList();
                    shapeData.RemoveAt(0);
                    shapeData.Insert(0, (slices[i].End.Value - slices[i].Begin));
                    data_shapes[item.Name] = new Shape(shapeData);
                    data_types[item.Name] = item.DataType;
                }

                var shared_exec = shared_group == null ? null : shared_group.train_execs[i];
                var train_exec = ExecuterManager.BindExec(sym, ctxlist[i], data_shapes, param_names, true,
                                shared_exec, shared_data_arrays[i], data_types);

                train_execs.Add(train_exec);
            }

            foreach (var name in data_names)
                for (int i = 0; i < train_execs.Count; i++)
                    data_arrays.Add(train_execs[i].ArgmentDictionary()[name]);

            foreach (var name in label_names)
                for (int i = 0; i < train_execs.Count; i++)
                    label_arrays.Add(train_execs[i].ArgmentDictionary()[name]);

            foreach (var idx in param_idx)
                for (int i = 0; i < train_execs.Count; i++)
                    param_arrays.Add(train_execs[i].ArgmentArrays[idx]);

            foreach (var idx in param_idx)
                for (int i = 0; i < train_execs.Count; i++)
                    grad_arrays.Add(train_execs[i].GradientArrays[idx]);

            for (int idx = 0; idx < aux_names.Count; idx++)
                for (int i = 0; i < train_execs.Count; i++)
                    aux_arrays.Add(train_execs[i].AuxiliaryArrays[i]);

            this.slices = slices;
        }

        public void LoadDataBatch(DataBatch data_batch)
        {
            ExecuterManager.LoadData(data_batch, data_arrays.ToArray());
            ExecuterManager.LoadData(data_batch, label_arrays.ToArray());
        }

        public void Forward(bool is_train = false)
        {
            foreach (var exec in train_execs)
            {
                exec.Forward(is_train);
            }
        }

        public void Backward()
        {
            foreach (var exec in train_execs)
            {
                exec.Backward();
            }
        }

        public void UpdateMetric(EvalMetric metric, NDArrayList labels, bool pre_sliced = false)
        {
            NDArrayList labels_slice = new NDArrayList();
            int i = 0;
            Enumerable.Zip(train_execs, slices, (e, s) =>
            {
                if (!pre_sliced)
                {
                    foreach (var label in labels)
                    {
                        labels_slice.Add(label.Slice(s.Begin, s.End.Value));
                    }
                }
                else
                {
                    labels_slice.Add(labels[i]);
                }

                metric.Update(labels_slice.ToArray(), e.Outputs.ToArray());
                i++;
                return true;
            });
        }
    }
}
