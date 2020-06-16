using MxNet.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet.Keras
{
    public class Function
    {
        public KerasSymbol[] inputs;

        public bool is_train;

        public KerasSymbol[] output;

        public KerasSymbol[] updates;

        public Function(KerasSymbol[] inputs, KerasSymbol[] output, KerasSymbol[] updates)
        {
            this.output = output;
            this.updates = updates;
            this.inputs = inputs;
            this.is_train = MxNetBackend.LearningPhase();
        }

        public NDArrayList Call(KerasSymbol[] inputs)
        {
            var ret_outputs = new List<NDArray>();
           
            foreach (var x in this.output)
            {
                var bind_values = MxNetBackend.DfsGetBindValues(x);
                NDArrayDict data = new NDArrayDict();
                for (int i = 0; i < this.inputs.Length; i++)
                {
                    var arr = bind_values.Where(a => a.Key == this.inputs[i].Name).FirstOrDefault();
                    if(arr.Value != null)
                        data[this.inputs[i].Name] = arr.Value;
                }
                
                var args = x.Symbol.ListArguments();
                List<DataDesc> data_shapes = new List<DataDesc>();
                Dictionary<string, OpGradReq> grad_types = new Dictionary<string, OpGradReq>();
                for (int i = 0; i < this.inputs.Length; i++)
                {
                    data_shapes.Add(new DataDesc(this.inputs[i].Name, inputs[i].Shape));
                    grad_types.Add(this.inputs[i].Name, OpGradReq.Null);
                }

                var executor = x.Symbol.SimpleBind(mx.Cpu(), grad_req: grad_types, kwargs: data_shapes.ToArray());
                var arg_dict = executor.ArgmentDictionary();
                foreach (var v in arg_dict)
                {
                    if (data.Contains(v.Key))
                    {
                        arg_dict[v.Key] = data[v.Key];
                    }
                }

                executor.Forward(this.is_train);
                var outputs = executor.Outputs;
                ret_outputs.Add(outputs[0]);
            }

            return ret_outputs;
        }
    }
}
