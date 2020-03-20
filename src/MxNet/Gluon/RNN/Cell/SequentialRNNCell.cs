using System;
using System.Collections.Generic;
using System.Linq;

namespace MxNet.Gluon.RNN
{
    public class SequentialRNNCell : RecurrentCell
    {
        public SequentialRNNCell(string prefix, ParameterDict @params) : base(prefix, @params)
        {
        }

        public int Length => _childrens.Count;

        public new SequentialRNNCell this[string i] => (SequentialRNNCell) _childrens[i];

        public void Add(RecurrentCell cell)
        {
            RegisterChild(cell);
        }

        public override NDArrayOrSymbol[] BeginState(int batch_size = 0, string func = null, FuncArgs args = null)
        {
            return RNNCell.CellsBeginState(_childrens.Values.ToArray(), batch_size, func);
        }

        public override (NDArrayOrSymbol, NDArrayOrSymbol[]) Call(NDArrayOrSymbol inputs,
            params NDArrayOrSymbol[] states)
        {
            _counter++;
            var next_states = new List<NDArrayOrSymbol>();
            var p = 0;
            foreach (var cell in _childrens.Values)
            {
                if (cell.GetType().Name == "BidirectionalCell")
                    throw new Exception("BidirectionalCell not allowed");
                var n = cell.StateInfo().Length;
                var state = states.Skip(p).Take(n).ToArray();

                p += n;
                (inputs, state) = cell.Call(inputs, state);
                next_states.AddRange(state);
            }

            return (inputs, new[] {next_states.Sum()});
        }

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            return RNNCell.CellsStateInfo(_childrens.Values.ToArray(), batch_size);
        }

        public override (NDArrayOrSymbol[], NDArrayOrSymbol[]) Unroll(int length, NDArrayOrSymbol[] inputs,
            NDArrayOrSymbol[] begin_state = null, string layout = "NTC", bool? merge_outputs = null,
            Symbol valid_length = null)
        {
            Reset();
            var (inputs1, _, batch_size) = RNNCell.FormatSequence(length, inputs, layout, false);
            inputs = inputs1;
            var num_cells = _childrens.Count;
            begin_state = RNNCell.GetBeginState(this, begin_state, inputs, batch_size);
            var p = 0;
            NDArrayOrSymbol[] states = null;

            var next_states = new List<NDArrayOrSymbol>();
            foreach (var item in _childrens)
            {
                var i = Convert.ToInt32(item.Key);
                var cell = item.Value;
                var n = cell.StateInfo().Length;
                p += n;
                (inputs, states) = cell.Unroll(length, inputs, states, layout, i < num_cells - 1 ? null : merge_outputs,
                    valid_length);
                next_states.AddRange(states);
            }

            return (inputs, next_states.ToArray());
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}