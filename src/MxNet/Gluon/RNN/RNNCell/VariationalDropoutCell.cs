using MxNet.Numpy;
using MxNet.Sym.Numpy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MxNet.Gluon.RNN.Cell
{
    public class VariationalDropoutCell : ModifierCell
    {
        public float drop_inputs;

        public NDArrayOrSymbol drop_inputs_mask;

        public float drop_outputs;

        public NDArrayOrSymbol drop_outputs_mask;

        public float drop_states;

        public NDArrayOrSymbol drop_states_mask;

        public VariationalDropoutCell(RecurrentCell base_cell, float drop_inputs = 0, float drop_states = 0, float drop_outputs = 0) : base(base_cell)
        {
            Debug.Assert(drop_states > 0 || !(base_cell is BidirectionalCell), "BidirectionalCell doesn't support variational state dropout. Please add VariationalDropoutCell to the cells underneath instead.");
            Debug.Assert(drop_states > 0 || !(base_cell is SequentialRNNCell), "Bidirectional SequentialRNNCell doesn't support variational state dropout. Please add VariationalDropoutCell to the cells underneath instead.");
            
            this.drop_inputs = drop_inputs;
            this.drop_states = drop_states;
            this.drop_outputs = drop_outputs;
            this.drop_inputs_mask = null;
            this.drop_states_mask = null;
            this.drop_outputs_mask = null;
        }

        public override string Alias()
        {
            return "vardrop";
        }

        public override void Reset()
        {
            base.Reset();
            this.drop_inputs_mask = null;
            this.drop_states_mask = null;
            this.drop_outputs_mask = null;
        }

        private void _initialize_input_masks(NDArrayOrSymbolList inputs, NDArrayOrSymbolList states)
        {
            if (this.drop_states > 0 && this.drop_states_mask == null)
            {
                this.drop_states_mask = F.dropout(F.ones_like(states[0]), p: this.drop_states);
            }
            if (this.drop_inputs > 0 && this.drop_inputs_mask == null)
            {
                this.drop_inputs_mask = F.dropout(F.ones_like(inputs), p: this.drop_inputs);
            }
        }

        private void _initialize_output_masks(NDArrayOrSymbol output)
        {
            if (this.drop_outputs > 0 && this.drop_outputs_mask == null)
            {
                this.drop_outputs_mask = F.dropout(F.ones_like(output), p: this.drop_outputs);
            }
        }

        public override (NDArrayOrSymbol, NDArrayOrSymbolList) HybridForward(NDArrayOrSymbol inputs, NDArrayOrSymbolList states)
        {
            var cell = this.BaseCell;
            this._initialize_input_masks(inputs, states);
            if (this.drop_states > 0)
            {
                states[0] = states[0] * this.drop_states_mask;
            }
            if (this.drop_inputs > 0)
            {
                inputs = inputs * this.drop_inputs_mask;
            }

            var (next_output, next_states) = cell.Call((inputs, states));
            this._initialize_output_masks(next_output);
            if (this.drop_outputs > 0)
            {
                next_output = next_output * this.drop_outputs_mask;
            }

            return (next_output, next_states);
        }

        public override (NDArrayOrSymbolList, NDArrayOrSymbolList) Unroll(int length, NDArrayOrSymbolList inputs, NDArrayOrSymbolList begin_state = null, string layout = "NTC", bool? merge_outputs = null, _Symbol valid_length = null)
        {
            if (this.drop_states > 0)
            {
                return base.Unroll(length, inputs, begin_state, layout, merge_outputs, valid_length: valid_length);
            }

            this.Reset();
            
            var _tup_1 = RNNCell.FormatSequence(length, inputs, layout, true);
            inputs = _tup_1.Item1;
            var axis = _tup_1.Item2;
            var batch_size = _tup_1.Item3;
            
            var states = RNNCell.GetBeginState(this, begin_state, inputs, batch_size);
            if (this.drop_inputs > 0)
            {
                inputs = F.dropout(inputs, p: this.drop_inputs, axes: new Shape(axis));
            }

            var _tup_2 = this.BaseCell.Unroll(length, inputs, states, layout, merge_outputs: true, valid_length: valid_length);
            var outputs = _tup_2.Item1;
            states = _tup_2.Item2;
            if (this.drop_outputs > 0)
            {
                outputs = F.dropout(outputs, p: this.drop_outputs, axes: new Shape(axis));
            }

            merge_outputs = merge_outputs == null ? outputs.IsNDArray : merge_outputs;
            var _tup_3 = RNNCell.FormatSequence(length, outputs, layout, merge_outputs.Value);
            outputs = _tup_3.Item1;
            if (valid_length != null)
            {
                outputs = RNNCell.MaskSequenceVariableLength(outputs, length, valid_length, axis, merge_outputs.Value);
            }

            return (outputs, states);
        }
    }
}
