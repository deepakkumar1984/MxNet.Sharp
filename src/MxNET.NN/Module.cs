using MxNet.DotNet;
using Newtonsoft.Json;
using MxNet.NN.EventArgs;
using MxNet.NN.Layers;
using MxNet.NN.Metrics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using SiaDNN.Initializers;

namespace MxNet.NN
{
    public partial class Module
    {
        /// <summary>
        ///     Occurs when [on batch end].
        /// </summary>
        public event EventHandler<BatchEndEventArgs> BatchEnd;

        /// <summary>
        ///     Occurs when [on batch start].
        /// </summary>
        public event EventHandler<BatchStartEventArgs> BatchStart;

        /// <summary>
        ///     Occurs when [on epoch end].
        /// </summary>
        public event EventHandler<EpochEndEventArgs> EpochEnd;

        /// <summary>
        ///     Occurs when [on epoch start].
        /// </summary>
        public event EventHandler<EpochStartEventArgs> EpochStart;

        /// <summary>
        ///     Occurs when [on training end].
        /// </summary>
        public event EventHandler<TrainingEndEventArgs> TrainingEnd;

        private List<ILayer> layers = new List<ILayer>();

        public uint[] InputShape { get; set; }

        public Shape OutputShape { get; set; }

        [JsonIgnore]
        public Symbol Model = null;

        public ILayer[] Layers
        {
            get => layers.ToArray();
        }

        [JsonIgnore]
        public BaseOptimizer ModelOptimizer
        {
            get; set;
        }

        [JsonIgnore]
        public BaseMetric Metric { get; set; }

        [JsonIgnore]
        public Symbol TrainingLoss { get; set; }

        [JsonIgnore]
        public BaseMetric TrainMetric { get; set; }

        private Dictionary<string, BaseInitializer> ParamInitializers = new Dictionary<string, BaseInitializer>();

        private Dictionary<string, Symbol> trainableParams = new Dictionary<string, Symbol>();

        public Module(params uint[] inputShape)
        {
            InputShape = inputShape;
            Model = Symbol.Variable("X");
        }

        public void Add(ILayer l)
        {
            layers.Add(l);
        }

        public void Compile(BaseOptimizer optimizer, LossType loss, MetricType metric = MetricType.None)
        {
            trainableParams.Clear();
            Metric = MetricRegistry.Get(metric);
            TrainMetric = MetricRegistry.Get(metric);

            ModelOptimizer = optimizer;

            foreach (var layer in layers)
            {
                Model = layer.Build(Model);
                foreach (var item in ((BaseLayer)layer).InitParams)
                {
                    ParamInitializers.Add(item.Key, item.Value);
                }
            }

            Model = Losses.Get(loss, Model, Symbol.Variable("label"));
        }

        public void Compile(Symbol model, BaseOptimizer optimizer, LossType loss, MetricType metric = MetricType.None)
        {
            trainableParams.Clear();
            Metric = MetricRegistry.Get(metric);
            TrainMetric = MetricRegistry.Get(metric);

            ModelOptimizer = optimizer;

            Model = model;

            Model = Losses.Get(loss, Model, Symbol.Variable("label"));
        }

        public void Compile(OptimizerType optimizer, LossType loss, MetricType metric = MetricType.None)
        {
            BaseOptimizer opt = Optimizers.Get(optimizer);
            Compile(opt, loss, metric);
        }

        public void Compile(Symbol model, OptimizerType optimizer, LossType loss, MetricType metric = MetricType.None)
        {
            BaseOptimizer opt = Optimizers.Get(optimizer);
            Compile(model, opt, loss, metric);
        }

        public void SaveModel(string folder, bool saveSymbol = false)
        {
            string sequential = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(folder + "/seq.json", sequential);

            if (saveSymbol)
            {
                string symbol = Model.ToJSON();
                File.WriteAllText(folder + "/sym.json", symbol);
            }
        }
    }
}
