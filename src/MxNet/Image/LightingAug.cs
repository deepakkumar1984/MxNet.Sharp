namespace MxNet.Image
{
    public class LightingAug : Augmenter
    {
        public LightingAug(float alphastd, NDArray eigval, NDArray eigvec)
        {
            Alphastd = alphastd;
            Eigval = eigval;
            Eigvec = eigvec;
        }

        public float Alphastd { get; set; }

        public NDArray Eigval { get; set; }

        public NDArray Eigvec { get; set; }

        public override NDArray Call(NDArray src)
        {
            var alpha = nd.Random.Uniform(0, Alphastd, new Shape(3));
            var rgb = nd.Dot(Eigvec * alpha, Eigval);
            src += rgb;
            return src;
        }
    }
}