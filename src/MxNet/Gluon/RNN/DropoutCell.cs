using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class DropoutCell : HybridRecurrentCell
    {
        private float _rate;
        private Shape _axes;

        public DropoutCell(float rate, Shape axes = null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            _rate = rate;
            _axes = axes;
        }

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            return new StateInfo[0];
        }

        public override string Alias()
        {
            return "dropout";
        }

        public override (NDArrayOrSymbol,NDArrayOrSymbol[]) HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if(_rate > 0)
            {
                if (x.IsNDArray)
                    x = nd.Dropout(x, _rate, axes: _axes);
                else
                    x = sym.Dropout(x, _rate, axes: _axes, symbol_name: $"t{_counter}_fwd");
            }

            return (x, args);
        }

        public override (NDArrayOrSymbol[], NDArrayOrSymbol[]) Unroll(int length, NDArrayOrSymbol[] inputs, NDArrayOrSymbol[] begin_state = null, string layout = "NTC", bool? merge_outputs = null, Symbol valid_length = null)
        {
            return base.Unroll(length, inputs, begin_state, layout);
        }
    }
}
