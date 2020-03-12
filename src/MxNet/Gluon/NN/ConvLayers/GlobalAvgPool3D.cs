namespace MxNet.Gluon.NN
{
    public class GlobalAvgPool3D : _Pooling
    {
        public GlobalAvgPool3D(string layout = "NCDHW", string prefix = null, ParameterDict @params = null)
            : base(new[] {1, 1, 1}, null, new[] {0, 0, 0}, true, true, PoolingType.Avg, layout, null, prefix,
                @params)
        {
        }
    }
}