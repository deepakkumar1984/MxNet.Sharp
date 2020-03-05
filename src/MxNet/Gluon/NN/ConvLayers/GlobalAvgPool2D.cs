namespace MxNet.Gluon.NN
{
    public class GlobalAvgPool2D : _Pooling
    {
        public GlobalAvgPool2D(string layout = "NCHW", string prefix = null, ParameterDict @params = null)
            : base(new[] {1, 1}, null, new[] {0, 0}, true, true, PoolingPoolType.Max, layout, null, prefix, @params)
        {
        }
    }
}