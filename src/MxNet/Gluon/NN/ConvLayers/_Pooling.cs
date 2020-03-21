namespace MxNet.Gluon.NN
{
    public abstract class _Pooling : HybridBlock
    {
        public _Pooling(int[] pool_size, int[] strides, int[] padding, bool ceil_mode, bool global_pool,
            PoolingType pool_type, string layout, bool? count_include_pad = null, string prefix = null,
            ParameterDict @params = null) : base(prefix, @params)
        {
            Kernel = pool_size;
            Strides = strides ?? pool_size;
            Padding = padding;
            GlobalPool = global_pool;
            Layout = layout;
            CountIncludePad = count_include_pad;
        }

        public int[] Kernel { get; set; }

        public int[] Strides { get; set; }

        public int[] Padding { get; set; }

        public bool CeilMode { get; set; }

        public bool GlobalPool { get; set; }

        public PoolingType PoolType { get; set; }

        public string Layout { get; set; }

        public bool? CountIncludePad { get; set; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.Pooling(x, new Shape(Kernel), PoolType, GlobalPool, stride: new Shape(Strides),
                    pad: new Shape(Padding),
                    count_include_pad: CountIncludePad, layout: Layout, 
                    pooling_convention: CeilMode ? PoolingConvention.Full : PoolingConvention.Valid);

            return sym.Pooling(x, new Shape(Kernel), PoolType, GlobalPool, stride: new Shape(Strides),
                pad: new Shape(Padding),
                count_include_pad: CountIncludePad, layout: Layout, pooling_convention: CeilMode ? PoolingConvention.Full : PoolingConvention.Valid, symbol_name: "fwd");
        }

        public override string Alias()
        {
            return "pool";
        }
    }
}