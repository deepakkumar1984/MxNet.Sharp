namespace MxNet.Image
{
    public class RandomSizedCropAug : Augmenter
    {
        public RandomSizedCropAug((int, int) size, (float, float) area, (float, float) ratio,
            ImgInterp interp = ImgInterp.Area_Based)
        {
            Size = size;
            Interp = interp;
            Area = area;
            Ratio = ratio;
        }

        public (int, int) Size { get; set; }

        public (float, float) Area { get; set; }

        public (float, float) Ratio { get; set; }

        public ImgInterp Interp { get; set; }

        public override NDArray Call(NDArray src)
        {
            return Img.RandomSizeCrop(src, Size, Area, Ratio, Interp).Item1;
        }
    }
}