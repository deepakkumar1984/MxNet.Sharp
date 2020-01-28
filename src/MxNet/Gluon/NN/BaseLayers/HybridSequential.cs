using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.NN
{
    public class HybridSequential : HybridBlock
    {
        public Block[] this[string key]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public HybridSequential(string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public void Add(params Block[] blocks)
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
