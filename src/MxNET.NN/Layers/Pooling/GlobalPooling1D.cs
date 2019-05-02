using System;
using System.Collections.Generic;
using System.Text;
using MxNet.DotNet;

namespace MxNet.NN.Layers
{
    public class GlobalPooling1D : BaseLayer, ILayer
    {
        public PoolingPoolType PoolingType { get; set; }

        public GlobalPooling1D(PoolingPoolType poolingType)
            :base("globalpooling1d")
        {
            PoolingType = poolingType;
        }

        public Symbol Build(Symbol x)
        {
            return Operators.Pooling(ID, x, new Shape(), PoolingType, true, Global.UseCudnn, 
                                    PoolingPoolingConvention.Valid, new Shape(), new Shape());
        }
    }
}
