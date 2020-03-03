using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.Gluon.RNN
{
    public class StateInfo
    {
        public Shape Shape { get; set; }

        public string Layout { get; set; }

        public float Mean { get; set; }

        public float Std { get; set; }

        public DType DataType { get; set; }

        public Context Ctx { get; set; }

        public string Name { get; set; }

        public StateInfo()
        {

        }

        public StateInfo(FuncArgs args)
        {
            foreach (var arg in args)
            {
                if (arg.Value == null)
                    continue;

                switch (arg.Key.ToLower())
                {
                    case "shape":
                        Shape = (Shape)arg.Value;
                        break;
                    case "layout":
                        Layout = arg.Value.ToString();
                        break;
                    case "in_layout":
                        Layout = arg.Value.ToString();
                        break;
                    case "mean":
                        Mean = Convert.ToSingle(arg.Value);
                        break;
                    case "std":
                        Mean = Convert.ToSingle(arg.Value);
                        break;
                    case "dtype":
                        DataType = (DType)arg.Value;
                        break;
                    case "ctx":
                        Ctx = (Context)arg.Value;
                        break;
                    default:
                        break;
                }
            }
        }

        public void Update(FuncArgs args)
        {
            foreach (var arg in args)
            {
                if (arg.Value == null)
                    continue;

                switch (arg.Key.ToLower())
                {
                    case "shape":
                        Shape = (Shape)arg.Value;
                        break;
                    case "layout":
                        Layout = arg.Value.ToString();
                        break;
                    case "in_layout":
                        Layout = arg.Value.ToString();
                        break;
                    case "mean":
                        Mean = Convert.ToSingle(arg.Value);
                        break;
                    case "std":
                        Std = Convert.ToSingle(arg.Value);
                        break;
                    case "dtype":
                        DataType = (DType)arg.Value;
                        break;
                    case "ctx":
                        Ctx = (Context)arg.Value;
                        break;
                    case "name":
                        Name = arg.Value.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        public object[] GetArgs(string[] keys)
        {
            List<object> args = new List<object>();
            foreach (var item in keys)
            {
                switch (item.ToLower())
                {
                    case "shape":
                        args.Add(Shape);
                        break;
                    case "layout":
                        args.Add(Layout);
                        break;
                    case "in_layout":
                        args.Add(Layout);
                        break;
                    case "mean":
                        args.Add(Mean);
                        break;
                    case "std":
                        args.Add(Std);
                        break;
                    case "dtype":
                        args.Add(DataType);
                        break;
                    case "ctx":
                        args.Add(Ctx);
                        break;
                    case "name":
                        args.Add(Name);
                        break;
                    default:
                        args.Add(null);
                        break;
                }
            }

            return args.ToArray();
        }
    }

    public abstract class RecurrentCell : HybridBlock
    {
        private bool _modified;
        private int _init_counter;
        private int _counter;
        private new Dictionary<string, RecurrentCell> _childrens = new Dictionary<string, RecurrentCell>();

        public RecurrentCell(string prefix, ParameterDict @params) : base(prefix, @params)
        {
            _modified = false;
            Reset();
        }

        public virtual void Reset()
        {
            _init_counter = 0;
            _counter = 0;
            foreach (var cell in _childrens.Values)
            {
                cell.Reset();
            }
        }

        public abstract StateInfo StateInfo(int batch_size= 0);

        public virtual NDArrayOrSymbol[] BeginState(int batch_size = 0, string func = null, FuncArgs args = null)
        {
            if (_modified)
                throw new Exception("After applying modifier cells (e.g. ZoneoutCell) the base " +
                                    "cell cannot be called directly. Call the modifier cell instead.");

            List<NDArrayOrSymbol> states = new List<NDArrayOrSymbol>();
            var state_info = StateInfo(batch_size);
            for (int i = 0; i < state_info.Length; i++)
            {
                var info = state_info[i];
                _init_counter++;
                if (info != null)
                {
                    info.Update(args);
                }
                else
                {
                    info = new StateInfo(args);
                }

                if (func.StartsWith("sym."))
                {
                    sym obj = new sym();
                    args.Add("name", $"{Prefix}begin_state_{_init_counter}");
                    var m = typeof(sym).GetMethod(func.Replace("sym.", ""), System.Reflection.BindingFlags.Static);
                    var keys = m.GetParameters().Select(x => x.Name).ToArray();
                    var paramArgs = info.GetArgs(keys);
                    var s = (Symbol)m.Invoke(obj, paramArgs);
                    states.Add(s);
                }
                else if (func.StartsWith("nd."))
                {
                    nd obj = new nd();
                    var m = typeof(sym).GetMethod(func.Replace("nd.", ""), System.Reflection.BindingFlags.Static);
                    var keys = m.GetParameters().Select(x => x.Name).ToArray();
                    var paramArgs = info.GetArgs(keys);
                    var x = (NDArray)m.Invoke(obj, paramArgs);
                    states.Add(x);
                }
            }

            return states.ToArray();
        }

        public virtual (NDArrayOrSymbol[], NDArrayOrSymbol[]) Unroll(int length, NDArrayOrSymbol[] inputs, NDArrayOrSymbol[] begin_state = null,
                            string layout = "NTC", bool? merge_outputs = null, Symbol valid_length = null)
        {
            if (!inputs[0].IsSymbol)
                throw new Exception("Only symbols is supported");

            Reset();
            var (f_inputs, axis, batch_size) = RNNCell.FormatSequence(length, inputs, layout, false);
            begin_state = RNNCell.GetBeginState(this, begin_state, f_inputs, batch_size);
            var states = begin_state;
            List<NDArrayOrSymbol> outputs = new List<NDArrayOrSymbol>();
            List<NDArrayOrSymbol[]> all_states = new List<NDArrayOrSymbol[]>();
            for (int i = 0; i < length; i++)
            {
                var (output, u_states) = Unroll(1, new NDArrayOrSymbol[] { inputs[i] }, states);
                outputs.Add(output[0]);
                if (valid_length != null)
                    all_states.Add(u_states);
            }

            if (valid_length != null)
            {
                states = all_states.Select(ele_list => (sym.SequenceLast(sym.Stack(ele_list.ToList().ToSymbols(), ele_list.Length, 0), valid_length, true, 0))).ToList().ToNDArrayOrSymbols();

                outputs = RNNCell.MaskSequenceVariableLength(outputs.ToArray(), length, valid_length, axis, true).ToList();
            }

            outputs = RNNCell.FormatSequence(length, outputs.ToArray(), layout, merge_outputs.Value).Item1.ToList();
            return (outputs.ToArray(), states);
        }


        private Symbol Activation(Symbol input, string activation, FuncArgs args = null)
        {
            switch (activation.ToLower())
            {
                case "tanh":
                    return sym.Activation(input, ActivationActType.Tanh);
                case "relu":
                    return sym.Activation(input, ActivationActType.Relu);
                case "sigmoid":
                    return sym.Activation(input, ActivationActType.Sigmoid);
                case "softrelu":
                    return sym.Activation(input, ActivationActType.Softrelu);
                case "softsign":
                    return sym.Activation(input, ActivationActType.Softsign);
                case "leakyrely":
                    return sym.LeakyReLU(input);
                default:
                    break;
            }

            return input;
        }

        private NDArray Activation(NDArray input, string activation, FuncArgs args = null)
        {
            switch (activation.ToLower())
            {
                case "tanh":
                    return nd.Activation(input, ActivationActType.Tanh);
                case "relu":
                    return nd.Activation(input, ActivationActType.Relu);
                case "sigmoid":
                    return nd.Activation(input, ActivationActType.Sigmoid);
                case "softrelu":
                    return nd.Activation(input, ActivationActType.Softrelu);
                case "softsign":
                    return nd.Activation(input, ActivationActType.Softsign);
                case "leakyrely":
                    return nd.LeakyReLU(input);
                default:
                    break;
            }

            return input;
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            return base.Forward(input, args);
        }
      
    }
}
