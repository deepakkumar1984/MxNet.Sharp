using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace MxNet.Metrics
{
    public abstract class EvalMetric : Base
    {
        public string Name { get; internal set; }

        public string OutputName { get; internal set; }

        public string LabelName { get; internal set; }

        internal bool hasGlobalStats;

        internal int num_inst;
        internal float sum_metric;
        internal int global_num_inst;
        internal float global_sum_metric;

        public EvalMetric(string name, string output_name= null, string label_name = null, bool has_global_stats = false)
        {
            Name = name;
            OutputName = output_name;
            LabelName = label_name;
            hasGlobalStats = has_global_stats;
        }

        public virtual ConfigData GetConfig()
        {
            ConfigData config = new ConfigData();
            config.Add("metric", this.GetType().Name);
            config.Add("name", Name);
            config.Add("output_names", new string[] { OutputName });
            config.Add("label_names", new string[] { LabelName });

            return config;
        }

        public abstract void Update(NDArray labels, NDArray preds);

        public virtual void Update(NDArrayList labels, NDArrayList preds)
        {
            if(labels.Length != preds.Length)
            {
                throw new ArgumentException("Labels and Predictions are unequal length");
            }

            for (int i = 0; i < labels.Length; i++)
            {
                Update(labels[i], preds[i]);
            }
        }

        public virtual void Reset()
        {
            num_inst = 0;
            global_num_inst = 0;
            sum_metric = 0;
            global_sum_metric = 0;
        }

        public virtual void ResetLocal()
        {
            num_inst = 0;
            sum_metric = 0;
        }

        public virtual (string, float) Get()
        {
            if (num_inst == 0)
                return (Name, float.NaN);

            return (Name, sum_metric / num_inst);
        }

        public virtual (string, float) GetGlobal()
        {
            if(hasGlobalStats)
            {
                if (global_num_inst == 0)
                    return (Name, float.NaN);

                return (Name, global_sum_metric / global_num_inst);
            }
            else
            {
                return Get();
            }
        }

        public Dictionary<string, float> GetNameValue()
        {
            var nameValue = Get();
            return new Dictionary<string, float>() { { nameValue.Item1, nameValue.Item2 } };
        }

        public Dictionary<string, float> GetGlobalNameValue()
        {
            var nameValue = GetGlobal();
            return new Dictionary<string, float>() { { nameValue.Item1, nameValue.Item2 } };
        }

        public static implicit operator EvalMetric(string name)
        {
            throw new NotImplementedException();
        }
    }
}
