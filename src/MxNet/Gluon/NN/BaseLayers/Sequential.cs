using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.NN
{
    public class Sequential : Block
    {
        private List<Block> blocks = new List<Block>();

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
        }

        public void Add(params Block[] blocks)
        {
            foreach (var item in blocks)
            {
                RegisterChild(item);
            }
        }

        public override NDArray Forward(NDArray input, params NDArray[] args)
        {
            foreach (var item in blocks)
            {
                input = item.Call(input).NdX;
            }

            return input;
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
