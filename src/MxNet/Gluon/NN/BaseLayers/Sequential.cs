using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.NN
{
    public class Sequential : Block
    {
        public List<Block> Blocks
        {
            get
            {
                return _childrens.Values.ToList();
            }
        }

        public Sequential this[string key]
        {
            get
            {
                Sequential net = new Sequential(Prefix);
                net.Add(_childrens[key]);
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

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            foreach (var item in Blocks)
            {
                input = item.Call(input, args);
            }

            return input;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.GetType().Name, Name);
        }

        public override void Hybridize(bool active = true, bool static_alloc = false, bool static_shape = false)
        {
            if(_childrens.Values.All(x=>(x.GetType() == typeof(HybridBlock))))
            {
                Logger.Warning(string.Format("All children of this Sequential layer '{0}' are HybridBlocks. Consider " +
                                                "using HybridSequential for the best performance.", Prefix));
            }

            base.Hybridize(active, static_alloc, static_shape);
        }
    }
}
