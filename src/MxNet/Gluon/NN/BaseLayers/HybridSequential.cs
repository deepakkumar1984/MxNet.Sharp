namespace MxNet.Gluon.NN
{
    public class HybridSequential : HybridBlock
    {
        public HybridSequential(string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public new HybridSequential this[string key]
        {
            get
            {
                var net = new HybridSequential(Prefix);
                net.Add((HybridBlock) _childrens[key]);
                return net;
            }
        }

        public int Length => _childrens.Count;

        public void Add(params HybridBlock[] blocks)
        {
            foreach (var item in blocks) RegisterChild(item);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            foreach (var item in _childrens) x = item.Value.Call(x, args);

            return x;
        }
    }
}