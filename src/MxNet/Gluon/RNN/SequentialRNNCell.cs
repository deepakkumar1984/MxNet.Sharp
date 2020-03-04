using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.Gluon.RNN
{
    public class SequentialRNNCell : RecurrentCell
    {
        public int Length => _childrens.Count;

        public SequentialRNNCell(string prefix, ParameterDict @params) : base(prefix, @params)
        {
        }

        public void Add(RecurrentCell cell)
        {
            RegisterChild(cell);
        }

        public override NDArrayOrSymbol[] BeginState(int batch_size = 0, string func = null, FuncArgs args = null)
        {
            return RNNCell.CellsBeginState(_childrens.Values.ToArray(), batch_size, func);
        }

        public (NDArrayOrSymbol, NDArrayOrSymbol) Call(NDArrayOrSymbol inputs, NDArrayOrSymbol states)
        {
            _counter++;
            List<NDArrayOrSymbol> next_states = new List<NDArrayOrSymbol>();
            int p = 0;
            foreach (var cell in _childrens.Values)
            {
                if (cell.GetType().Name == "BidirectionalCell")
                    throw new Exception("BidirectionalCell not allowed");
                int n = cell.StateInfo().Length;
                NDArrayOrSymbol state = states.IsNDArray 
                                                    ? new NDArrayOrSymbol(states.NdX[$"{p}:{p + n}"])
                                                    : new NDArrayOrSymbol(states.SymX[$"{p}:{p + n}"]);

                p += n;
                inputs = cell.Call(inputs, state);
                next_states.Add(state);
            }

            next_states.ToList().ToNDArrays().Sum();
            return (inputs, next_states.Sum());
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            return null;
        }

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            return RNNCell.CellsStateInfo(_childrens.Values.ToArray(), batch_size);
        }

        public override (NDArrayOrSymbol[], NDArrayOrSymbol[]) Unroll(int length, NDArrayOrSymbol[] inputs, NDArrayOrSymbol[] begin_state = null, string layout = "NTC", bool? merge_outputs = null, Symbol valid_length = null)
        {
            Reset();
            var (inputs1, _, batch_size) = RNNCell.FormatSequence(length, inputs, layout, false);
            inputs = inputs1;
            int num_cells = _childrens.Count;
            begin_state = RNNCell.GetBeginState(this, begin_state, inputs, batch_size);
            int p = 0;
            NDArrayOrSymbol[] states = null;

            List<NDArrayOrSymbol> next_states = new List<NDArrayOrSymbol>();
            foreach (var item in _childrens)
            {
                int i = Convert.ToInt32(item.Key);
                var cell = item.Value;
                int n = cell.StateInfo().Length;
                (inputs, states) = cell.Unroll(length, inputs, states, layout, merge_outputs: i < num_cells - 1 ? null : merge_outputs, valid_length: valid_length);
                next_states.AddRange(states);
            }
        }

        public new SequentialRNNCell this[string i]
        {
            get
            {
                return (SequentialRNNCell)_childrens[i];
            }
        }
    }
}
