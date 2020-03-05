using System.Collections.Generic;
using System.Linq;

namespace MxNet.Gluon.NN
{
    public class Sequential : Block
    {
        public Sequential(string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public List<Block> Blocks => _childrens.Values.ToList();

        public Sequential this[string key]
        {
            get
            {
                var net = new Sequential(Prefix);
                net.Add(_childrens[key]);
                return net;
            }
        }

        public int Length => _childrens.Count;

        public void Add(params Block[] blocks)
        {
            foreach (var item in blocks) RegisterChild(item);
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            foreach (var item in Blocks) input = item.Call(input, args);

            return input;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", GetType().Name, Name);
        }

        public override void Hybridize(bool active = true, bool static_alloc = false, bool static_shape = false)
        {
            if (_childrens.Values.All(x => x.GetType() == typeof(HybridBlock)))
                Logger.Warning(string.Format("All children of this Sequential layer '{0}' are HybridBlocks. Consider " +
                                             "using HybridSequential for the best performance.", Prefix));

            base.Hybridize(active, static_alloc, static_shape);
        }
    }
}