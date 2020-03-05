using NumSharp;

namespace MxNet.Image
{
    public class BrightnessJitterAug : Augmenter
    {
        public BrightnessJitterAug(float brightness)
        {
            Brightness = brightness;
        }

        public float Brightness { get; set; }

        public override NDArray Call(NDArray src)
        {
            var alpha = 1f + np.random.uniform(-Brightness, Brightness);
            src *= alpha;
            return src;
        }
    }
}