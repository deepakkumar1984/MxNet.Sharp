namespace MxNet.Initializers
{
    public class Normal : Initializer
    {
        public Normal(float sigma = 0.01f)
        {
            Sigma = sigma;
        }

        public float Sigma { get; set; }

        public override void InitWeight(string name, ref NDArray arr)
        {
            arr = nd.Random.Normal(0, Sigma, arr.Shape);
        }
    }
}