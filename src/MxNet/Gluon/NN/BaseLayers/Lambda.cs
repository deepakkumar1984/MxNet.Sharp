using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.NN
{
    public class Lambda : Block
    {
        public LambdaFn Function { get; }

        public delegate NDArray LambdaFn(NDArray x, params object[] args);

        public Lambda(LambdaFn function, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Function = function;
        }

        public override NDArray Forward(NDArray input, params NDArray[] args)
        {
            return Function(input);
        }

    }
}
