using MxNet.Optimizers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace MxNet
{
    public class PickedStates
    {
        public List<KeyValuePair<int, string>> States { get; set; }

        public Optimizer Optimizer { get; set; }

        public PickedStates()
        {
            States = new List<KeyValuePair<int, string>>();
        }
    }

    public class Pickle
    {
        public static string Dumps(Dictionary<int, (NDArrayDict, NDArray)> states, Optimizer optimizer = null)
        {
            string result = "";
            PickedStates pickedStates = new PickedStates();
            var states_dump = states.ToList();
            Dictionary<int, NDArrayDict> dict = new Dictionary<int, NDArrayDict>();
            foreach (var item in states)
            {
                NDArrayDict v = item.Value.Item1;
                v["_state_item2_"] = item.Value.Item2;
                dict.Add(item.Key, v);
            }

            foreach (var item in dict)
            {
                NDArray.Save("temp.txt", item.Value);
                pickedStates.States.Add(new KeyValuePair<int, string>(item.Key, File.ReadAllText("temp.txt")));
                File.Delete("temp.txt");
            }

            pickedStates.Optimizer = optimizer;
            result = Newtonsoft.Json.JsonConvert.SerializeObject(pickedStates);
            return result;
        }

        public static (Dictionary<int, (NDArrayDict, NDArray)>, Optimizer) Loads(string data, bool load_optimizer = false)
        {
            PickedStates pickedStates = Newtonsoft.Json.JsonConvert.DeserializeObject<PickedStates>(data);
            Dictionary<int, (NDArrayDict, NDArray)> states = new Dictionary<int, (NDArrayDict, NDArray)>();

            foreach (var item in pickedStates.States)
            {
                NDArrayDict item1 = null;
                File.AppendAllText("temp.txt", item.Value);
                item1 = NDArray.Load("temp.txt");
                var item2 = item1["_state_item2_"];
                item1.Remove("_state_item2_");

                states.Add(item.Key, (item1, item2));
            }

            if (load_optimizer)
                return (states, pickedStates.Optimizer);

            return (states, null);
        }
    }
}
