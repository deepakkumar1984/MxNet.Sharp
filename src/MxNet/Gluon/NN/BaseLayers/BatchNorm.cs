using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.NN
{
    public class BatchNorm : HybridBlock
    {
        public BatchNorm(int axis= 1, float momentum= 0.9f, float epsilon= 1e-5f, bool center= true, bool scale= true,
                        bool use_global_stats= false, string beta_initializer= "zeros", string gamma_initializer= "ones",
                        string running_mean_initializer= "zeros", string running_variance_initializer= "ones",
                        int in_channels= 0, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
