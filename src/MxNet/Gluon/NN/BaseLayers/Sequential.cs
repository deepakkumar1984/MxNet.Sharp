using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.NN
{
    public class Sequential : Block
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

        public Sequential(string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public void Add(params Block[] blocks) => throw new NotImplementedException();

        public override NDArray Forward(NDArray input, params NDArray[] args)
        {
            throw new NotImplementedException();
        }

        public override void Summary(NDArray[] inputs)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override void Hybridize(bool active = true, bool static_alloc = false, bool static_shape = false)
        {
            throw new NotImplementedException();
        }
    }
}
