namespace MxNet.Gluon.NN
{
    public class Lambda : Block
    {
        public delegate NDArray LambdaFn(NDArray x, params object[] args);

        public Lambda(LambdaFn function, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Function = function;
        }

        public LambdaFn Function { get; }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            return Function(input);
        }
    }
}