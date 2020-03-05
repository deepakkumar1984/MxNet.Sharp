namespace MxNet.Image
{
    public class SequentialAug : Augmenter
    {
        public SequentialAug(Augmenter[] ts)
        {
            Augmenters = ts;
        }

        public Augmenter[] Augmenters { get; set; }

        public override NDArray Call(NDArray src)
        {
            foreach (var aug in Augmenters) src = aug.Call(src);

            return src;
        }
    }
}