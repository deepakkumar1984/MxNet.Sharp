using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.NN
{
    public class Lambda : Block
    {
        public delegate NDArray[] LambdaFn(NDArray[] x, params object[] args);


        public Lambda(LambdaFn function, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArray[] Forward(NDArray[] inputs)
        {
            return base.Forward(inputs);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
