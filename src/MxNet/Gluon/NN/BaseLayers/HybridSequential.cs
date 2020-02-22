using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.NN
{
    public class HybridSequential : HybridBlock
    {
        public new HybridSequential this[string key]
        {
            get
            {
                HybridSequential net = new HybridSequential(Prefix);
                net.Add((HybridBlock)_childrens[key]);
                return net;
            }
        }

        public int Length
        {
            get
            {
                return _childrens.Count;
            }
        }

        public HybridSequential(string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public void Add(params HybridBlock[] blocks)
        {
            foreach (var item in blocks)
            {
                RegisterChild(item);
            }
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            foreach (var item in _childrens)
            {
                x = item.Value.Call(x, args);
            }

            return x;
        }
    }
}
