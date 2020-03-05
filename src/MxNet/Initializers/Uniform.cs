namespace MxNet.Initializers
{
    public class Uniform : Initializer
    {
        public Uniform(float scale = 0.07f)
        {
            Scale = scale;
        }

        public float Scale { get; set; }

        public override void InitWeight(string name, ref NDArray arr)
        {
            arr = nd.Random.Uniform(-Scale, Scale, arr.Shape);
        }
    }
}