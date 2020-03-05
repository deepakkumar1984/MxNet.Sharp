namespace MxNet.Initializers
{
    public class Constant : Initializer
    {
        public Constant(float value)
        {
            Value = value;
        }

        public float Value { get; set; }

        public override void InitWeight(string name, ref NDArray arr)
        {
            arr.Constant(Value);
        }
    }
}