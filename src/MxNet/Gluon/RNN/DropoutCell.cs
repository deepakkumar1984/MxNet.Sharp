using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class DropoutCell : HybridRecurrentCell
    {
        public DropoutCell(float rate, Shape axes = null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            throw new NotImplementedException();
        }

        public override string Alias()
        {
            return "dropout";
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override (NDArrayOrSymbol[], NDArrayOrSymbol[]) Unroll(int length, NDArrayOrSymbol[] inputs, NDArrayOrSymbol[] begin_state = null, string layout = "NTC", bool? merge_outputs = null, Symbol valid_length = null)
        {
            return base.Unroll(length, inputs, begin_state, layout, merge_outputs, valid_length);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
