using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class NormalizedPerClassBoxCenterEncoder : HybridBlock
    {
        public NormalizedPerClassBoxCenterEncoder(int num_class, int max_pos= 128, int per_device_batch_size= 1, float[] stds = null, float[] mean = null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
