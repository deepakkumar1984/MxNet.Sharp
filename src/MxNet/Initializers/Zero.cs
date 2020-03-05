namespace MxNet.Initializers
{
    public class Zero : Initializer
    {
        public override void InitWeight(string name, ref NDArray arr)
        {
            arr.Constant(0);
        }
    }
}