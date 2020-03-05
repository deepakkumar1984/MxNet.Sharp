namespace MxNet.Image
{
    public class DetBorrowAug : DetAugmenter
    {
        public DetBorrowAug(Augmenter augmenter)
        {
            Augmenter = augmenter;
        }

        public Augmenter Augmenter { get; set; }

        public override (NDArray, NDArray) Call(NDArray src, NDArray label)
        {
            src = Augmenter.Call(src);
            return (src, label);
        }
    }
}