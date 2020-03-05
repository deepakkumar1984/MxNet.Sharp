namespace MxNet.Gluon.NN
{
    public class HybridLambda : HybridBlock
    {
        public delegate NDArrayOrSymbol LambdaFn(NDArrayOrSymbol x, params NDArrayOrSymbol[] args);

        public HybridLambda(LambdaFn function, string prefix = null, ParameterDict @params = null) : base(prefix,
            @params)
        {
            Function = function;
        }

        public LambdaFn Function { get; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            return Function(x, args);
        }
    }
}