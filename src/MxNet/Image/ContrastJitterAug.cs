using NumSharp;

namespace MxNet.Image
{
    public class ContrastJitterAug : Augmenter
    {
        private readonly NDArray coef;

        public ContrastJitterAug(float contrast)
        {
            Contrast = contrast;
            coef = new NDArray(new[] {0.299f, 0.587f, 0.114f}).Reshape(1, 3);
        }

        public float Contrast { get; set; }

        public override NDArray Call(NDArray src)
        {
            var alpha = 1f + np.random.uniform(-Contrast, Contrast);
            var gray = src * coef;
            gray = 3.0 * (1.0 - alpha) / gray.Size * nd.Sum(gray);
            src *= alpha;
            src += gray;
            return src;
        }
    }
}