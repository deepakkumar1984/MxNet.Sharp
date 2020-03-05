namespace MxNet.Image
{
    public class CenterCropAug : Augmenter
    {
        public CenterCropAug((int, int) size, ImgInterp interp = ImgInterp.Area_Based)
        {
            Size = size;
            Interp = interp;
        }

        public (int, int) Size { get; set; }

        public ImgInterp Interp { get; set; }

        public override NDArray Call(NDArray src)
        {
            return Img.CenterCrop(src, Size, Interp).Item1;
        }
    }
}