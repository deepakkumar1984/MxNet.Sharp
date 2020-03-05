namespace MxNet.Image
{
    public class CastAug : Augmenter
    {
        public CastAug(DType dtype)
        {
            DataType = dtype;
        }

        public DType DataType { get; set; }

        public override NDArray Call(NDArray src)
        {
            return src.AsType(DataType);
        }
    }
}