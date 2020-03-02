using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.Gluon.RNN
{
    public class RNNCell : HybridRecurrentCell
    {
        public RNNCell(int hidden_size, string activation= "tanh", string i2h_weight_initializer= null, string h2h_weight_initializer= null,
                        string i2h_bias_initializer= "zeros", string h2h_bias_initializer= "zeros", int input_size= 0,
                        string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override StateInfo StateInfo(int batch_size = 0)
        {
            throw new NotImplementedException();
        }

        public override string Alias()
        {
            return "rnn";
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        internal static StateInfo[] CellsStateInfo(RNNCell[] cells, int batch_size)
        {
            var ret = cells.Select(x => (x.StateInfo(batch_size))).ToList();
            ret.Add(new RNN.StateInfo());
            return ret.ToArray();
        }

        internal static List<List<NDArrayOrSymbol[]>> CellsBeginState(RNNCell[] cells, int batch_size, StateFunc state_func)
        {
            var ret = cells.Select(x => (x.BeginState(batch_size, state_func))).ToList();
            return ret;
        }

        internal static List<NDArrayOrSymbol[]>  GetBeginState(RNNCell cell, List<NDArrayOrSymbol[]> begin_state, NDArrayOrSymbol inputs, int batch_size)
        {
            if(begin_state != null)
            {
                if(inputs.IsNDArray)
                {
                    var ctx = inputs.NdX.context;
                    begin_state = cell.BeginState(batch_size, func: nd.Zeros);
                }
            }

            return begin_state;
        }

        internal static (NDArrayOrSymbol, int, int) FormatSequence(int length, NDArrayOrSymbol inputs, string layout, bool merge, string in_layout= null) => throw new NotImplementedException();

        internal static NDArrayOrSymbol[] MaskSequenceVariableLength(NDArrayOrSymbol data, int length, NDArrayOrSymbol valid_length, int time_axis, bool merge) => throw new NotImplementedException();

        internal static NDArrayOrSymbol[] _reverse_sequences(NDArrayOrSymbol[] sequences, int unroll_step, NDArrayOrSymbol valid_length= null) => throw new NotImplementedException();
    }
}
