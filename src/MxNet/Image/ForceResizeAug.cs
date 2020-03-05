namespace MxNet.Image
{
    public class ForceResizeAug : Augmenter
    {
        public ForceResizeAug((int, int) size, ImgInterp interp = ImgInterp.Area_Based)
        {
            Size = size;
            Interp = interp;
        }

        public (int, int) Size { get; set; }

        public ImgInterp Interp { get; set; }

        public override NDArray Call(NDArray src)
        {
            var sizes = (src.Shape[0], src.Shape[1], Size.Item2, Size.Item1);
            return Img.ImResize(src, Size.Item1, Size.Item2, Img.GetInterpMethod(Interp, sizes));
        }
    }
}