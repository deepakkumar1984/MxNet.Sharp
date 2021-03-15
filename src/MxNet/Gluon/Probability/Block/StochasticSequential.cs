using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Probability
{
    public class StochasticSequential : StochasticBlock
    {
        public int Length => throw new NotImplementedException();

        public new StochasticSequential this[string key]
        {
            get
            {
                var layer = this._childrens[key];
                var net = new StochasticSequential();
                net.Add(layer);
                return net;
            }
        }

        public StochasticSequential(Dictionary<string, Block> blocks = null, bool loadkeys = false) : base(blocks, loadkeys)
        {
            throw new NotImplementedException();
        }

        public void Add(params Block[] blocks)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
