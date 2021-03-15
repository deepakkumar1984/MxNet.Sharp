using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Probability
{
    public class StochasticBlock : HybridBlock
    {
        public NDArrayOrSymbolList Losses
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public StochasticBlock(Dictionary<string, Block> blocks, bool loadkeys = false) : base(blocks, loadkeys)
        {
            throw new NotImplementedException();
        }

        public void AddLoss(NDArrayOrSymbol loss)
        {
            throw new NotImplementedException();
        }

        public static Func<FuncArgs, (NDArrayOrSymbol, NDArrayOrSymbolList)> CollectLoss(Func<FuncArgs, NDArrayOrSymbol> func)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Call(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
