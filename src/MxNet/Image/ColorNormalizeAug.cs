namespace MxNet.Image
{
    public class ColorNormalizeAug : Augmenter
    {
        public ColorNormalizeAug(NDArray mean, NDArray std)
        {
            Mean = mean;
            Std = std;
        }

        public NDArray Mean { get; set; }

        public NDArray Std { get; set; }

        public override NDArray Call(NDArray src)
        {
            return Img.ColorNormalize(src, Mean, Std);
        }
    }
}