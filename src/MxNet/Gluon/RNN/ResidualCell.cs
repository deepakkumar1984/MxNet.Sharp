using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class ResidualCell : ModifierCell
    {
        public ResidualCell(RecurrentCell base_cell) : base(base_cell)
        {
        }

        public override (NDArrayOrSymbol, NDArrayOrSymbol[]) HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            var (output, states) = BaseCell.Call(x, args);
            if (x.IsNDArray)
                output = nd.ElemwiseAdd(output, x);
            else
                output = sym.ElemwiseAdd(output, x, symbol_name: $"t{_counter}_fwd");

            return (output, states);
        }

        public override (NDArrayOrSymbol[], NDArrayOrSymbol[]) Unroll(int length, NDArrayOrSymbol[] inputs, NDArrayOrSymbol[] begin_state = null, string layout = "NTC", bool? merge_outputs = null, Symbol valid_length = null)
        {
            Reset();
            BaseCell._modified = false;
            var (outputs, states) = BaseCell.Unroll(length, inputs, begin_state, layout, merge_outputs, valid_length);
            BaseCell._modified = true;

            if(!merge_outputs.HasValue)
            {
                merge_outputs = outputs.Length > 1;
            }

            if(merge_outputs.Value)
            {
                outputs = Enumerable.Zip(outputs, inputs, (i, j) => 
                {
                    if(i.IsNDArray)
                        return new NDArrayOrSymbol(nd.ElemwiseAdd(i, j));

                    return new NDArrayOrSymbol(sym.ElemwiseAdd(i, j));
                }).ToArray();
            }

            return (outputs, states);
        }
    }
}
