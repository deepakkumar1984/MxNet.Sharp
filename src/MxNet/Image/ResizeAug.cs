namespace MxNet.Image
{
    public class ResizeAug : Augmenter
    {
        public ResizeAug(int size, ImgInterp interp = ImgInterp.Area_Based)
        {
            Size = size;
            Interp = interp;
        }

        public int Size { get; set; }

        public ImgInterp Interp { get; set; }

        public override NDArray Call(NDArray src)
        {
            return Img.ResizeShort(src, Size, Interp);
        }
    }
}