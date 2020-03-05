using NumSharp;

namespace MxNet.Image
{
    public class SaturationJitterAug : Augmenter
    {
        private readonly NDArray coef;

        public SaturationJitterAug(float saturation)
        {
            Saturation = saturation;
            coef = new NDArray(new[] {0.299f, 0.587f, 0.114f}).Reshape(1, 3);
        }

        public float Saturation { get; set; }

        public override NDArray Call(NDArray src)
        {
            var alpha = 1f + np.random.uniform(-Saturation, Saturation);
            var gray = src * coef;
            gray = nd.Sum(gray, 2, true);
            gray *= 1 - alpha;
            src *= gray;
            src += gray;
            return src;
        }
    }
}