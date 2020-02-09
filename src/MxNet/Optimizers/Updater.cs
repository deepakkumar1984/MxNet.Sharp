using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class Updater
    {
        internal Optimizer optimizer;
        internal Dictionary<int, (NDArrayDict, NDArray)> states;
        private Dictionary<int, bool> states_synced;
        private bool aggregate_updates;

        public Updater(Optimizer opt)
        {
            optimizer = opt;
            states = new Dictionary<int, (NDArrayDict, NDArray)>();
            states_synced = new Dictionary<int, bool>();
            aggregate_updates = opt.AggregateNum > 0;
        }

        public void Call(int[] indices, NDArray[] grads, NDArray[] weights)
        {
            if (weights != null)
                optimizer.SetCurrentContext(weights[0].context.GetDeviceId());

            for(int i=0;i<indices.Length;i++)
            {
                int index = indices[i];
                if (!states.ContainsKey(index))
                {
                    states[index] = optimizer.CreateStateMultiPrecision(index, weights[i]);
                    states_synced[index] = true;
                }
                else if (!states_synced[index])
                {
                    states[i] = SyncStateContext(states[i], weights[i].context);
                    states_synced[index] = true;
                }
            }

            if(aggregate_updates)
            {
                Dictionary<string, List<(int, NDArray, NDArray)>> type_map = new Dictionary<string, List<(int, NDArray, NDArray)>>();
                for(int i = 0;i<indices.Length;i++)
                {
                    var w = weights[i];
                    var g = grads[i];
                    if (type_map.ContainsKey(w.DataType.Name))
                        type_map[w.DataType.Name].Add((i, w, g));
                    else
                    {
                        type_map[w.DataType.Name] = new List<(int, NDArray, NDArray)>();
                        type_map[w.DataType.Name].Add((i, w, g));
                    }
                }

                foreach (var item in type_map)
                {
                    int current_index = 0;
                    while (current_index < item.Value.Count)
                    {
                        Dictionary<int, (NDArrayDict, NDArray)> local_states = new Dictionary<int, (NDArrayDict, NDArray)>();
                        var step = (int)Math.Min(optimizer.AggregateNum, item.Value.Count - current_index);
                        var (index, weight, grad) = item.Value[current_index + optimizer.AggregateNum];
                        for (int j = 0; j < step; j++)
                            local_states.Add(j, states[item.Value[current_index + j].Item1]);

                        optimizer.UpdateMultiPrecision(index, weight, grad, local_states[0]); //ToDo: revisit code

                        current_index += optimizer.AggregateNum;
                    }
                }
            }
            else
            {
                for (int i = 0; i < indices.Length; i++)
                {
                    optimizer.UpdateMultiPrecision(indices[i], weights[i], grads[i], states[i]);
                }
            }
        }

        public (NDArrayDict, NDArray) SyncStateContext((NDArrayDict, NDArray) state, Context context)
        {
            var (dict, arr) = state;
            NDArrayDict dict1 = new NDArrayDict();
            foreach (var item in dict)
            {
                dict1[item.Key] = item.Value.AsInContext(context);
            }

            return (dict1, arr.AsInContext(context));
        }

        public void SetStates(string states_data)
        {
            var (states, opt) = Pickle.Loads(states_data);
            if (opt != null)
                optimizer = opt;
             
            this.states = states;
            states_synced.Clear();
            foreach (var item in states.Keys)
            {
                states_synced.Add(item, false);
            }
        }

        public string GetStates(bool dump_optimizer = false)
        {
            if(dump_optimizer)
                return Pickle.Dumps(states, optimizer);

            return Pickle.Dumps(states);
        }
    }
}
