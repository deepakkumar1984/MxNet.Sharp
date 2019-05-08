using MxNetLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using MxNetLib.Optimizers;
using MxNetLib.Metrics;
using MxNetLib.EventArgs;

namespace MxNetLib
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

        public uint[] InputShape { get; set; }

        public Shape OutputShape { get; set; }

        [JsonIgnore]
        public Symbol Model = null;

        [JsonIgnore]
        public BaseOptimizer ModelOptimizer
        {
            get; set;
        }

        [JsonIgnore]
        public BaseMetric Metric { get; set; }

        [JsonIgnore]
        public BaseMetric TrainMetric { get; set; }

        private Dictionary<string, Symbol> trainableParams = new Dictionary<string, Symbol>();

        public Module(params uint[] inputShape)
        {
            InputShape = inputShape;
            Model = Symbol.Variable("X");
        }

        public void Compile(Symbol model, BaseOptimizer optimizer, MetricType metric = MetricType.None)
        {
            trainableParams.Clear();
            Metric = MetricRegistry.Get(metric);
            TrainMetric = MetricRegistry.Get(metric);

            ModelOptimizer = optimizer;

            Model = model;
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
