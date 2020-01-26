using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.Optimizers
{
    public abstract class Optimizer
    {
        public float LearningRate
        {
            get
            {
                if (Scheduler != null)
                    return Scheduler.Call(NumUpdate);
                else
                    return lr;
            }
        }

        public float WD { get; set; }
        public float? ClipGradient { get; set; }
        public float RescaleGrad { get; set; }
        public LRScheduler Scheduler { get; set; }
        public bool MultiPrecision { get; set; }
        public uint BeginNumUpdate { get; set; }
        public uint NumUpdate { get; set; }
        public int AggregateNum { get; set; }
        public Dictionary<int, string> Idx2Name { get; set; }
        public Dictionary<int, Gluon.Parameter> ParamDict { get; set; }

        private float lr;
        private Dictionary<int, float> lr_mult = new Dictionary<int, float>();
        private Dictionary<int, float> wd_mult = new Dictionary<int, float>();
        private Dictionary<int, Dictionary<int, int>> all_index_update_counts = new Dictionary<int, Dictionary<int, int>>();
        private Dictionary<int, int> index_update_count = new Dictionary<int, int>();
        private (Dictionary<string, Dictionary<string, string>>, List<string>) sym_info;

        private Dictionary<string, Optimizer> opt_registry = new Dictionary<string, Optimizer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Optimizer"/> class.
        /// </summary>
        /// <param name="lr">The lr.</param>
        /// <param name="name">The name.</param>
        public Optimizer(float rescale_grad= 1, Dictionary<int, string> param_idx2name= null, float wd= 0,
                        float? clip_gradient= null, float learning_rate= 0.01f, LRScheduler lr_scheduler= null,
                        Symbol sym= null, uint begin_num_update= 0, bool multi_precision= false, Dictionary<int, Gluon.Parameter> param_dict= null)
        {
            lr = learning_rate;
            RescaleGrad = rescale_grad;
            Scheduler = lr_scheduler;
            if (Scheduler != null)
                Scheduler.BaseLearningRate = learning_rate;

            WD = wd;
            BeginNumUpdate = begin_num_update;
            NumUpdate = begin_num_update;
            all_index_update_counts.Add(0, new Dictionary<int, int>());
            index_update_count = all_index_update_counts[0];
            ClipGradient = clip_gradient;
            MultiPrecision = multi_precision;
            AggregateNum = 0;
            if (param_idx2name == null)
                param_idx2name = new Dictionary<int, string>();

            Idx2Name = param_idx2name;
            if(sym !=null)
            {
                sym_info = (sym.ListAttributeDict(), sym.ListArguments().ToList());
            }
            else
            {
                sym_info = new ValueTuple<Dictionary<string, Dictionary<string, string>>, List<string>>(new Dictionary<string, Dictionary<string, string>>(), new List<string>());
            }

            if (param_dict != null)
                ParamDict = param_dict;
            else
                ParamDict = new Dictionary<int, Gluon.Parameter>();

            SetLrMult(new Dictionary<int, float>());
            SetWdMult(new Dictionary<int, float>());
        }

        public abstract object CreateState(int index, NDArray weight);

        public object CreateStatec(int index, NDArray weight) => throw new NotImplementedException();

        public abstract void Update(int iteration, int index, NDArray param, NDArray grad, object state);

        public void UpdateMultiPrecision(int iteration, int index, NDArray param, NDArray grad, object state) => throw new NotImplementedException();

        public void SetLearningRate(float lr) => throw new NotImplementedException();

        public static Updater GetUpdater(Optimizer optimizer)
        {
            throw new NotImplementedException();
        }

        public static void Register(Optimizer klass) => throw new NotImplementedException();

        public static Optimizer CreateOptimizer(string name, FuncArgs kwargs) => throw new NotImplementedException();

        private void SetLrMult(Dictionary<int, float> lr_mult) => throw new NotImplementedException();

        private void SetWdMult(Dictionary<int, float> lr_mult) => throw new NotImplementedException();
    }
}
