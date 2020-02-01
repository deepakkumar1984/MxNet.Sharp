using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.NN
{
    public abstract class _Pooling : HybridBlock
    {
        public _Pooling(int[] pool_size, int[] strides, int[] padding, bool ceil_mode, bool global_pool,
                        string pool_type, string layout, bool? count_include_pad= null, string prefix = null,
                        ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override string Alias()
        {
            return "pool";
        }

    }
}
